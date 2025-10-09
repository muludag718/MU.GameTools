using System.IO;
using MU.GameTools.IO;

namespace MU.GameTools.Prototype.Fight.Prototype1.Track
{
	[KnownNodeForContext(ContextHash.Motion)]
	[KnownTrack(TrackHash.Reload)]
	public class ReloadTrack : P1Track
	{
		public bool ApplyOnParent { get; set; }

		public ulong GrabSlot { get; set; }

		public ulong AmmoProfile { get; set; }

		public override void Serialize(Stream output, Endian endianess)
		{
			base.Serialize(output, endianess);
			output.WriteValueB32(ApplyOnParent, endianess);
			output.WriteValueU64(GrabSlot, endianess);
			output.WriteValueU64(AmmoProfile, endianess);
		}

		public override void Deserialize(Stream input, Endian endianess)
		{
			base.Deserialize(input, endianess);
			ApplyOnParent = input.ReadValueB32(endianess);
			GrabSlot = input.ReadValueU64(endianess);
			AmmoProfile = input.ReadValueU64(endianess);
		}
	}
}
