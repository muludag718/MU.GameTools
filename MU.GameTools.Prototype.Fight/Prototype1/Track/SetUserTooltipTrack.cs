using System.IO;
using MU.GameTools.IO;

namespace MU.GameTools.Prototype.Fight.Prototype1.Track
{
	[KnownTrack(TrackHash.SetUserTooltip)]
	public class SetUserTooltipTrack : P1Track
	{
		public float TimeBegin { get; set; }

		public string Tooltip { get; set; }

		public override void Serialize(Stream output, Endian endianess)
		{
			base.Serialize(output, endianess);
			output.WriteValueF32(TimeBegin, endianess);
			output.WriteStringAlignedU32(Tooltip, endianess);
		}

		public override void Deserialize(Stream input, Endian endianess)
		{
			base.Deserialize(input, endianess);
			TimeBegin = input.ReadValueF32(endianess);
			Tooltip = input.ReadStringAlignedU32(endianess);
		}
	}
}
