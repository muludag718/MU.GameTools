using System.IO;
using MU.GameTools.IO;

namespace MU.GameTools.Prototype.Fight.Prototype1.Track
{
	[KnownTrack(TrackHash.AnimationControl)]
	public class AnimationControlTrack : P1Track
	{
		public enum CycleModeType : ulong
		{
			AnimationDefault = 3086659247459262221uL,
			Hold = 20324833833942495uL,
			Forward = 8950535410429879495uL,
			Backward = 11506969557286345811uL,
			ForwardBackward = 13343446975489786740uL,
			BackwardForward = 2555556056228720566uL
		}

		public float TimeBegin { get; set; }

		public float StartFrame { get; set; }

		public float EndFrame { get; set; }

		public float RelativeSpeed { get; set; }

		public CycleModeType CycleMode { get; set; }

		public int NumCycles { get; set; }

		public override void Serialize(Stream output, Endian endianess)
		{
			base.Serialize(output, endianess);
			output.WriteValueF32(TimeBegin, endianess);
			output.WriteValueF32(StartFrame, endianess);
			output.WriteValueF32(EndFrame, endianess);
			output.WriteValueF32(RelativeSpeed, endianess);
			BaseProperty.SerializePropertyEnum(output, endianess, CycleMode);
			output.WriteValueS32(NumCycles, endianess);
		}

		public override void Deserialize(Stream input, Endian endianess)
		{
			base.Deserialize(input, endianess);
			TimeBegin = input.ReadValueF32(endianess);
			StartFrame = input.ReadValueF32(endianess);
			EndFrame = input.ReadValueF32(endianess);
			RelativeSpeed = input.ReadValueF32(endianess);
			CycleMode = BaseProperty.DeserializePropertyEnum<CycleModeType>(input, endianess);
			NumCycles = input.ReadValueS32(endianess);
		}
	}
}
