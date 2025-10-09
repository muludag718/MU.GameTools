using System.IO;
using MU.GameTools.IO;

namespace MU.GameTools.Prototype.Fight.Prototype1.Track
{
	[KnownTrack(TrackHash.VehiclePowerOnOff)]
	public class VehiclePowerOnOffTrack : P1Track
	{
		public float TimeBegin { get; set; }

		public bool PowerOn { get; set; }

		public bool UseSpinup { get; set; }

		public override void Serialize(Stream output, Endian endianess)
		{
			base.Serialize(output, endianess);
			output.WriteValueF32(TimeBegin, endianess);
			output.WriteValueB32(PowerOn, endianess);
			output.WriteValueB32(UseSpinup, endianess);
		}

		public override void Deserialize(Stream input, Endian endianess)
		{
			base.Deserialize(input, endianess);
			TimeBegin = input.ReadValueF32(endianess);
			PowerOn = input.ReadValueB32(endianess);
			UseSpinup = input.ReadValueB32(endianess);
		}
	}
}
