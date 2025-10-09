using System.IO;
using MU.GameTools.IO;

namespace MU.GameTools.Prototype.Fight.Prototype1.Track
{
	[KnownTrack(TrackHash.Fog)]
	public class FogTrack : P1Track
	{
		public float Wait { get; set; }

		public float FadeIn { get; set; }

		public float Duration { get; set; }

		public float FadeOut { get; set; }

		public ScaleFunction FadingFunction { get; set; }

		public bool Enable { get; set; }

		public ulong EffectController { get; set; }

		public AttachSpaceType EmitSpace { get; set; }

		public Vector Offset { get; set; } = new Vector();

		public AttachSpaceType AttachSpace { get; set; }

		public Vector FogAreaSize { get; set; } = new Vector();

		public float GeneratorWidthBias { get; set; }

		public float GeneratorHeightBias { get; set; }

		public float FogThickness { get; set; }

		public Color DarkTint { get; set; } = new Color();

		public Color LightTint { get; set; } = new Color();

		public float FogHorizTiling { get; set; }

		public float FogVertTiling { get; set; }

		public bool RandomMoveDir { get; set; }

		public Vector FogMoveDir { get; set; } = new Vector();

		public float Speed { get; set; }

		public float FogFalloff { get; set; }

		public float FalloffModifier { get; set; }

		public float FogVariation { get; set; }

		public float NoiseStrength { get; set; }

		public override void Serialize(Stream output, Endian endianess)
		{
			base.Serialize(output, endianess);
			output.WriteValueF32(Wait, endianess);
			output.WriteValueF32(FadeIn, endianess);
			output.WriteValueF32(Duration, endianess);
			output.WriteValueF32(FadeOut, endianess);
			BaseProperty.SerializePropertyEnum(output, endianess, FadingFunction);
			output.WriteValueB32(Enable, endianess);
			output.WriteValueU64(EffectController, endianess);
			BaseProperty.SerializePropertyEnum(output, endianess, EmitSpace);
			Offset.Serialize(output, endianess);
			BaseProperty.SerializePropertyEnum(output, endianess, AttachSpace);
			FogAreaSize.Serialize(output, endianess);
			output.WriteValueF32(GeneratorWidthBias, endianess);
			output.WriteValueF32(GeneratorHeightBias, endianess);
			output.WriteValueF32(FogThickness, endianess);
			DarkTint.Serialize(output, endianess);
			LightTint.Serialize(output, endianess);
			output.WriteValueF32(FogHorizTiling, endianess);
			output.WriteValueF32(FogVertTiling, endianess);
			output.WriteValueB32(RandomMoveDir, endianess);
			FogMoveDir.Serialize(output, endianess);
			output.WriteValueF32(Speed, endianess);
			output.WriteValueF32(FogFalloff, endianess);
			output.WriteValueF32(FalloffModifier, endianess);
			output.WriteValueF32(FogVariation, endianess);
			output.WriteValueF32(NoiseStrength, endianess);
		}

		public override void Deserialize(Stream input, Endian endianess)
		{
			base.Deserialize(input, endianess);
			Wait = input.ReadValueF32(endianess);
			FadeIn = input.ReadValueF32(endianess);
			Duration = input.ReadValueF32(endianess);
			FadeOut = input.ReadValueF32(endianess);
			FadingFunction = BaseProperty.DeserializePropertyEnum<ScaleFunction>(input, endianess);
			Enable = input.ReadValueB32(endianess);
			EffectController = input.ReadValueU64(endianess);
			EmitSpace = BaseProperty.DeserializePropertyEnum<AttachSpaceType>(input, endianess);
			Offset.Deserialize(input, endianess);
			AttachSpace = BaseProperty.DeserializePropertyEnum<AttachSpaceType>(input, endianess);
			FogAreaSize.Deserialize(input, endianess);
			GeneratorWidthBias = input.ReadValueF32(endianess);
			GeneratorHeightBias = input.ReadValueF32(endianess);
			FogThickness = input.ReadValueF32(endianess);
			DarkTint.Deserialize(input, endianess);
			LightTint.Deserialize(input, endianess);
			FogHorizTiling = input.ReadValueF32(endianess);
			FogVertTiling = input.ReadValueF32(endianess);
			RandomMoveDir = input.ReadValueB32(endianess);
			FogMoveDir.Deserialize(input, endianess);
			Speed = input.ReadValueF32(endianess);
			FogFalloff = input.ReadValueF32(endianess);
			FalloffModifier = input.ReadValueF32(endianess);
			FogVariation = input.ReadValueF32(endianess);
			NoiseStrength = input.ReadValueF32(endianess);
		}
	}
}
