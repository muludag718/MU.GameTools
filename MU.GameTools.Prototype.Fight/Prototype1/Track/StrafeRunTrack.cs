using System.IO;
using MU.GameTools.IO;

namespace MU.GameTools.Prototype.Fight.Prototype1.Track
{
	[KnownTrack(TrackHash.StrafeRun)]
	public class StrafeRunTrack : P1Track
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

		public float MinHeightAtTarget { get; set; }

		public float MaxHeightAtEnds { get; set; }

		public float MinHeightAtEnds { get; set; }

		public float SafeHeightAtEnds { get; set; }

		public float MaxHeightDiffTargetAndEnds { get; set; }

		public float MaxPathHeightFromTarget { get; set; }

		public float MaxPathYaw { get; set; }

		public float MaxPathPitch { get; set; }

		public float FreeRadiusPath { get; set; }

		public int TurningFactorA { get; set; }

		public int TurningFactorB { get; set; }

		public HeuristicType Heuristic { get; set; }

		public bool SameHeightPath { get; set; }

		public bool OrientAtEnd { get; set; }

		public bool GoBack { get; set; }

		public bool Brake { get; set; }

		public float MinSpeed { get; set; }

		public float MaxSpeed { get; set; }

		public Vector SpeedFactor { get; set; } = new Vector();

		public Vector PassMidPointSpeedFactor { get; set; } = new Vector();

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
			output.WriteValueF32(MinHeightAtTarget, endianess);
			output.WriteValueF32(MaxHeightAtEnds, endianess);
			output.WriteValueF32(MinHeightAtEnds, endianess);
			output.WriteValueF32(SafeHeightAtEnds, endianess);
			output.WriteValueF32(MaxHeightDiffTargetAndEnds, endianess);
			output.WriteValueF32(MaxPathHeightFromTarget, endianess);
			output.WriteValueF32(MaxPathYaw, endianess);
			output.WriteValueF32(MaxPathPitch, endianess);
			output.WriteValueF32(FreeRadiusPath, endianess);
			output.WriteValueS32(TurningFactorA, endianess);
			output.WriteValueS32(TurningFactorB, endianess);
			BaseProperty.SerializePropertyEnum(output, endianess, Heuristic);
			output.WriteValueB32(SameHeightPath, endianess);
			output.WriteValueB32(OrientAtEnd, endianess);
			output.WriteValueB32(GoBack, endianess);
			output.WriteValueB32(Brake, endianess);
			output.WriteValueF32(MinSpeed, endianess);
			output.WriteValueF32(MaxSpeed, endianess);
			SpeedFactor.Serialize(output, endianess);
			PassMidPointSpeedFactor.Serialize(output, endianess);
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
			MinHeightAtTarget = input.ReadValueF32(endianess);
			MaxHeightAtEnds = input.ReadValueF32(endianess);
			MinHeightAtEnds = input.ReadValueF32(endianess);
			SafeHeightAtEnds = input.ReadValueF32(endianess);
			MaxHeightDiffTargetAndEnds = input.ReadValueF32(endianess);
			MaxPathHeightFromTarget = input.ReadValueF32(endianess);
			MaxPathYaw = input.ReadValueF32(endianess);
			MaxPathPitch = input.ReadValueF32(endianess);
			FreeRadiusPath = input.ReadValueF32(endianess);
			TurningFactorA = input.ReadValueS32(endianess);
			TurningFactorB = input.ReadValueS32(endianess);
			Heuristic = BaseProperty.DeserializePropertyEnum<HeuristicType>(input, endianess);
			SameHeightPath = input.ReadValueB32(endianess);
			OrientAtEnd = input.ReadValueB32(endianess);
			GoBack = input.ReadValueB32(endianess);
			Brake = input.ReadValueB32(endianess);
			MinSpeed = input.ReadValueF32(endianess);
			MaxSpeed = input.ReadValueF32(endianess);
			SpeedFactor.Deserialize(input, endianess);
			PassMidPointSpeedFactor.Deserialize(input, endianess);
		}
	}
}
