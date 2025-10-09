using System.IO;
using MU.GameTools.IO;

namespace MU.GameTools.Prototype.FileFormats.Pure3D.Sound
{
	public class AudioSubtitle
	{
		public byte[] Unknown1 { get; set; }

		public string Language { get; set; }

		public string Text { get; set; }

		public AudioSubtitle()
		{
		}

		public AudioSubtitle(Stream input, Endian endian)
		{
			Deserialize(input, endian);
		}

		public void Serialize(Stream output, Endian endian)
		{
			output.WriteBytes(Unknown1);
			output.WriteValueU32((uint)(Language.Length - 1), endian);
			output.WriteString(Language);
			output.WriteValueU32((uint)(Text.Length - 1), endian);
			output.WriteString(Text);
		}

		public void Deserialize(Stream input, Endian endian)
		{
			Unknown1 = input.ReadBytes(9);
			uint num = input.ReadValueU32(endian);
			Language = input.ReadString((int)(num + 1));
			num = input.ReadValueU32(endian);
			Text = input.ReadString((int)(num + 1));
		}
	}
}
