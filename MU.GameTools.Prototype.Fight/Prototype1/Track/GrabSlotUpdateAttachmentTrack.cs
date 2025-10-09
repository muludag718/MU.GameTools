using System.IO;
using MU.GameTools.IO;

namespace MU.GameTools.Prototype.Fight.Prototype1.Track
{
	[KnownNodeForContext(ContextHash.Motion)]
	[KnownTrack(TrackHash.GrabSlotUpdateAttachment)]
	public class GrabSlotUpdateAttachmentTrack : P1Track
	{
		public float BeginTime { get; set; }

		public ulong GrabSlotHash { get; set; }

		public ulong ParentJointHash { get; set; }

		public bool OverrideParentTranslationJoint { get; set; }

		public ulong ParentTranslationJoint { get; set; }

		public float ParentPositionOffsetX { get; set; }

		public float ParentPositionOffsetY { get; set; }

		public float ParentPositionOffsetZ { get; set; }

		public float ParentRotationOffsetX { get; set; }

		public float ParentRotationOffsetY { get; set; }

		public float ParentRotationOffsetZ { get; set; }

		public ulong ChildJointHash { get; set; }

		public bool OverrideChildTranslationJoint { get; set; }

		public ulong ChildTranslationJointHash { get; set; }

		public float ChildPositionOffsetX { get; set; }

		public float ChildPositionOffsetY { get; set; }

		public float ChildPositionOffsetZ { get; set; }

		public float ChildRotationOffsetX { get; set; }

		public float ChildRotationOffsetY { get; set; }

		public float ChildRotationOffsetZ { get; set; }

		public bool ConsiderChildAlternateRotation { get; set; }

		public float ChildAlternateRotationOffsetX { get; set; }

		public float ChildAlternateRotationOffsetY { get; set; }

		public float ChildAlternateRotationOffsetZ { get; set; }

		public float BlendTime { get; set; }

		public PhysicsMode PhysicsMode { get; set; }

		public override void Serialize(Stream output, Endian endianess)
		{
			base.Serialize(output, endianess);
			output.WriteValueF32(BeginTime, endianess);
			output.WriteValueU64(GrabSlotHash, endianess);
			output.WriteValueU64(ParentJointHash, endianess);
			output.WriteValueB32(OverrideParentTranslationJoint, endianess);
			output.WriteValueU64(ParentTranslationJoint, endianess);
			output.WriteValueF32(ParentPositionOffsetX, endianess);
			output.WriteValueF32(ParentPositionOffsetY, endianess);
			output.WriteValueF32(ParentPositionOffsetZ, endianess);
			output.WriteValueF32(ParentRotationOffsetX, endianess);
			output.WriteValueF32(ParentRotationOffsetY, endianess);
			output.WriteValueF32(ParentRotationOffsetZ, endianess);
			output.WriteValueU64(ChildJointHash, endianess);
			output.WriteValueB32(OverrideChildTranslationJoint, endianess);
			output.WriteValueU64(ChildTranslationJointHash, endianess);
			output.WriteValueF32(ChildPositionOffsetX, endianess);
			output.WriteValueF32(ChildPositionOffsetY, endianess);
			output.WriteValueF32(ChildPositionOffsetZ, endianess);
			output.WriteValueF32(ChildRotationOffsetX, endianess);
			output.WriteValueF32(ChildRotationOffsetY, endianess);
			output.WriteValueF32(ChildRotationOffsetZ, endianess);
			output.WriteValueB32(ConsiderChildAlternateRotation, endianess);
			output.WriteValueF32(ChildAlternateRotationOffsetX, endianess);
			output.WriteValueF32(ChildAlternateRotationOffsetY, endianess);
			output.WriteValueF32(ChildAlternateRotationOffsetZ, endianess);
			output.WriteValueF32(BlendTime, endianess);
			BaseProperty.SerializePropertyEnum(output, endianess, PhysicsMode);
		}

		public override void Deserialize(Stream input, Endian endianess)
		{
			base.Deserialize(input, endianess);
			BeginTime = input.ReadValueF32(endianess);
			GrabSlotHash = input.ReadValueU64(endianess);
			ParentJointHash = input.ReadValueU64(endianess);
			OverrideParentTranslationJoint = input.ReadValueB32(endianess);
			ParentTranslationJoint = input.ReadValueU64(endianess);
			ParentPositionOffsetX = input.ReadValueF32(endianess);
			ParentPositionOffsetY = input.ReadValueF32(endianess);
			ParentPositionOffsetZ = input.ReadValueF32(endianess);
			ParentRotationOffsetX = input.ReadValueF32(endianess);
			ParentRotationOffsetY = input.ReadValueF32(endianess);
			ParentRotationOffsetZ = input.ReadValueF32(endianess);
			ChildJointHash = input.ReadValueU64(endianess);
			OverrideChildTranslationJoint = input.ReadValueB32(endianess);
			ChildTranslationJointHash = input.ReadValueU64(endianess);
			ChildPositionOffsetX = input.ReadValueF32(endianess);
			ChildPositionOffsetY = input.ReadValueF32(endianess);
			ChildPositionOffsetZ = input.ReadValueF32(endianess);
			ChildRotationOffsetX = input.ReadValueF32(endianess);
			ChildRotationOffsetY = input.ReadValueF32(endianess);
			ChildRotationOffsetZ = input.ReadValueF32(endianess);
			ConsiderChildAlternateRotation = input.ReadValueB32(endianess);
			ChildAlternateRotationOffsetX = input.ReadValueF32(endianess);
			ChildAlternateRotationOffsetY = input.ReadValueF32(endianess);
			ChildAlternateRotationOffsetZ = input.ReadValueF32(endianess);
			BlendTime = input.ReadValueF32(endianess);
			PhysicsMode = BaseProperty.DeserializePropertyEnum<PhysicsMode>(input, endianess);
		}
	}
}
