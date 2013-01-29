using System;
using System.Collections.Generic;
using System.IO;

namespace PivotalTFSSync.Serializers
{
	public interface ICsvSerializer<T>
	{
		IEnumerable<T> Deserialize(Stream sourceStream);

		Stream Serialize(IEnumerable<T> collection);
		Stream Serialize(IEnumerable<T> collection, Action onFinishedAction);
	}
}