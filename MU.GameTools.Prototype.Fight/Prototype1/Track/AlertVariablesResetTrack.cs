using System.IO;
using MU.GameTools.IO;

namespace MU.GameTools.Prototype.Fight.Prototype1.Track
{
	[KnownNodeForContext(ContextHash.Alert)]
	[KnownTrack(TrackHash.AlertVariablesReset)]
	public class AlertVariablesResetTrack : P1Track
	{
		public float TimeBegin { get; set; }

		public float TimeEnd { get; set; }

		public bool ResetJustTime { get; set; }

		public bool DontResetFactionIfSniffer { get; set; }

		public override void Serialize(Stream output, Endian endianess)
		{
			base.Serialize(output, endianess);
			output.WriteValueF32(TimeBegin, endianess);
			output.WriteValueF32(TimeEnd, endianess);
			output.WriteValueB32(ResetJustTime, endianess);
			output.WriteValueB32(DontResetFactionIfSniffer, endianess);
		}

		public override void Deserialize(Stream input, Endian endianess)
		{
			base.Deserialize(input, endianess);
			TimeBegin = input.ReadValueF32(endianess);
			TimeEnd = input.ReadValueF32(endianess);
			ResetJustTime = input.ReadValueB32(endianess);
			DontResetFactionIfSniffer = input.ReadValueB32(endianess);
		}
	}
}
