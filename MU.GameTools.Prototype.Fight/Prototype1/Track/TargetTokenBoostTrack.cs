using System.IO;
using MU.GameTools.IO;

namespace MU.GameTools.Prototype.Fight.Prototype1.Track
{
	[KnownTrack(TrackHash.TargetTokenBoost)]
	public class TargetTokenBoostTrack : P1Track
	{
		public float TimeBegin { get; set; }

		public int ExtraTokens { get; set; }

		public float BoostTime { get; set; }

		public override void Serialize(Stream output, Endian endianess)
		{
			base.Serialize(output, endianess);
			output.WriteValueF32(TimeBegin, endianess);
			output.WriteValueS32(ExtraTokens, endianess);
			output.WriteValueF32(BoostTime, endianess);
		}

		public override void Deserialize(Stream input, Endian endianess)
		{
			base.Deserialize(input, endianess);
			TimeBegin = input.ReadValueF32(endianess);
			ExtraTokens = input.ReadValueS32(endianess);
			BoostTime = input.ReadValueF32(endianess);
		}
	}
}
