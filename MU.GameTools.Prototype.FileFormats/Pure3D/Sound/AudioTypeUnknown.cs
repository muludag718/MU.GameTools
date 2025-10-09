using System.IO;
using MU.GameTools.IO;

namespace MU.GameTools.Prototype.FileFormats.Pure3D.Sound
{
	public class AudioTypeUnknown : AudioType
	{
		public int Length;

		public byte[] Data { get; set; }

		public AudioTypeUnknown()
		{
		}

		public AudioTypeUnknown(Stream input, Endian endian, int length)
			: base(input, endian)
		{
			Length = length;
			Deserialize(input, endian);
		}

		public override void Serialize(Stream output, Endian endian)
		{
			output.WriteBytes(Data);
		}

		public override void Deserialize(Stream input, Endian endian)
		{
			Data = input.ReadBytes(Length);
		}
	}
}
