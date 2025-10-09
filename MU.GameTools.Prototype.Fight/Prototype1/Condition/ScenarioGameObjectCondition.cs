using System.IO;
using MU.GameTools.IO;

namespace MU.GameTools.Prototype.Fight.Prototype1.Condition
{
	[KnownNodeForContext(ContextHash.Scenario)]
	[KnownCondition(ConditionHash.GameObject)]
	public class ScenarioGameObjectCondition : P1Condition
	{
		public ScenarioGameObjectSlot GameObjectSlot { get; set; }

		public ulong GameObjectNameHash { get; set; }

		public override void Serialize(Stream output, Endian endianess)
		{
			base.Serialize(output, endianess);
			BaseProperty.SerializePropertyEnum(output, endianess, GameObjectSlot);
			output.WriteValueU64(GameObjectNameHash, endianess);
		}

		public override void Deserialize(Stream input, Endian endianess)
		{
			base.Deserialize(input, endianess);
			GameObjectSlot = BaseProperty.DeserializePropertyEnum<ScenarioGameObjectSlot>(input, endianess);
			GameObjectNameHash = input.ReadValueU64(endianess);
		}
	}
}
