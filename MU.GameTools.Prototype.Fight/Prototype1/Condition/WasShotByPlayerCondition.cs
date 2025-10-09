using System.IO;
using MU.GameTools.IO;

namespace MU.GameTools.Prototype.Fight.Prototype1.Condition
{
	[KnownCondition(ConditionHash.WasShotByPlayer)]
	public class WasShotByPlayerCondition : P1Condition
	{
		public bool ShotByPlayer { get; set; }

		public override void Serialize(Stream output, Endian endianess)
		{
			base.Serialize(output, endianess);
			output.WriteValueB32(ShotByPlayer, endianess);
		}

		public override void Deserialize(Stream input, Endian endianess)
		{
			base.Deserialize(input, endianess);
			ShotByPlayer = input.ReadValueB32(endianess);
		}
	}
}
