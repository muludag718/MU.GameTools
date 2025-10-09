using System.IO;
using MU.GameTools.IO;

namespace MU.GameTools.Prototype.Fight.Prototype1.Condition
{
	[KnownCondition(ConditionHash.AlertStatus)]
	public class AlertStatusCondition : P1Condition
	{
		public ulong Affiliate { get; set; }

		public bool Alert { get; set; }

		public override void Serialize(Stream output, Endian endianess)
		{
			base.Serialize(output, endianess);
			output.WriteValueU64(Affiliate, endianess);
			output.WriteValueB32(Alert, endianess);
		}

		public override void Deserialize(Stream input, Endian endianess)
		{
			base.Deserialize(input, endianess);
			Affiliate = input.ReadValueU64(endianess);
			Alert = input.ReadValueB32(endianess);
		}
	}
}
