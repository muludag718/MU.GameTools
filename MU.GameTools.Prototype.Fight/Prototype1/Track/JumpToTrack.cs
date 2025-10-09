using System.IO;
using MU.GameTools.IO;

namespace MU.GameTools.Prototype.Fight.Prototype1.Track
{
	[KnownNodeForContext(ContextHash.Motion)]
	[KnownTrack(TrackHash.JumpTo)]
	public class JumpToTrack : P1Track
	{
		public enum JumpToChargeType : ulong
		{
			Invalid = 4122290943349627157uL,
			Jump = 20889331387467136uL,
			Attack = 17648781240126830036uL,
			Throw = 5973634341500805012uL
		}

		public float TimeBegin { get; set; }

		public float TimeEnd { get; set; }

		public bool UseTarget { get; set; }

		public JumpToChargeType ChargeType { get; set; }

		public float DistanceMin { get; set; }

		public float DistanceMax { get; set; }

		public bool UseDistanceWhenUsingTarget { get; set; }

		public float MinInitialVelocityMin { get; set; }

		public float MinInitialVelocityMax { get; set; }

		public float MaxInitialVelocityMin { get; set; }

		public float MaxInitialVelocityMax { get; set; }

		public float TrackingMin { get; set; }

		public float TrackingMax { get; set; }

		public float MinSpeedTracking { get; set; }

		public float LaunchAngle { get; set; }

		public float MinLaunchAngle { get; set; }

		public float Gravity { get; set; }

		public Vector Offset { get; set; } = new Vector();

		public int Priority { get; set; }

		public float BlendInTime { get; set; }

		public float BlendOutTime { get; set; }

		public override void Serialize(Stream output, Endian endianess)
		{
			base.Serialize(output, endianess);
			output.WriteValueF32(TimeBegin, endianess);
			output.WriteValueF32(TimeEnd, endianess);
			output.WriteValueB32(UseTarget, endianess);
			BaseProperty.SerializePropertyEnum(output, endianess, ChargeType);
			output.WriteValueF32(DistanceMin, endianess);
			output.WriteValueF32(DistanceMax, endianess);
			output.WriteValueB32(UseDistanceWhenUsingTarget, endianess);
			output.WriteValueF32(MinInitialVelocityMin, endianess);
			output.WriteValueF32(MinInitialVelocityMax, endianess);
			output.WriteValueF32(MaxInitialVelocityMin, endianess);
			output.WriteValueF32(MaxInitialVelocityMax, endianess);
			output.WriteValueF32(TrackingMin, endianess);
			output.WriteValueF32(TrackingMax, endianess);
			output.WriteValueF32(MinSpeedTracking, endianess);
			output.WriteValueF32(LaunchAngle, endianess);
			output.WriteValueF32(MinLaunchAngle, endianess);
			output.WriteValueF32(Gravity, endianess);
			Offset.Serialize(output, endianess);
			output.WriteValueS32(Priority, endianess);
			output.WriteValueF32(BlendInTime, endianess);
			output.WriteValueF32(BlendOutTime, endianess);
		}

		public override void Deserialize(Stream input, Endian endianess)
		{
			base.Deserialize(input, endianess);
			TimeBegin = input.ReadValueF32(endianess);
			TimeEnd = input.ReadValueF32(endianess);
			UseTarget = input.ReadValueB32(endianess);
			ChargeType = BaseProperty.DeserializePropertyEnum<JumpToChargeType>(input, endianess);
			DistanceMin = input.ReadValueF32(endianess);
			DistanceMax = input.ReadValueF32(endianess);
			UseDistanceWhenUsingTarget = input.ReadValueB32(endianess);
			MinInitialVelocityMin = input.ReadValueF32(endianess);
			MinInitialVelocityMax = input.ReadValueF32(endianess);
			MaxInitialVelocityMin = input.ReadValueF32(endianess);
			MaxInitialVelocityMax = input.ReadValueF32(endianess);
			TrackingMin = input.ReadValueF32(endianess);
			TrackingMax = input.ReadValueF32(endianess);
			MinSpeedTracking = input.ReadValueF32(endianess);
			LaunchAngle = input.ReadValueF32(endianess);
			MinLaunchAngle = input.ReadValueF32(endianess);
			Gravity = input.ReadValueF32(endianess);
			Offset = new Vector(input, endianess);
			Priority = input.ReadValueS32(endianess);
			BlendInTime = input.ReadValueF32(endianess);
			BlendOutTime = input.ReadValueF32(endianess);
		}
	}
}
