using System.IO;
using MU.GameTools.IO;

namespace MU.GameTools.Prototype.Fight.Prototype1.Condition
{
	[KnownCondition(ConditionHash.AtRoofsEdge)]
	public class AtRoofsEdgeCondition : P1Condition
	{
		public CompareOperator Compare { get; set; }

		public float TimeAtEdge { get; set; }

		public override void Serialize(Stream output, Endian endianess)
		{
			base.Serialize(output, endianess);
			BaseProperty.SerializePropertyEnum(output, endianess, Compare);
			output.WriteValueF32(TimeAtEdge, endianess);
		}

		public override void Deserialize(Stream input, Endian endianess)
		{
			base.Deserialize(input, endianess);
			Compare = BaseProperty.DeserializePropertyEnum<CompareOperator>(input, endianess);
			TimeAtEdge = input.ReadValueF32(endianess);
		}
	}
}
