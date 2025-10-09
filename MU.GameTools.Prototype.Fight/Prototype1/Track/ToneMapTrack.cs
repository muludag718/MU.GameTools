using System.IO;
using MU.GameTools.IO;

namespace MU.GameTools.Prototype.Fight.Prototype1.Track
{
	[KnownTrack(TrackHash.ToneMap)]
	public class ToneMapTrack : P1Track
	{
		public float TimeBegin { get; set; }

		public bool Enable { get; set; }

		public bool BlendFromPreviousState { get; set; }

		public float AdaptRate { get; set; }

		public float AverageLuminanceTarget { get; set; }

		public override void Serialize(Stream output, Endian endianess)
		{
			base.Serialize(output, endianess);
			output.WriteValueF32(TimeBegin, endianess);
			output.WriteValueB32(Enable, endianess);
			output.WriteValueB32(BlendFromPreviousState, endianess);
			output.WriteValueF32(AdaptRate, endianess);
			output.WriteValueF32(AverageLuminanceTarget, endianess);
		}

		public override void Deserialize(Stream input, Endian endianess)
		{
			base.Deserialize(input, endianess);
			TimeBegin = input.ReadValueF32(endianess);
			Enable = input.ReadValueB32(endianess);
			BlendFromPreviousState = input.ReadValueB32(endianess);
			AdaptRate = input.ReadValueF32(endianess);
			AverageLuminanceTarget = input.ReadValueF32(endianess);
		}
	}
}
