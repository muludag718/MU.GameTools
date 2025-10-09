using System.IO;
using MU.GameTools.IO;

namespace MU.GameTools.Prototype.Fight.Prototype1.Condition
{
	[KnownCondition(ConditionHash.InsideReservedVolume)]
	public class InsideReservedVolumeCondition : P1Condition
	{
		public bool Inside { get; set; }

		public float Radius { get; set; }

		public bool Destination { get; set; }

		public override void Serialize(Stream output, Endian endianess)
		{
			base.Serialize(output, endianess);
			output.WriteValueB32(Inside, endianess);
			output.WriteValueF32(Radius, endianess);
			output.WriteValueB32(Destination, endianess);
		}

		public override void Deserialize(Stream input, Endian endianess)
		{
			base.Deserialize(input, endianess);
			Inside = input.ReadValueB32(endianess);
			Radius = input.ReadValueF32(endianess);
			Destination = input.ReadValueB32(endianess);
		}
	}
}
