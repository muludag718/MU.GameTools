using System.IO;
using MU.GameTools.IO;

namespace MU.GameTools.Prototype.Fight.Prototype1.Track
{
	[KnownTrack(TrackHash.SetVehicleHeadlight)]
	public class SetVehicleHeadlightTrack : P1Track
	{
		public bool Enabled { get; set; }

		public override void Serialize(Stream output, Endian endianess)
		{
			base.Serialize(output, endianess);
			output.WriteValueB32(Enabled, endianess);
		}

		public override void Deserialize(Stream input, Endian endianess)
		{
			base.Deserialize(input, endianess);
			Enabled = input.ReadValueB32(endianess);
		}
	}
}
