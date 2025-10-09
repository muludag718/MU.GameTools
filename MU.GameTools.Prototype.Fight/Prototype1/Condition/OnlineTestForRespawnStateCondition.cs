using System.IO;
using MU.GameTools.IO;

namespace MU.GameTools.Prototype.Fight.Prototype1.Condition
{
	[KnownCondition(ConditionHash.OnlineTestForRespawnState)]
	public class OnlineTestForRespawnStateCondition : P1Condition
	{
		public PlayerType Player { get; set; }

		public OnlineStateType State { get; set; }

		public override void Serialize(Stream output, Endian endianess)
		{
			base.Serialize(output, endianess);
			BaseProperty.SerializePropertyEnum(output, endianess, Player);
			BaseProperty.SerializePropertyEnum(output, endianess, State);
		}

		public override void Deserialize(Stream input, Endian endianess)
		{
			base.Deserialize(input, endianess);
			Player = BaseProperty.DeserializePropertyEnum<PlayerType>(input, endianess);
			State = BaseProperty.DeserializePropertyEnum<OnlineStateType>(input, endianess);
		}
	}
}
