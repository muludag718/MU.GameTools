using System.IO;
using MU.GameTools.IO;

namespace MU.GameTools.Prototype.Fight.Prototype1.Track
{
	[KnownTrack(TrackHash.AbortEffect)]
	public class AbortEffectTrack : P1Track
	{
		public ulong Slot { get; set; }

		public bool AllowFade { get; set; }

		public float FadeTime { get; set; }

		public float TimeBegin { get; set; }

		public float TimeEnd { get; set; }

		public override void Serialize(Stream output, Endian endianess)
		{
			base.Serialize(output, endianess);
			output.WriteValueU64(Slot, endianess);
			output.WriteValueB32(AllowFade, endianess);
			output.WriteValueF32(FadeTime, endianess);
			output.WriteValueF32(TimeBegin, endianess);
			output.WriteValueF32(TimeEnd, endianess);
		}

		public override void Deserialize(Stream input, Endian endianess)
		{
			base.Deserialize(input, endianess);
			Slot = input.ReadValueU64(endianess);
			AllowFade = input.ReadValueB32(endianess);
			FadeTime = input.ReadValueF32(endianess);
			TimeBegin = input.ReadValueF32(endianess);
			TimeEnd = input.ReadValueF32(endianess);
		}
	}
}
