using System.IO;
using MU.GameTools.IO;

namespace MU.GameTools.Prototype.Fight.Prototype1.Track
{
	[KnownNodeForContext(ContextHash.Scenario)]
	[KnownNodeForContext(ContextHash.Motion)]
	[KnownTrack(TrackHash.Wait)]
	public class WaitTrack : P1Track
	{
		public float TimeBegin { get; set; }

		public float TimeEndMin { get; set; }

		public float TimeEndMax { get; set; }

		public override void Serialize(Stream output, Endian endianess)
		{
			base.Serialize(output, endianess);
			output.WriteValueF32(TimeBegin, endianess);
			output.WriteValueF32(TimeEndMin, endianess);
			output.WriteValueF32(TimeEndMax, endianess);
		}

		public override void Deserialize(Stream input, Endian endianess)
		{
			base.Deserialize(input, endianess);
			TimeBegin = input.ReadValueF32(endianess);
			TimeEndMin = input.ReadValueF32(endianess);
			TimeEndMax = input.ReadValueF32(endianess);
		}
	}
}
