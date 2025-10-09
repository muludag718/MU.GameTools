using System.IO;
using MU.GameTools.IO;

namespace MU.GameTools.Prototype.Fight.Prototype1.Track
{
	[KnownNodeForContext(ContextHash.Motion)]
	[KnownTrack(TrackHash.GroundSpikeConfigureAutoOffShoots)]
	public class GroundSpikeConfigureAutoOffshootsTrack : P1Track
	{
		public ulong Type { get; set; }

		public float Step { get; set; }

		public float MaxDistance { get; set; }

		public float OffsetAngleMin { get; set; }

		public float OffsetAngleMax { get; set; }

		public float TimeBegin { get; set; }

		public float TimeEnd { get; set; }

		public override void Serialize(Stream output, Endian endianess)
		{
			base.Serialize(output, endianess);
			output.WriteValueU64(Type, endianess);
			output.WriteValueF32(Step, endianess);
			output.WriteValueF32(MaxDistance, endianess);
			output.WriteValueF32(OffsetAngleMin, endianess);
			output.WriteValueF32(OffsetAngleMax, endianess);
			output.WriteValueF32(TimeBegin, endianess);
			output.WriteValueF32(TimeEnd, endianess);
		}

		public override void Deserialize(Stream input, Endian endianess)
		{
			base.Deserialize(input, endianess);
			Type = input.ReadValueU64(endianess);
			Step = input.ReadValueF32(endianess);
			MaxDistance = input.ReadValueF32(endianess);
			OffsetAngleMin = input.ReadValueF32(endianess);
			OffsetAngleMax = input.ReadValueF32(endianess);
			TimeBegin = input.ReadValueF32(endianess);
			TimeEnd = input.ReadValueF32(endianess);
		}
	}
}
