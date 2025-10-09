using System.IO;
using MU.GameTools.IO;

namespace MU.GameTools.Prototype.Fight.Prototype1.Track
{
	[KnownTrack(TrackHash.TightStrafeRun)]
	public class TightStrafeRunTrack : P1Track
	{
		public float TimeBegin { get; set; }

		public float TimeEnd { get; set; }

		public float Distance { get; set; }

		public float TurnRate { get; set; }

		public float MinSpeed { get; set; }

		public float MaxSpeed { get; set; }

		public float DistanceTolerance { get; set; }

		public float HeightTolerance { get; set; }

		public float ExtraHeightStart { get; set; }

		public float LengthPostStart { get; set; }

		public float FreeRadiusEnd { get; set; }

		public bool GoBack { get; set; }

		public bool UseTargetIntermediate { get; set; }

		public bool GoUpSoon { get; set; }

		public float HeightAtTarget { get; set; }

		public LookAtType TemporaryTarget { get; set; }

		public Vector SpeedFactor { get; set; } = new Vector();

		public override void Serialize(Stream output, Endian endianess)
		{
			base.Serialize(output, endianess);
			output.WriteValueF32(TimeBegin, endianess);
			output.WriteValueF32(TimeEnd, endianess);
			output.WriteValueF32(Distance, endianess);
			output.WriteValueF32(TurnRate, endianess);
			output.WriteValueF32(MinSpeed, endianess);
			output.WriteValueF32(MaxSpeed, endianess);
			output.WriteValueF32(DistanceTolerance, endianess);
			output.WriteValueF32(HeightTolerance, endianess);
			output.WriteValueF32(ExtraHeightStart, endianess);
			output.WriteValueF32(LengthPostStart, endianess);
			output.WriteValueF32(FreeRadiusEnd, endianess);
			output.WriteValueB32(GoBack, endianess);
			output.WriteValueB32(UseTargetIntermediate, endianess);
			output.WriteValueB32(GoUpSoon, endianess);
			output.WriteValueF32(HeightAtTarget, endianess);
			BaseProperty.SerializePropertyEnum(output, endianess, TemporaryTarget);
			SpeedFactor.Serialize(output, endianess);
		}

		public override void Deserialize(Stream input, Endian endianess)
		{
			base.Deserialize(input, endianess);
			TimeBegin = input.ReadValueF32(endianess);
			TimeEnd = input.ReadValueF32(endianess);
			Distance = input.ReadValueF32(endianess);
			TurnRate = input.ReadValueF32(endianess);
			MinSpeed = input.ReadValueF32(endianess);
			MaxSpeed = input.ReadValueF32(endianess);
			DistanceTolerance = input.ReadValueF32(endianess);
			HeightTolerance = input.ReadValueF32(endianess);
			ExtraHeightStart = input.ReadValueF32(endianess);
			LengthPostStart = input.ReadValueF32(endianess);
			FreeRadiusEnd = input.ReadValueF32(endianess);
			GoBack = input.ReadValueB32(endianess);
			UseTargetIntermediate = input.ReadValueB32(endianess);
			GoUpSoon = input.ReadValueB32(endianess);
			HeightAtTarget = input.ReadValueF32(endianess);
			TemporaryTarget = BaseProperty.DeserializePropertyEnum<LookAtType>(input, endianess);
			SpeedFactor.Deserialize(input, endianess);
		}
	}
}
