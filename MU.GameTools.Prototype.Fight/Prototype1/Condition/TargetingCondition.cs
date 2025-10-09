using System.IO;
using MU.GameTools.IO;

namespace MU.GameTools.Prototype.Fight.Prototype1.Condition
{
	[KnownNodeForContext(ContextHash.Motion)]
	[KnownCondition(ConditionHash.Targeting)]
	public class TargetingCondition : P1Condition
	{
		public bool IsTargeting { get; set; }

		public bool IncludeAutoTarget { get; set; }

		public override void Serialize(Stream output, Endian endianess)
		{
			base.Serialize(output, endianess);
			output.WriteValueB32(IsTargeting, endianess);
			output.WriteValueB32(IncludeAutoTarget, endianess);
		}

		public override void Deserialize(Stream input, Endian endianess)
		{
			base.Deserialize(input, endianess);
			IsTargeting = input.ReadValueB32(endianess);
			IncludeAutoTarget = input.ReadValueB32(endianess);
		}
	}
}
