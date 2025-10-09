using System.IO;
using MU.GameTools.IO;

namespace MU.GameTools.Prototype.Fight.Prototype1.Condition
{
	[KnownNodeForContext(ContextHash.Motion)]
	[KnownCondition(ConditionHash.ReactionEvent)]
	public class ReactionEventCondition : P1Condition
	{
		public bool IsReactionEvent { get; set; }

		public ReactionType ReactionType { get; set; }

		public override void Serialize(Stream output, Endian endianess)
		{
			base.Serialize(output, endianess);
			output.WriteValueB32(IsReactionEvent, endianess);
			BaseProperty.SerializePropertyEnum(output, endianess, ReactionType);
		}

		public override void Deserialize(Stream input, Endian endianess)
		{
			base.Deserialize(input, endianess);
			IsReactionEvent = input.ReadValueB32(endianess);
			ReactionType = BaseProperty.DeserializePropertyEnum<ReactionType>(input, endianess);
		}
	}
}
