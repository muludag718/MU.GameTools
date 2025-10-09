using System.IO;
using MU.GameTools.IO;

namespace MU.GameTools.Prototype.Fight.Prototype1.Condition
{
	[KnownNodeForContext(ContextHash.Motion)]
	[KnownCondition(ConditionHash.NPCAnimationVersion)]
	public class NPCAnimationVersionCondition : P1Condition
	{
		public bool Match { get; set; }

		public int Version { get; set; }

		public override void Serialize(Stream output, Endian endianess)
		{
			base.Serialize(output, endianess);
			output.WriteValueB32(Match, endianess);
			output.WriteValueS32(Version, endianess);
		}

		public override void Deserialize(Stream input, Endian endianess)
		{
			base.Deserialize(input, endianess);
			Match = input.ReadValueB32(endianess);
			Version = input.ReadValueS32(endianess);
		}
	}
}
