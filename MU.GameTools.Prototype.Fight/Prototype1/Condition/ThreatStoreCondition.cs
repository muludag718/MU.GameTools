using System.IO;
using MU.GameTools.IO;

namespace MU.GameTools.Prototype.Fight.Prototype1.Condition
{
	[KnownNodeForContext(ContextHash.Motion)]
	[KnownCondition(ConditionHash.ThreatStore)]
	public class ThreatStoreCondition : P1Condition
	{
		public enum ThreatObjectType : ulong
		{
			None = 31052086116886518uL,
			Thrown = 12170483751774391586uL,
			Giver = 7304932156285466995uL
		}

		public ulong Name { get; set; }

		public ThreatObjectType ThreatObject { get; set; }

		public override void Serialize(Stream output, Endian endianess)
		{
			base.Serialize(output, endianess);
			output.WriteValueU64(Name, endianess);
			BaseProperty.SerializePropertyEnum(output, endianess, ThreatObject);
		}

		public override void Deserialize(Stream input, Endian endianess)
		{
			base.Deserialize(input, endianess);
			Name = input.ReadValueU64(endianess);
			ThreatObject = BaseProperty.DeserializePropertyEnum<ThreatObjectType>(input, endianess);
		}
	}
}
