using System.IO;
using MU.GameTools.IO;

namespace MU.GameTools.Prototype.Fight.Prototype1.Track
{
	[KnownTrack(TrackHash.AnchorToGround)]
	public class AnchorToGroundTrack : P1Track
	{
		public float TimeBegin { get; set; }

		public bool Anchor { get; set; }

		public bool GroundLevel { get; set; }

		public override void Serialize(Stream output, Endian endianess)
		{
			base.Serialize(output, endianess);
			output.WriteValueF32(TimeBegin, endianess);
			output.WriteValueB32(Anchor, endianess);
			output.WriteValueB32(GroundLevel, endianess);
		}

		public override void Deserialize(Stream input, Endian endianess)
		{
			base.Deserialize(input, endianess);
			TimeBegin = input.ReadValueF32(endianess);
			Anchor = input.ReadValueB32(endianess);
			GroundLevel = input.ReadValueB32(endianess);
		}
	}
}
