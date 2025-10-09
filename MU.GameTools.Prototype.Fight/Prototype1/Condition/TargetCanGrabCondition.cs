using System.IO;
using MU.GameTools.IO;

namespace MU.GameTools.Prototype.Fight.Prototype1.Condition
{
	[KnownCondition(ConditionHash.TargetCanGrab)]
	public class TargetCanGrabCondition : P1Condition
	{
		public bool SetGrabTarget { get; set; }

		public override void Serialize(Stream output, Endian endianess)
		{
			base.Serialize(output, endianess);
			output.WriteValueB32(SetGrabTarget, endianess);
		}

		public override void Deserialize(Stream input, Endian endianess)
		{
			base.Deserialize(input, endianess);
			SetGrabTarget = input.ReadValueB32(endianess);
		}
	}
}
