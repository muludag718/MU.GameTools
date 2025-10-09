using System.IO;
using MU.GameTools.IO;

namespace MU.GameTools.Prototype.FileFormats.Pure3D.Sound
{
	public abstract class AudioType : ISerializable
	{
		public AudioType()
		{
		}

		public AudioType(Stream input, Endian endian)
		{
			Deserialize(input, endian);
		}

		public abstract void Serialize(Stream output, Endian endian);

		public abstract void Deserialize(Stream input, Endian endian);
	}
}
