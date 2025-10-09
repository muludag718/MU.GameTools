using System.IO;
using MU.GameTools.IO;

namespace MU.GameTools.Prototype.Fight.Prototype1.Condition
{
	[KnownCondition(ConditionHash.InfectedAlerted)]
	public class InfectedAlertedCondition : P1Condition
	{
		public DirectionType Direction { get; set; }

		public CompareOperator Compare { get; set; }

		public float Distance { get; set; }

		public bool TargetingMe { get; set; }

		public bool RequireToughGuy { get; set; }

		public override void Serialize(Stream output, Endian endianess)
		{
			base.Serialize(output, endianess);
			BaseProperty.SerializePropertyEnum(output, endianess, Direction);
			BaseProperty.SerializePropertyEnum(output, endianess, Compare);
			output.WriteValueF32(Distance, endianess);
			output.WriteValueB32(TargetingMe, endianess);
			output.WriteValueB32(RequireToughGuy, endianess);
		}

		public override void Deserialize(Stream input, Endian endianess)
		{
			base.Deserialize(input, endianess);
			Direction = BaseProperty.DeserializePropertyEnum<DirectionType>(input, endianess);
			Compare = BaseProperty.DeserializePropertyEnum<CompareOperator>(input, endianess);
			Distance = input.ReadValueF32(endianess);
			TargetingMe = input.ReadValueB32(endianess);
			RequireToughGuy = input.ReadValueB32(endianess);
		}
	}
}
