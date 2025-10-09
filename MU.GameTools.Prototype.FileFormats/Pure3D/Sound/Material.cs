using System.IO;
using MU.GameTools.IO;

namespace MU.GameTools.Prototype.FileFormats.Pure3D.Sound
{
	public class Material
	{
		public byte[] Unknown1 { get; set; }

		public string MaterialName { get; set; }

		public byte[] Unknown2 { get; set; }

		public string AudioClipName { get; set; }

		public Material()
		{
		}

		public Material(Stream input, Endian endian)
		{
			Deserialize(input, endian);
		}

		public void Serialize(Stream output, Endian endian)
		{
			output.WriteBytes(Unknown1);
			output.WriteValueU32((uint)(MaterialName.Length - 1), endian);
			output.WriteString(MaterialName);
			output.WriteBytes(Unknown2);
			output.WriteValueU32((uint)(AudioClipName.Length - 1), endian);
			output.WriteString(AudioClipName);
		}

		public void Deserialize(Stream input, Endian endian)
		{
			Unknown1 = input.ReadBytes(9);
			uint num = input.ReadValueU32(endian);
			MaterialName = input.ReadString((int)(num + 1));
			Unknown2 = input.ReadBytes(9);
			num = input.ReadValueU32(endian);
			AudioClipName = input.ReadString((int)(num + 1));
		}
	}
}
