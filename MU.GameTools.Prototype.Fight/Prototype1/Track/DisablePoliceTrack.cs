using System.IO;
using MU.GameTools.IO;

namespace MU.GameTools.Prototype.Fight.Prototype1.Track
{
	[KnownTrack(TrackHash.DisablePolice)]
	public class DisablePoliceTrack : P1Track
	{
		public float TimeBegin { get; set; }

		public bool Disable { get; set; }

		public float Delay { get; set; }

		public override void Serialize(Stream output, Endian endianess)
		{
			base.Serialize(output, endianess);
			output.WriteValueF32(TimeBegin, endianess);
			output.WriteValueB32(Disable, endianess);
			output.WriteValueF32(Delay, endianess);
		}

		public override void Deserialize(Stream input, Endian endianess)
		{
			base.Deserialize(input, endianess);
			TimeBegin = input.ReadValueF32(endianess);
			Disable = input.ReadValueB32(endianess);
			Delay = input.ReadValueF32(endianess);
		}
	}
}
