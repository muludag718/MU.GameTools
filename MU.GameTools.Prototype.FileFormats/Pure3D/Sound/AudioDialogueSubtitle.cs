using System.IO;
using MU.GameTools.IO;

namespace MU.GameTools.Prototype.FileFormats.Pure3D.Sound
{
	public class AudioDialogueSubtitle : AudioType
	{
		public uint Unknown1 { get; set; }

		public AudioSubtitle[] AudioSubtitles { get; set; }

		public byte[] Unknown2 { get; set; }

		public AudioDialogueSubtitle(Stream input, Endian endian)
		{
			Deserialize(input, endian);
		}

		public override void Serialize(Stream output, Endian endian)
		{
			output.WriteValueU32(Unknown1, endian);
			for (int i = 0; i < AudioSubtitles.Length; i++)
			{
				AudioSubtitles[i].Serialize(output, endian);
			}
			output.WriteBytes(Unknown2);
		}

		public override void Deserialize(Stream input, Endian endian)
		{
			Unknown1 = input.ReadValueU32();
			AudioSubtitles = new AudioSubtitle[5];
			for (int i = 0; i < AudioSubtitles.Length; i++)
			{
				AudioSubtitles[i] = new AudioSubtitle(input, endian);
			}
			Unknown2 = input.ReadBytes(14);
		}
	}
}
