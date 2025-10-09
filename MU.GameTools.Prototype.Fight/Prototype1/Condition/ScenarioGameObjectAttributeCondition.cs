using System.IO;
using MU.GameTools.IO;

namespace MU.GameTools.Prototype.Fight.Prototype1.Condition
{
	[KnownNodeForContext(ContextHash.Scenario)]
	[KnownCondition(ConditionHash.GameObjectAttribute)]
	public class ScenarioGameObjectAttributeCondition : P1Condition
	{
		public ScenarioGameObjectSlot GameObjectSlot { get; set; }

		public string AttributeKey { get; set; }

		public ulong ValueHash { get; set; }

		public override void Serialize(Stream output, Endian endianess)
		{
			base.Serialize(output, endianess);
			BaseProperty.SerializePropertyEnum(output, endianess, GameObjectSlot);
			output.WriteStringAlignedU32(AttributeKey, endianess);
			output.WriteValueU64(ValueHash, endianess);
		}

		public override void Deserialize(Stream input, Endian endianess)
		{
			base.Deserialize(input, endianess);
			GameObjectSlot = BaseProperty.DeserializePropertyEnum<ScenarioGameObjectSlot>(input, endianess);
			AttributeKey = input.ReadStringAlignedU32(endianess);
			ValueHash = input.ReadValueU64(endianess);
		}
	}
}
