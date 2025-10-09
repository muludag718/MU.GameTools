using System.IO;
using MU.GameTools.IO;

namespace MU.GameTools.Prototype.Fight.Prototype1.Track
{
	[KnownTrack(TrackHash.Light)]
	public class LightTrack : P1Track
	{
		public float TimeBegin { get; set; }

		public float TimeEnd { get; set; }

		public ulong LightName { get; set; }

		public int Colour { get; set; }

		public Color ColourColour { get; set; } = new Color();

		public int Intensity { get; set; }

		public float IntensityIntensity { get; set; }

		public int ShadowCaster { get; set; }

		public float ShadowCasterShadowOffset { get; set; }

		public float ShadowCasterRangeMultiplier { get; set; }

		public float ShadowCasterRadiusMultiplier { get; set; }

		public float ShadowCasterMaxRadius { get; set; }

		public int Umbra { get; set; }

		public float UmbraUmbra { get; set; }

		public float UmbraPenumbra { get; set; }

		public int Decay { get; set; }

		public float DecayInner { get; set; }

		public float DecayOuter { get; set; }

		public override void Serialize(Stream output, Endian endianess)
		{
			base.Serialize(output, endianess);
			output.WriteValueF32(TimeBegin, endianess);
			output.WriteValueF32(TimeEnd, endianess);
			output.WriteValueU64(LightName, endianess);
			output.WriteValueS32(Colour, endianess);
			ColourColour.Serialize(output, endianess);
			output.WriteValueS32(Intensity, endianess);
			output.WriteValueF32(IntensityIntensity, endianess);
			output.WriteValueS32(ShadowCaster, endianess);
			output.WriteValueF32(ShadowCasterShadowOffset, endianess);
			output.WriteValueF32(ShadowCasterRangeMultiplier, endianess);
			output.WriteValueF32(ShadowCasterRadiusMultiplier, endianess);
			output.WriteValueF32(ShadowCasterMaxRadius, endianess);
			output.WriteValueS32(Umbra, endianess);
			output.WriteValueF32(UmbraUmbra, endianess);
			output.WriteValueF32(UmbraPenumbra, endianess);
			output.WriteValueS32(Decay, endianess);
			output.WriteValueF32(DecayInner, endianess);
			output.WriteValueF32(DecayOuter, endianess);
		}

		public override void Deserialize(Stream input, Endian endianess)
		{
			base.Deserialize(input, endianess);
			TimeBegin = input.ReadValueF32(endianess);
			TimeEnd = input.ReadValueF32(endianess);
			LightName = input.ReadValueU64(endianess);
			Colour = input.ReadValueS32(endianess);
			ColourColour.Deserialize(input, endianess);
			Intensity = input.ReadValueS32(endianess);
			IntensityIntensity = input.ReadValueF32(endianess);
			ShadowCaster = input.ReadValueS32(endianess);
			ShadowCasterShadowOffset = input.ReadValueF32(endianess);
			ShadowCasterRangeMultiplier = input.ReadValueF32(endianess);
			ShadowCasterRadiusMultiplier = input.ReadValueF32(endianess);
			ShadowCasterMaxRadius = input.ReadValueF32(endianess);
			Umbra = input.ReadValueS32(endianess);
			UmbraUmbra = input.ReadValueF32(endianess);
			UmbraPenumbra = input.ReadValueF32(endianess);
			Decay = input.ReadValueS32(endianess);
			DecayInner = input.ReadValueF32(endianess);
			DecayOuter = input.ReadValueF32(endianess);
		}
	}
}
