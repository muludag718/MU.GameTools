using System.IO;
using MU.GameTools.IO;

namespace MU.GameTools.Prototype.Fight.Prototype1.Condition
{
	[KnownNodeForContext(ContextHash.Motion)]
	[KnownCondition(ConditionHash.EdgePosition)]
	public class EdgePositionCondition : P1Condition
	{
		public PositionType Component { get; set; }

		public CompareOperator Compare { get; set; }

		public float Offset { get; set; }

		public override void Serialize(Stream output, Endian endianess)
		{
			base.Serialize(output, endianess);
			BaseProperty.SerializePropertyEnum(output, endianess, Component);
			BaseProperty.SerializePropertyEnum(output, endianess, Compare);
			output.WriteValueF32(Offset, endianess);
		}

		public override void Deserialize(Stream input, Endian endianess)
		{
			base.Deserialize(input, endianess);
			Component = BaseProperty.DeserializePropertyEnum<PositionType>(input, endianess);
			Compare = BaseProperty.DeserializePropertyEnum<CompareOperator>(input, endianess);
			Offset = input.ReadValueF32(endianess);
		}
	}
}
