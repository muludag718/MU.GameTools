using System.IO;
using MU.GameTools.IO;

namespace MU.GameTools.Prototype.Fight.Prototype1.Condition
{
	[KnownNodeForContext(ContextHash.AI)]
	[KnownCondition(ConditionHash.DestinationTargetDistance)]
	public class DestinationTargetDistanceCondition : P1Condition
	{
		public DirectionType Direction { get; set; }

		public CompareOperator Compare { get; set; }

		public float Distance { get; set; }

		public bool UseParams { get; set; }

		public override void Serialize(Stream output, Endian endianess)
		{
			base.Serialize(output, endianess);
			BaseProperty.SerializePropertyEnum(output, endianess, Direction);
			BaseProperty.SerializePropertyEnum(output, endianess, Compare);
			output.WriteValueF32(Distance, endianess);
			output.WriteValueB32(UseParams, endianess);
		}

		public override void Deserialize(Stream input, Endian endianess)
		{
			base.Deserialize(input, endianess);
			Direction = BaseProperty.DeserializePropertyEnum<DirectionType>(input, endianess);
			Compare = BaseProperty.DeserializePropertyEnum<CompareOperator>(input, endianess);
			Distance = input.ReadValueF32(endianess);
			UseParams = input.ReadValueB32(endianess);
		}
	}
}
