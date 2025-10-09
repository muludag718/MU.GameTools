using System.IO;
using MU.GameTools.IO;

namespace MU.GameTools.Prototype.FileFormats.Pure3D.Sound
{
	public class Cue : AudioType
	{
		public uint Unknown1 { get; set; }

		public uint NumberOfEntries { get; set; }

		public uint Unknown2 { get; set; }

		public byte[] Unknown3 { get; set; }

		public Cue()
		{
		}

		public Cue(Stream input, Endian endian)
			: base(input, endian)
		{
		}

		public override void Serialize(Stream output, Endian endian)
		{
		}

		public override void Deserialize(Stream input, Endian endian)
		{
		}
	}
}
