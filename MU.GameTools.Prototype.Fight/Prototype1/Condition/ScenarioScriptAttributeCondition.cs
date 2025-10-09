using System.IO;
using MU.GameTools.IO;

namespace MU.GameTools.Prototype.Fight.Prototype1.Condition
{
	[KnownCondition(ConditionHash.ScenarioScriptAttribute)]
	public class ScenarioScriptAttributeCondition : P1Condition
	{
		public ulong GameObjectSlot { get; set; }

		public GameObjectAttributeType Type { get; set; }

		public string Attributekey { get; set; }

		public string Value { get; set; }

		public override void Serialize(Stream output, Endian endianess)
		{
			base.Serialize(output, endianess);
			output.WriteValueU64(GameObjectSlot, endianess);
			BaseProperty.SerializePropertyEnum(output, endianess, Type);
			output.WriteStringAlignedU32(Attributekey, endianess);
			output.WriteStringAlignedU32(Value, endianess);
		}

		public override void Deserialize(Stream input, Endian endianess)
		{
			base.Deserialize(input, endianess);
			GameObjectSlot = input.ReadValueU64(endianess);
			Type = BaseProperty.DeserializePropertyEnum<GameObjectAttributeType>(input, endianess);
			Attributekey = input.ReadStringAlignedU32(endianess);
			Value = input.ReadStringAlignedU32(endianess);
		}
	}
}
