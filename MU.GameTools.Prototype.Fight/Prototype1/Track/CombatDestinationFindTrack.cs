using System.IO;
using MU.GameTools.IO;
using MU.GameTools.Common;
using MU.GameTools.Prototype.Fight.Property;

namespace MU.GameTools.Prototype.Fight.Prototype1.Track
{
	[KnownNodeForContext(ContextHash.AI)]
	[KnownTrack(TrackHash.CombatDestinationFind)]
	public class CombatDestinationFindTrack : P1Track
	{
		public enum HeightDiferenceType : ulong
		{
			Absolute = 11751081574227249751uL,
			GreaterThan = 6405607611880470083uL,
			LessThan = 18107689237601833186uL
		}

		public enum CameraVisibilityType : ulong
		{
			None = 31052086116886518uL,
			Outside = 15663523954389067717uL,
			Inside = 9915946547602718564uL
		}

		public enum ReferencePositionType : ulong
		{
			Target = 12772528083933579047uL,
			Me = 7150262uL,
			FixedArea = 15026010715474639685uL,
			Anchor = 11548714336321995175uL
		}

		public float TimeBegin { get; set; }

		public float TimeEnd { get; set; }

		public float MinDistance { get; set; }

		public float MaxDistance { get; set; }

		public float MinAngle { get; set; }

		public float MaxAngle { get; set; }

		public int NumTries { get; set; }

		public bool IgnoreRestrictions { get; set; }

		public bool CheckNotReserved { get; set; }

		public bool CheckCanGo { get; set; }

		public bool UseNavMeshHeight { get; set; }

		public HeightDiferenceType HeightDifferenceCheck { get; set; }

		public float MaxHeightDifference { get; set; }

		public float MinHeightDifference { get; set; }

		public float LookJustCloser { get; set; }

		public float MinDistanceFromCurrent { get; set; }

		public float FreeRadiusAround { get; set; }

		public AllowedAreasFlags AllowedAreas { get; set; }

		public bool IgnoreAreasWhenAgentOutside { get; set; }

		public float MaxDistanceToGround { get; set; }

		public float MaxAbsoluteHeight { get; set; }

		public Vector ReferenceOffset { get; set; } = new Vector();

		public bool AirDestination { get; set; }

		public Vector Offset { get; set; } = new Vector();

		public CameraVisibilityType CameraVisibility { get; set; }

		public CollisionFlagsType CollisionFlagsLOF { get; set; }

		public ColliderType CollideWithTypeLOF { get; set; }

		public Vector OffsetLOF { get; set; } = new Vector();

		public HeuristicType Heuristic { get; set; }

		public int InitialHeuristic { get; set; }

		public ulong InitialHeuristicTimer { get; set; }

		public float InitialHeuristicMinTimer { get; set; }

		public float InitialHeuristicMinTimerFactor { get; set; }

		public float InitialHeuristicMaxTimer { get; set; }

		public float InitialHeuristicMaxTimerFactor { get; set; }

		public ReferencePositionType ReferencePosition { get; set; }

		public float DeadReckoningTime { get; set; }

		public BranchReference WhenFound { get; set; } = new BranchReference();

		public int Priority { get; set; }

		public PropertyConditionGroup Conditions { get; set; } = new PropertyConditionGroup(PropertyHash.Conditions);

		public override void Serialize(Stream output, Endian endianess)
		{
			base.Serialize(output, endianess);
			output.WriteValueF32(TimeBegin, endianess);
			output.WriteValueF32(TimeEnd, endianess);
			output.WriteValueF32(MinDistance, endianess);
			output.WriteValueF32(MaxDistance, endianess);
			output.WriteValueF32(MinAngle, endianess);
			output.WriteValueF32(MaxAngle, endianess);
			output.WriteValueS32(NumTries, endianess);
			output.WriteValueB32(IgnoreRestrictions, endianess);
			output.WriteValueB32(CheckNotReserved, endianess);
			output.WriteValueB32(CheckCanGo, endianess);
			output.WriteValueB32(UseNavMeshHeight, endianess);
			BaseProperty.SerializePropertyEnum(output, endianess, HeightDifferenceCheck);
			output.WriteValueF32(MaxHeightDifference, endianess);
			output.WriteValueF32(MinHeightDifference, endianess);
			output.WriteValueF32(LookJustCloser, endianess);
			output.WriteValueF32(MinDistanceFromCurrent, endianess);
			output.WriteValueF32(FreeRadiusAround, endianess);
			BaseProperty.SerializePropertyBitfield(output, endianess, AllowedAreas);
			output.WriteValueB32(IgnoreAreasWhenAgentOutside, endianess);
			output.WriteValueF32(MaxDistanceToGround, endianess);
			output.WriteValueF32(MaxAbsoluteHeight, endianess);
			ReferenceOffset.Serialize(output, endianess);
			output.WriteValueB32(AirDestination, endianess);
			Offset.Serialize(output, endianess);
			BaseProperty.SerializePropertyEnum(output, endianess, CameraVisibility);
			BaseProperty.SerializePropertyEnum(output, endianess, CollisionFlagsLOF);
			BaseProperty.SerializePropertyBitfield(output, endianess, CollideWithTypeLOF);
			OffsetLOF.Serialize(output, endianess);
			BaseProperty.SerializePropertyEnum(output, endianess, Heuristic);
			output.WriteValueS32(InitialHeuristic, endianess);
			output.WriteValueU64(InitialHeuristicTimer, endianess);
			output.WriteValueF32(InitialHeuristicMinTimer, endianess);
			output.WriteValueF32(InitialHeuristicMinTimerFactor, endianess);
			output.WriteValueF32(InitialHeuristicMaxTimer, endianess);
			output.WriteValueF32(InitialHeuristicMaxTimerFactor, endianess);
			BaseProperty.SerializePropertyEnum(output, endianess, ReferencePosition);
			output.WriteValueF32(DeadReckoningTime, endianess);
			WhenFound.Serialize(output, endianess);
			output.WriteValueS32(Priority, endianess);
		}

