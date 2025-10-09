using System.IO;
using MU.GameTools.IO;

namespace MU.GameTools.Prototype.Fight.Prototype1.Condition
{
	[KnownCondition(ConditionHash.WaitingForObject)]
	public class WaitingForObjectCondition : P1Condition
	{
		public bool Waiting { get; set; }

		public override void Serialize(Stream output, Endian endianess)
		{
			base.Serialize(output, endianess);
			output.WriteValueB32(Waiting, endianess);
		}

		public override void Deserialize(Stream input, Endian endianess)
		{
			base.Deserialize(input, endianess);
			Waiting = input.ReadValueB32(endianess);
		}
	}
}
