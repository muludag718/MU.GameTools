using System;
using System.IO;
using MU.GameTools.IO;

namespace MU.GameTools.Prototype.Fight.Prototype1.Track
{
	[KnownNodeForContext(ContextHash.Motion)]
	[KnownTrack(TrackHash.AutoTarget)]
	public class AutoTargetTrack : P1Track
	{
		[Flags]
		public enum AutoTargetType : ulong
		{
			ExistingAutoTarget = 1uL,
			DetectedObject = 2uL,
			ReactionGiver = 4uL,
			PowerTarget = 8uL,
			ForceExistingTarget = 0x10uL
		}

		public float TimeBegin { get; set; }

		public float TimeEnd { get; set; }

		public float TurningVelocity { get; set; }

		public bool UseInput { get; set; }

		public bool UseCamera { get; set; }

		public Vector Direction { get; set; } = new Vector();

		public float Arc { get; set; }

		public float MaxDistance { get; set; }

		public bool CheckArc { get; set; }

		public bool CheckDistance { get; set; }

		public float OrientOffsetFromTarget { get; set; }

		public TargetFilterType TargetFilter { get; set; }

		public AutoTargetType TargetOverrides { get; set; }

		public TargetClass MinPriorityTargetClass { get; set; }

		public TargetClass MaxPriorityTargetClass { get; set; }

		public int Priority { get; set; }

		public float BlendInTime { get; set; }

		public float BlendOutTime { get; set; }

		public override void Serialize(Stream output, Endian endianess)
		{
			base.Serialize(output, endianess);
			output.WriteValueF32(TimeBegin, endianess);
			output.WriteValueF32(TimeEnd, endianess);
			output.WriteValueF32(TurningVelocity, endianess);
			output.WriteValueB32(UseInput, endianess);
			output.WriteValueB32(UseCamera, endianess);
			Direction.Serialize(output, endianess);
			output.WriteValueF32(Arc, endianess);
			output.WriteValueF32(MaxDistance, endianess);
			output.WriteValueB32(CheckArc, endianess);
			output.WriteValueB32(CheckDistance, endianess);
			output.WriteValueF32(OrientOffsetFromTarget, endianess);
			BaseProperty.SerializePropertyBitfield(output, endianess, TargetFilter);
			BaseProperty.SerializePropertyBitfield(output, endianess, TargetOverrides);
			BaseProperty.SerializePropertyEnum(output, endianess, MinPriorityTargetClass);
			BaseProperty.SerializePropertyEnum(output, endianess, MaxPriorityTargetClass);
			output.WriteValueS32(Priority, endianess);
			output.WriteValueF32(BlendInTime, endianess);
			output.WriteValueF32(BlendOutTime, endianess);
		}

		public override void Deserialize(Stream input, Endian endianess)
		{
			base.Deserialize(input, endianess);
			TimeBegin = input.ReadValueF32(endianess);
			TimeEnd = input.ReadValueF32(endianess);
			TurningVelocity = input.ReadValueF32(endianess);
			UseInput = input.ReadValueB32(endianess);
			UseCamera = input.ReadValueB32(endianess);
			Direction = new Vector(input, endianess);
			Arc = input.ReadValueF32(endianess);
			MaxDistance = input.ReadValueF32(endianess);
			CheckArc = input.ReadValueB32(endianess);
			CheckDistance = input.ReadValueB32(endianess);
			OrientOffsetFromTarget = input.ReadValueF32(endianess);
			TargetFilter = BaseProperty.DeserializePropertyBitfield<TargetFilterType>(input, endianess);
			TargetOverrides = BaseProperty.DeserializePropertyBitfield<AutoTargetType>(input, endianess);
			MinPriorityTargetClass = BaseProperty.DeserializePropertyEnum<TargetClass>(input, endianess);
			MaxPriorityTargetClass = BaseProperty.DeserializePropertyEnum<TargetClass>(input, endianess);
			Priority = input.ReadValueS32(endianess);
			BlendInTime = input.ReadValueF32(endianess);
			BlendOutTime = input.ReadValueF32(endianess);
		}
	}
}
