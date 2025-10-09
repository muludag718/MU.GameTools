using System.IO;
using MU.GameTools.IO;

namespace MU.GameTools.Prototype.Fight.Prototype1.Track
{
	[KnownTrack(TrackHash.SubTitle)]
	public class SubTitleTrack : P1Track
	{
		public float TimeBegin { get; set; }

		public float TimeEnd { get; set; }

		public string SubTitle { get; set; }

		public string SubTitleType { get; set; }

		public string Speaker { get; set; }

		public override void Serialize(Stream output, Endian endianess)
		{
			base.Serialize(output, endianess);
			output.WriteValueF32(TimeBegin, endianess);
			output.WriteValueF32(TimeEnd, endianess);
			output.WriteStringAlignedU32(SubTitle, endianess);
			output.WriteStringAlignedU32(SubTitleType, endianess);
			output.WriteStringAlignedU32(Speaker, endianess);
		}

		public override void Deserialize(Stream input, Endian endianess)
		{
			base.Deserialize(input, endianess);
			TimeBegin = input.ReadValueF32(endianess);
			TimeEnd = input.ReadValueF32(endianess);
			SubTitle = input.ReadStringAlignedU32(endianess);
			SubTitleType = input.ReadStringAlignedU32(endianess);
			Speaker = input.ReadStringAlignedU32(endianess);
		}
	}
}
