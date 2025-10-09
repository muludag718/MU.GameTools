using System.IO;
using MU.GameTools.IO;

namespace MU.GameTools.Prototype.Fight.Prototype1.Track
{
	[KnownTrack(TrackHash.DisableMotionTrackedExpression)]
	public class DisableMotionTrackedExpressionTrack : P1Track
	{
		public float TimeBegin { get; set; }

		public float BlendDuration { get; set; }

		public override void Serialize(Stream output, Endian endianess)
		{
			base.Serialize(output, endianess);
			output.WriteValueF32(TimeBegin, endianess);
			output.WriteValueF32(BlendDuration, endianess);
		}

		public override void Deserialize(Stream input, Endian endianess)
		{
			base.Deserialize(input, endianess);
			TimeBegin = input.ReadValueF32(endianess);
			BlendDuration = input.ReadValueF32(endianess);
		}
	}
}
