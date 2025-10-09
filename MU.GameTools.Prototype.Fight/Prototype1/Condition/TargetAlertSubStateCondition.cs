using System.IO;
using MU.GameTools.IO;

namespace MU.GameTools.Prototype.Fight.Prototype1.Condition
{
	[KnownCondition(ConditionHash.TargetAlertSubState)]
	public class TargetAlertSubStateCondition : P1Condition
	{
		public enum TargetAlertSubStateType : ulong
		{
			Default = 16487629634260232271uL,
			Disoriented = 7264117317165478180uL,
			NotFooled = 2569352039904682526uL
		}

		public TargetAlertSubStateType SubState { get; set; }

		public override void Serialize(Stream output, Endian endianess)
		{
			base.Serialize(output, endianess);
			BaseProperty.SerializePropertyEnum(output, endianess, SubState);
		}

		public override void Deserialize(Stream input, Endian endianess)
		{
			base.Deserialize(input, endianess);
			SubState = BaseProperty.DeserializePropertyEnum<TargetAlertSubStateType>(input, endianess);
		}
	}
}
