using System.IO;
using MU.GameTools.IO;

namespace MU.GameTools.Prototype.Fight.Prototype1.Track
{
	[KnownNodeForContext(ContextHash.Motion)]
	[KnownTrack(TrackHash.GrabbedUpdateAttachment)]
	public class GrabbedUpdateAttachmentTrack : P1Track
	{
		public float TimeBegin { get; set; }

		public ulong ParentJoint { get; set; }

		public Vector ParentPositionOffset { get; set; } = new Vector();

		public bool UpdateRotationOffset { get; set; }

		public Vector ParentRotationOffset { get; set; } = new Vector();

		public ulong ChildJoint { get; set; }

		public Vector ChildPositionOffset { get; set; } = new Vector();

		public Vector ChildRotationOffset { get; set; } = new Vector();

		public float BlendTime { get; set; }

		public PhysicsMode PhysicsMode { get; set; }

		public override void Serialize(Stream output, Endian endianess)
		{
			base.Serialize(output, endianess);
			output.WriteValueF32(TimeBegin, endianess);
			output.WriteValueU64(ParentJoint, endianess);
			ParentPositionOffset.Serialize(output, endianess);
			output.WriteValueB32(UpdateRotationOffset, endianess);
			ParentRotationOffset.Serialize(output, endianess);
			output.WriteValueU64(ChildJoint, endianess);
			ChildPositionOffset.Serialize(output, endianess);
			ChildRotationOffset.Serialize(output, endianess);
			output.WriteValueF32(BlendTime, endianess);
			BaseProperty.SerializePropertyEnum(output, endianess, PhysicsMode);
		}

		public override void Deserialize(Stream input, Endian endianess)
		{
			base.Deserialize(input, endianess);
			TimeBegin = input.ReadValueF32(endianess);
			ParentJoint = input.ReadValueU64(endianess);
			ParentPositionOffset = new Vector(input, endianess);
			UpdateRotationOffset = input.ReadValueB32(endianess);
			ParentRotationOffset = new Vector(input, endianess);
			ChildJoint = input.ReadValueU64(endianess);
			ChildPositionOffset = new Vector(input, endianess);
			ChildRotationOffset = new Vector(input, endianess);
			BlendTime = input.ReadValueF32(endianess);
			PhysicsMode = BaseProperty.DeserializePropertyEnum<PhysicsMode>(input, endianess);
		}
	}
}
