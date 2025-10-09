using System.IO;
using MU.GameTools.IO;

namespace MU.GameTools.Prototype.Fight.Prototype1.Condition
{
	[KnownCondition(ConditionHash.HaveStrafeRunToken)]
	public class HaveStrafeRunTokenCondition : P1Condition
	{
		public bool RequestIt { get; set; }

		public override void Serialize(Stream output, Endian endianess)
		{
			base.Serialize(output, endianess);
			output.WriteValueB32(RequestIt, endianess);
		}

		public override void Deserialize(Stream input, Endian endianess)
		{
			base.Deserialize(input, endianess);
			RequestIt = input.ReadValueB32(endianess);
		}
	}
}
