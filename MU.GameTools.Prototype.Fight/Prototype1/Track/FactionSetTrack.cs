using System.IO;
using MU.GameTools.IO;

namespace MU.GameTools.Prototype.Fight.Prototype1.Track
{
	[KnownNodeForContext(ContextHash.Motion)]
	[KnownTrack(TrackHash.FactionSet)]
	public class FactionSetTrack : P1Track
	{
		public float TimeBegin { get; set; }

		public ulong Faction { get; set; }

		public bool NotifyAI { get; set; }

		public override void Serialize(Stream output, Endian endianess)
		{
			base.Serialize(output, endianess);
			output.WriteValueF32(TimeBegin, endianess);
			output.WriteValueU64(Faction, endianess);
			output.WriteValueB32(NotifyAI, endianess);
		}

		public override void Deserialize(Stream input, Endian endianess)
		{
			base.Deserialize(input, endianess);
			TimeBegin = input.ReadValueF32(endianess);
			Faction = input.ReadValueU64(endianess);
			NotifyAI = input.ReadValueB32(endianess);
		}
	}
}
