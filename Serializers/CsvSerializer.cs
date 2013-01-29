using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace PivotalTFSSync.Serializers
{
	public abstract class CsvSerializer<T> : ICsvSerializer<T>
	{
		private char columnDelimiter = ',';
		private Encoding encoding = Encoding.UTF8;
		private char rowDelimiter = ';';
		private bool useExplicitHeaderRow;
		private bool useNewLineAsRowDelimiter;

		public char ColumnDelimiter
		{
			get { return columnDelimiter; }
			set { columnDelimiter = value; }
		}

		public char RowDelimiter
		{
			get { return rowDelimiter; }
			set { rowDelimiter = value; }
		}

		public bool UseNewLineAsRowDelimiter
		{
			get { return useNewLineAsRowDelimiter; }
			set { useNewLineAsRowDelimiter = value; }
		}

		public bool UseExplicitHeaderRow
		{
			get { return useExplicitHeaderRow; }
			set { useExplicitHeaderRow = value; }
		}

		public Encoding Encoding
		{
			get { return encoding; }
			set { encoding = value; }
		}

		public string EncodingName
		{
			set { Encoding = Encoding.GetEncoding(value); }
		}

		protected abstract int NumberOfColumns { get; }

		#region ICsvSerializer<T> Members

		public IEnumerable<T> Deserialize(Stream sourceStream)
		{
			if (sourceStream == null)
				throw new ArgumentNullException("sourceStream");

			var radnummer = 0;

			using (var reader = new StreamReader(sourceStream, Encoding))
			{
				if (UseExplicitHeaderRow)
					ReadLine(reader);

				while (!reader.EndOfStream)
				{
					radnummer++;

					var line = ReadLine(reader);

					if (line.Length == 0)
						throw new ArgumentException(string.Format("Tom rad i indata. Rad:{0}", radnummer),
						                            "sourceStream");

					var lineTokens = line.Split(ColumnDelimiter);

					if (lineTokens.Length != NumberOfColumns)
						throw new ArgumentOutOfRangeException("sourceStream", lineTokens.Length,
						                                      string.Format(
						                                      	"Ogiltigt antal kolumnvärden i filen på rad {0}. Förväntade {1} men är {2}",
						                                      	radnummer, NumberOfColumns, lineTokens.Length));

					T element;

					try
					{
						element = FromLineTokens(lineTokens);
					}
					catch (FormatException ex)
					{
						throw new ArgumentException(string.Format("Fel format på indata rad:{0}", radnummer),
						                            "sourceStream", ex);
					}

					yield return element;
				}
			}
		}

		public Stream Serialize(IEnumerable<T> collection)
		{
			return Serialize(collection, delegate { });
		}

		public Stream Serialize(IEnumerable<T> collection, Action onFinishedAction)
		{
			if (collection == null)
				throw new ArgumentNullException("collection");

			if (onFinishedAction == null)
				throw new ArgumentNullException("onFinishedAction");

			return new SerializingStream(this, collection.GetEnumerator(), onFinishedAction);
		}

		#endregion

		private string ReadLine(StreamReader reader)
		{
			if (UseNewLineAsRowDelimiter)
				return reader.ReadLine();

			var lineBuilder = new StringBuilder();

			int c;

			while ((c = reader.Read()) != -1)
			{
				if (c == RowDelimiter)
					break;

				lineBuilder.Append((char) c);
			}
			return lineBuilder.ToString();
		}

		private byte[] SerializeHeader()
		{
			return SerializeTokens(GetHeaderTokens());
		}

		private byte[] SerializeElement(T element)
		{
			if (element == null)
				throw new ArgumentNullException("element");

			return SerializeTokens(ToLineTokens(element));
		}

		private byte[] SerializeTokens(string[] lineTokens)
		{
			var line = string.Join(ColumnDelimiter.ToString(), lineTokens) +
			           (UseNewLineAsRowDelimiter ? Environment.NewLine : RowDelimiter.ToString());

			return Encoding.GetBytes(line);
		}

		protected abstract T FromLineTokens(string[] lineTokens);

		protected abstract string[] ToLineTokens(T element);

		protected virtual string[] GetHeaderTokens()
		{
			var tokens = new string[NumberOfColumns];

			for (var i = 0; i < tokens.Length; i++)
				tokens[i] = string.Empty;

			return tokens;
		}

		public CsvSerializer<string[]> GetIntermediateSerializer()
		{
			return new IntermediateSerializer(NumberOfColumns, RowDelimiter, ColumnDelimiter, UseExplicitHeaderRow,
			                                  UseNewLineAsRowDelimiter, Encoding);
		}

		private class IntermediateSerializer : CsvSerializer<string[]>
		{
			private int numberOfColumns;

			public IntermediateSerializer(int numberOfColumns, char rowDelimiter, char columnDelimiter,
			                              bool useExplicitHeaderRow, bool useNewLineAsRowDelimiter, Encoding encoding)
			{
				this.numberOfColumns = numberOfColumns;
				this.rowDelimiter = rowDelimiter;
				this.columnDelimiter = columnDelimiter;
				this.useExplicitHeaderRow = useExplicitHeaderRow;
				this.useNewLineAsRowDelimiter = useNewLineAsRowDelimiter;
				this.encoding = encoding;
			}

			protected override int NumberOfColumns
			{
				get { return numberOfColumns; }
			}

			protected override string[] FromLineTokens(string[] lineTokens)
			{
				return lineTokens;
			}

			protected override string[] ToLineTokens(string[] element)
			{
				return element;
			}
		}

		private class SerializingStream : Stream
		{
			private byte[] buffer;
			private int bufferOffset;
			private IEnumerator<T> enumerator;
			private bool hasSerializedExplicitHeader;
			private Action onFinishedAction;
			private long position;
			private CsvSerializer<T> serializer;

			public SerializingStream(CsvSerializer<T> serializer, IEnumerator<T> enumerator, Action onFinishedAction)
			{
				this.serializer = serializer;
				this.enumerator = enumerator;
				this.onFinishedAction = onFinishedAction;
			}

			public override bool CanRead
			{
				get { return true; }
			}

			public override bool CanSeek
			{
				get { return false; }
			}

			public override bool CanWrite
			{
				get { return true; }
			}

			public override long Length
			{
				get { return buffer.Length; }
			}

			public override long Position
			{
				get { return position; }
				set
				{
					if (position < 0)
					{
						throw new ArgumentException("Position cannot be less than zero.");
					}
					if (position > buffer.Length)
					{
						throw new ArgumentException("Position cannot be greater than buffer size:" +
						                            buffer.Length);
					}
					position = value;
				}
			}

			public override void Flush()
			{
				throw new NotSupportedException();
			}

			public override long Seek(long offset, SeekOrigin origin)
			{
				throw new NotSupportedException();
			}

			public override void SetLength(long value)
			{
				throw new NotSupportedException();
			}

			public override int Read(byte[] incomingbuffer, int offset, int count)
			{
				if (incomingbuffer == null)
					throw new ArgumentNullException("incomingbuffer");

				if (offset < 0 || offset > incomingbuffer.Length)
					throw new ArgumentOutOfRangeException("offset");

				if (count < 0 || count > incomingbuffer.Length - offset)
					throw new ArgumentOutOfRangeException("count");

				var readCount = 0;

				while (readCount < count)
				{
					if (buffer == null || bufferOffset >= buffer.Length)
					{
						if (serializer.UseExplicitHeaderRow && !hasSerializedExplicitHeader)
						{
							buffer = serializer.SerializeHeader();
							hasSerializedExplicitHeader = true;
						}
						else
						{
							if (!enumerator.MoveNext())
								break;

							buffer = serializer.SerializeElement(enumerator.Current);
						}

						bufferOffset = 0;
					}

					while (readCount < count && bufferOffset < buffer.Length)
						incomingbuffer[offset + (readCount++)] = buffer[bufferOffset++];
				}

				return readCount;
			}

			public override void Write(byte[] incomingbuffer, int offset, int count)
			{
				if (buffer == null)
				{
					buffer = incomingbuffer;
				}
				else
				{
					buffer.Concat(incomingbuffer);
				}
				position = buffer.Length;
			}

			public override void Close()
			{
				base.Close();
				onFinishedAction();
			}
		}
	}
}