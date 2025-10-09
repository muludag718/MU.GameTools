using System.IO;
using MU.GameTools.IO;

namespace MU.GameTools.Prototype.Fight.Prototype1.Track
{
	[KnownTrack(TrackHash.SpawnCopsBesideCar)]
	public class SpawnCopsBesideCarTrack : P1Track
	{
		public float TimeBegin { get; set; }

		public float TimeEnd { get; set; }

		public float XOffset { get; set; }

		public override void Serialize(Stream output, Endian endianess)
		{
			base.Serialize(output, endianess);
			output.WriteValueF32(TimeBegin, endianess);
			output.WriteValueF32(TimeEnd, endianess);
			output.WriteValueF32(XOffset, endianess);
		}

		public override void Deserialize(Stream input, Endian endianess)
		{
			base.Deserialize(input, endianess);
			TimeBegin = input.ReadValueF32(endianess);
			TimeEnd = input.ReadValueF32(endianess);
			XOffset = input.ReadValueF32(endianess);
		}
	}
}
