using System.IO;
using MU.GameTools.IO;

namespace MU.GameTools.Prototype.Fight.Prototype1.Track
{
	[KnownNodeForContext(ContextHash.Motion)]
	[KnownTrack(TrackHash.ThreatSendToTarget)]
	public class ThreatSendToTargetTrack : P1Track
	{
		public ulong ThreatName { get; set; }

		public ulong ThrownObjectFromGrabSlot { get; set; }

		public float TimeBegin { get; set; }

		public float TimeEnd { get; set; }

		public override void Serialize(Stream output, Endian endianess)
		{
			base.Serialize(output, endianess);
			output.WriteValueU64(ThreatName, endianess);
			output.WriteValueU64(ThrownObjectFromGrabSlot, endianess);
			output.WriteValueF32(TimeBegin, endianess);
			output.WriteValueF32(TimeEnd, endianess);
		}

		public override void Deserialize(Stream input, Endian endianess)
		{
			base.Deserialize(input, endianess);
			ThreatName = input.ReadValueU64(endianess);
			ThrownObjectFromGrabSlot = input.ReadValueU64(endianess);
			TimeBegin = input.ReadValueF32(endianess);
			TimeEnd = input.ReadValueF32(endianess);
		}
	}
}
