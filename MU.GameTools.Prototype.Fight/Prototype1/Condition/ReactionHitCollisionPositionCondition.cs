using System.IO;
using MU.GameTools.IO;

namespace MU.GameTools.Prototype.Fight.Prototype1.Condition
{
	[KnownCondition(ConditionHash.ReactionHitCollisionPosition)]
	public class ReactionHitCollisionPositionCondition : P1Condition
	{
		public PositionType Component { get; set; }

		public CompareOperator Compare { get; set; }

		public float Position { get; set; }

		public override void Serialize(Stream output, Endian endianess)
		{
			base.Serialize(output, endianess);
			BaseProperty.SerializePropertyEnum(output, endianess, Component);
			BaseProperty.SerializePropertyEnum(output, endianess, Compare);
			output.WriteValueF32(Position, endianess);
		}

		public override void Deserialize(Stream input, Endian endianess)
		{
			base.Deserialize(input, endianess);
			Component = BaseProperty.DeserializePropertyEnum<PositionType>(input, endianess);
			Compare = BaseProperty.DeserializePropertyEnum<CompareOperator>(input, endianess);
			Position = input.ReadValueF32(endianess);
		}
	}
}
