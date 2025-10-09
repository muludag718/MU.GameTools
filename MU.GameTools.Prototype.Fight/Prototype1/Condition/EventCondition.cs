using System.IO;
using MU.GameTools.IO;

namespace MU.GameTools.Prototype.Fight.Prototype1.Condition
{
	[KnownCondition(ConditionHash.Event)]
	public class EventCondition : P1Condition
	{
		public enum WhenType : ulong
		{
			OnEnter = 4674110501632545327uL,
			OnExit = 10613578434616600639uL
		}

		public ulong Event { get; set; }

		public WhenType When { get; set; }

		public override void Serialize(Stream output, Endian endianess)
		{
			base.Serialize(output, endianess);
			output.WriteValueU64(Event, endianess);
			BaseProperty.SerializePropertyEnum(output, endianess, When);
		}

		public override void Deserialize(Stream input, Endian endianess)
		{
			base.Deserialize(input, endianess);
			Event = input.ReadValueU64(endianess);
			When = BaseProperty.DeserializePropertyEnum<WhenType>(input, endianess);
		}
	}
}
