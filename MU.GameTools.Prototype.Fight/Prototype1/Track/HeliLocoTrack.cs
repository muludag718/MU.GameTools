using System.IO;
using MU.GameTools.IO;

namespace MU.GameTools.Prototype.Fight.Prototype1.Track
{
	[KnownTrack(TrackHash.HeliLoco)]
	public class HeliLocoTrack : P1Track
	{
		public float TimeBegin { get; set; }

		public float TimeEnd { get; set; }

		public float Acceleration { get; set; }

		public float Velocity { get; set; }

		public float ExtraFallingVelocity { get; set; }

		public float TurnAcceleration { get; set; }

		public float TurnVelocity { get; set; }

		public Vector Minimum { get; set; } = new Vector();

		public Vector Maximum { get; set; } = new Vector();

		public float TiltMax { get; set; }

		public float TiltDampingConstant { get; set; }

		public float TiltSpringConstant { get; set; }

		public float VelocityToAngleFactor { get; set; }

		public float MaxWashEffectHeight { get; set; }

		public float WashEffectFrequency { get; set; }

		public int Priority { get; set; }

		public float BlendInTime { get; set; }

		public float BlendOutTime { get; set; }

		public override void Serialize(Stream output, Endian endianess)
		{
			base.Serialize(output, endianess);
			output.WriteValueF32(TimeBegin, endianess);
			output.WriteValueF32(TimeEnd, endianess);
			output.WriteValueF32(Acceleration, endianess);
			output.WriteValueF32(Velocity, endianess);
			output.WriteValueF32(ExtraFallingVelocity, endianess);
			output.WriteValueF32(TurnAcceleration, endianess);
			output.WriteValueF32(TurnVelocity, endianess);
			Minimum.Serialize(output, endianess);
			Maximum.Serialize(output, endianess);
			output.WriteValueF32(TiltMax, endianess);
			output.WriteValueF32(TiltDampingConstant, endianess);
			output.WriteValueF32(TiltSpringConstant, endianess);
			output.WriteValueF32(VelocityToAngleFactor, endianess);
			output.WriteValueF32(MaxWashEffectHeight, endianess);
			output.WriteValueF32(WashEffectFrequency, endianess);
			output.WriteValueS32(Priority, endianess);
			output.WriteValueF32(BlendInTime, endianess);
			output.WriteValueF32(BlendOutTime, endianess);
		}

		public override void Deserialize(Stream input, Endian endianess)
		{
			base.Deserialize(input, endianess);
			TimeBegin = input.ReadValueF32(endianess);
			TimeEnd = input.ReadValueF32(endianess);
			Acceleration = input.ReadValueF32(endianess);
			Velocity = input.ReadValueF32(endianess);
			ExtraFallingVelocity = input.ReadValueF32(endianess);
			TurnAcceleration = input.ReadValueF32(endianess);
			TurnVelocity = input.ReadValueF32(endianess);
			Minimum.Deserialize(input, endianess);
			Maximum.Deserialize(input, endianess);
			TiltMax = input.ReadValueF32(endianess);
			TiltDampingConstant = input.ReadValueF32(endianess);
			TiltSpringConstant = input.ReadValueF32(endianess);
			VelocityToAngleFactor = input.ReadValueF32(endianess);
			MaxWashEffectHeight = input.ReadValueF32(endianess);
			WashEffectFrequency = input.ReadValueF32(endianess);
			Priority = input.ReadValueS32(endianess);
			BlendInTime = input.ReadValueF32(endianess);
			BlendOutTime = input.ReadValueF32(endianess);
		}
	}
}
