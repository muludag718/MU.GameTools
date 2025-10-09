using System.IO;
using MU.GameTools.IO;

namespace MU.GameTools.Prototype.Fight.Prototype1.Condition
{
	[KnownCondition(ConditionHash.TargetFreeHeightRadius)]
	public class TargetFreeHeightRadiusCondition : P1Condition
	{
		public CompareOperator Compare { get; set; }

		public float Radius { get; set; }

		public float HeightTolerance { get; set; }

		public bool GroundUnit { get; set; }

		public override void Serialize(Stream output, Endian endianess)
		{
			base.Serialize(output, endianess);
			BaseProperty.SerializePropertyEnum(output, endianess, Compare);
			output.WriteValueF32(Radius, endianess);
			output.WriteValueF32(HeightTolerance, endianess);
			output.WriteValueB32(GroundUnit, endianess);
		}

		public override void Deserialize(Stream input, Endian endianess)
		{
			base.Deserialize(input, endianess);
			Compare = BaseProperty.DeserializePropertyEnum<CompareOperator>(input, endianess);
			Radius = input.ReadValueF32(endianess);
			HeightTolerance = input.ReadValueF32(endianess);
			GroundUnit = input.ReadValueB32(endianess);
		}
	}
}
