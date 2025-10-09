using System.IO;
using MU.GameTools.IO;

namespace MU.GameTools.Prototype.Fight.Prototype1.Condition
{
	[KnownNodeForContext(ContextHash.Motion)]
	[KnownCondition(ConditionHash.SupportingSurfaceSupportingLimb)]
	public class SupportingSurfaceSupportingLimbCondition : P1Condition
	{
		public ulong SupportingLimb { get; set; }

		public bool IsSupportingLimb { get; set; }

		public override void Serialize(Stream output, Endian endianess)
		{
			base.Serialize(output, endianess);
			output.WriteValueU64(SupportingLimb, endianess);
			output.WriteValueB32(IsSupportingLimb, endianess);
		}

		public override void Deserialize(Stream input, Endian endianess)
		{
			base.Deserialize(input, endianess);
			SupportingLimb = input.ReadValueU64(endianess);
			IsSupportingLimb = input.ReadValueB32(endianess);
		}
	}
}
