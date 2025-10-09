using System.IO;
using MU.GameTools.IO;

namespace MU.GameTools.Prototype.Fight.Prototype1.Track
{
	[KnownNodeForContext(ContextHash.Motion)]
	[KnownTrack(TrackHash.EnableRagdoll)]
	public class EnableRagdollTrack : P1Track
	{
		public float TimeBegin { get; set; }

		public bool DisableSupportingLimb { get; set; }

		public bool InheritJointVelocities { get; set; }

		public bool UseNormalPhysicsObjectAsRagdoll { get; set; }

		public float PhysicsTransitionDuration { get; set; }

		public ulong RootJoint { get; set; }

		public bool IncludeRootJoint { get; set; }

		public override void Serialize(Stream output, Endian endianess)
		{
			base.Serialize(output, endianess);
			output.WriteValueF32(TimeBegin, endianess);
			output.WriteValueB32(DisableSupportingLimb, endianess);
			output.WriteValueB32(InheritJointVelocities, endianess);
			output.WriteValueB32(UseNormalPhysicsObjectAsRagdoll, endianess);
			output.WriteValueF32(PhysicsTransitionDuration, endianess);
			output.WriteValueU64(RootJoint, endianess);
			output.WriteValueB32(IncludeRootJoint, endianess);
		}

		public override void Deserialize(Stream input, Endian endianess)
		{
			base.Deserialize(input, endianess);
			TimeBegin = input.ReadValueF32(endianess);
			DisableSupportingLimb = input.ReadValueB32(endianess);
			InheritJointVelocities = input.ReadValueB32(endianess);
			UseNormalPhysicsObjectAsRagdoll = input.ReadValueB32(endianess);
			PhysicsTransitionDuration = input.ReadValueF32(endianess);
			RootJoint = input.ReadValueU64(endianess);
			IncludeRootJoint = input.ReadValueB32(endianess);
		}
	}
}
