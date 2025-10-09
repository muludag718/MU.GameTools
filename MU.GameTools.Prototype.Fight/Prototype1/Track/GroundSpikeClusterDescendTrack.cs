using System.IO;
using MU.GameTools.IO;

namespace MU.GameTools.Prototype.Fight.Prototype1.Track
{
	[KnownNodeForContext(ContextHash.Motion)]
	[KnownTrack(TrackHash.GroundSpikeClusterDescend)]
	public class GroundSpikeClusterDescendTrack : P1Track
	{
		public bool ApplyToOffshoots { get; set; }

		public float DescendDuration { get; set; }

		public float DescendDelayMin { get; set; }

		public float DescendDelayMax { get; set; }

		public float TimeBegin { get; set; }

		public float TimeEnd { get; set; }

		public override void Serialize(Stream output, Endian endianess)
		{
			base.Serialize(output, endianess);
			output.WriteValueB32(ApplyToOffshoots, endianess);
			output.WriteValueF32(DescendDuration, endianess);
			output.WriteValueF32(DescendDelayMin, endianess);
			output.WriteValueF32(DescendDelayMax, endianess);
			output.WriteValueF32(TimeBegin, endianess);
			output.WriteValueF32(TimeEnd, endianess);
		}

		public override void Deserialize(Stream input, Endian endianess)
		{
			base.Deserialize(input, endianess);
			ApplyToOffshoots = input.ReadValueB32(endianess);
			DescendDuration = input.ReadValueF32(endianess);
			DescendDelayMin = input.ReadValueF32(endianess);
			DescendDelayMax = input.ReadValueF32(endianess);
			TimeBegin = input.ReadValueF32(endianess);
			TimeEnd = input.ReadValueF32(endianess);
		}
	}
}
