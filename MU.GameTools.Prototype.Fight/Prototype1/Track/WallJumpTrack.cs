using System.IO;
using MU.GameTools.IO;

namespace MU.GameTools.Prototype.Fight.Prototype1.Track
{
	[KnownNodeForContext(ContextHash.Motion)]
	[KnownTrack(TrackHash.WallJump)]
	public class WallJumpTrack : P1Track
	{
		public float TimeBegin { get; set; }

		public float TimeEnd { get; set; }

		public float VelocityMin { get; set; }

		public float VelocityMax { get; set; }

		public float VelocityXZMax { get; set; }

		public float Gravity { get; set; }

		public float WallAngleMin { get; set; }

		public float WallAngleMax { get; set; }

		public float TurningVelocity { get; set; }

		public float UpThresholdArc { get; set; }

		public bool UseMomentum { get; set; }

		public float Arc { get; set; }

		public float MinYAngle { get; set; }

		public int Priority { get; set; }

		public float BlendInTime { get; set; }

		public float BlendOutTime { get; set; }

		public override void Serialize(Stream output, Endian endianess)
		{
			base.Serialize(output, endianess);
			output.WriteValueF32(TimeBegin, endianess);
			output.WriteValueF32(TimeEnd, endianess);
			output.WriteValueF32(VelocityMin, endianess);
			output.WriteValueF32(VelocityMax, endianess);
			output.WriteValueF32(VelocityXZMax, endianess);
			output.WriteValueF32(Gravity, endianess);
			output.WriteValueF32(WallAngleMin, endianess);
			output.WriteValueF32(WallAngleMax, endianess);
			output.WriteValueF32(TurningVelocity, endianess);
			output.WriteValueF32(UpThresholdArc, endianess);
			output.WriteValueB32(UseMomentum, endianess);
			output.WriteValueF32(Arc, endianess);
			output.WriteValueF32(MinYAngle, endianess);
			output.WriteValueS32(Priority, endianess);
			output.WriteValueF32(BlendInTime, endianess);
			output.WriteValueF32(BlendOutTime, endianess);
		}

		public override void Deserialize(Stream input, Endian endianess)
		{
			base.Deserialize(input, endianess);
			TimeBegin = input.ReadValueF32(endianess);
			TimeEnd = input.ReadValueF32(endianess);
			VelocityMin = input.ReadValueF32(endianess);
			VelocityMax = input.ReadValueF32(endianess);
			VelocityXZMax = input.ReadValueF32(endianess);
			Gravity = input.ReadValueF32(endianess);
			WallAngleMin = input.ReadValueF32(endianess);
			WallAngleMax = input.ReadValueF32(endianess);
			TurningVelocity = input.ReadValueF32(endianess);
			UpThresholdArc = input.ReadValueF32(endianess);
			UseMomentum = input.ReadValueB32(endianess);
			Arc = input.ReadValueF32(endianess);
			MinYAngle = input.ReadValueF32(endianess);
			Priority = input.ReadValueS32(endianess);
			BlendInTime = input.ReadValueF32(endianess);
			BlendOutTime = input.ReadValueF32(endianess);
		}
	}
}
