using System.IO;
using MU.GameTools.IO;

namespace MU.GameTools.Prototype.Fight.Prototype1.Condition
{
	[KnownNodeForContext(ContextHash.Alert)]
	[KnownCondition(ConditionHash.AlertVariable)]
	public class AlertVariableCondition : P1Condition
	{
		public VariableType Variable { get; set; }

		public CompareOperator Compare { get; set; }

		public float Value { get; set; }

		public override void Serialize(Stream output, Endian endianess)
		{
			base.Serialize(output, endianess);
			BaseProperty.SerializePropertyEnum(output, endianess, Variable);
			BaseProperty.SerializePropertyEnum(output, endianess, Compare);
			output.WriteValueF32(Value, endianess);
		}

		public override void Deserialize(Stream input, Endian endianess)
		{
			base.Deserialize(input, endianess);
			Variable = BaseProperty.DeserializePropertyEnum<VariableType>(input, endianess);
			Compare = BaseProperty.DeserializePropertyEnum<CompareOperator>(input, endianess);
			Value = input.ReadValueF32(endianess);
		}
	}
}
