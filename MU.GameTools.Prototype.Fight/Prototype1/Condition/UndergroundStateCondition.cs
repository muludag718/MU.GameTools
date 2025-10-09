using System.IO;
using MU.GameTools.IO;

namespace MU.GameTools.Prototype.Fight.Prototype1.Condition
{
	[KnownCondition(ConditionHash.UndergroundState)]
	public class UndergroundStateCondition : P1Condition
	{
		public enum UndergrounStateType : ulong
		{
			Outside = 3287350578625685413uL,
			Underground = 3391944239439239047uL,
			ComingOut = 16788696097060275829uL,
			GoingUnder = 3665617697216476576uL
		}

		public UndergrounStateType State { get; set; }

		public override void Serialize(Stream output, Endian endianess)
		{
			base.Serialize(output, endianess);
			BaseProperty.SerializePropertyEnum(output, endianess, State);
		}

		public override void Deserialize(Stream input, Endian endianess)
		{
			base.Deserialize(input, endianess);
			State = BaseProperty.DeserializePropertyEnum<UndergrounStateType>(input, endianess);
		}
	}
}
