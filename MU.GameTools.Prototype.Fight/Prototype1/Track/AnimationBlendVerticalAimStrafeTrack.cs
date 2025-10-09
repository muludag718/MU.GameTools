using System.IO;
using MU.GameTools.IO;

namespace MU.GameTools.Prototype.Fight.Prototype1.Track
{
	[KnownNodeForContext(ContextHash.Motion)]
	[KnownTrack(TrackHash.AnimationBlendVerticalAimStrafe)]
	public class AnimationBlendVerticalAimStrafeTrack : P1Track
	{
		public float TimeBegin { get; set; }

		public float TimeEnd { get; set; }

		public ulong RefLocomotionName { get; set; }

		public float AngleRate { get; set; }

		public float AngleDefault { get; set; }

		public float AngleOffset { get; set; }

		public float AngleOffsetMin { get; set; }

		public float OffsetInterpolationDist { get; set; }

		public DirectionType InterpolationDirection { get; set; }

		public float Speed { get; set; }

		public AnimationCyclic Cyclic { get; set; }

		public ulong PivotJoint { get; set; }

		public Vector PivotOffset { get; set; } = new Vector();

		public Axis TargetingMode { get; set; }

		public float AnimUpAngle { get; set; }

		public float AnimNeutralAngle { get; set; }

		public float AnimDownAngle { get; set; }

		public ulong AnimIdleUp { get; set; }

		public ulong AnimIdleNeutral { get; set; }

		public ulong AnimIdleDown { get; set; }

		public ulong AnimNorthUp { get; set; }

		public ulong AnimNorthNeutral { get; set; }

		public ulong AnimNorthDown { get; set; }

		public ulong AnimEastUp { get; set; }

		public ulong AnimEastNeutral { get; set; }

		public ulong AnimEastDown { get; set; }

		public ulong AnimSouthUp { get; set; }

		public ulong AnimSouthNeutral { get; set; }

		public ulong AnimSouthDown { get; set; }

		public ulong AnimWestUp { get; set; }

		public ulong AnimWestNeutral { get; set; }

		public ulong AnimWestDown { get; set; }

		public ulong Partition { get; set; }

		public int Priority { get; set; }

		public float BlendInTime { get; set; }

		public float BlendOutTime { get; set; }

		public override void Serialize(Stream output, Endian endianess)
		{
			base.Serialize(output, endianess);
			output.WriteValueF32(TimeBegin, endianess);
			output.WriteValueF32(TimeEnd, endianess);
			output.WriteValueU64(RefLocomotionName, endianess);
			output.WriteValueF32(AngleRate, endianess);
			output.WriteValueF32(AngleDefault, endianess);
			output.WriteValueF32(AngleOffset, endianess);
			output.WriteValueF32(AngleOffsetMin, endianess);
			output.WriteValueF32(OffsetInterpolationDist, endianess);
			BaseProperty.SerializePropertyEnum(output, endianess, InterpolationDirection);
			output.WriteValueF32(Speed, endianess);
			BaseProperty.SerializePropertyEnum(output, endianess, Cyclic);
			output.WriteValueU64(PivotJoint, endianess);
			PivotOffset.Serialize(output, endianess);
			BaseProperty.SerializePropertyEnum(output, endianess, TargetingMode);
			output.WriteValueF32(AnimUpAngle, endianess);
			output.WriteValueF32(AnimNeutralAngle, endianess);
			output.WriteValueF32(AnimDownAngle, endianess);
			output.WriteValueU64(AnimIdleUp, endianess);
			output.WriteValueU64(AnimIdleNeutral, endianess);
			output.WriteValueU64(AnimIdleDown, endianess);
			output.WriteValueU64(AnimNorthUp, endianess);
			output.WriteValueU64(AnimNorthNeutral, endianess);
			output.WriteValueU64(AnimNorthDown, endianess);
			output.WriteValueU64(AnimEastUp, endianess);
			output.WriteValueU64(AnimEastNeutral, endianess);
			output.WriteValueU64(AnimEastDown, endianess);
			output.WriteValueU64(AnimSouthUp, endianess);
			output.WriteValueU64(AnimSouthNeutral, endianess);
			output.WriteValueU64(AnimSouthDown, endianess);
			output.WriteValueU64(AnimWestUp, endianess);
			output.WriteValueU64(AnimWestNeutral, endianess);
			output.WriteValueU64(AnimWestDown, endianess);
			output.WriteValueU64(Partition, endianess);
			output.WriteValueS32(Priority, endianess);
			output.WriteValueF32(BlendInTime, endianess);
			output.WriteValueF32(BlendOutTime, endianess);
		}

		public override void Deserialize(Stream input, Endian endianess)
		{
			base.Deserialize(input, endianess);
			TimeBegin = input.ReadValueF32(endianess);
			TimeEnd = input.ReadValueF32(endianess);
			RefLocomotionName = input.ReadValueU64(endianess);
			AngleRate = input.ReadValueF32(endianess);
			AngleDefault = input.ReadValueF32(endianess);
			AngleOffset = input.ReadValueF32(endianess);
			AngleOffsetMin = input.ReadValueF32(endianess);
			OffsetInterpolationDist = input.ReadValueF32(endianess);
			InterpolationDirection = BaseProperty.DeserializePropertyEnum<DirectionType>(input, endianess);
			Speed = input.ReadValueF32(endianess);
			Cyclic = BaseProperty.DeserializePropertyEnum<AnimationCyclic>(input, endianess);
			PivotJoint = input.ReadValueU64(endianess);
			PivotOffset = new Vector(input, endianess);
			TargetingMode = BaseProperty.DeserializePropertyEnum<Axis>(input, endianess);
			AnimUpAngle = input.ReadValueF32(endianess);
			AnimNeutralAngle = input.ReadValueF32(endianess);
			AnimDownAngle = input.ReadValueF32(endianess);
			AnimIdleUp = input.ReadValueU64(endianess);
			AnimIdleNeutral = input.ReadValueU64(endianess);
			AnimIdleDown = input.ReadValueU64(endianess);
			AnimNorthUp = input.ReadValueU64(endianess);
			AnimNorthNeutral = input.ReadValueU64(endianess);
			AnimNorthDown = input.ReadValueU64(endianess);
			AnimEastUp = input.ReadValueU64(endianess);
			AnimEastNeutral = input.ReadValueU64(endianess);
			AnimEastDown = input.ReadValueU64(endianess);
			AnimSouthUp = input.ReadValueU64(endianess);
			AnimSouthNeutral = input.ReadValueU64(endianess);
			AnimSouthDown = input.ReadValueU64(endianess);
			AnimWestUp = input.ReadValueU64(endianess);
			AnimWestNeutral = input.ReadValueU64(endianess);
			AnimWestDown = input.ReadValueU64(endianess);
			Partition = input.ReadValueU64(endianess);
			Priority = input.ReadValueS32(endianess);
			BlendInTime = input.ReadValueF32(endianess);
			BlendOutTime = input.ReadValueF32(endianess);
		}
	}
}
