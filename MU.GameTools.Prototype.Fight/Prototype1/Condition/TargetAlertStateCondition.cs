using System.IO;
using MU.GameTools.IO;

namespace MU.GameTools.Prototype.Fight.Prototype1.Condition
{
	[KnownNodeForContext(ContextHash.AI)]
	[KnownCondition(ConditionHash.TargetAlertState)]
	public class TargetAlertStateCondition : P1Condition
	{
		public AIState State { get; set; }

		public override void Serialize(Stream output, Endian endianess)
		{
			base.Serialize(output, endianess);
			BaseProperty.SerializePropertyEnum(output, endianess, State);
		}

		public override void Deserialize(Stream input, Endian endianess)
		{
			base.Deserialize(input, endianess);
			State = BaseProperty.DeserializePropertyEnum<AIState>(input, endianess);
		}
	}
}
