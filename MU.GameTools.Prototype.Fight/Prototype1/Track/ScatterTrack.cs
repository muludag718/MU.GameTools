using System.IO;
using MU.GameTools.IO;

namespace MU.GameTools.Prototype.Fight.Prototype1.Track
{
	[KnownTrack(TrackHash.Scatter)]
	public class ScatterTrack : P1Track
	{
		public float TimeBegin { get; set; }

		public bool Enable { get; set; }

		public bool BlendFromPreviousState { get; set; }

		public Color ScatterColour { get; set; } = new Color();

		public float SaturationMin { get; set; }

		public float SaturationMax { get; set; }

		public float ContrastMin { get; set; }

		public float ContrastMax { get; set; }

		public float BrightnessMin { get; set; }

		public float BrightnessMax { get; set; }

		public float TintMin { get; set; }

		public float TintMax { get; set; }

		public float DistanceBrightening { get; set; }

		public float ContrastDropoff { get; set; }

		public override void Serialize(Stream output, Endian endianess)
		{
			base.Serialize(output, endianess);
			output.WriteValueF32(TimeBegin, endianess);
			output.WriteValueB32(Enable, endianess);
			output.WriteValueB32(BlendFromPreviousState, endianess);
			ScatterColour.Serialize(output, endianess);
			output.WriteValueF32(SaturationMin, endianess);
			output.WriteValueF32(SaturationMax, endianess);
			output.WriteValueF32(ContrastMin, endianess);
			output.WriteValueF32(ContrastMax, endianess);
			output.WriteValueF32(BrightnessMin, endianess);
			output.WriteValueF32(BrightnessMax, endianess);
			output.WriteValueF32(TintMin, endianess);
			output.WriteValueF32(TintMax, endianess);
			output.WriteValueF32(DistanceBrightening, endianess);
			output.WriteValueF32(ContrastDropoff, endianess);
		}

		public override void Deserialize(Stream input, Endian endianess)
		{
			base.Deserialize(input, endianess);
			TimeBegin = input.ReadValueF32(endianess);
			Enable = input.ReadValueB32(endianess);
			BlendFromPreviousState = input.ReadValueB32(endianess);
			ScatterColour.Deserialize(input, endianess);
			SaturationMin = input.ReadValueF32(endianess);
			SaturationMax = input.ReadValueF32(endianess);
			ContrastMin = input.ReadValueF32(endianess);
			ContrastMax = input.ReadValueF32(endianess);
			BrightnessMin = input.ReadValueF32(endianess);
			BrightnessMax = input.ReadValueF32(endianess);
			TintMin = input.ReadValueF32(endianess);
			TintMax = input.ReadValueF32(endianess);
			DistanceBrightening = input.ReadValueF32(endianess);
			ContrastDropoff = input.ReadValueF32(endianess);
		}
	}
}
