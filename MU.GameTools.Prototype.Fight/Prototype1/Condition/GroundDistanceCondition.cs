using System.IO;
using MU.GameTools.IO;

namespace MU.GameTools.Prototype.Fight.Prototype1.Condition
{
	[KnownCondition(ConditionHash.GroundDistance)]
	public class GroundDistanceCondition : P1Condition
	{
		public CompareOperator Compare { get; set; }

		public float Distance { get; set; }

		public float Radius { get; set; }

		public bool GroundUnit { get; set; }

		public override void Serialize(Stream output, Endian endianess)
		{
			base.Serialize(output, endianess);
			BaseProperty.SerializePropertyEnum(output, endianess, Compare);
			output.WriteValueF32(Distance, endianess);
			output.WriteValueF32(Radius, endianess);
			output.WriteValueB32(GroundUnit, endianess);
		}

		public override void Deserialize(Stream input, Endian endianess)
		{
			base.Deserialize(input, endianess);
			Compare = BaseProperty.DeserializePropertyEnum<CompareOperator>(input, endianess);
			Distance = input.ReadValueF32(endianess);
			Radius = input.ReadValueF32(endianess);
			GroundUnit = input.ReadValueB32(endianess);
		}
	}
}
