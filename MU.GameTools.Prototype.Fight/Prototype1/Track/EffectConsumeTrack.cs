using System.IO;
using MU.GameTools.IO;

namespace MU.GameTools.Prototype.Fight.Prototype1.Track
{
	[KnownNodeForContext(ContextHash.Motion)]
	[KnownTrack(TrackHash.EffectConsume)]
	public class EffectConsumeTrack : P1Track
	{
		public enum ConsumeModeType : ulong
		{
			AnimationDefault = 3086659247459262221uL,
			Hold = 20324833833942495uL,
			Forward = 8950535410429879495uL,
			Backward = 11506969557286345811uL,
			ForwardBackward = 13343446975489786740uL,
			BackwardForward = 2555556056228720566uL
		}

		public enum RevealModeType : ulong
		{
			None = 22018610510307286uL,
			Solid = 5865620095936752093uL,
			FadeOut = 8691507612549003382uL,
			FadeIn = 975912642622236387uL
		}

		public float TimeBegin { get; set; }

		public float TimeEnd { get; set; }

		public ulong Shader { get; set; }

		public float SpreadRate { get; set; }

		public float GrowthThreshold { get; set; }

		public ConsumeModeType ConsumeMode { get; set; }

		public float TimeReverse { get; set; }

		public bool UseTimeReveal { get; set; }

		public float TimeReveal { get; set; }

		public RevealModeType RevealMode { get; set; }

		public ulong StartJoint1 { get; set; }

		public Vector StartOffset1 { get; set; } = new Vector();

		public bool UseSecondStartPoint { get; set; }

		public ulong StartJoint2 { get; set; }

		public Vector StartOffset2 { get; set; } = new Vector();

		public override void Serialize(Stream output, Endian endianess)
		{
			base.Serialize(output, endianess);
			output.WriteValueF32(TimeBegin, endianess);
			output.WriteValueF32(TimeEnd, endianess);
			output.WriteValueU64(Shader, endianess);
			output.WriteValueF32(SpreadRate, endianess);
			output.WriteValueF32(GrowthThreshold, endianess);
			BaseProperty.SerializePropertyEnum(output, endianess, ConsumeMode);
			output.WriteValueF32(TimeReverse, endianess);
			output.WriteValueB32(UseTimeReveal, endianess);
			output.WriteValueF32(TimeReveal, endianess);
			BaseProperty.SerializePropertyEnum(output, endianess, RevealMode);
			output.WriteValueU64(StartJoint1, endianess);
			StartOffset1.Serialize(output, endianess);
			output.WriteValueB32(UseSecondStartPoint, endianess);
			output.WriteValueU64(StartJoint2, endianess);
			StartOffset2.Serialize(output, endianess);
		}

		public override void Deserialize(Stream input, Endian endianess)
		{
			base.Deserialize(input, endianess);
			TimeBegin = input.ReadValueF32(endianess);
			TimeEnd = input.ReadValueF32(endianess);
			Shader = input.ReadValueU64(endianess);
			SpreadRate = input.ReadValueF32(endianess);
			GrowthThreshold = input.ReadValueF32(endianess);
			ConsumeMode = BaseProperty.DeserializePropertyEnum<ConsumeModeType>(input, endianess);
			TimeReverse = input.ReadValueF32(endianess);
			UseTimeReveal = input.ReadValueB32(endianess);
			TimeReveal = input.ReadValueF32(endianess);
			RevealMode = BaseProperty.DeserializePropertyEnum<RevealModeType>(input, endianess);
			StartJoint1 = input.ReadValueU64(endianess);
			StartOffset1 = new Vector(input, endianess);
			UseSecondStartPoint = input.ReadValueB32(endianess);
			StartJoint2 = input.ReadValueU64(endianess);
			StartOffset2 = new Vector(input, endianess);
		}
	}
}
