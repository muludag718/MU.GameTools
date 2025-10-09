using System.IO;
using MU.GameTools.IO;

namespace MU.GameTools.Prototype.Fight.Prototype1.Track
{
	[KnownNodeForContext(ContextHash.Motion)]
	[KnownTrack(TrackHash.Hit)]
	public class CollisionHitTrack : P1Track
	{
		public enum TravelMode : ulong
		{
			None = 22018610510307286uL,
			Sphere = 2636713307244341551uL,
			ExtendingCapsule = 10827414619816049493uL
		}

		public float BeginTime { get; set; }

		public float EndTime { get; set; }

		public bool UseShapecast { get; set; }

		public int CollisionCountMax { get; set; }

		public float TimeBetweenHits { get; set; }

		public ulong jointName { get; set; }

		public ulong jointEnd { get; set; }

		public float OffsetX { get; set; }

		public float OffsetY { get; set; }

		public float OffsetZ { get; set; }

		public float Radius { get; set; }

		public float ArcOffset { get; set; }

		public float ArcRange { get; set; }

		public Collidables CollideWith { get; set; }

		public float DamageMin { get; set; }

		public float DamageMax { get; set; }

		public bool UseTransformationDamageMultiplier { get; set; }

		public bool UseWeaponDamageMultiplier { get; set; }

		public float FriendlyFire { get; set; }

		public AttackType AttackType { get; set; }

		public ulong HitTypeName { get; set; }

		public DamageType DamageType { get; set; }

		public ulong EffectTypeName { get; set; }

		public float ScaleX { get; set; }

		public float ScaleY { get; set; }

		public float EffectScale { get; set; }

		public float PropAreaEmissionScale { get; set; }

		public ScaleFunction PropAreaEmissionScaleFunction { get; set; }

		public float PropAreaSizeScale { get; set; }

		public ScaleFunction propAreaSizeScaleFunction { get; set; }

		public float ImpulseMinX { get; set; }

		public float ImpulseMinY { get; set; }

		public float ImpulseMinZ { get; set; }

		public float ImpulseMaxX { get; set; }

		public float ImpulseMaxY { get; set; }

		public float ImpulseMaxZ { get; set; }

		public float ImpulseRandomPlusMinus { get; set; }

		public bool UseMotion { get; set; }

		public float CollisionDirectionX { get; set; }

		public float CollisionDirectionY { get; set; }

		public float CollisionDirectionZ { get; set; }

		public float DeformDirStr { get; set; }

		public float DeformStr { get; set; }

		public ulong CollisionFlagName { get; set; }

		public BranchReference GiverBranchRef { get; set; } = new BranchReference();

		public BranchReference ReceiverBranchRef { get; set; } = new BranchReference();

		public bool UseDamageOriginator { get; set; }

		public bool SendAlert { get; set; }

		public bool SendOnlyToAIManager { get; set; }

		public bool UseOriginatorToValidate { get; set; }

		public bool IsThrown { get; set; }

		public float MomentumDamageVelocity { get; set; }

		public float MomentumDamageMax { get; set; }

		public float TravelVelocity { get; set; }

		public TravelMode TravelTowardsTarget { get; set; }

		public bool IgnorePowerTarget { get; set; }

		public override void Serialize(Stream output, Endian endianess)
		{
			base.Serialize(output, endianess);
			output.WriteValueF32(BeginTime, endianess);
			output.WriteValueF32(EndTime, endianess);
			output.WriteValueB32(UseShapecast, endianess);
			output.WriteValueS32(CollisionCountMax, endianess);
			output.WriteValueF32(TimeBetweenHits, endianess);
			output.WriteValueU64(jointName, endianess);
			output.WriteValueU64(jointEnd, endianess);
			output.WriteValueF32(OffsetX, endianess);
			output.WriteValueF32(OffsetY, endianess);
			output.WriteValueF32(OffsetZ, endianess);
			output.WriteValueF32(Radius, endianess);
			output.WriteValueF32(ArcOffset, endianess);
			output.WriteValueF32(ArcRange, endianess);
			BaseProperty.SerializePropertyBitfield(output, endianess, CollideWith);
			output.WriteValueF32(DamageMin, endianess);
			output.WriteValueF32(DamageMax, endianess);
			output.WriteValueB32(UseTransformationDamageMultiplier, endianess);
			output.WriteValueB32(UseWeaponDamageMultiplier, endianess);
			output.WriteValueF32(FriendlyFire, endianess);
			BaseProperty.SerializePropertyEnum(output, endianess, AttackType);
			output.WriteValueU64(HitTypeName, endianess);
			BaseProperty.SerializePropertyEnum(output, endianess, DamageType);
			output.WriteValueU64(EffectTypeName, endianess);
			output.WriteValueF32(ScaleX, endianess);
			output.WriteValueF32(ScaleY, endianess);
			output.WriteValueF32(EffectScale, endianess);
			output.WriteValueF32(PropAreaEmissionScale, endianess);
			BaseProperty.SerializePropertyEnum(output, endianess, PropAreaEmissionScaleFunction);
			output.WriteValueF32(PropAreaSizeScale, endianess);
			BaseProperty.SerializePropertyEnum(output, endianess, propAreaSizeScaleFunction);
			output.WriteValueF32(ImpulseMinX, endianess);
			output.WriteValueF32(ImpulseMinY, endianess);
			output.WriteValueF32(ImpulseMinZ, endianess);
			output.WriteValueF32(ImpulseMaxX, endianess);
			output.WriteValueF32(ImpulseMaxY, endianess);
			output.WriteValueF32(ImpulseMaxZ, endianess);
			output.WriteValueF32(ImpulseRandomPlusMinus, endianess);
			output.WriteValueB32(UseMotion, endianess);
			output.WriteValueF32(CollisionDirectionX, endianess);
			output.WriteValueF32(CollisionDirectionY, endianess);
			output.WriteValueF32(CollisionDirectionZ, endianess);
			output.WriteValueF32(DeformDirStr, endianess);
			output.WriteValueF32(DeformStr, endianess);
			output.WriteValueU64(CollisionFlagName, endianess);
			GiverBranchRef.Serialize(output, endianess);
			ReceiverBranchRef.Serialize(output, endianess);
			output.WriteValueB32(UseDamageOriginator, endianess);
			output.WriteValueB32(SendAlert, endianess);
			output.WriteValueB32(SendOnlyToAIManager, endianess);
			output.WriteValueB32(UseOriginatorToValidate, endianess);
			output.WriteValueB32(IsThrown, endianess);
			output.WriteValueF32(MomentumDamageVelocity, endianess);
			output.WriteValueF32(MomentumDamageMax, endianess);
			output.WriteValueF32(TravelVelocity, endianess);
			BaseProperty.SerializePropertyEnum(output, endianess, TravelTowardsTarget);
			output.WriteValueB32(IgnorePowerTarget, endianess);
		}

