using System.IO;
using MU.GameTools.IO;

namespace MU.GameTools.Prototype.Fight.Prototype1.Condition
{
	[KnownCondition(ConditionHash.InZone)]
	public class InZoneCondition : P1Condition
	{
		public ulong ZoneType { get; set; }

		public override void Serialize(Stream output, Endian endianess)
		{
			base.Serialize(output, endianess);
			output.WriteValueU64(ZoneType, endianess);
		}

		public override void Deserialize(Stream input, Endian endianess)
		{
			base.Deserialize(input, endianess);
			ZoneType = input.ReadValueU64(endianess);
		}
	}
}
