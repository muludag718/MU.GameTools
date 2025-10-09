using System.IO;
using MU.GameTools.IO;

namespace MU.GameTools.Prototype.Fight.Prototype1.Condition
{
	[KnownNodeForContext(ContextHash.Motion)]
	[KnownCondition(ConditionHash.ReactionHitImpulse)]
	public class ReactionHitImpulseCondition : P1Condition
	{
		public DirectionType Direction { get; set; }

		public CompareOperator Compare { get; set; }

		public float Impulse { get; set; }

		public override void Serialize(Stream output, Endian endianess)
		{
			base.Serialize(output, endianess);
			BaseProperty.SerializePropertyEnum(output, endianess, Direction);
			BaseProperty.SerializePropertyEnum(output, endianess, Compare);
			output.WriteValueF32(Impulse, endianess);
		}

		public override void Deserialize(Stream input, Endian endianess)
		{
			base.Deserialize(input, endianess);
			Direction = BaseProperty.DeserializePropertyEnum<DirectionType>(input, endianess);
			Compare = BaseProperty.DeserializePropertyEnum<CompareOperator>(input, endianess);
			Impulse = input.ReadValueF32(endianess);
		}
	}
}