		public override void Deserialize(Stream input, Endian endianess)
		{
			base.Deserialize(input, endianess);
			BeginTime = input.ReadValueF32(endianess);
			EndTime = input.ReadValueF32(endianess);
			UseShapecast = input.ReadValueB32(endianess);
			CollisionCountMax = input.ReadValueS32(endianess);
			TimeBetweenHits = input.ReadValueF32(endianess);
			jointName = input.ReadValueU64(endianess);
			jointEnd = input.ReadValueU64(endianess);
			OffsetX = input.ReadValueF32(endianess);
			OffsetY = input.ReadValueF32(endianess);
			OffsetZ = input.ReadValueF32(endianess);
			Radius = input.ReadValueF32(endianess);
			ArcOffset = input.ReadValueF32(endianess);
			ArcRange = input.ReadValueF32(endianess);
			CollideWith = BaseProperty.DeserializePropertyBitfield<Collidables>(input, endianess);
			DamageMin = input.ReadValueF32(endianess);
			DamageMax = input.ReadValueF32(endianess);
			UseTransformationDamageMultiplier = input.ReadValueB32(endianess);
			UseWeaponDamageMultiplier = input.ReadValueB32(endianess);
			FriendlyFire = input.ReadValueF32(endianess);
			AttackType = BaseProperty.DeserializePropertyEnum<AttackType>(input, endianess);
			HitTypeName = input.ReadValueU64(endianess);
			DamageType = BaseProperty.DeserializePropertyEnum<DamageType>(input, endianess);
			EffectTypeName = input.ReadValueU64(endianess);
			ScaleX = input.ReadValueF32(endianess);
			ScaleY = input.ReadValueF32(endianess);
			EffectScale = input.ReadValueF32(endianess);
			PropAreaEmissionScale = input.ReadValueF32(endianess);
			PropAreaEmissionScaleFunction = BaseProperty.DeserializePropertyEnum<ScaleFunction>(input, endianess);
			PropAreaSizeScale = input.ReadValueF32(endianess);
			propAreaSizeScaleFunction = BaseProperty.DeserializePropertyEnum<ScaleFunction>(input, endianess);
			ImpulseMinX = input.ReadValueF32(endianess);
			ImpulseMinY = input.ReadValueF32(endianess);
			ImpulseMinZ = input.ReadValueF32(endianess);
			ImpulseMaxX = input.ReadValueF32(endianess);
			ImpulseMaxY = input.ReadValueF32(endianess);
			ImpulseMaxZ = input.ReadValueF32(endianess);
			ImpulseRandomPlusMinus = input.ReadValueF32(endianess);
			UseMotion = input.ReadValueB32(endianess);
			CollisionDirectionX = input.ReadValueF32(endianess);
			CollisionDirectionY = input.ReadValueF32(endianess);
			CollisionDirectionZ = input.ReadValueF32(endianess);
			DeformDirStr = input.ReadValueF32(endianess);
			DeformStr = input.ReadValueF32(endianess);
			CollisionFlagName = input.ReadValueU64(endianess);
			GiverBranchRef = new BranchReference(input, endianess);
			ReceiverBranchRef = new BranchReference(input, endianess);
			UseDamageOriginator = input.ReadValueB32(endianess);
			SendAlert = input.ReadValueB32(endianess);
			SendOnlyToAIManager = input.ReadValueB32(endianess);
			UseOriginatorToValidate = input.ReadValueB32(endianess);
			IsThrown = input.ReadValueB32(endianess);
			MomentumDamageVelocity = input.ReadValueF32(endianess);
			MomentumDamageMax = input.ReadValueF32(endianess);
			TravelVelocity = input.ReadValueF32(endianess);
			TravelTowardsTarget = BaseProperty.DeserializePropertyEnum<TravelMode>(input, endianess);
			IgnorePowerTarget = input.ReadValueB32(endianess);
		}
	}
}
