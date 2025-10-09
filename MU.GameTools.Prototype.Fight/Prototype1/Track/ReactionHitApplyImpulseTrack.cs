using System.IO;
using MU.GameTools.IO;

namespace MU.GameTools.Prototype.Fight.Prototype1.Track
{
	[KnownNodeForContext(ContextHash.Motion)]
	[KnownTrack(TrackHash.ReactionHitApplyImpulse)]
	public class ReactionHitApplyImpulseTrack : P1Track
	{
		public float TimeBegin { get; set; }

		public float ImpulseScale { get; set; }

		public override void Serialize(Stream output, Endian endianess)
		{
			base.Serialize(output, endianess);
			output.WriteValueF32(TimeBegin, endianess);
			output.WriteValueF32(ImpulseScale, endianess);
		}

		public override void Deserialize(Stream input, Endian endianess)
		{
			base.Deserialize(input, endianess);
			TimeBegin = input.ReadValueF32(endianess);
			ImpulseScale = input.ReadValueF32(endianess);
		}
	}
}
