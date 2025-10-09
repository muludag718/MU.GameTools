using System.IO;
using MU.GameTools.IO;

namespace MU.GameTools.Prototype.Fight.Prototype1.Track
{
	[KnownNodeForContext(ContextHash.Motion)]
	[KnownTrack(TrackHash.AutoTargetPlayer)]
	public class AutoTargetPlayerTrack : P1Track
	{
		public float TimeBegin { get; set; }

		public float TimeEnd { get; set; }

		public bool SetTarget { get; set; }

		public float Arc { get; set; }

		public float MaxDistance { get; set; }

		public bool KeepChecking { get; set; }

		public override void Serialize(Stream output, Endian endianess)
		{
			base.Serialize(output, endianess);
			output.WriteValueF32(TimeBegin, endianess);
			output.WriteValueF32(TimeEnd, endianess);
			output.WriteValueB32(SetTarget, endianess);
			output.WriteValueF32(Arc, endianess);
			output.WriteValueF32(MaxDistance, endianess);
			output.WriteValueB32(KeepChecking, endianess);
		}

		public override void Deserialize(Stream input, Endian endianess)
		{
			base.Deserialize(input, endianess);
			TimeBegin = input.ReadValueF32(endianess);
			TimeEnd = input.ReadValueF32(endianess);
			SetTarget = input.ReadValueB32(endianess);
			Arc = input.ReadValueF32(endianess);
			MaxDistance = input.ReadValueF32(endianess);
			KeepChecking = input.ReadValueB32(endianess);
		}
	}
}
