using System.IO;
using MU.GameTools.IO;

namespace MU.GameTools.Prototype.Fight.Prototype1.Track
{
	[KnownNodeForContext(ContextHash.Motion)]
	[KnownTrack(TrackHash.JumpFromWater)]
	public class JumpFromWaterTrack : P1Track
	{
		public float TimeBegin { get; set; }

		public float TimeEnd { get; set; }

		public float FlightTimeMin { get; set; }

		public float FlightTimeMax { get; set; }

		public float UpOvershootDistance { get; set; }

		public float ForwardDistanceMin { get; set; }

		public float ForwardDistanceMax { get; set; }

		public float TurningVelocityMin { get; set; }

		public float TurningVelocityMinForwardSpeedCap { get; set; }

		public float TurningVelocityMax { get; set; }

		public float TurningVelocityMaxForwardSpeedCap { get; set; }

		public float MaxFallSpeed { get; set; }

		public float ForwardVelocityScale { get; set; }

		public int Priority { get; set; }

		public float BlendInTime { get; set; }

		public float BlendOutTime { get; set; }

		public override void Serialize(Stream output, Endian endianess)
		{
			base.Serialize(output, endianess);
			output.WriteValueF32(TimeBegin, endianess);
			output.WriteValueF32(TimeEnd, endianess);
			output.WriteValueF32(FlightTimeMin, endianess);
			output.WriteValueF32(FlightTimeMax, endianess);
			output.WriteValueF32(UpOvershootDistance, endianess);
			output.WriteValueF32(ForwardDistanceMin, endianess);
			output.WriteValueF32(ForwardDistanceMax, endianess);
			output.WriteValueF32(TurningVelocityMin, endianess);
			output.WriteValueF32(TurningVelocityMinForwardSpeedCap, endianess);
			output.WriteValueF32(TurningVelocityMax, endianess);
			output.WriteValueF32(TurningVelocityMaxForwardSpeedCap, endianess);
			output.WriteValueF32(MaxFallSpeed, endianess);
			output.WriteValueF32(ForwardVelocityScale, endianess);
			output.WriteValueS32(Priority, endianess);
			output.WriteValueF32(BlendInTime, endianess);
			output.WriteValueF32(BlendOutTime, endianess);
		}

		public override void Deserialize(Stream input, Endian endianess)
		{
			base.Deserialize(input, endianess);
			TimeBegin = input.ReadValueF32(endianess);
			TimeEnd = input.ReadValueF32(endianess);
			FlightTimeMin = input.ReadValueF32(endianess);
			FlightTimeMax = input.ReadValueF32(endianess);
			UpOvershootDistance = input.ReadValueF32(endianess);
			ForwardDistanceMin = input.ReadValueF32(endianess);
			ForwardDistanceMax = input.ReadValueF32(endianess);
			TurningVelocityMin = input.ReadValueF32(endianess);
			TurningVelocityMinForwardSpeedCap = input.ReadValueF32(endianess);
			TurningVelocityMax = input.ReadValueF32(endianess);
			TurningVelocityMaxForwardSpeedCap = input.ReadValueF32(endianess);
			MaxFallSpeed = input.ReadValueF32(endianess);
			ForwardVelocityScale = input.ReadValueF32(endianess);
			Priority = input.ReadValueS32(endianess);
			BlendInTime = input.ReadValueF32(endianess);
			BlendOutTime = input.ReadValueF32(endianess);
		}
	}
}
