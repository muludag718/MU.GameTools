using System.IO;
using MU.GameTools.IO;

namespace MU.GameTools.Prototype.Fight.Prototype1.Track
{
	[KnownTrack(TrackHash.ColourMatrix)]
	public class ColourMatrixTrack : P1Track
	{
		public float TimeBegin { get; set; }

		public bool Enable { get; set; }

		public bool BlendFromPreviousState { get; set; }

		public float Brightness { get; set; }

		public float Contrast { get; set; }

		public float Midpoint { get; set; }

		public float Saturate { get; set; }

		public float Hue { get; set; }

		public Color Tint { get; set; } = new Color();

		public override void Serialize(Stream output, Endian endianess)
		{
			base.Serialize(output, endianess);
			output.WriteValueF32(TimeBegin, endianess);
			output.WriteValueB32(Enable, endianess);
			output.WriteValueB32(BlendFromPreviousState, endianess);
			output.WriteValueF32(Brightness, endianess);
			output.WriteValueF32(Contrast, endianess);
			output.WriteValueF32(Midpoint, endianess);
			output.WriteValueF32(Saturate, endianess);
			output.WriteValueF32(Hue, endianess);
			Tint.Serialize(output, endianess);
		}

		public override void Deserialize(Stream input, Endian endianess)
		{
			base.Deserialize(input, endianess);
			TimeBegin = input.ReadValueF32(endianess);
			Enable = input.ReadValueB32(endianess);
			BlendFromPreviousState = input.ReadValueB32(endianess);
			Brightness = input.ReadValueF32(endianess);
			Contrast = input.ReadValueF32(endianess);
			Midpoint = input.ReadValueF32(endianess);
			Saturate = input.ReadValueF32(endianess);
			Hue = input.ReadValueF32(endianess);
			Tint.Deserialize(input, endianess);
		}
	}
}
