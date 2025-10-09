using System.IO;
using MU.GameTools.IO;

namespace MU.GameTools.Prototype.Fight.Prototype1.Track
{
	[KnownNodeForContext(ContextHash.Motion)]
	[KnownTrack(TrackHash.GrabGrabTarget)]
	public class GrabGrabTargetTrack : P1Track
	{
		public float TimeBegin { get; set; }

		public float TimeEnd { get; set; }

		public ulong GrabSlot { get; set; }

		public ulong ParentJoint { get; set; }

		public Vector ParentPositionOffset { get; set; } = new Vector();

		public Vector ParentRotationOffset { get; set; } = new Vector();

		public ulong ChildJoint { get; set; }

		public Vector ChildPositionOffset { get; set; } = new Vector();

		public Vector ChildRotationOffset { get; set; } = new Vector();

		public float BlendTime { get; set; }

		public BranchReference GiverBranch { get; set; } = new BranchReference();

		public BranchReference ReceiverBranch { get; set; } = new BranchReference();

		public int InterruptPriority { get; set; }

		public override void Serialize(Stream output, Endian endianess)
		{
			base.Serialize(output, endianess);
			output.WriteValueF32(TimeBegin, endianess);
			output.WriteValueF32(TimeEnd, endianess);
			output.WriteValueU64(GrabSlot, endianess);
			output.WriteValueU64(ParentJoint, endianess);
			ParentPositionOffset.Serialize(output, endianess);
			ParentRotationOffset.Serialize(output, endianess);
			output.WriteValueU64(ChildJoint, endianess);
			ChildPositionOffset.Serialize(output, endianess);
			ChildRotationOffset.Serialize(output, endianess);
			output.WriteValueF32(BlendTime, endianess);
			GiverBranch.Serialize(output, endianess);
			ReceiverBranch.Serialize(output, endianess);
			output.WriteValueS32(InterruptPriority, endianess);
		}

		public override void Deserialize(Stream input, Endian endianess)
		{
			base.Deserialize(input, endianess);
			TimeBegin = input.ReadValueF32(endianess);
			TimeEnd = input.ReadValueF32(endianess);
			GrabSlot = input.ReadValueU64(endianess);
			ParentJoint = input.ReadValueU64(endianess);
			ParentPositionOffset = new Vector(input, endianess);
			ParentRotationOffset = new Vector(input, endianess);
			ChildJoint = input.ReadValueU64(endianess);
			ChildPositionOffset = new Vector(input, endianess);
			ChildRotationOffset = new Vector(input, endianess);
			BlendTime = input.ReadValueF32(endianess);
			GiverBranch = new BranchReference(input, endianess);
			ReceiverBranch = new BranchReference(input, endianess);
			InterruptPriority = input.ReadValueS32(endianess);
		}
	}
}
