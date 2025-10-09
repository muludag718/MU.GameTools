using System.IO;
using MU.GameTools.IO;

namespace MU.GameTools.Prototype.Fight.Prototype1.Track
{
	[KnownTrack(TrackHash.TimerContinousSet)]
	public class TimerContinousSetTrack : P1Track
	{
		public float TimeBegin { get; set; }

		public float TimeEnd { get; set; }

		public ulong Timer { get; set; }

		public float Time { get; set; }

		public bool Incrementing { get; set; }

		public float RandomRange { get; set; }

		public override void Serialize(Stream output, Endian endianess)
		{
			base.Serialize(output, endianess);
			output.WriteValueF32(TimeBegin, endianess);
			output.WriteValueF32(TimeEnd, endianess);
			output.WriteValueU64(Timer, endianess);
			output.WriteValueF32(Time, endianess);
			output.WriteValueB32(Incrementing, endianess);
			output.WriteValueF32(RandomRange, endianess);
		}

		public override void Deserialize(Stream input, Endian endianess)
		{
			base.Deserialize(input, endianess);
			TimeBegin = input.ReadValueF32(endianess);
			TimeEnd = input.ReadValueF32(endianess);
			Timer = input.ReadValueU64(endianess);
			Time = input.ReadValueF32(endianess);
			Incrementing = input.ReadValueB32(endianess);
			RandomRange = input.ReadValueF32(endianess);
		}
	}
}
