using System.IO;
using MU.GameTools.IO;

namespace MU.GameTools.Prototype.Fight.Prototype1.Condition
{
	[KnownNodeForContext(ContextHash.Motion)]
	[KnownCondition(ConditionHash.Health)]
	public class HealthCondition : P1Condition
	{
		public CompareOperator Compare { get; set; }

		public float HealthThreshold { get; set; }

		public bool UsePercentage { get; set; }

		public override void Serialize(Stream output, Endian endianess)
		{
			base.Serialize(output, endianess);
			BaseProperty.SerializePropertyEnum(output, endianess, Compare);
			output.WriteValueF32(HealthThreshold, endianess);
			output.WriteValueB32(UsePercentage, endianess);
		}

		public override void Deserialize(Stream input, Endian endianess)
		{
			base.Deserialize(input, endianess);
			Compare = BaseProperty.DeserializePropertyEnum<CompareOperator>(input, endianess);
			HealthThreshold = input.ReadValueF32(endianess);
			UsePercentage = input.ReadValueB32(endianess);
		}
	}
}
