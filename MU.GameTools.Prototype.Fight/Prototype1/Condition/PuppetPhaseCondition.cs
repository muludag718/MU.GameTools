using System.IO;
using MU.GameTools.IO;

namespace MU.GameTools.Prototype.Fight.Prototype1.Condition
{
	[KnownCondition(ConditionHash.PuppetPhase)]
	public class PuppetPhaseCondition : P1Condition
	{
		public enum RangeType : ulong
		{
			InsideRange = 16608783493572752571uL,
			OutsideRange = 5936946687786899414uL
		}

		public RangeType PositionConditionType { get; set; }

		public float MinPositionPhase { get; set; }

		public float MaxPositionPhase { get; set; }

		public RangeType VelocityConditionType { get; set; }

		public float MinVelocityPhase { get; set; }

		public float MaxVelocityPhase { get; set; }

		public override void Serialize(Stream output, Endian endianess)
		{
			base.Serialize(output, endianess);
			BaseProperty.SerializePropertyEnum(output, endianess, PositionConditionType);
			output.WriteValueF32(MinPositionPhase, endianess);
			output.WriteValueF32(MaxPositionPhase, endianess);
			BaseProperty.SerializePropertyEnum(output, endianess, VelocityConditionType);
			output.WriteValueF32(MinVelocityPhase, endianess);
			output.WriteValueF32(MaxVelocityPhase, endianess);
		}

		public override void Deserialize(Stream input, Endian endianess)
		{
			base.Deserialize(input, endianess);
			PositionConditionType = BaseProperty.DeserializePropertyEnum<RangeType>(input, endianess);
			MinPositionPhase = input.ReadValueF32(endianess);
			MaxPositionPhase = input.ReadValueF32(endianess);
			VelocityConditionType = BaseProperty.DeserializePropertyEnum<RangeType>(input, endianess);
			MinVelocityPhase = input.ReadValueF32(endianess);
			MaxVelocityPhase = input.ReadValueF32(endianess);
		}
	}
}
