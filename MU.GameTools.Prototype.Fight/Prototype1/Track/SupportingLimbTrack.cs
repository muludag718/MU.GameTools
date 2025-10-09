using System.IO;
using MU.GameTools.IO;

namespace MU.GameTools.Prototype.Fight.Prototype1.Track
{
	[KnownNodeForContext(ContextHash.Motion)]
	[KnownTrack(TrackHash.SupportingLimb)]
	public class SupportingLimbTrack : P1Track
	{
		public float TimeBegin { get; set; }

		public ulong SupportingLimb { get; set; }

		public Vector Direction { get; set; } = new Vector();

		public override void Serialize(Stream output, Endian endianess)
		{
			base.Serialize(output, endianess);
			output.WriteValueF32(TimeBegin, endianess);
			output.WriteValueU64(SupportingLimb, endianess);
			Direction.Serialize(output, endianess);
		}

		public override void Deserialize(Stream input, Endian endianess)
		{
			base.Deserialize(input, endianess);
			TimeBegin = input.ReadValueF32(endianess);
			SupportingLimb = input.ReadValueU64(endianess);
			Direction = new Vector(input, endianess);
		}
	}
}
