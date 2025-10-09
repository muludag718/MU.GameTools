using System.IO;
using MU.GameTools.IO;

namespace MU.GameTools.Prototype.FileFormats.Pure3D.Sound
{
	public class AudioFile : AudioType
	{
		public string IDName { get; set; }

		public uint Unknown1 { get; set; }

		public uint Unknown2 { get; set; }

		public byte[] Data { get; set; }

		public AudioFile()
		{
		}

		public AudioFile(Stream input, Endian endian)
			: base(input, endian)
		{
		}

		public override void Serialize(Stream output, Endian endian)
		{
			output.WriteValueU32((uint)(IDName.Length - 1), endian);
			output.WriteString(IDName);
			output.WriteValueU32(Unknown1, endian);
			output.WriteValueU32(Unknown2, endian);
			output.WriteBytes(Data);
		}

		public override void Deserialize(Stream input, Endian endian)
		{
			uint num = input.ReadValueU32(endian);
			IDName = input.ReadString((int)(num + 1));
			Unknown1 = input.ReadValueU32(endian);
			Unknown2 = input.ReadValueU32(endian);
			input.Position += 21L;
			uint num2 = input.ReadValueU32(endian);
			input.Position -= 25L;
			Data = input.ReadBytes((int)(25 + num2));
		}
	}
}
