using System.IO;
using MU.GameTools.IO;

namespace MU.GameTools.Prototype.Fight.Prototype1.Track
{
	[KnownTrack(TrackHash.FollowTarget)]
	public class FollowTargetTrack : P1Track
	{
		public float TimeBegin { get; set; }

		public float TimeEnd { get; set; }

		public float MaxAngleFromTargetFacing { get; set; }

		public float MaxMotionLengthDelta { get; set; }

		public float MaxRotationDelta { get; set; }

		public bool SmoothWithLast { get; set; }

		public override void Serialize(Stream output, Endian endianess)
		{
			base.Serialize(output, endianess);
			output.WriteValueF32(TimeBegin, endianess);
			output.WriteValueF32(TimeEnd, endianess);
			output.WriteValueF32(MaxAngleFromTargetFacing, endianess);
			output.WriteValueF32(MaxMotionLengthDelta, endianess);
			output.WriteValueF32(MaxRotationDelta, endianess);
			output.WriteValueB32(SmoothWithLast, endianess);
		}

		public override void Deserialize(Stream input, Endian endianess)
		{
			base.Deserialize(input, endianess);
			TimeBegin = input.ReadValueF32(endianess);
			TimeEnd = input.ReadValueF32(endianess);
			MaxAngleFromTargetFacing = input.ReadValueF32(endianess);
			MaxMotionLengthDelta = input.ReadValueF32(endianess);
			MaxRotationDelta = input.ReadValueF32(endianess);
			SmoothWithLast = input.ReadValueB32(endianess);
		}
	}
}
