using System.IO;
using MU.GameTools.IO;

namespace MU.GameTools.Prototype.Fight.Prototype1.Condition
{
	[KnownNodeForContext(ContextHash.Motion)]
	[KnownCondition(ConditionHash.Charge)]
	public class ChargeCondition : P1Condition
	{
		public CompareOperator Compare { get; set; }

		public float Charge { get; set; }

		public ChargeType Type { get; set; }

		public override void Serialize(Stream output, Endian endianess)
		{
			base.Serialize(output, endianess);
			BaseProperty.SerializePropertyEnum(output, endianess, Compare);
			output.WriteValueF32(Charge, endianess);
			BaseProperty.SerializePropertyEnum(output, endianess, Type);
		}

		public override void Deserialize(Stream input, Endian endianess)
		{
			base.Deserialize(input, endianess);
			Compare = BaseProperty.DeserializePropertyEnum<CompareOperator>(input, endianess);
			Charge = input.ReadValueF32(endianess);
			Type = BaseProperty.DeserializePropertyEnum<ChargeType>(input, endianess);
		}
	}
}
