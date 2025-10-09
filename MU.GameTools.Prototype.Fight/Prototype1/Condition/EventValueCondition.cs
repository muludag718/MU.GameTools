using System.IO;
using MU.GameTools.IO;

namespace MU.GameTools.Prototype.Fight.Prototype1.Condition
{
	[KnownCondition(ConditionHash.EventValue)]
	public class EventValueCondition : P1Condition
	{
		public ulong Event { get; set; }

		public CompareOperator Compare { get; set; }

		public int Value { get; set; }

		public override void Serialize(Stream output, Endian endianess)
		{
			base.Serialize(output, endianess);
			output.WriteValueU64(Event, endianess);
			BaseProperty.SerializePropertyEnum(output, endianess, Compare);
			output.WriteValueS32(Value, endianess);
		}

		public override void Deserialize(Stream input, Endian endianess)
		{
			base.Deserialize(input, endianess);
			Event = input.ReadValueU64(endianess);
			Compare = BaseProperty.DeserializePropertyEnum<CompareOperator>(input, endianess);
			Value = input.ReadValueS32(endianess);
		}
	}
}
