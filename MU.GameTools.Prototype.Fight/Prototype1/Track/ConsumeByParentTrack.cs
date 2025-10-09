using System.IO;
using MU.GameTools.IO;

namespace MU.GameTools.Prototype.Fight.Prototype1.Track
{
	[KnownNodeForContext(ContextHash.Motion)]
	[KnownTrack(TrackHash.ConsumeByParent)]
	public class ConsumeByParentTrack : P1Track
	{
		public float TimeBegin { get; set; }

		public float TimeEnd { get; set; }

		public ulong RagdollIfNeeded { get; set; }

		public bool SwitchToRagdollMode { get; set; }

		public ulong ParentObjectName { get; set; }

		public ulong ParentDestinationJoint { get; set; }

		public Vector ParentPositionOffset { get; set; } = new Vector();

		public bool ConsumeUpwards { get; set; }

		public float BoneSweepConstant { get; set; }

		public bool TransformationConsume { get; set; }

		public float TransformationConsumeTime { get; set; }

		public bool Stealthy { get; set; }

		public ulong ConsumableProperties { get; set; }

		public override void Serialize(Stream output, Endian endianess)
		{
			base.Serialize(output, endianess);
			output.WriteValueF32(TimeBegin, endianess);
			output.WriteValueF32(TimeEnd, endianess);
			output.WriteValueU64(RagdollIfNeeded, endianess);
			output.WriteValueB32(SwitchToRagdollMode, endianess);
			output.WriteValueU64(ParentObjectName, endianess);
			output.WriteValueU64(ParentDestinationJoint, endianess);
			ParentPositionOffset.Serialize(output, endianess);
			output.WriteValueB32(ConsumeUpwards, endianess);
			output.WriteValueF32(BoneSweepConstant, endianess);
			output.WriteValueB32(TransformationConsume, endianess);
			output.WriteValueF32(TransformationConsumeTime, endianess);
			output.WriteValueB32(Stealthy, endianess);
			output.WriteValueU64(ConsumableProperties, endianess);
		}

		public override void Deserialize(Stream input, Endian endianess)
		{
			base.Deserialize(input, endianess);
			TimeBegin = input.ReadValueF32(endianess);
			TimeEnd = input.ReadValueF32(endianess);
			RagdollIfNeeded = input.ReadValueU64(endianess);
			SwitchToRagdollMode = input.ReadValueB32(endianess);
			ParentObjectName = input.ReadValueU64(endianess);
			ParentDestinationJoint = input.ReadValueU64(endianess);
			ParentPositionOffset = new Vector(input, endianess);
			ConsumeUpwards = input.ReadValueB32(endianess);
			BoneSweepConstant = input.ReadValueF32(endianess);
			TransformationConsume = input.ReadValueB32(endianess);
			TransformationConsumeTime = input.ReadValueF32(endianess);
			Stealthy = input.ReadValueB32(endianess);
			ConsumableProperties = input.ReadValueU64(endianess);
		}
	}
}
