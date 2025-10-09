using System.IO;
using MU.GameTools.IO;

namespace MU.GameTools.Prototype.Fight.Prototype1.Track
{
	[KnownNodeForContext(ContextHash.Motion)]
	[KnownTrack(TrackHash.SlowMotion)]
	public class SlowmotionTrack : P1Track
	{
		public float BeginTime { get; set; }

		public float EndTime { get; set; }

		public float SimulationRate { get; set; }

		public float FadeInTime { get; set; }

		public float SimulationDuration { get; set; }

		public float FadeOutTime { get; set; }

		public bool Realtime { get; set; }

		public bool AbortOnEnd { get; set; }

		public override void Serialize(Stream output, Endian endianess)
		{
			base.Serialize(output, endianess);
			output.WriteValueF32(BeginTime, endianess);
			output.WriteValueF32(EndTime, endianess);
			output.WriteValueF32(SimulationRate, endianess);
			output.WriteValueF32(FadeInTime, endianess);
			output.WriteValueF32(SimulationDuration, endianess);
			output.WriteValueF32(FadeOutTime, endianess);
			output.WriteValueB32(Realtime, endianess);
			output.WriteValueB32(AbortOnEnd, endianess);
		}

		public override void Deserialize(Stream input, Endian endianess)
		{
			base.Deserialize(input, endianess);
			BeginTime = input.ReadValueF32(endianess);
			EndTime = input.ReadValueF32(endianess);
			SimulationRate = input.ReadValueF32(endianess);
			FadeInTime = input.ReadValueF32(endianess);
			SimulationDuration = input.ReadValueF32(endianess);
			FadeOutTime = input.ReadValueF32(endianess);
			Realtime = input.ReadValueB32(endianess);
			AbortOnEnd = input.ReadValueB32(endianess);
		}
	}
}
