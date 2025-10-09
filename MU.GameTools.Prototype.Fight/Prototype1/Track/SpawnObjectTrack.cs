using System.IO;
using MU.GameTools.IO;

namespace MU.GameTools.Prototype.Fight.Prototype1.Track
{
	[KnownNodeForContext(ContextHash.Motion)]
	[KnownTrack(TrackHash.SpawnObject)]
	public class SpawnObjectTrack : P1Track
	{
		public float TimeBegin { get; set; }

		public ulong TemplateName { get; set; }

		public ulong ObjectName { get; set; }

		public bool AddSuffix { get; set; }

		public string InitialState { get; set; }

		public ulong SpecificPlaybackset { get; set; }

		public SpaceType SpawnSpace { get; set; }

		public ulong SpawnJoint { get; set; }

		public Vector Offset { get; set; } = new Vector();

		public Vector Orientation { get; set; } = new Vector();

		public bool AttachToParent { get; set; }

		public bool DetachAfterSpawn { get; set; }

		public bool AICharacter { get; set; }

		public ulong AutomaticTag { get; set; }

		public ulong GrabSlot { get; set; }

		public bool CopyPose { get; set; }

		public bool InheritSpawnerVelocity { get; set; }

		public Vector LinearVelocity { get; set; } = new Vector();

		public Vector AngularVelocity { get; set; } = new Vector();

		public float CollideWithSpawnerDelay { get; set; }

		public bool SpawnSleeping { get; set; }

		public bool ManageLifetime { get; set; }

		public bool ManageLifetimeThrownProp { get; set; }

		public bool InheritSpawnerTarget { get; set; }

		public ChargeType InheritSpawnerCharge { get; set; }

		public bool UseParentScale { get; set; }

		public bool SetScale { get; set; }

		public Vector Scale { get; set; } = new Vector();

		public float Probability { get; set; }

		public bool UseSpawnerAsDamageOriginator { get; set; }

		public bool DamageOriginatorFromSpawner { get; set; }

		public bool TransferTargetLocks { get; set; }

		public bool SendMessageToScenarioTree { get; set; }

		public bool ApplyColourTint { get; set; }

		public bool InheritPackage { get; set; }

		public Color TintColour { get; set; } = new Color();

		public bool CacheDamageOrigionatorAsCollider { get; set; }

		public override void Serialize(Stream output, Endian endianess)
		{
			base.Serialize(output, endianess);
			output.WriteValueF32(TimeBegin, endianess);
			output.WriteValueU64(TemplateName, endianess);
			output.WriteValueU64(ObjectName, endianess);
			output.WriteValueB32(AddSuffix, endianess);
			output.WriteStringAlignedU32(InitialState, endianess);
			output.WriteValueU64(SpecificPlaybackset, endianess);
			BaseProperty.SerializePropertyEnum(output, endianess, SpawnSpace);
			output.WriteValueU64(SpawnJoint, endianess);
			Offset.Serialize(output, endianess);
			Orientation.Serialize(output, endianess);
			output.WriteValueB32(AttachToParent, endianess);
			output.WriteValueB32(DetachAfterSpawn, endianess);
			output.WriteValueB32(AICharacter, endianess);
			output.WriteValueU64(AutomaticTag, endianess);
			output.WriteValueU64(GrabSlot, endianess);
			output.WriteValueB32(CopyPose, endianess);
			output.WriteValueB32(InheritSpawnerVelocity, endianess);
			LinearVelocity.Serialize(output, endianess);
			AngularVelocity.Serialize(output, endianess);
			output.WriteValueF32(CollideWithSpawnerDelay, endianess);
			output.WriteValueB32(SpawnSleeping, endianess);
			output.WriteValueB32(ManageLifetime, endianess);
			output.WriteValueB32(ManageLifetimeThrownProp, endianess);
			output.WriteValueB32(InheritSpawnerTarget, endianess);
			BaseProperty.SerializePropertyEnum(output, endianess, InheritSpawnerCharge);
			output.WriteValueB32(UseParentScale, endianess);
			output.WriteValueB32(SetScale, endianess);
			Scale.Serialize(output, endianess);
			output.WriteValueF32(Probability, endianess);
			output.WriteValueB32(UseSpawnerAsDamageOriginator, endianess);
			output.WriteValueB32(DamageOriginatorFromSpawner, endianess);
			output.WriteValueB32(TransferTargetLocks, endianess);
			output.WriteValueB32(SendMessageToScenarioTree, endianess);
			output.WriteValueB32(ApplyColourTint, endianess);
			output.WriteValueB32(InheritPackage, endianess);
			TintColour.Serialize(output, endianess);
			output.WriteValueB32(CacheDamageOrigionatorAsCollider, endianess);
		}

		public override void Deserialize(Stream input, Endian endianess)
		{
			base.Deserialize(input, endianess);
			TimeBegin = input.ReadValueF32(endianess);
			TemplateName = input.ReadValueU64(endianess);
			ObjectName = input.ReadValueU64(endianess);
			AddSuffix = input.ReadValueB32(endianess);
			InitialState = input.ReadStringAlignedU32(endianess);
			SpecificPlaybackset = input.ReadValueU64(endianess);
			SpawnSpace = BaseProperty.DeserializePropertyEnum<SpaceType>(input, endianess);
			SpawnJoint = input.ReadValueU64(endianess);
			Offset = new Vector(input, endianess);
			Orientation = new Vector(input, endianess);
			AttachToParent = input.ReadValueB32(endianess);
			DetachAfterSpawn = input.ReadValueB32(endianess);
			AICharacter = input.ReadValueB32(endianess);
			AutomaticTag = input.ReadValueU64(endianess);
			GrabSlot = input.ReadValueU64(endianess);
			CopyPose = input.ReadValueB32(endianess);
			InheritSpawnerVelocity = input.ReadValueB32(endianess);
			LinearVelocity = new Vector(input, endianess);
			AngularVelocity = new Vector(input, endianess);
			CollideWithSpawnerDelay = input.ReadValueF32(endianess);
			SpawnSleeping = input.ReadValueB32(endianess);
			ManageLifetime = input.ReadValueB32(endianess);
			ManageLifetimeThrownProp = input.ReadValueB32(endianess);
			InheritSpawnerTarget = input.ReadValueB32(endianess);
			InheritSpawnerCharge = BaseProperty.DeserializePropertyEnum<ChargeType>(input, endianess);
			UseParentScale = input.ReadValueB32(endianess);
			SetScale = input.ReadValueB32(endianess);
			Scale = new Vector(input, endianess);
			Probability = input.ReadValueF32(endianess);
			UseSpawnerAsDamageOriginator = input.ReadValueB32(endianess);
			DamageOriginatorFromSpawner = input.ReadValueB32(endianess);
			TransferTargetLocks = input.ReadValueB32(endianess);
			SendMessageToScenarioTree = input.ReadValueB32(endianess);
			ApplyColourTint = input.ReadValueB32(endianess);
			InheritPackage = input.ReadValueB32(endianess);
			TintColour = new Color(input, endianess);
			CacheDamageOrigionatorAsCollider = input.ReadValueB32(endianess);
		}
	}
}
