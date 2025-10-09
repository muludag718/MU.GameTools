using System.IO;
using MU.GameTools.IO;

namespace MU.GameTools.Prototype.Fight.Prototype1.Track
{
	[KnownNodeForContext(ContextHash.Motion)]
	[KnownTrack(TrackHash.WhipFistRetract)]
	public class WhipFistRetractTrack : P1Track
	{
		public float TimeBegin { get; set; }

		public float TimeEnd { get; set; }

		public float Velocity { get; set; }

		public float SoundLeadTime { get; set; }

		public int MinSegmentsRemaining { get; set; }

		public override void Serialize(Stream output, Endian endianess)
		{
			base.Serialize(output, endianess);
			output.WriteValueF32(TimeBegin, endianess);
			output.WriteValueF32(TimeEnd, endianess);
			output.WriteValueF32(Velocity, endianess);
			output.WriteValueF32(SoundLeadTime, endianess);
			output.WriteValueS32(MinSegmentsRemaining, endianess);
		}

		public override void Deserialize(Stream input, Endian endianess)
		{
			base.Deserialize(input, endianess);
			TimeBegin = input.ReadValueF32(endianess);
			TimeEnd = input.ReadValueF32(endianess);
			Velocity = input.ReadValueF32(endianess);
			SoundLeadTime = input.ReadValueF32(endianess);
			MinSegmentsRemaining = input.ReadValueS32(endianess);
		}
	}
}
