using System.IO;
using MU.GameTools.IO;

namespace MU.GameTools.Prototype.Fight.Prototype1.Condition
{
	[KnownNodeForContext(ContextHash.Motion)]
	[KnownCondition(ConditionHash.ConsumptionName)]
	public class ConsumptionNameCondition : P1Condition
	{
		public ulong Name { get; set; }

		public bool IsActive { get; set; }

		public override void Serialize(Stream output, Endian endianess)
		{
			base.Serialize(output, endianess);
			output.WriteValueU64(Name, endianess);
			output.WriteValueB32(IsActive, endianess);
		}

		public override void Deserialize(Stream input, Endian endianess)
		{
			base.Deserialize(input, endianess);
			Name = input.ReadValueU64(endianess);
			IsActive = input.ReadValueB32(endianess);
		}
	}
}
