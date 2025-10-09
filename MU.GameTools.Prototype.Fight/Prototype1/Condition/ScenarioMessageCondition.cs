using System.IO;
using MU.GameTools.IO;

namespace MU.GameTools.Prototype.Fight.Prototype1.Condition
{
	[KnownNodeForContext(ContextHash.Scenario)]
	[KnownCondition(ConditionHash.Event)]
	public class ScenarioMessageCondition : P1Condition
	{
		public ulong Type { get; set; }

		public override void Serialize(Stream output, Endian endianess)
		{
			base.Serialize(output, endianess);
			output.WriteValueU64(Type, endianess);
		}

		public override void Deserialize(Stream input, Endian endianess)
		{
			base.Deserialize(input, endianess);
			Type = input.ReadValueU64(endianess);
		}
	}
}
