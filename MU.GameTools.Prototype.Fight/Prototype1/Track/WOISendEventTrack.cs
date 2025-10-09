using System.IO;
using MU.GameTools.IO;

namespace MU.GameTools.Prototype.Fight.Prototype1.Track
{
	[KnownNodeForContext(ContextHash.Motion)]
	[KnownTrack(TrackHash.WOISendEvent)]
	public class WOISendEventTrack : P1Track
	{
		public float TimeBegin { get; set; }

		public bool ToScenario { get; set; }

		public bool ToFrontend { get; set; }

		public override void Serialize(Stream output, Endian endianess)
		{
			base.Serialize(output, endianess);
			output.WriteValueF32(TimeBegin, endianess);
			output.WriteValueB32(ToScenario, endianess);
			output.WriteValueB32(ToFrontend, endianess);
		}

		public override void Deserialize(Stream input, Endian endianess)
		{
			base.Deserialize(input, endianess);
			TimeBegin = input.ReadValueF32(endianess);
			ToScenario = input.ReadValueB32(endianess);
			ToFrontend = input.ReadValueB32(endianess);
		}
	}
}
