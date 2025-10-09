using System.IO;
using MU.GameTools.IO;

namespace MU.GameTools.Prototype.Fight.Prototype1.Track
{
	[KnownNodeForContext(ContextHash.Motion)]
	[KnownTrack(TrackHash.ScenarioStringEvent)]
	public class ScenarioStringEventTrack : P1Track
	{
		public float TimeBegin { get; set; }

		public ulong String { get; set; }

		public bool TutorialOnly { get; set; }

		public override void Serialize(Stream output, Endian endianess)
		{
			base.Serialize(output, endianess);
			output.WriteValueF32(TimeBegin, endianess);
			output.WriteValueU64(String, endianess);
			output.WriteValueB32(TutorialOnly, endianess);
		}

		public override void Deserialize(Stream input, Endian endianess)
		{
			base.Deserialize(input, endianess);
			TimeBegin = input.ReadValueF32(endianess);
			String = input.ReadValueU64(endianess);
			TutorialOnly = input.ReadValueB32(endianess);
		}
	}
}
