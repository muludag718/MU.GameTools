using System.IO;
using MU.GameTools.IO;

namespace MU.GameTools.Prototype.Fight.Prototype1.Track
{
	[KnownTrack(TrackHash.Print)]
	public class PrintTrack : P1Track
	{
		public float TimeBegin { get; set; }

		public string Channel { get; set; }

		public string Text { get; set; }

		public override void Serialize(Stream output, Endian endianess)
		{
			base.Serialize(output, endianess);
			output.WriteValueF32(TimeBegin, endianess);
			output.WriteStringAlignedU32(Channel, endianess);
			output.WriteStringAlignedU32(Text, endianess);
		}

		public override void Deserialize(Stream input, Endian endianess)
		{
			base.Deserialize(input, endianess);
			TimeBegin = input.ReadValueF32(endianess);
			Channel = input.ReadStringAlignedU32(endianess);
			Text = input.ReadStringAlignedU32(endianess);
		}
	}
}
