using System.IO;
using MU.GameTools.IO;

namespace MU.GameTools.Prototype.Fight.Prototype1.Condition
{
	[KnownCondition(ConditionHash.TargetIsGrabTarget)]
	public class TargetIsGrabTargetCondition : P1Condition
	{
		public bool Is { get; set; }

		public override void Serialize(Stream output, Endian endianess)
		{
			base.Serialize(output, endianess);
			output.WriteValueB32(Is, endianess);
		}

		public override void Deserialize(Stream input, Endian endianess)
		{
			base.Deserialize(input, endianess);
			Is = input.ReadValueB32(endianess);
		}
	}
}
