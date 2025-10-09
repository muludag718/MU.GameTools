using System.IO;
using MU.GameTools.IO;

namespace MU.GameTools.Prototype.Fight.Prototype1.Condition
{
	[KnownCondition(ConditionHash.DisguiseReaction)]
	public class DisguiseReactionCondition : P1Condition
	{
		public CompareOperator Compare { get; set; }

		public AIState Reaction { get; set; }

		public override void Serialize(Stream output, Endian endianess)
		{
			base.Serialize(output, endianess);
			BaseProperty.SerializePropertyEnum(output, endianess, Compare);
			BaseProperty.SerializePropertyEnum(output, endianess, Reaction);
		}

		public override void Deserialize(Stream input, Endian endianess)
		{
			base.Deserialize(input, endianess);
			Compare = BaseProperty.DeserializePropertyEnum<CompareOperator>(input, endianess);
			Reaction = BaseProperty.DeserializePropertyEnum<AIState>(input, endianess);
		}
	}
}
