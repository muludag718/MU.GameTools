using System.IO;
using MU.GameTools.IO;

namespace MU.GameTools.Prototype.Fight.Prototype1.Track
{
	[KnownTrack(TrackHash.EffectLODBias)]
	public class EffectLODBiasTrack : P1Track
	{
		public float LodStartDistance { get; set; }

		public float LodUpdateRateMilliseconds { get; set; }

		public int Biases { get; set; }

		public float BiasesEmissionRate { get; set; }

		public float BiasesEmissionRateAreaScale { get; set; }

		public ScaleFunction BiasesEmissionRateScaleFunction { get; set; }

		public float BiasesLifeSpan { get; set; }

		public float BiasesLifeSpanVariance { get; set; }

		public float BiasesSpeed { get; set; }

		public float BiasesSpeedVariance { get; set; }

		public float BiasesSize1D { get; set; }

		public float BiasesSize1DVariance { get; set; }

		public float BiasesSize1DAreaScale { get; set; }

		public ScaleFunction BiasesSize1DScaleFunction { get; set; }

		public float BiasesSpin1D { get; set; }

		public float BiasesSpin1DVariance { get; set; }

		public float BiasesWeight { get; set; }

		public float BiasesWeightVariance { get; set; }

		public float BiasesAngle { get; set; }

		public float BiasesAngleVariance { get; set; }

		public float BiasesGravity { get; set; }

		public float BiasesDrag { get; set; }

		public float BiasesColourRed { get; set; }

		public float BiasesColourGreen { get; set; }

		public float BiasesColourBlue { get; set; }

		public float BiasesAlpha { get; set; }

		public float BiasesColourOverLifeRed { get; set; }

		public float BiasesColourOverLifeGreen { get; set; }

		public float BiasesColourOverLifeBlue { get; set; }

		public float BiasesAlphaOverLife { get; set; }

		public float BiasesColourVariance { get; set; }

		public float BiasesAlphaVariance { get; set; }

		public float BiasesGeneratorRadius { get; set; }

		public float BiasesGeneratorRadial { get; set; }

		public float BiasesGeneratorHorizSpread { get; set; }

		public float BiasesGeneratorVertSpread { get; set; }

		public float BiasesGeneratorWidth { get; set; }

		public float BiasesGeneratorHeight { get; set; }

		public Vector BiasesMeshGeneratorScale { get; set; } = new Vector();

		public int Overrides { get; set; }

		public float OverridesEmissionRate { get; set; }

		public float OverridesEmissionRatePerMeter { get; set; }

		public float OverridesMaxParticles { get; set; }

		public float OverridesParticleAllocation { get; set; }

		public float OverridesLifeSpan { get; set; }

		public float OverridesLifeSpanVariance { get; set; }

		public float OverridesSpeed { get; set; }

		public float OverridesSpeedVariance { get; set; }

		public float OverridesSize1D { get; set; }

		public float OverridesSize1DVariance { get; set; }

		public float OverridesSpin1D { get; set; }

		public float OverridesSpin1DVariance { get; set; }

		public float OverridesWeight { get; set; }

		public float OverridesWeightVariance { get; set; }

		public float OverridesAngle { get; set; }

		public float OverridesAngleVariance { get; set; }

		public float OverridesGravity { get; set; }

		public float OverridesDrag { get; set; }

		public float OverridesColourRed { get; set; }

		public float OverridesColourGreen { get; set; }

		public float OverridesColourBlue { get; set; }

		public float OverridesAlpha { get; set; }

		public float OverridesColourVariance { get; set; }

		public float OverridesAlphaVariance { get; set; }

		public float OverridesGeneratorWidth { get; set; }

		public float OverridesGeneratorHeight { get; set; }

