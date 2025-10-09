using System.IO;
using MU.GameTools.IO;
using MU.GameTools.Common;
using MU.GameTools.Prototype.Fight.Property;

namespace MU.GameTools.Prototype.Fight.Prototype1.Track
{
	[KnownTrack(TrackHash.TryStrafeRun)]
	public class TryStrafeRunTrack : P1Track
	{
		public enum HeuristicType : ulong
		{
			OnlyValid = 17132745256354547704uL,
			Lowest = 15981311668301248366uL
		}

		public float TimeBegin { get; set; }

		public float TimeEnd { get; set; }

		public float MinDistance { get; set; }

		public float MaxDistance { get; set; }

		public float MinAngle { get; set; }

		public float FreeRadiusEnd { get; set; }

		public float FreeRadiusTarget { get; set; }

		public int NumTries { get; set; }

		public float MinHeightAtTarget { get; set; }

		public float MaxHeightAtEnds { get; set; }

		public float MinHeightAtEnds { get; set; }

		public float SafeHeightAtEnds { get; set; }

		public float MaxHeightDiffTargetAndEnds { get; set; }

		public float MaxHeightDiffTargetAndWaypoint { get; set; }

		public float MaxPathHeightFromTarget { get; set; }

		public float MaxPathYaw { get; set; }

		public float MaxPathPitch { get; set; }

		public float FreeRadiusPath { get; set; }

		public int TurningFactorA { get; set; }

		public int TurningFactorB { get; set; }

		public HeuristicType Heuristic { get; set; }

		public bool SameHeightPath { get; set; }

		public bool Brake { get; set; }

		public float TimeBetweenTries { get; set; }

		public BranchReference IfFound { get; set; } = new BranchReference();

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
			output.WriteValueF32(FreeRadiusEnd, endianess);
			output.WriteValueF32(FreeRadiusTarget, endianess);
			output.WriteValueS32(NumTries, endianess);
			output.WriteValueF32(MinHeightAtTarget, endianess);
			output.WriteValueF32(MaxHeightAtEnds, endianess);
			output.WriteValueF32(MinHeightAtEnds, endianess);
			output.WriteValueF32(SafeHeightAtEnds, endianess);
			output.WriteValueF32(MaxHeightDiffTargetAndEnds, endianess);
			output.WriteValueF32(MaxHeightDiffTargetAndWaypoint, endianess);
			output.WriteValueF32(MaxPathHeightFromTarget, endianess);
			output.WriteValueF32(MaxPathYaw, endianess);
			output.WriteValueF32(MaxPathPitch, endianess);
			output.WriteValueF32(FreeRadiusPath, endianess);
			output.WriteValueS32(TurningFactorA, endianess);
			output.WriteValueS32(TurningFactorB, endianess);
			BaseProperty.SerializePropertyEnum(output, endianess, Heuristic);
			output.WriteValueB32(SameHeightPath, endianess);
			output.WriteValueB32(Brake, endianess);
			output.WriteValueF32(TimeBetweenTries, endianess);
			IfFound.Serialize(output, endianess);
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
			FreeRadiusEnd = input.ReadValueF32(endianess);
			FreeRadiusTarget = input.ReadValueF32(endianess);
			NumTries = input.ReadValueS32(endianess);
			MinHeightAtTarget = input.ReadValueF32(endianess);
			MaxHeightAtEnds = input.ReadValueF32(endianess);
			MinHeightAtEnds = input.ReadValueF32(endianess);
			SafeHeightAtEnds = input.ReadValueF32(endianess);
			MaxHeightDiffTargetAndEnds = input.ReadValueF32(endianess);
			MaxHeightDiffTargetAndWaypoint = input.ReadValueF32(endianess);
			MaxPathHeightFromTarget = input.ReadValueF32(endianess);
			MaxPathYaw = input.ReadValueF32(endianess);
			MaxPathPitch = input.ReadValueF32(endianess);
			FreeRadiusPath = input.ReadValueF32(endianess);
			TurningFactorA = input.ReadValueS32(endianess);
			TurningFactorB = input.ReadValueS32(endianess);
			Heuristic = BaseProperty.DeserializePropertyEnum<HeuristicType>(input, endianess);
			SameHeightPath = input.ReadValueB32(endianess);
			Brake = input.ReadValueB32(endianess);
			TimeBetweenTries = input.ReadValueF32(endianess);
			IfFound.Deserialize(input, endianess);
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
