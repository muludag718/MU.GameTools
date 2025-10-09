using System.IO;
using MU.GameTools.IO;

namespace MU.GameTools.Prototype.Fight.Prototype1.Condition
{
	[KnownCondition(ConditionHash.FixedDestinationDistance)]
	public class FixedDestinationDistanceCondition : P1Condition
	{
		public DirectionType Direction { get; set; }

		public CompareOperator Compare { get; set; }

		public float Distance { get; set; }

		public override void Serialize(Stream output, Endian endianess)
		{
			base.Serialize(output, endianess);
			BaseProperty.SerializePropertyEnum(output, endianess, Direction);
			BaseProperty.SerializePropertyEnum(output, endianess, Compare);
			output.WriteValueF32(Distance, endianess);
		}

		public override void Deserialize(Stream input, Endian endianess)
		{
			base.Deserialize(input, endianess);
			Direction = BaseProperty.DeserializePropertyEnum<DirectionType>(input, endianess);
			Compare = BaseProperty.DeserializePropertyEnum<CompareOperator>(input, endianess);
			Distance = input.ReadValueF32(endianess);
		}
	}
}
