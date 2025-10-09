using System.IO;
using MU.GameTools.IO;

namespace MU.GameTools.Prototype.Fight.Prototype1.Track
{
	[KnownNodeForContext(ContextHash.Motion)]
	[KnownTrack(TrackHash.SpawnGib)]
	public class SpawnGibTrack : P1Track
	{
		public float TimeBegin { get; set; }

		public ulong GibName { get; set; }

		public bool AddSuffix { get; set; }

		public ulong TemplateName { get; set; }

		public bool CopyShader { get; set; }

		public ulong Joint { get; set; }

		public Vector Offset { get; set; } = new Vector();

		public Vector Rotation { get; set; } = new Vector();

		public bool AttachToParent { get; set; }

		public ulong GrabSlot { get; set; }

		public bool InheritPose { get; set; }

		public bool AttachToGrandParent { get; set; }

		public float ImpulseScale { get; set; }

		public bool TransferTargetLocks { get; set; }

		public bool CopyTranformationDescription { get; set; }

		public bool UseParentExclusionGroup { get; set; }

		public override void Serialize(Stream output, Endian endianess)
		{
			base.Serialize(output, endianess);
			output.WriteValueF32(TimeBegin, endianess);
			output.WriteValueU64(GibName, endianess);
			output.WriteValueB32(AddSuffix, endianess);
			output.WriteValueU64(TemplateName, endianess);
			output.WriteValueB32(CopyShader, endianess);
			output.WriteValueU64(Joint, endianess);
			Offset.Serialize(output, endianess);
			Rotation.Serialize(output, endianess);
			output.WriteValueB32(AttachToParent, endianess);
			output.WriteValueU64(GrabSlot, endianess);
			output.WriteValueB32(InheritPose, endianess);
			output.WriteValueB32(AttachToGrandParent, endianess);
			output.WriteValueF32(ImpulseScale, endianess);
			output.WriteValueB32(TransferTargetLocks, endianess);
			output.WriteValueB32(CopyTranformationDescription, endianess);
			output.WriteValueB32(UseParentExclusionGroup, endianess);
		}

		public override void Deserialize(Stream input, Endian endianess)
		{
			base.Deserialize(input, endianess);
			TimeBegin = input.ReadValueF32(endianess);
			GibName = input.ReadValueU64(endianess);
			AddSuffix = input.ReadValueB32(endianess);
			TemplateName = input.ReadValueU64(endianess);
			CopyShader = input.ReadValueB32(endianess);
			Joint = input.ReadValueU64(endianess);
			Offset = new Vector(input, endianess);
			Rotation = new Vector(input, endianess);
			AttachToParent = input.ReadValueB32(endianess);
			GrabSlot = input.ReadValueU64(endianess);
			InheritPose = input.ReadValueB32(endianess);
			AttachToGrandParent = input.ReadValueB32(endianess);
			ImpulseScale = input.ReadValueF32(endianess);
			TransferTargetLocks = input.ReadValueB32(endianess);
			CopyTranformationDescription = input.ReadValueB32(endianess);
			UseParentExclusionGroup = input.ReadValueB32(endianess);
		}
	}
}
