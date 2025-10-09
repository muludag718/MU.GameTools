using System.IO;
using MU.GameTools.IO;

namespace MU.GameTools.Prototype.Fight.Prototype1.Condition
{
	[KnownNodeForContext(ContextHash.Motion)]
	[KnownCondition(ConditionHash.SupportingLimbIsActive)]
	public class SupportingLimbIsActiveCondition : P1Condition
	{
		public ulong SupportingLimbHash { get; set; }

		public bool IsActive { get; set; }

		public override void Serialize(Stream output, Endian endianess)
		{
			base.Serialize(output, endianess);
			output.WriteValueU64(SupportingLimbHash, endianess);
			output.WriteValueB32(IsActive, endianess);
		}

		public override void Deserialize(Stream input, Endian endianess)
		{
			base.Deserialize(input, endianess);
			SupportingLimbHash = input.ReadValueU64(endianess);
			IsActive = input.ReadValueB32(endianess);
		}
	}
}
