using System.IO;
using MU.GameTools.IO;

namespace MU.GameTools.Prototype.Fight.Prototype1.Track
{
	[KnownTrack(TrackHash.Reverb)]
	public class ReverbTrack : P1Track
	{
		public float TimeBegin { get; set; }

		public ulong Preset { get; set; }

		public float Gain { get; set; }

		public override void Serialize(Stream output, Endian endianess)
		{
			base.Serialize(output, endianess);
			output.WriteValueF32(TimeBegin, endianess);
			output.WriteValueU64(Preset, endianess);
			output.WriteValueF32(Gain, endianess);
		}

		public override void Deserialize(Stream input, Endian endianess)
		{
			base.Deserialize(input, endianess);
			TimeBegin = input.ReadValueF32(endianess);
			Preset = input.ReadValueU64(endianess);
			Gain = input.ReadValueF32(endianess);
		}
	}
}
