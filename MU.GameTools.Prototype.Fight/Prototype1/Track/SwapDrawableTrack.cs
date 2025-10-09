using System.IO;
using MU.GameTools.IO;

namespace MU.GameTools.Prototype.Fight.Prototype1.Track
{
	[KnownTrack(TrackHash.SwapDrawable)]
	public class SwapDrawableTrack : P1Track
	{
		public ulong ObjectName { get; set; }

		public ulong DrawableName { get; set; }

		public bool Persistent { get; set; }

		public override void Serialize(Stream output, Endian endianess)
		{
			base.Serialize(output, endianess);
			output.WriteValueU64(ObjectName, endianess);
			output.WriteValueU64(DrawableName, endianess);
			output.WriteValueB32(Persistent, endianess);
		}

		public override void Deserialize(Stream input, Endian endianess)
		{
			base.Deserialize(input, endianess);
			ObjectName = input.ReadValueU64(endianess);
			DrawableName = input.ReadValueU64(endianess);
			Persistent = input.ReadValueB32(endianess);
		}
	}
}
