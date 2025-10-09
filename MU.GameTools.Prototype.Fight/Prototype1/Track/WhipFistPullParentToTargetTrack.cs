using System.IO;
using MU.GameTools.IO;

namespace MU.GameTools.Prototype.Fight.Prototype1.Track
{
	[KnownNodeForContext(ContextHash.Motion)]
	[KnownTrack(TrackHash.WhipFistPullParentToTarget)]
	public class WhipFistPullParentToTargetTrack : P1Track
	{
		public float TimeBegin { get; set; }

		public float TimeEnd { get; set; }

		public float Velocity { get; set; }

		public float Acceleration { get; set; }

		public float ParabolicConstant { get; set; }

		public float ParabolicOffset { get; set; }

		public Vector GoalOffsetFromTarget { get; set; } = new Vector();

		public float FaceTargetMaxTurnRate { get; set; }

		public float MaxStuckTime { get; set; }

		public int Priority { get; set; }

		public float BlendInTime { get; set; }

		public float BlendOutTime { get; set; }

		public override void Serialize(Stream output, Endian endianess)
		{
			base.Serialize(output, endianess);
			output.WriteValueF32(TimeBegin, endianess);
			output.WriteValueF32(TimeEnd, endianess);
			output.WriteValueF32(Velocity, endianess);
			output.WriteValueF32(Acceleration, endianess);
			output.WriteValueF32(ParabolicConstant, endianess);
			output.WriteValueF32(ParabolicOffset, endianess);
			GoalOffsetFromTarget.Serialize(output, endianess);
			output.WriteValueF32(FaceTargetMaxTurnRate, endianess);
			output.WriteValueF32(MaxStuckTime, endianess);
			output.WriteValueS32(Priority, endianess);
			output.WriteValueF32(BlendInTime, endianess);
			output.WriteValueF32(BlendOutTime, endianess);
		}

		public override void Deserialize(Stream input, Endian endianess)
		{
			base.Deserialize(input, endianess);
			TimeBegin = input.ReadValueF32(endianess);
			TimeEnd = input.ReadValueF32(endianess);
			Velocity = input.ReadValueF32(endianess);
			Acceleration = input.ReadValueF32(endianess);
			ParabolicConstant = input.ReadValueF32(endianess);
			ParabolicOffset = input.ReadValueF32(endianess);
			GoalOffsetFromTarget = new Vector(input, endianess);
			FaceTargetMaxTurnRate = input.ReadValueF32(endianess);
			MaxStuckTime = input.ReadValueF32(endianess);
			Priority = input.ReadValueS32(endianess);
			BlendInTime = input.ReadValueF32(endianess);
			BlendOutTime = input.ReadValueF32(endianess);
		}
	}
}
