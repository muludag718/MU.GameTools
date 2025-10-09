using System.IO;
using MU.GameTools.IO;

namespace MU.GameTools.Prototype.Fight.Prototype1.Track
{
	[KnownTrack(TrackHash.StartStrikeTeamMeter)]
	public class StartStrikeTeamMeterTrack : P1Track
	{
		public float TimeBegin { get; set; }

		public float TimeToSpawn { get; set; }

		public override void Serialize(Stream output, Endian endianess)
		{
			base.Serialize(output, endianess);
			output.WriteValueF32(TimeBegin, endianess);
			output.WriteValueF32(TimeToSpawn, endianess);
		}

		public override void Deserialize(Stream input, Endian endianess)
		{
			base.Deserialize(input, endianess);
			TimeBegin = input.ReadValueF32(endianess);
			TimeToSpawn = input.ReadValueF32(endianess);
		}
	}
}
