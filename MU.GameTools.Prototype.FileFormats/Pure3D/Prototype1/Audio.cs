using System.ComponentModel;
using System.IO;
using MU.GameTools.IO;
using MU.GameTools.Prototype.FileFormats.Pure3D.Sound;
using MU.GameTools.Common;

namespace MU.GameTools.Prototype.FileFormats.Pure3D.Prototype1
{
	[KnownGame(PrototypeGame.P1)]
	[KnownType(4261412864)]
	public class Audio : BaseNode
	{
		public AudioType AudioType;

		public uint Unknown1 { get; set; }

		[ReadOnly(true)]
		public string FileType { get; set; }

		public uint Unknown2 { get; set; }

		public string Name { get; set; }

		public override bool Exportable => FileType == "AudioFile\0";

		public override string ExportExtension => "radp";

		public override string ToString()
		{
			if (string.IsNullOrEmpty(Name))
			{
				return base.ToString();
			}
			return base.ToString() + " (" + Name.Trim(default(char)) + ") (" + FileType.Trim(default(char)) + ")";
		}

		public override void Export(Stream output)
		{
			if (Exportable)
			{
				AudioFile audioFile = (AudioFile)AudioType;
				output.Write(audioFile.Data, 0, audioFile.Data.Length);
			}
		}

		public override void Serialize(Stream output, Endian endian)
		{
			output.WriteValueU32(Unknown1, endian);
			output.WriteValueU32((uint)(FileType.Length - 1), endian);
			output.WriteString(FileType);
			output.WriteValueU32(Unknown2, endian);
			output.WriteValueU32((uint)(Name.Length - 1), endian);
			output.WriteString(Name);
			AudioType.Serialize(output, endian);
		}

		public override void Deserialize(Stream input, Endian endian)
		{
			Unknown1 = input.ReadValueU32(endian);
			uint num = input.ReadValueU32(endian);
			FileType = input.ReadString((int)(num + 1));
			Unknown2 = input.ReadValueU32(endian);
			num = input.ReadValueU32(endian);
			Name = input.ReadString((int)(num + 1));
			if (FileType == "AudioFile\0")
			{
				AudioType = new AudioFile(input, endian);
				return;
			}
			int length = (int)(base.StartPosition + base.TotalSize - input.Position);
			AudioType = new AudioTypeUnknown(input, endian, length);
		}
	}
}
