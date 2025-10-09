using System.IO;
using MU.GameTools.IO;

namespace MU.GameTools.Prototype.Fight.Prototype1.Condition
{
	[KnownNodeForContext(ContextHash.Motion)]
	[KnownCondition(ConditionHash.AutoTargeting)]
	public class AutoTargetingCondition : P1Condition
	{
		public bool IsAutoTargeting { get; set; }

		public override void Serialize(Stream output, Endian endianess)
		{
			base.Serialize(output, endianess);
			output.WriteValueB32(IsAutoTargeting, endianess);
		}

		public override void Deserialize(Stream input, Endian endianess)
		{
			base.Deserialize(input, endianess);
			IsAutoTargeting = input.ReadValueB32(endianess);
		}
	}
}
