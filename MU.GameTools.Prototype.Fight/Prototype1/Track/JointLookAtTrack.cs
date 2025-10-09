using System.IO;
using MU.GameTools.IO;

namespace MU.GameTools.Prototype.Fight.Prototype1.Track
{
	[KnownNodeForContext(ContextHash.Motion)]
	[KnownTrack(TrackHash.JointLookAt)]
	public class JointLookAtTrack : P1Track
	{
		public float TimeBegin { get; set; }

		public float TimeEnd { get; set; }

		public ulong Joint { get; set; }

		public Vector Heading { get; set; } = new Vector();

		public Vector PrimaryRotationAxis { get; set; } = new Vector();

		public float PrimaryTurnRate { get; set; }

		public float PrimaryAngleMin { get; set; }

		public float PrimaryAngleMax { get; set; }

		public float SecondaryTurnRate { get; set; }

		public float SecondaryAngleMin { get; set; }

		public float SecondaryAngleMax { get; set; }

		public int Priority { get; set; }

		public float BlendInTime { get; set; }

		public float BlendOutTime { get; set; }

		public ulong UseGrabSlot { get; set; }

		public LookAtType Where { get; set; }

		public bool UseAutoTarget { get; set; }

		public bool UseIntentionWhenNoTarget { get; set; }

		public bool UseFreeAimWhenNoTarget { get; set; }

		public bool UseLocalAngelsInIntention { get; set; }

		public Vector TargetOffset { get; set; } = new Vector();

		public override void Serialize(Stream output, Endian endianess)
		{
			base.Serialize(output, endianess);
			output.WriteValueF32(TimeBegin, endianess);
			output.WriteValueF32(TimeEnd, endianess);
			output.WriteValueU64(Joint, endianess);
			Heading.Serialize(output, endianess);
			PrimaryRotationAxis.Serialize(output, endianess);
			output.WriteValueF32(PrimaryTurnRate, endianess);
			output.WriteValueF32(PrimaryAngleMin, endianess);
			output.WriteValueF32(PrimaryAngleMax, endianess);
			output.WriteValueF32(SecondaryTurnRate, endianess);
			output.WriteValueF32(SecondaryAngleMin, endianess);
			output.WriteValueF32(SecondaryAngleMax, endianess);
			output.WriteValueS32(Priority, endianess);
			output.WriteValueF32(BlendInTime, endianess);
			output.WriteValueF32(BlendOutTime, endianess);
			output.WriteValueU64(UseGrabSlot, endianess);
			BaseProperty.SerializePropertyEnum(output, endianess, Where);
			output.WriteValueB32(UseAutoTarget, endianess);
			output.WriteValueB32(UseIntentionWhenNoTarget, endianess);
			output.WriteValueB32(UseFreeAimWhenNoTarget, endianess);
			output.WriteValueB32(UseLocalAngelsInIntention, endianess);
			TargetOffset.Serialize(output, endianess);
		}

		public override void Deserialize(Stream input, Endian endianess)
		{
			base.Deserialize(input, endianess);
			TimeBegin = input.ReadValueF32(endianess);
			TimeEnd = input.ReadValueF32(endianess);
			Joint = input.ReadValueU64(endianess);
			Heading = new Vector(input, endianess);
			PrimaryRotationAxis = new Vector(input, endianess);
			PrimaryTurnRate = input.ReadValueF32(endianess);
			PrimaryAngleMin = input.ReadValueF32(endianess);
			PrimaryAngleMax = input.ReadValueF32(endianess);
			SecondaryTurnRate = input.ReadValueF32(endianess);
			SecondaryAngleMin = input.ReadValueF32(endianess);
			SecondaryAngleMax = input.ReadValueF32(endianess);
			Priority = input.ReadValueS32(endianess);
			BlendInTime = input.ReadValueF32(endianess);
			BlendOutTime = input.ReadValueF32(endianess);
			UseGrabSlot = input.ReadValueU64(endianess);
			Where = BaseProperty.DeserializePropertyEnum<LookAtType>(input, endianess);
			UseAutoTarget = input.ReadValueB32(endianess);
			UseIntentionWhenNoTarget = input.ReadValueB32(endianess);
			UseFreeAimWhenNoTarget = input.ReadValueB32(endianess);
			UseLocalAngelsInIntention = input.ReadValueB32(endianess);
			TargetOffset = new Vector(input, endianess);
		}
	}
}