		public override void Serialize(Stream output, Endian endianess)
		{
			base.Serialize(output, endianess);
			output.WriteValueF32(LodStartDistance, endianess);
			output.WriteValueF32(LodUpdateRateMilliseconds, endianess);
			output.WriteValueS32(Biases, endianess);
			output.WriteValueF32(BiasesEmissionRate, endianess);
			output.WriteValueF32(BiasesEmissionRateAreaScale, endianess);
			BaseProperty.SerializePropertyEnum(output, endianess, BiasesEmissionRateScaleFunction);
			output.WriteValueF32(BiasesLifeSpan, endianess);
			output.WriteValueF32(BiasesLifeSpanVariance, endianess);
			output.WriteValueF32(BiasesSpeed, endianess);
			output.WriteValueF32(BiasesSpeedVariance, endianess);
			output.WriteValueF32(BiasesSize1D, endianess);
			output.WriteValueF32(BiasesSize1DVariance, endianess);
			output.WriteValueF32(BiasesSize1DAreaScale, endianess);
			BaseProperty.SerializePropertyEnum(output, endianess, BiasesSize1DScaleFunction);
			output.WriteValueF32(BiasesSpin1D, endianess);
			output.WriteValueF32(BiasesSpin1DVariance, endianess);
			output.WriteValueF32(BiasesWeight, endianess);
			output.WriteValueF32(BiasesWeightVariance, endianess);
			output.WriteValueF32(BiasesAngle, endianess);
			output.WriteValueF32(BiasesAngleVariance, endianess);
			output.WriteValueF32(BiasesGravity, endianess);
			output.WriteValueF32(BiasesDrag, endianess);
			output.WriteValueF32(BiasesColourRed, endianess);
			output.WriteValueF32(BiasesColourGreen, endianess);
			output.WriteValueF32(BiasesColourBlue, endianess);
			output.WriteValueF32(BiasesAlpha, endianess);
			output.WriteValueF32(BiasesColourOverLifeRed, endianess);
			output.WriteValueF32(BiasesColourOverLifeGreen, endianess);
			output.WriteValueF32(BiasesColourOverLifeBlue, endianess);
			output.WriteValueF32(BiasesAlphaOverLife, endianess);
			output.WriteValueF32(BiasesColourVariance, endianess);
			output.WriteValueF32(BiasesAlphaVariance, endianess);
			output.WriteValueF32(BiasesGeneratorRadius, endianess);
			output.WriteValueF32(BiasesGeneratorRadial, endianess);
			output.WriteValueF32(BiasesGeneratorHorizSpread, endianess);
			output.WriteValueF32(BiasesGeneratorVertSpread, endianess);
			output.WriteValueF32(BiasesGeneratorWidth, endianess);
			output.WriteValueF32(BiasesGeneratorHeight, endianess);
			BiasesMeshGeneratorScale.Serialize(output, endianess);
			output.WriteValueS32(Overrides, endianess);
			output.WriteValueF32(OverridesEmissionRate, endianess);
			output.WriteValueF32(OverridesEmissionRatePerMeter, endianess);
			output.WriteValueF32(OverridesMaxParticles, endianess);
			output.WriteValueF32(OverridesParticleAllocation, endianess);
			output.WriteValueF32(OverridesLifeSpan, endianess);
			output.WriteValueF32(OverridesLifeSpanVariance, endianess);
			output.WriteValueF32(OverridesSpeed, endianess);
			output.WriteValueF32(OverridesSpeedVariance, endianess);
			output.WriteValueF32(OverridesSize1D, endianess);
			output.WriteValueF32(OverridesSize1DVariance, endianess);
			output.WriteValueF32(OverridesSpin1D, endianess);
			output.WriteValueF32(OverridesSpin1DVariance, endianess);
			output.WriteValueF32(OverridesWeight, endianess);
			output.WriteValueF32(OverridesWeightVariance, endianess);
			output.WriteValueF32(OverridesAngle, endianess);
			output.WriteValueF32(OverridesAngleVariance, endianess);
			output.WriteValueF32(OverridesGravity, endianess);
			output.WriteValueF32(OverridesDrag, endianess);
			output.WriteValueF32(OverridesColourRed, endianess);
			output.WriteValueF32(OverridesColourGreen, endianess);
			output.WriteValueF32(OverridesColourBlue, endianess);
			output.WriteValueF32(OverridesAlpha, endianess);
			output.WriteValueF32(OverridesColourVariance, endianess);
			output.WriteValueF32(OverridesAlphaVariance, endianess);
			output.WriteValueF32(OverridesGeneratorWidth, endianess);
			output.WriteValueF32(OverridesGeneratorHeight, endianess);
		}

