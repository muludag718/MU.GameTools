using System.IO;
using MU.GameTools.IO;

namespace MU.GameTools.Prototype.Fight.Prototype1.Track
{
	[KnownNodeForContext(ContextHash.Motion)]
	[KnownTrack(TrackHash.SupportingSurfaceStick)]
	public class SupportingSurfaceStickTrack : P1Track
	{
		public float TimeBegin { get; set; }

		public float TimeEnd { get; set; }

		public bool StickToSupportingSurface { get; set; }

		public bool ResetOrientationDelta { get; set; }

		public bool ResetLimbSmoothing { get; set; }

		public bool RestoreOnEnd { get; set; }

		public override void Serialize(Stream output, Endian endianess)
		{
			base.Serialize(output, endianess);
			output.WriteValueF32(TimeBegin, endianess);
			output.WriteValueF32(TimeEnd, endianess);
			output.WriteValueB32(StickToSupportingSurface, endianess);
			output.WriteValueB32(ResetOrientationDelta, endianess);
			output.WriteValueB32(ResetLimbSmoothing, endianess);
			output.WriteValueB32(RestoreOnEnd, endianess);
		}

		public override void Deserialize(Stream input, Endian endianess)
		{
			base.Deserialize(input, endianess);
			TimeBegin = input.ReadValueF32(endianess);
			TimeEnd = input.ReadValueF32(endianess);
			StickToSupportingSurface = input.ReadValueB32(endianess);
			ResetOrientationDelta = input.ReadValueB32(endianess);
			ResetLimbSmoothing = input.ReadValueB32(endianess);
			RestoreOnEnd = input.ReadValueB32(endianess);
		}
	}
}
