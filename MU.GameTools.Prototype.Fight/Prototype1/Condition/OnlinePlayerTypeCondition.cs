using System.IO;
using MU.GameTools.IO;

namespace MU.GameTools.Prototype.Fight.Prototype1.Condition
{
	[KnownCondition(ConditionHash.OnlinePlayerType)]
	public class OnlinePlayerTypeCondition : P1Condition
	{
		public CompareOperator Compare { get; set; }

		public PlayerType Player { get; set; }

		public override void Serialize(Stream output, Endian endianess)
		{
			base.Serialize(output, endianess);
			BaseProperty.SerializePropertyEnum(output, endianess, Compare);
			BaseProperty.SerializePropertyEnum(output, endianess, Player);
		}

		public override void Deserialize(Stream input, Endian endianess)
		{
			base.Deserialize(input, endianess);
			Compare = BaseProperty.DeserializePropertyEnum<CompareOperator>(input, endianess);
			Player = BaseProperty.DeserializePropertyEnum<PlayerType>(input, endianess);
		}
	}
}
