using System.IO;
using MU.GameTools.IO;

namespace MU.GameTools.Prototype.Fight.Prototype1.Track
{
	[KnownTrack(TrackHash.DepthOfField)]
	public class DepthOfFieldTrack : P1Track
	{
		public float TimeBegin { get; set; }

		public bool Enable { get; set; }

		public bool BlendFromPreviousState { get; set; }

		public float NearDepth { get; set; }

		public float FarDepth { get; set; }

		public float Range { get; set; }

		public float Aperture { get; set; }

		public override void Serialize(Stream output, Endian endianess)
		{
			base.Serialize(output, endianess);
			output.WriteValueF32(TimeBegin, endianess);
			output.WriteValueB32(Enable, endianess);
			output.WriteValueB32(BlendFromPreviousState, endianess);
			output.WriteValueF32(NearDepth, endianess);
			output.WriteValueF32(FarDepth, endianess);
			output.WriteValueF32(Range, endianess);
			output.WriteValueF32(Aperture, endianess);
		}

		public override void Deserialize(Stream input, Endian endianess)
		{
			base.Deserialize(input, endianess);
			TimeBegin = input.ReadValueF32(endianess);
			Enable = input.ReadValueB32(endianess);
			BlendFromPreviousState = input.ReadValueB32(endianess);
			NearDepth = input.ReadValueF32(endianess);
			FarDepth = input.ReadValueF32(endianess);
			Range = input.ReadValueF32(endianess);
			Aperture = input.ReadValueF32(endianess);
		}
	}
}
