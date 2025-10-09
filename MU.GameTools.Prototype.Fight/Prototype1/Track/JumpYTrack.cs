using System.IO;
using MU.GameTools.IO;

namespace MU.GameTools.Prototype.Fight.Prototype1.Track
{
	[KnownNodeForContext(ContextHash.Motion)]
	[KnownTrack(TrackHash.JumpY)]
	public class JumpYTrack : P1Track
	{
		public float TimeBegin { get; set; }

		public float TimeEnd { get; set; }

		public float FlightTimeMin { get; set; }

		public float FlightTimeMax { get; set; }

		public float HeightMin { get; set; }

		public float HeightMax { get; set; }

		public float ForwardVelocityMin { get; set; }

		public float ForwardVelocityMax { get; set; }

		public float MaxFallSpeed { get; set; }

		public bool UseSprintVelocity { get; set; }

		public float TurningVelocityMin { get; set; }

		public float TurningVelocityMinForwardSpeedCap { get; set; }

		public float TurningVelocityMax { get; set; }

		public float TurningVelocityMaxForwardSpeedCap { get; set; }

		public UnlockableEnum UnlockableFirst { get; set; }

		public UnlockableEnum UnlockableLast { get; set; }

		public float UnlockableFlightTimeMin { get; set; }

		public float UnlockableHeightMin { get; set; }

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
			output.WriteValueF32(HeightMin, endianess);
			output.WriteValueF32(HeightMax, endianess);
			output.WriteValueF32(ForwardVelocityMin, endianess);
			output.WriteValueF32(ForwardVelocityMax, endianess);
			output.WriteValueF32(MaxFallSpeed, endianess);
			output.WriteValueB32(UseSprintVelocity, endianess);
			output.WriteValueF32(TurningVelocityMin, endianess);
			output.WriteValueF32(TurningVelocityMinForwardSpeedCap, endianess);
			output.WriteValueF32(TurningVelocityMax, endianess);
			output.WriteValueF32(TurningVelocityMaxForwardSpeedCap, endianess);
			BaseProperty.SerializePropertyEnum(output, endianess, UnlockableFirst);
			BaseProperty.SerializePropertyEnum(output, endianess, UnlockableLast);
			output.WriteValueF32(UnlockableFlightTimeMin, endianess);
			output.WriteValueF32(UnlockableHeightMin, endianess);
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
			HeightMin = input.ReadValueF32(endianess);
			HeightMax = input.ReadValueF32(endianess);
			ForwardVelocityMin = input.ReadValueF32(endianess);
			ForwardVelocityMax = input.ReadValueF32(endianess);
			MaxFallSpeed = input.ReadValueF32(endianess);
			UseSprintVelocity = input.ReadValueB32(endianess);
			TurningVelocityMin = input.ReadValueF32(endianess);
			TurningVelocityMinForwardSpeedCap = input.ReadValueF32(endianess);
			TurningVelocityMax = input.ReadValueF32(endianess);
			TurningVelocityMaxForwardSpeedCap = input.ReadValueF32(endianess);
			UnlockableFirst = BaseProperty.DeserializePropertyEnum<UnlockableEnum>(input, endianess);
			UnlockableLast = BaseProperty.DeserializePropertyEnum<UnlockableEnum>(input, endianess);
			UnlockableFlightTimeMin = input.ReadValueF32(endianess);
			UnlockableHeightMin = input.ReadValueF32(endianess);
			Priority = input.ReadValueS32(endianess);
			BlendInTime = input.ReadValueF32(endianess);
			BlendOutTime = input.ReadValueF32(endianess);
		}
	}
}
