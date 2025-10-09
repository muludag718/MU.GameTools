using System.IO;
using MU.GameTools.IO;

namespace MU.GameTools.Prototype.Fight.Prototype1.Track
{
	[KnownTrack(TrackHash.UndergroundSet)]
	public class UndergroundSetTrack : P1Track
	{
		public float TimeBegin { get; set; }

		public bool Underground { get; set; }

		public bool Instantaneous { get; set; }

		public override void Serialize(Stream output, Endian endianess)
		{
			base.Serialize(output, endianess);
			output.WriteValueF32(TimeBegin, endianess);
			output.WriteValueB32(Underground, endianess);
			output.WriteValueB32(Instantaneous, endianess);
		}

		public override void Deserialize(Stream input, Endian endianess)
		{
			base.Deserialize(input, endianess);
			TimeBegin = input.ReadValueF32(endianess);
			Underground = input.ReadValueB32(endianess);
			Instantaneous = input.ReadValueB32(endianess);
		}
	}
}