		public override void Deserialize(Stream input, Endian endianess)
		{
			base.Deserialize(input, endianess);
			TimeBegin = input.ReadValueF32(endianess);
			TimeEnd = input.ReadValueF32(endianess);
			MinDistance = input.ReadValueF32(endianess);
			MaxDistance = input.ReadValueF32(endianess);
			MinAngle = input.ReadValueF32(endianess);
			MaxAngle = input.ReadValueF32(endianess);
			NumTries = input.ReadValueS32(endianess);
			IgnoreRestrictions = input.ReadValueB32(endianess);
			CheckNotReserved = input.ReadValueB32(endianess);
			CheckCanGo = input.ReadValueB32(endianess);
			UseNavMeshHeight = input.ReadValueB32(endianess);
			HeightDifferenceCheck = BaseProperty.DeserializePropertyEnum<HeightDiferenceType>(input, endianess);
			MaxHeightDifference = input.ReadValueF32(endianess);
			MinHeightDifference = input.ReadValueF32(endianess);
			LookJustCloser = input.ReadValueF32(endianess);
			MinDistanceFromCurrent = input.ReadValueF32(endianess);
			FreeRadiusAround = input.ReadValueF32(endianess);
			AllowedAreas = BaseProperty.DeserializePropertyBitfield<AllowedAreasFlags>(input, endianess);
			IgnoreAreasWhenAgentOutside = input.ReadValueB32(endianess);
			MaxDistanceToGround = input.ReadValueF32(endianess);
			MaxAbsoluteHeight = input.ReadValueF32(endianess);
			ReferenceOffset = new Vector(input, endianess);
			AirDestination = input.ReadValueB32(endianess);
			Offset = new Vector(input, endianess);
			CameraVisibility = BaseProperty.DeserializePropertyEnum<CameraVisibilityType>(input, endianess);
			CollisionFlagsLOF = BaseProperty.DeserializePropertyEnum<CollisionFlagsType>(input, endianess);
			CollideWithTypeLOF = BaseProperty.DeserializePropertyBitfield<ColliderType>(input, endianess);
			OffsetLOF = new Vector(input, endianess);
			Heuristic = BaseProperty.DeserializePropertyEnum<HeuristicType>(input, endianess);
			InitialHeuristic = input.ReadValueS32(endianess);
			InitialHeuristicTimer = input.ReadValueU64(endianess);
			InitialHeuristicMinTimer = input.ReadValueF32(endianess);
			InitialHeuristicMinTimerFactor = input.ReadValueF32(endianess);
			InitialHeuristicMaxTimer = input.ReadValueF32(endianess);
			InitialHeuristicMaxTimerFactor = input.ReadValueF32(endianess);
			ReferencePosition = BaseProperty.DeserializePropertyEnum<ReferencePositionType>(input, endianess);
			DeadReckoningTime = input.ReadValueF32(endianess);
			WhenFound = new BranchReference(input, endianess);
			Priority = input.ReadValueS32(endianess);
		}

		public override void SerializeProperties(PrototypeGame game, Stream output, Endian endianess)
		{
			BaseProperty.SerializeBaseProperty(PrototypeGame.P1, output, endianess, Conditions);
		}

		public override void DeserializeProperties(PrototypeGame game, Stream input, Endian endianess)
		{
			Conditions = BaseProperty.DeserializeConditionProperty(PrototypeGame.P1, input, endianess, PropertyHash.Conditions);
		}
	}
}
