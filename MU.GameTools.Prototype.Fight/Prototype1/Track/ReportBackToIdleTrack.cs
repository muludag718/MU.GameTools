using System.IO;
using MU.GameTools.IO;

namespace MU.GameTools.Prototype.Fight.Prototype1.Track
{
	[KnownNodeForContext(ContextHash.Alert)]
	[KnownTrack(TrackHash.ReportBackToIdle)]
	public class ReportBackToIdleTrack : P1Track
	{
		public float TimeBegin { get; set; }

		public bool Evade { get; set; }

		public override void Serialize(Stream output, Endian endianess)
		{
			base.Serialize(output, endianess);
			output.WriteValueF32(TimeBegin, endianess);
			output.WriteValueB32(Evade, endianess);
		}

		public override void Deserialize(Stream input, Endian endianess)
		{
			base.Deserialize(input, endianess);
			TimeBegin = input.ReadValueF32(endianess);
			Evade = input.ReadValueB32(endianess);
		}
	}
}
