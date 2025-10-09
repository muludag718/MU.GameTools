using System.IO;
using MU.GameTools.IO;

namespace MU.GameTools.Prototype.Fight.Prototype1.Track
{
	[KnownNodeForContext(ContextHash.Motion)]
	[KnownTrack(TrackHash.GrabSetGrabbingTimer)]
	public class GrabSetGrabbingTimerTrack : P1Track
	{
		public float Duration { get; set; }

		public bool IsGrabAttack { get; set; }

		public override void Serialize(Stream output, Endian endianess)
		{
			base.Serialize(output, endianess);
			output.WriteValueF32(Duration, endianess);
			output.WriteValueB32(IsGrabAttack, endianess);
		}

		public override void Deserialize(Stream input, Endian endianess)
		{
			base.Deserialize(input, endianess);
			Duration = input.ReadValueF32(endianess);
			IsGrabAttack = input.ReadValueB32(endianess);
		}
	}
}
