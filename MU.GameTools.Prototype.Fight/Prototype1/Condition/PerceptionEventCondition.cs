using System.IO;
using MU.GameTools.IO;

namespace MU.GameTools.Prototype.Fight.Prototype1.Condition
{
	[KnownCondition(ConditionHash.PerceptionEvent)]
	public class PerceptionEventCondition : P1Condition
	{
		public enum PerceptionEventType : ulong
		{
			Confused = 5636306821393634529uL,
			KilledEnemy = 6285212487246905469uL,
			LostBait = 760992217660282718uL,
			AcquiredBait = 4818839403936553164uL
		}

		public PerceptionEventType Event { get; set; }

		public override void Serialize(Stream output, Endian endianess)
		{
			base.Serialize(output, endianess);
			BaseProperty.SerializePropertyEnum(output, endianess, Event);
		}

		public override void Deserialize(Stream input, Endian endianess)
		{
			base.Deserialize(input, endianess);
			Event = BaseProperty.DeserializePropertyEnum<PerceptionEventType>(input, endianess);
		}
	}
}
