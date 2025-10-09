using System.IO;
using MU.GameTools.IO;

namespace MU.GameTools.Prototype.Fight.Prototype1.Track
{
	[KnownNodeForContext(ContextHash.Motion)]
	[KnownTrack(TrackHash.Grab)]
	public class CollisionGrabTrack : P1Track
	{
		public float TimeBegin { get; set; }

		public float TimeEnd { get; set; }

		public ulong GrabSlot { get; set; }

		public ulong Joint { get; set; }

		public Vector Offset { get; set; } = new Vector();

		public float Radius { get; set; }

		public bool UseMotion { get; set; }

		public float ArcOffset { get; set; }

		public float ArcRange { get; set; }

		public Collidables CollideWith { get; set; }

		public bool CheckForObstruction { get; set; }

		public bool GrabOnlyPowerTarget { get; set; }

		public bool ConsiderPlatformAsTarget { get; set; }

		public bool ReverseAttachOnMountable { get; set; }

		public BranchReference GiverBranch { get; set; } = new BranchReference();

		public BranchReference ReceiverBranch { get; set; } = new BranchReference();

		public int InterruptPriority { get; set; }

		public bool DevastatorGrab { get; set; }

		public PhysicsMode PhysicsMode { get; set; }

		public override void Serialize(Stream output, Endian endianess)
		{
			base.Serialize(output, endianess);
			output.WriteValueF32(TimeBegin, endianess);
			output.WriteValueF32(TimeEnd, endianess);
			output.WriteValueU64(GrabSlot, endianess);
			output.WriteValueU64(Joint, endianess);
			Offset.Serialize(output, endianess);
			output.WriteValueF32(Radius, endianess);
			output.WriteValueB32(UseMotion, endianess);
			output.WriteValueF32(ArcOffset, endianess);
			output.WriteValueF32(ArcRange, endianess);
			BaseProperty.SerializePropertyBitfield(output, endianess, CollideWith);
			output.WriteValueB32(CheckForObstruction, endianess);
			output.WriteValueB32(GrabOnlyPowerTarget, endianess);
			output.WriteValueB32(ConsiderPlatformAsTarget, endianess);
			output.WriteValueB32(ReverseAttachOnMountable, endianess);
			GiverBranch.Serialize(output, endianess);
			ReceiverBranch.Serialize(output, endianess);
			output.WriteValueS32(InterruptPriority, endianess);
			output.WriteValueB32(DevastatorGrab, endianess);
			BaseProperty.SerializePropertyEnum(output, endianess, PhysicsMode);
		}

		public override void Deserialize(Stream input, Endian endianess)
		{
			base.Deserialize(input, endianess);
			TimeBegin = input.ReadValueF32(endianess);
			TimeEnd = input.ReadValueF32(endianess);
			GrabSlot = input.ReadValueU64(endianess);
			Joint = input.ReadValueU64(endianess);
			Offset = new Vector(input, endianess);
			Radius = input.ReadValueF32(endianess);
			UseMotion = input.ReadValueB32(endianess);
			ArcOffset = input.ReadValueF32(endianess);
			ArcRange = input.ReadValueF32(endianess);
			CollideWith = BaseProperty.DeserializePropertyBitfield<Collidables>(input, endianess);
			CheckForObstruction = input.ReadValueB32(endianess);
			GrabOnlyPowerTarget = input.ReadValueB32(endianess);
			ConsiderPlatformAsTarget = input.ReadValueB32(endianess);
			ReverseAttachOnMountable = input.ReadValueB32(endianess);
			GiverBranch = new BranchReference(input, endianess);
			ReceiverBranch = new BranchReference(input, endianess);
			InterruptPriority = input.ReadValueS32(endianess);
			DevastatorGrab = input.ReadValueB32(endianess);
			PhysicsMode = BaseProperty.DeserializePropertyEnum<PhysicsMode>(input, endianess);
		}
	}
}
