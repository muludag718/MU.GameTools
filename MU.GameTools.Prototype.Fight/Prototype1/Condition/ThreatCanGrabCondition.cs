using System.IO;
using MU.GameTools.IO;

namespace MU.GameTools.Prototype.Fight.Prototype1.Condition
{
	[KnownCondition(ConditionHash.ThreatCanGrab)]
	public class ThreatCanGrabCondition : P1Condition
	{
		public ulong Name { get; set; }

		public bool SetGrabTarget { get; set; }

		public override void Serialize(Stream output, Endian endianess)
		{
			base.Serialize(output, endianess);
			output.WriteValueU64(Name, endianess);
			output.WriteValueB32(SetGrabTarget, endianess);
		}

		public override void Deserialize(Stream input, Endian endianess)
		{
			base.Deserialize(input, endianess);
			Name = input.ReadValueU64(endianess);
			SetGrabTarget = input.ReadValueB32(endianess);
		}
	}
}
