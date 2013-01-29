using System;
using PivotalTFS_GENERAL;

namespace PivotalTFSSync.Serializers
{
	public class StorySerializer : CsvSerializer<Story>
	{
		public char EncapsulateAllFieldsWith;
		public Iteration Iteration { get; set; }

		protected override int NumberOfColumns
		{
			get { return 7; }
		}

		protected override Story FromLineTokens(string[] lineTokens)
		{
			throw new NotImplementedException();
		}

		protected override string[] ToLineTokens(Story element)
		{
			if (Iteration != null)
			{
				return
					new[]
						{
							EnCapsulateFieldWithCharacter(Iteration.Number.ToString()),
							EnCapsulateFieldWithCharacter(Iteration.Start),
							EnCapsulateFieldWithCharacter(element.Id.ToString()),
							EnCapsulateFieldWithCharacter(element.Name),
							EnCapsulateFieldWithCharacter(ReplaceAllNewLinesWithSingleSpace(element.Description)),
							EnCapsulateFieldWithCharacter(element.CreatedAt),
							EnCapsulateFieldWithCharacter(element.CurrentState)
						};
			}

			return
				new[]
					{
						"Icebox",
						"",
						EnCapsulateFieldWithCharacter(element.Id.ToString()),
						EnCapsulateFieldWithCharacter(element.Name),
						EnCapsulateFieldWithCharacter(ReplaceAllNewLinesWithSingleSpace(element.Description)),
						EnCapsulateFieldWithCharacter(element.CreatedAt),
						EnCapsulateFieldWithCharacter(element.CurrentState)
					};
		}

		private static string ReplaceAllNewLinesWithSingleSpace(string description)
		{
			return description.Replace("\r\n", " ");
		}

		private string EnCapsulateFieldWithCharacter(string s)
		{
			if (!string.IsNullOrEmpty(EncapsulateAllFieldsWith.ToString()))
				return string.Format("{0}{1}{0}", EncapsulateAllFieldsWith,
				                     s.Replace(EncapsulateAllFieldsWith, ' ').Trim());

			return s;
		}
	}
}