using System.IO;
using MU.GameTools.IO;

namespace MU.GameTools.Prototype.Fight.Prototype1.Condition
{
	[KnownNodeForContext(ContextHash.Motion)]
	[KnownCondition(ConditionHash.ReactionHitHitType)]
	public class ReactionHitHitTypeCondition : P1Condition
	{
		public bool DoesMatch { get; set; }

		public ulong HitType { get; set; }

		public override void Serialize(Stream output, Endian endianess)
		{
			base.Serialize(output, endianess);
			output.WriteValueB32(DoesMatch, endianess);
			output.WriteValueU64(HitType, endianess);
		}

		public override void Deserialize(Stream input, Endian endianess)
		{
			base.Deserialize(input, endianess);
			DoesMatch = input.ReadValueB32(endianess);
			HitType = input.ReadValueU64(endianess);
		}
	}
}
