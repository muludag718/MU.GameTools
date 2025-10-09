using System.IO;
using MU.GameTools.IO;

namespace MU.GameTools.Prototype.Fight.Prototype1.Condition
{
	[KnownNodeForContext(ContextHash.Motion)]
	[KnownCondition(ConditionHash.TargetClass)]
	public class TargetClassCondition : P1Condition
	{
		public CompareOperator Compare { get; set; }

		public TargetClass TargetClass { get; set; }

		public override void Serialize(Stream output, Endian endianess)
		{
			base.Serialize(output, endianess);
			BaseProperty.SerializePropertyEnum(output, endianess, Compare);
			BaseProperty.SerializePropertyEnum(output, endianess, TargetClass);
		}

		public override void Deserialize(Stream input, Endian endianess)
		{
			base.Deserialize(input, endianess);
			Compare = BaseProperty.DeserializePropertyEnum<CompareOperator>(input, endianess);
			TargetClass = BaseProperty.DeserializePropertyEnum<TargetClass>(input, endianess);
		}
	}
}
