using System.IO;
using MU.GameTools.IO;

namespace MU.GameTools.Prototype.Fight.Prototype1.Track
{
	[KnownNodeForContext(ContextHash.Scenario)]
	[KnownTrack(TrackHash.PackageLoad)]
	public class PackageLoadTrack : P1Track
	{
		public string PackageName { get; set; }

		public bool Async { get; set; }

		public override void Serialize(Stream output, Endian endianess)
		{
			base.Serialize(output, endianess);
			output.WriteStringAlignedU32(PackageName, endianess);
			output.WriteValueB32(Async, endianess);
		}

		public override void Deserialize(Stream input, Endian endianess)
		{
			base.Deserialize(input, endianess);
			PackageName = input.ReadStringAlignedU32(endianess);
			Async = input.ReadValueB32(endianess);
		}
	}
}
