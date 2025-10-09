using System.IO;
using MU.GameTools.IO;

namespace MU.GameTools.Prototype.Fight.Prototype1.Condition
{
	[KnownNodeForContext(ContextHash.Motion)]
	[KnownCondition(ConditionHash.TargetCanSee)]
	public class TargetCanSeeCondition : P1Condition
	{
		public bool Seen { get; set; }

		public float Since { get; set; }

		public override void Serialize(Stream output, Endian endianess)
		{
			base.Serialize(output, endianess);
			output.WriteValueB32(Seen, endianess);
			output.WriteValueF32(Since, endianess);
		}

		public override void Deserialize(Stream input, Endian endianess)
		{
			base.Deserialize(input, endianess);
			Seen = input.ReadValueB32(endianess);
			Since = input.ReadValueF32(endianess);
		}
	}
}
