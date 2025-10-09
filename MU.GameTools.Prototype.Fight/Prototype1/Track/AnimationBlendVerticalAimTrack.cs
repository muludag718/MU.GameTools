using System.IO;
using MU.GameTools.IO;

namespace MU.GameTools.Prototype.Fight.Prototype1.Track
{
	[KnownNodeForContext(ContextHash.Motion)]
	[KnownTrack(TrackHash.AnimationBlendVerticalAim)]
	public class AnimationBlendVerticalAimTrack : P1Track
	{
		public enum InterpolationDirectionType : ulong
		{
			X = 88uL,
			Y = 89uL,
			Z = 90uL,
			XZ = 5772786uL,
			Magnitude = 2822888922154341390uL,
			AbsX = 18348266184121448uL,
			AbsY = 18348266184121449uL,
			AbsZ = 18348266184121450uL,
			WorldY = 6581076010052170401uL,
			WorldXZ = 2853626387689600314uL
		}

		public enum TargetingModeType : ulong
		{
			Target = 856854631462190855uL,
			TargetFeet = 697244243143271027uL,
			Intention = 9713923695382230984uL,
			Motion = 6297553359567207254uL
		}

		public float TimeBegin { get; set; }

		public float TimeEnd { get; set; }

		public float AngleRate { get; set; }

		public float AngleDefault { get; set; }

		public float AngleOffset { get; set; }

		public float AngleOffsetMin { get; set; }

		public float AngleMin { get; set; }

		public float AngleMax { get; set; }

		public float OffsetInterpolationDist { get; set; }

		public InterpolationDirectionType InterpolationDirection { get; set; }

		public float Speed { get; set; }

		public AnimationCyclic Cyclic { get; set; }

		public ulong AnimUp { get; set; }

		public float AnimUpAngle { get; set; }

		public float AnimUpSyncFrame { get; set; }

		public float AnimUpStartFrame { get; set; }

		public float AnimUpEndFrame { get; set; }

		public float AnimUpSpeed { get; set; }

		public ulong AnimNeutral { get; set; }

		public float AnimNeutralAngle { get; set; }

		public float AnimNeutralSyncFrame { get; set; }

		public float AnimNeutralStartFrame { get; set; }

		public float AnimNeutralEndFrame { get; set; }

		public float AnimNeutralSpeed { get; set; }

		public ulong AnimDown { get; set; }

		public float AnimDownAngle { get; set; }

		public float AnimDownSyncFrame { get; set; }

		public float AnimDownStartFrame { get; set; }

		public float AnimDownEndFrame { get; set; }

		public float AnimDownSpeed { get; set; }

		public ulong Partition { get; set; }

		public int Priority { get; set; }

		public float BlendInTime { get; set; }

		public float BlendOutTime { get; set; }

		public TargetingModeType TargetingMode { get; set; }

		public override void Serialize(Stream output, Endian endianess)
		{
			base.Serialize(output, endianess);
			output.WriteValueF32(TimeBegin, endianess);
			output.WriteValueF32(TimeEnd, endianess);
			output.WriteValueF32(AngleRate, endianess);
			output.WriteValueF32(AngleDefault, endianess);
			output.WriteValueF32(AngleOffset, endianess);
			output.WriteValueF32(AngleOffsetMin, endianess);
			output.WriteValueF32(AngleMin, endianess);
			output.WriteValueF32(AngleMax, endianess);
			output.WriteValueF32(OffsetInterpolationDist, endianess);
			BaseProperty.SerializePropertyEnum(output, endianess, InterpolationDirection);
			output.WriteValueF32(Speed, endianess);
			BaseProperty.SerializePropertyEnum(output, endianess, Cyclic);
			output.WriteValueU64(AnimUp, endianess);
			output.WriteValueF32(AnimUpAngle, endianess);
			output.WriteValueF32(AnimUpSyncFrame, endianess);
			output.WriteValueF32(AnimUpStartFrame, endianess);
			output.WriteValueF32(AnimUpEndFrame, endianess);
			output.WriteValueF32(AnimUpSpeed, endianess);
			output.WriteValueU64(AnimNeutral, endianess);
			output.WriteValueF32(AnimNeutralAngle, endianess);
			output.WriteValueF32(AnimNeutralSyncFrame, endianess);
			output.WriteValueF32(AnimNeutralStartFrame, endianess);
			output.WriteValueF32(AnimNeutralEndFrame, endianess);
			output.WriteValueF32(AnimNeutralSpeed, endianess);
			output.WriteValueU64(AnimDown, endianess);
			output.WriteValueF32(AnimDownAngle, endianess);
			output.WriteValueF32(AnimDownSyncFrame, endianess);
			output.WriteValueF32(AnimDownStartFrame, endianess);
			output.WriteValueF32(AnimDownEndFrame, endianess);
			output.WriteValueF32(AnimDownSpeed, endianess);
			output.WriteValueU64(Partition, endianess);
			output.WriteValueS32(Priority, endianess);
			output.WriteValueF32(BlendInTime, endianess);
			output.WriteValueF32(BlendOutTime, endianess);
			BaseProperty.SerializePropertyEnum(output, endianess, TargetingMode);
		}

		public override void Deserialize(Stream input, Endian endianess)
		{
			base.Deserialize(input, endianess);
			TimeBegin = input.ReadValueF32(endianess);
			TimeEnd = input.ReadValueF32(endianess);
			AngleRate = input.ReadValueF32(endianess);
			AngleDefault = input.ReadValueF32(endianess);
			AngleOffset = input.ReadValueF32(endianess);
			AngleOffsetMin = input.ReadValueF32(endianess);
			AngleMin = input.ReadValueF32(endianess);
			AngleMax = input.ReadValueF32(endianess);
			OffsetInterpolationDist = input.ReadValueF32(endianess);
			InterpolationDirection = BaseProperty.DeserializePropertyEnum<InterpolationDirectionType>(input, endianess);
			Speed = input.ReadValueF32(endianess);
			Cyclic = BaseProperty.DeserializePropertyEnum<AnimationCyclic>(input, endianess);
			AnimUp = input.ReadValueU64(endianess);
			AnimUpAngle = input.ReadValueF32(endianess);
			AnimUpSyncFrame = input.ReadValueF32(endianess);
			AnimUpStartFrame = input.ReadValueF32(endianess);
			AnimUpEndFrame = input.ReadValueF32(endianess);
			AnimUpSpeed = input.ReadValueF32(endianess);
			AnimNeutral = input.ReadValueU64(endianess);
			AnimNeutralAngle = input.ReadValueF32(endianess);
			AnimNeutralSyncFrame = input.ReadValueF32(endianess);
			AnimNeutralStartFrame = input.ReadValueF32(endianess);
			AnimNeutralEndFrame = input.ReadValueF32(endianess);
			AnimNeutralSpeed = input.ReadValueF32(endianess);
			AnimDown = input.ReadValueU64(endianess);
			AnimDownAngle = input.ReadValueF32(endianess);
			AnimDownSyncFrame = input.ReadValueF32(endianess);
			AnimDownStartFrame = input.ReadValueF32(endianess);
			AnimDownEndFrame = input.ReadValueF32(endianess);
			AnimDownSpeed = input.ReadValueF32(endianess);
			Partition = input.ReadValueU64(endianess);
			Priority = input.ReadValueS32(endianess);
			BlendInTime = input.ReadValueF32(endianess);
			BlendOutTime = input.ReadValueF32(endianess);
			TargetingMode = BaseProperty.DeserializePropertyEnum<TargetingModeType>(input, endianess);
		}
	}
}