		public override void Deserialize(Stream input, Endian endianess)
		{
			base.Deserialize(input, endianess);
			LodStartDistance = input.ReadValueF32(endianess);
			LodUpdateRateMilliseconds = input.ReadValueF32(endianess);
			Biases = input.ReadValueS32(endianess);
			BiasesEmissionRate = input.ReadValueF32(endianess);
			BiasesEmissionRateAreaScale = input.ReadValueF32(endianess);
			BiasesEmissionRateScaleFunction = BaseProperty.DeserializePropertyEnum<ScaleFunction>(input, endianess);
			BiasesLifeSpan = input.ReadValueF32(endianess);
			BiasesLifeSpanVariance = input.ReadValueF32(endianess);
			BiasesSpeed = input.ReadValueF32(endianess);
			BiasesSpeedVariance = input.ReadValueF32(endianess);
			BiasesSize1D = input.ReadValueF32(endianess);
			BiasesSize1DVariance = input.ReadValueF32(endianess);
			BiasesSize1DAreaScale = input.ReadValueF32(endianess);
			BiasesSize1DScaleFunction = BaseProperty.DeserializePropertyEnum<ScaleFunction>(input, endianess);
			BiasesSpin1D = input.ReadValueF32(endianess);
			BiasesSpin1DVariance = input.ReadValueF32(endianess);
			BiasesWeight = input.ReadValueF32(endianess);
			BiasesWeightVariance = input.ReadValueF32(endianess);
			BiasesAngle = input.ReadValueF32(endianess);
			BiasesAngleVariance = input.ReadValueF32(endianess);
			BiasesGravity = input.ReadValueF32(endianess);
			BiasesDrag = input.ReadValueF32(endianess);
			BiasesColourRed = input.ReadValueF32(endianess);
			BiasesColourGreen = input.ReadValueF32(endianess);
			BiasesColourBlue = input.ReadValueF32(endianess);
			BiasesAlpha = input.ReadValueF32(endianess);
			BiasesColourOverLifeRed = input.ReadValueF32(endianess);
			BiasesColourOverLifeGreen = input.ReadValueF32(endianess);
			BiasesColourOverLifeBlue = input.ReadValueF32(endianess);
			BiasesAlphaOverLife = input.ReadValueF32(endianess);
			BiasesColourVariance = input.ReadValueF32(endianess);
			BiasesAlphaVariance = input.ReadValueF32(endianess);
			BiasesGeneratorRadius = input.ReadValueF32(endianess);
			BiasesGeneratorRadial = input.ReadValueF32(endianess);
			BiasesGeneratorHorizSpread = input.ReadValueF32(endianess);
			BiasesGeneratorVertSpread = input.ReadValueF32(endianess);
			BiasesGeneratorWidth = input.ReadValueF32(endianess);
			BiasesGeneratorHeight = input.ReadValueF32(endianess);
			BiasesMeshGeneratorScale.Deserialize(input, endianess);
			Overrides = input.ReadValueS32(endianess);
			OverridesEmissionRate = input.ReadValueF32(endianess);
			OverridesEmissionRatePerMeter = input.ReadValueF32(endianess);
			OverridesMaxParticles = input.ReadValueF32(endianess);
			OverridesParticleAllocation = input.ReadValueF32(endianess);
			OverridesLifeSpan = input.ReadValueF32(endianess);
			OverridesLifeSpanVariance = input.ReadValueF32(endianess);
			OverridesSpeed = input.ReadValueF32(endianess);
			OverridesSpeedVariance = input.ReadValueF32(endianess);
			OverridesSize1D = input.ReadValueF32(endianess);
			OverridesSize1DVariance = input.ReadValueF32(endianess);
			OverridesSpin1D = input.ReadValueF32(endianess);
			OverridesSpin1DVariance = input.ReadValueF32(endianess);
			OverridesWeight = input.ReadValueF32(endianess);
			OverridesWeightVariance = input.ReadValueF32(endianess);
			OverridesAngle = input.ReadValueF32(endianess);
			OverridesAngleVariance = input.ReadValueF32(endianess);
			OverridesGravity = input.ReadValueF32(endianess);
			OverridesDrag = input.ReadValueF32(endianess);
			OverridesColourRed = input.ReadValueF32(endianess);
			OverridesColourGreen = input.ReadValueF32(endianess);
			OverridesColourBlue = input.ReadValueF32(endianess);
			OverridesAlpha = input.ReadValueF32(endianess);
			OverridesColourVariance = input.ReadValueF32(endianess);
			OverridesAlphaVariance = input.ReadValueF32(endianess);
			OverridesGeneratorWidth = input.ReadValueF32(endianess);
			OverridesGeneratorHeight = input.ReadValueF32(endianess);
		}
	}
}
