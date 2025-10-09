using System.IO;
using MU.GameTools.IO;

namespace MU.GameTools.Prototype.Fight.Prototype1.Condition
{
	[KnownNodeForContext(ContextHash.Scenario)]
	[KnownCondition(ConditionHash.GameObjectTouchesTrigger)]
	public class ScenarioGameObjectTouchesTriggerCondition : P1Condition
	{
		public enum TriggerDirection : ulong
		{
			Enter = 4872555661335756302uL,
			Exit = 19477321536111832uL
		}

		public ulong GameObjectNameHash { get; set; }

		public ulong TriggerNameHash { get; set; }

		public TriggerDirection Direction { get; set; }

		public override void Serialize(Stream output, Endian endianess)
		{
			base.Serialize(output, endianess);
			output.WriteValueU64(GameObjectNameHash, endianess);
			output.WriteValueU64(TriggerNameHash, endianess);
			BaseProperty.SerializePropertyEnum(output, endianess, Direction);
		}

		public override void Deserialize(Stream input, Endian endianess)
		{
			base.Deserialize(input, endianess);
			GameObjectNameHash = input.ReadValueU64(endianess);
			TriggerNameHash = input.ReadValueU64(endianess);
			Direction = BaseProperty.DeserializePropertyEnum<TriggerDirection>(input, endianess);
		}
	}
}
