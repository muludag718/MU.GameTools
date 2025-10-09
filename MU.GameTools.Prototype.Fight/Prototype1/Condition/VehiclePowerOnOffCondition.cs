using System.IO;
using MU.GameTools.IO;

namespace MU.GameTools.Prototype.Fight.Prototype1.Condition
{
	[KnownCondition(ConditionHash.VehiclePowerOnOff)]
	public class VehiclePowerOnOffCondition : P1Condition
	{
		public bool PowerOn { get; set; }

		public override void Serialize(Stream output, Endian endianess)
		{
			base.Serialize(output, endianess);
			output.WriteValueB32(PowerOn, endianess);
		}

		public override void Deserialize(Stream input, Endian endianess)
		{
			base.Deserialize(input, endianess);
			PowerOn = input.ReadValueB32(endianess);
		}
	}
}
