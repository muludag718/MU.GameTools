using System.IO;
using MU.GameTools.IO;
using MU.GameTools.Common;
using MU.GameTools.Prototype.Fight.Property;

namespace MU.GameTools.Prototype.Fight.Prototype1.Track
{
	[KnownNodeForContext(ContextHash.Motion)]
	[KnownTrack(TrackHash.Effect)]
	public class EffectTrack : P1Track
	{
		public enum EmitSpaceType : ulong
		{
			WorldSpace = 5062814898204701870uL,
			GameObjectSpace = 15800074974379949085uL,
			GameObjectGlobalUpSpace = 17097909269456236103uL,
			JointSpace = 17857802742059722934uL,
			CollisionSpace = 15089097238419252282uL,
			SurfaceSpace = 12523631433317549063uL
		}

		public enum EffectStoreType : ulong
		{
			General = 1312132684818588012uL,
			MainCharacter = 4221446839816560754uL,
			Character = 11883458559045687845uL,
			Ambient = 2975268716008832216uL,
			Persistent = 9976967587781602699uL,
			Explosion = 6119690315119812053uL,
			Squib = 5872959678684774360uL,
			Tracer = 2105929059253389387uL,
			Bloodtox = 18124356316935178433uL,
			Gameplay = 13278221393172672664uL,
			Devastator = 16626996011609549067uL,
			Collectible = 6733211562610446494uL
		}

		public float TimeBegin { get; set; }

		public float TimeEnd { get; set; }

		public ulong EffectName { get; set; }

		public ulong ParentObjectName { get; set; }

		public EmitSpaceType EmitSpace { get; set; }

		public ulong EmitJoint { get; set; }

		public Vector Offset { get; set; } = new Vector();

		public Vector Orientation { get; set; } = new Vector();

		public AttachSpaceType AttachSpace { get; set; }

		public ulong AttachJoint { get; set; }

		public bool AbortWhenInterrupted { get; set; }

		public ulong SlotName { get; set; }

		public float AbortBelowJointScale { get; set; }

		public float FadeTime { get; set; }

		public ulong EffectController { get; set; }

		public EffectStoreType EffectStore { get; set; }

		public bool HighPriority { get; set; }

		public float Scale { get; set; }

		public bool Collides { get; set; }

		public float Restitution { get; set; }

		public float Friction { get; set; }

		public float RenderOffset { get; set; }

		public bool UsePropScaling { get; set; }

		public ulong CloneName { get; set; }

		public Color CloneTint { get; set; } = new Color();

		public byte[] Biases { get; set; }

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

		public byte[] Overrides { get; set; }

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

		public PropertyTrackGroup Lods { get; set; } = new PropertyTrackGroup(PropertyHash.Lods);

		public override void Serialize(Stream output, Endian endianess)
		{
			base.Serialize(output, endianess);
			output.WriteValueF32(TimeBegin, endianess);
			output.WriteValueF32(TimeEnd, endianess);
			output.WriteValueU64(EffectName, endianess);
			output.WriteValueU64(ParentObjectName, endianess);
			BaseProperty.SerializePropertyEnum(output, endianess, EmitSpace);
			output.WriteValueU64(EmitJoint, endianess);
			Offset.Serialize(output, endianess);
			Orientation.Serialize(output, endianess);
			BaseProperty.SerializePropertyEnum(output, endianess, AttachSpace);
			output.WriteValueU64(AttachJoint, endianess);
			output.WriteValueB32(AbortWhenInterrupted, endianess);
			output.WriteValueU64(SlotName, endianess);
			output.WriteValueF32(AbortBelowJointScale, endianess);
			output.WriteValueF32(FadeTime, endianess);
			output.WriteValueU64(EffectController, endianess);
			BaseProperty.SerializePropertyEnum(output, endianess, EffectStore);
			output.WriteValueB32(HighPriority, endianess);
			output.WriteValueF32(Scale, endianess);
			output.WriteValueB32(Collides, endianess);
			output.WriteValueF32(Restitution, endianess);
			output.WriteValueF32(Friction, endianess);
			output.WriteValueF32(RenderOffset, endianess);
			output.WriteValueB32(UsePropScaling, endianess);
			output.WriteValueU64(CloneName, endianess);
			CloneTint.Serialize(output, endianess);
			output.WriteBytes(Biases);
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
			output.WriteBytes(Overrides);
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

		public override void SerializeProperties(PrototypeGame game, Stream output, Endian endianess)
		{
			BaseProperty.SerializeBaseProperty(PrototypeGame.P1, output, endianess, Lods);
		}

		public override void Deserialize(Stream input, Endian endianess)
		{
			base.Deserialize(input, endianess);
			TimeBegin = input.ReadValueF32(endianess);
			TimeEnd = input.ReadValueF32(endianess);
			EffectName = input.ReadValueU64(endianess);
			ParentObjectName = input.ReadValueU64(endianess);
			EmitSpace = BaseProperty.DeserializePropertyEnum<EmitSpaceType>(input, endianess);
			EmitJoint = input.ReadValueU64(endianess);
			Offset = new Vector(input, endianess);
			Orientation = new Vector(input, endianess);
			AttachSpace = BaseProperty.DeserializePropertyEnum<AttachSpaceType>(input, endianess);
			AttachJoint = input.ReadValueU64(endianess);
			AbortWhenInterrupted = input.ReadValueB32(endianess);
			SlotName = input.ReadValueU64(endianess);
			AbortBelowJointScale = input.ReadValueF32(endianess);
			FadeTime = input.ReadValueF32(endianess);
			EffectController = input.ReadValueU64(endianess);
			EffectStore = BaseProperty.DeserializePropertyEnum<EffectStoreType>(input, endianess);
			HighPriority = input.ReadValueB32(endianess);
			Scale = input.ReadValueF32(endianess);
			Collides = input.ReadValueB32(endianess);
			Restitution = input.ReadValueF32(endianess);
			Friction = input.ReadValueF32(endianess);
			RenderOffset = input.ReadValueF32(endianess);
			UsePropScaling = input.ReadValueB32(endianess);
			CloneName = input.ReadValueU64(endianess);
			CloneTint = new Color(input, endianess);
			Biases = input.ReadBytes(4);
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
			BiasesMeshGeneratorScale = new Vector(input, endianess);
			Overrides = input.ReadBytes(4);
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

		public override void DeserializeProperties(PrototypeGame game, Stream input, Endian endianess)
		{
			Lods = BaseProperty.DeserializeTrackProperty(PrototypeGame.P1, input, endianess, PropertyHash.Lods);
		}
	}
}
