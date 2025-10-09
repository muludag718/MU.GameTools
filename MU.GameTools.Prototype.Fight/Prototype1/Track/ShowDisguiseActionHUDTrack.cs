using System.IO;
using MU.GameTools.IO;

namespace MU.GameTools.Prototype.Fight.Prototype1.Track
{
	[KnownNodeForContext(ContextHash.Motion)]
	[KnownTrack(TrackHash.ShowDisguiseActionHUD)]
	public class ShowDisguiseActionHUDTrack : P1Track
	{
		public float TimeBegin { get; set; }

		public float TimeEnd { get; set; }

		public bool ShowAndHideOnly { get; set; }

		public bool StealthConsumeInRange { get; set; }

		public bool StealthConsumeUsable { get; set; }

		public bool PatsyUsable { get; set; }

		public bool AirStrikeUsable { get; set; }

		public override void Serialize(Stream output, Endian endianess)
		{
			base.Serialize(output, endianess);
			output.WriteValueF32(TimeBegin, endianess);
			output.WriteValueF32(TimeEnd, endianess);
			output.WriteValueB32(ShowAndHideOnly, endianess);
			output.WriteValueB32(StealthConsumeInRange, endianess);
			output.WriteValueB32(StealthConsumeUsable, endianess);
			output.WriteValueB32(PatsyUsable, endianess);
			output.WriteValueB32(AirStrikeUsable, endianess);
		}

		public override void Deserialize(Stream input, Endian endianess)
		{
			base.Deserialize(input, endianess);
			TimeBegin = input.ReadValueF32(endianess);
			TimeEnd = input.ReadValueF32(endianess);
			ShowAndHideOnly = input.ReadValueB32(endianess);
			StealthConsumeInRange = input.ReadValueB32(endianess);
			StealthConsumeUsable = input.ReadValueB32(endianess);
			PatsyUsable = input.ReadValueB32(endianess);
			AirStrikeUsable = input.ReadValueB32(endianess);
		}
	}
}
