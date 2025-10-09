using System.IO;
using MU.GameTools.IO;

namespace MU.GameTools.Prototype.Fight.Prototype1.Track
{
	[KnownNodeForContext(ContextHash.Motion)]
	[KnownTrack(TrackHash.FlyingAttack)]
	public class FlyingAttackTrack : P1Track
	{
		public float TimeBegin { get; set; }

		public float TimeEndMin { get; set; }

		public float TimeEndMax { get; set; }

		public Vector Direction { get; set; } = new Vector();

		public float VelocityMin { get; set; }

		public float VelocityMax { get; set; }

		public float AccelerationMin { get; set; }

		public float AccelerationMax { get; set; }

		public float TrackingMin { get; set; }

		public float TrackingMax { get; set; }

		public bool FaceDirection { get; set; }

		public bool UseAutoTarget { get; set; }

		public bool SlideOnGround { get; set; }

		public int Priority { get; set; }

		public float BlendInTime { get; set; }

		public float BlendOutTime { get; set; }

		public override void Serialize(Stream output, Endian endianess)
		{
			base.Serialize(output, endianess);
			output.WriteValueF32(TimeBegin, endianess);
			output.WriteValueF32(TimeEndMin, endianess);
			output.WriteValueF32(TimeEndMax, endianess);
			Direction.Serialize(output, endianess);
			output.WriteValueF32(VelocityMin, endianess);
			output.WriteValueF32(VelocityMax, endianess);
			output.WriteValueF32(AccelerationMin, endianess);
			output.WriteValueF32(AccelerationMax, endianess);
			output.WriteValueF32(TrackingMin, endianess);
			output.WriteValueF32(TrackingMax, endianess);
			output.WriteValueB32(FaceDirection, endianess);
			output.WriteValueB32(UseAutoTarget, endianess);
			output.WriteValueB32(SlideOnGround, endianess);
			output.WriteValueS32(Priority, endianess);
			output.WriteValueF32(BlendInTime, endianess);
			output.WriteValueF32(BlendOutTime, endianess);
		}

		public override void Deserialize(Stream input, Endian endianess)
		{
			base.Deserialize(input, endianess);
			TimeBegin = input.ReadValueF32(endianess);
			TimeEndMin = input.ReadValueF32(endianess);
			TimeEndMax = input.ReadValueF32(endianess);
			Direction = new Vector(input, endianess);
			VelocityMin = input.ReadValueF32(endianess);
			VelocityMax = input.ReadValueF32(endianess);
			AccelerationMin = input.ReadValueF32(endianess);
			AccelerationMax = input.ReadValueF32(endianess);
			TrackingMin = input.ReadValueF32(endianess);
			TrackingMax = input.ReadValueF32(endianess);
			FaceDirection = input.ReadValueB32(endianess);
			UseAutoTarget = input.ReadValueB32(endianess);
			SlideOnGround = input.ReadValueB32(endianess);
			Priority = input.ReadValueS32(endianess);
			BlendInTime = input.ReadValueF32(endianess);
			BlendOutTime = input.ReadValueF32(endianess);
		}
	}
}
