using System.IO;
using MU.GameTools.IO;

namespace MU.GameTools.Prototype.Fight.Prototype1.Condition
{
	[KnownNodeForContext(ContextHash.Motion)]
	[KnownCondition(ConditionHash.VariableNameCompare)]
	public class VariableNameCompareCondition : P1Condition
	{
		public ulong Variable { get; set; }

		public CompareOperator Compare { get; set; }

		public ulong Value { get; set; }

		public override void Serialize(Stream output, Endian endianess)
		{
			base.Serialize(output, endianess);
			output.WriteValueU64(Variable, endianess);
			BaseProperty.SerializePropertyEnum(output, endianess, Compare);
			output.WriteValueU64(Value, endianess);
		}

		public override void Deserialize(Stream input, Endian endianess)
		{
			base.Deserialize(input, endianess);
			Variable = input.ReadValueU64(endianess);
			Compare = BaseProperty.DeserializePropertyEnum<CompareOperator>(input, endianess);
			Value = input.ReadValueU64(endianess);
		}
	}
}
