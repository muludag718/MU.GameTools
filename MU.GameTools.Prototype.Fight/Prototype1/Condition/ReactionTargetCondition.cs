using System.IO;
using MU.GameTools.IO;

namespace MU.GameTools.Prototype.Fight.Prototype1.Condition
{
	[KnownCondition(ConditionHash.ReactionTarget)]
	public class ReactionTargetCondition : P1Condition
	{
		public bool DoesMatch { get; set; }

		public override void Serialize(Stream output, Endian endianess)
		{
			base.Serialize(output, endianess);
			output.WriteValueB32(DoesMatch, endianess);
		}

		public override void Deserialize(Stream input, Endian endianess)
		{
			base.Deserialize(input, endianess);
			DoesMatch = input.ReadValueB32(endianess);
		}
	}
}
