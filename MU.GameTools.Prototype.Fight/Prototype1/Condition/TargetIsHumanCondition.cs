using System.IO;
using MU.GameTools.IO;

namespace MU.GameTools.Prototype.Fight.Prototype1.Condition
{
	[KnownNodeForContext(ContextHash.Motion)]
	[KnownCondition(ConditionHash.TargetIsHuman)]
	public class TargetIsHumanCondition : P1Condition
	{
		public bool Human { get; set; }

		public bool CheckPointPeds { get; set; }

		public override void Serialize(Stream output, Endian endianess)
		{
			base.Serialize(output, endianess);
			output.WriteValueB32(Human, endianess);
			output.WriteValueB32(CheckPointPeds, endianess);
		}

		public override void Deserialize(Stream input, Endian endianess)
		{
			base.Deserialize(input, endianess);
			Human = input.ReadValueB32(endianess);
			CheckPointPeds = input.ReadValueB32(endianess);
		}
	}
}
