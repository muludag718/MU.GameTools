using System;
using System.IO;
using MU.GameTools.IO;

namespace MU.GameTools.Prototype.Fight.Prototype1.Track
{
	[KnownNodeForContext(ContextHash.Motion)]
	[KnownTrack(TrackHash.Fall)]
	public class FallTrack : P1Track
	{
		[Flags]
		public enum PreserveMomentumType : ulong
		{
			PreserveMomentum = 1uL,
			UseSprintVelocity = 2uL,
			SnapToFaceMotion = 4uL
		}

		public float BeginTime { get; set; }

		public float EndTime { get; set; }

		public float TurningVelocityMin { get; set; }

		public float TurningAccelerationMin { get; set; }

		public float TurningVelocityMinForwardSpeedCap { get; set; }

		public float TurningVelocityMax { get; set; }

		public float TurningAccelerationMax { get; set; }

		public float TurningVelocityMaxForwardSpeedCap { get; set; }

		public PreserveMomentumType PreserveMomentum { get; set; }

		public Vector InitialVelocity { get; set; } = new Vector();

		public float Gravity { get; set; }

		public float MaxVelocity { get; set; }

		public float GravityDecreaseRate { get; set; }

		public float MaxVelocityXY { get; set; }

		public float MaxVelocityUp { get; set; }

		public bool LimitTurning { get; set; }

		public int Priority { get; set; }

		public float BlendInTime { get; set; }

		public float BlendOutTime { get; set; }

		public override void Serialize(Stream output, Endian endianess)
		{
			base.Serialize(output, endianess);
			output.WriteValueF32(BeginTime, endianess);
			output.WriteValueF32(EndTime, endianess);
			output.WriteValueF32(TurningVelocityMin, endianess);
			output.WriteValueF32(TurningAccelerationMin, endianess);
			output.WriteValueF32(TurningVelocityMinForwardSpeedCap, endianess);
			output.WriteValueF32(TurningVelocityMax, endianess);
			output.WriteValueF32(TurningAccelerationMax, endianess);
			output.WriteValueF32(TurningVelocityMaxForwardSpeedCap, endianess);
			BaseProperty.SerializePropertyBitfield(output, endianess, PreserveMomentum);
			InitialVelocity.Serialize(output, endianess);
			output.WriteValueF32(Gravity, endianess);
			output.WriteValueF32(MaxVelocity, endianess);
			output.WriteValueF32(GravityDecreaseRate, endianess);
			output.WriteValueF32(MaxVelocityXY, endianess);
			output.WriteValueF32(MaxVelocityUp, endianess);
			output.WriteValueB32(LimitTurning, endianess);
			output.WriteValueS32(Priority, endianess);
			output.WriteValueF32(BlendInTime, endianess);
			output.WriteValueF32(BlendOutTime, endianess);
		}

		public override void Deserialize(Stream input, Endian endianess)
		{
			base.Deserialize(input, endianess);
			BeginTime = input.ReadValueF32(endianess);
			EndTime = input.ReadValueF32(endianess);
			TurningVelocityMin = input.ReadValueF32(endianess);
			TurningAccelerationMin = input.ReadValueF32(endianess);
			TurningVelocityMinForwardSpeedCap = input.ReadValueF32(endianess);
			TurningVelocityMax = input.ReadValueF32(endianess);
			TurningAccelerationMax = input.ReadValueF32(endianess);
			TurningVelocityMaxForwardSpeedCap = input.ReadValueF32(endianess);
			PreserveMomentum = BaseProperty.DeserializePropertyBitfield<PreserveMomentumType>(input, endianess);
			InitialVelocity = new Vector(input, endianess);
			Gravity = input.ReadValueF32(endianess);
			MaxVelocity = input.ReadValueF32(endianess);
			GravityDecreaseRate = input.ReadValueF32(endianess);
			MaxVelocityXY = input.ReadValueF32(endianess);
			MaxVelocityUp = input.ReadValueF32(endianess);
			LimitTurning = input.ReadValueB32(endianess);
			Priority = input.ReadValueS32(endianess);
			BlendInTime = input.ReadValueF32(endianess);
			BlendOutTime = input.ReadValueF32(endianess);
		}
	}
}
