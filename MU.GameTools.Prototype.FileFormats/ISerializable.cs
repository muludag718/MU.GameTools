using System.IO;
using MU.GameTools.IO;

namespace MU.GameTools.Prototype.FileFormats
{
	public interface ISerializable
	{
		void Serialize(Stream output, Endian endian);

		void Deserialize(Stream input, Endian endian);
	}
}
