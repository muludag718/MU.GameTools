using System.IO;
using MU.GameTools.IO;

namespace MU.GameTools.Prototype.Fight.Prototype1.Track
{
	[KnownTrack(TrackHash.VehicleReticule)]
	public class VehicleReticuleTrack : P1Track
	{
		public bool ReticuleOn { get; set; }

		public override void Serialize(Stream output, Endian endianess)
		{
			base.Serialize(output, endianess);
			output.WriteValueB32(ReticuleOn, endianess);
		}

		public override void Deserialize(Stream input, Endian endianess)
		{
			base.Deserialize(input, endianess);
			ReticuleOn = input.ReadValueB32(endianess);
		}
	}
}
