using System.IO;
using MU.GameTools.IO;

namespace MU.GameTools.Prototype.Fight.Prototype1.Track
{
	[KnownNodeForContext(ContextHash.Motion)]
	[KnownTrack(TrackHash.FlyingAutoTarget)]
	public class FlyingAutoTargetTrack : P1Track
	{
		public float TimeBegin { get; set; }

		public float TimeEnd { get; set; }

		public float Velocity { get; set; }

		public float TurningVelocity { get; set; }

		public Vector Offset { get; set; } = new Vector();

		public float Arc { get; set; }

		public float MaxDistance { get; set; }

		public bool CheckArc { get; set; }

		public bool CheckDistance { get; set; }

		public TargetFilterType TargetFilter { get; set; }

		public bool StickToTarget { get; set; }

		public bool UseExistingAutoTarget { get; set; }

		public bool UseReactionHitEvent { get; set; }

		public float CharacterHeight { get; set; }

		public float CharacterWidth { get; set; }

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
			output.WriteValueF32(Velocity, endianess);
			output.WriteValueF32(TurningVelocity, endianess);
			Offset.Serialize(output, endianess);
			output.WriteValueF32(Arc, endianess);
			output.WriteValueF32(MaxDistance, endianess);
			output.WriteValueB32(CheckArc, endianess);
			output.WriteValueB32(CheckDistance, endianess);
			BaseProperty.SerializePropertyBitfield(output, endianess, TargetFilter);
			output.WriteValueB32(StickToTarget, endianess);
			output.WriteValueB32(UseExistingAutoTarget, endianess);
			output.WriteValueB32(UseReactionHitEvent, endianess);
			output.WriteValueF32(CharacterHeight, endianess);
			output.WriteValueF32(CharacterWidth, endianess);
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
			Velocity = input.ReadValueF32(endianess);
			TurningVelocity = input.ReadValueF32(endianess);
			Offset = new Vector(input, endianess);
			Arc = input.ReadValueF32(endianess);
			MaxDistance = input.ReadValueF32(endianess);
			CheckArc = input.ReadValueB32(endianess);
			CheckDistance = input.ReadValueB32(endianess);
			TargetFilter = BaseProperty.DeserializePropertyBitfield<TargetFilterType>(input, endianess);
			StickToTarget = input.ReadValueB32(endianess);
			UseExistingAutoTarget = input.ReadValueB32(endianess);
			UseReactionHitEvent = input.ReadValueB32(endianess);
			CharacterHeight = input.ReadValueF32(endianess);
			CharacterWidth = input.ReadValueF32(endianess);
			MinPriorityTargetClass = BaseProperty.DeserializePropertyEnum<TargetClass>(input, endianess);
			MaxPriorityTargetClass = BaseProperty.DeserializePropertyEnum<TargetClass>(input, endianess);
			Priority = input.ReadValueS32(endianess);
			BlendInTime = input.ReadValueF32(endianess);
			BlendOutTime = input.ReadValueF32(endianess);
		}
	}
}
