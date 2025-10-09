using System.IO;
using MU.GameTools.IO;

namespace MU.GameTools.Prototype.Fight.Prototype1.Track
{
	[KnownTrack(TrackHash.Playback)]
	public class PlaybackTrack : P1Track
	{
		public float TimeBegin { get; set; }

		public ulong State { get; set; }

		public ulong SpecificPlaybackSet { get; set; }

		public bool NotifyOnPlaybackFinished { get; set; }

		public override void Serialize(Stream output, Endian endianess)
		{
			base.Serialize(output, endianess);
			output.WriteValueF32(TimeBegin, endianess);
			output.WriteValueU64(State, endianess);
			output.WriteValueU64(SpecificPlaybackSet, endianess);
			output.WriteValueB32(NotifyOnPlaybackFinished, endianess);
		}

		public override void Deserialize(Stream input, Endian endianess)
		{
			base.Deserialize(input, endianess);
			TimeBegin = input.ReadValueF32(endianess);
			State = input.ReadValueU64(endianess);
			SpecificPlaybackSet = input.ReadValueU64(endianess);
			NotifyOnPlaybackFinished = input.ReadValueB32(endianess);
		}
	}
}
