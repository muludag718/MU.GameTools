using System.IO;
using MU.GameTools.IO;

namespace MU.GameTools.Prototype.Fight.Prototype1.Track
{
	[KnownNodeForContext(ContextHash.Motion)]
	[KnownTrack(TrackHash.RadialBlur)]
	public class RadialBlurTrack : P1Track
	{
		public float TimeBegin { get; set; }

		public float TimeEnd { get; set; }

		public float Wait { get; set; }

		public float FadeIn { get; set; }

		public float Duration { get; set; }

		public float FadeOut { get; set; }

		public float WaitRand { get; set; }

		public float FadeInRand { get; set; }

		public float DurationRand { get; set; }

		public float FadeOutRand { get; set; }

		public float IntensityStart { get; set; }

		public float IntensityEnd { get; set; }

		public float SizeStart { get; set; }

		public float SizeEnd { get; set; }

		public float FalloffStart { get; set; }

		public float FalloffEnd { get; set; }

		public float FlickerIntensityFreq { get; set; }

		public float FlickerIntensityFreqRand { get; set; }

		public float FlickerIntensityMag { get; set; }

		public float FlickerIntensityMagRand { get; set; }

		public float FlickerSizeFreq { get; set; }

		public float FlickerSizeFreqRand { get; set; }

		public float FlickerSizeMag { get; set; }

		public float FlickerSizeMagRand { get; set; }

		public float FlickerFalloffFreq { get; set; }

		public float FlickerFalloffFreqRand { get; set; }

		public float FlickerFalloffMag { get; set; }

		public float FlickerFalloffMagRand { get; set; }

		public Vector Offset { get; set; } = new Vector();

		public AttachSpaceType AttachSpace { get; set; }

		public ulong AttachJoint { get; set; }

		public string Patch { get; set; }

		public bool InGameCameraOnly { get; set; }

		public override void Serialize(Stream output, Endian endianess)
		{
			base.Serialize(output, endianess);
			output.WriteValueF32(TimeBegin, endianess);
			output.WriteValueF32(TimeEnd, endianess);
			output.WriteValueF32(Wait, endianess);
			output.WriteValueF32(FadeIn, endianess);
			output.WriteValueF32(Duration, endianess);
			output.WriteValueF32(FadeOut, endianess);
			output.WriteValueF32(WaitRand, endianess);
			output.WriteValueF32(FadeInRand, endianess);
			output.WriteValueF32(DurationRand, endianess);
			output.WriteValueF32(FadeOutRand, endianess);
			output.WriteValueF32(IntensityStart, endianess);
			output.WriteValueF32(IntensityEnd, endianess);
			output.WriteValueF32(SizeStart, endianess);
			output.WriteValueF32(SizeEnd, endianess);
			output.WriteValueF32(FalloffStart, endianess);
			output.WriteValueF32(FalloffEnd, endianess);
			output.WriteValueF32(FlickerIntensityFreq, endianess);
			output.WriteValueF32(FlickerIntensityFreqRand, endianess);
			output.WriteValueF32(FlickerIntensityMag, endianess);
			output.WriteValueF32(FlickerIntensityMagRand, endianess);
			output.WriteValueF32(FlickerSizeFreq, endianess);
			output.WriteValueF32(FlickerSizeFreqRand, endianess);
			output.WriteValueF32(FlickerSizeMag, endianess);
			output.WriteValueF32(FlickerSizeMagRand, endianess);
			output.WriteValueF32(FlickerFalloffFreq, endianess);
			output.WriteValueF32(FlickerFalloffFreqRand, endianess);
			output.WriteValueF32(FlickerFalloffMag, endianess);
			output.WriteValueF32(FlickerFalloffMagRand, endianess);
			Offset.Serialize(output, endianess);
			BaseProperty.SerializePropertyEnum(output, endianess, AttachSpace);
			output.WriteValueU64(AttachJoint, endianess);
			output.WriteStringAlignedU32(Patch, endianess);
			output.WriteValueB32(InGameCameraOnly, endianess);
		}

		public override void Deserialize(Stream input, Endian endianess)
		{
			base.Deserialize(input, endianess);
			TimeBegin = input.ReadValueF32(endianess);
			TimeEnd = input.ReadValueF32(endianess);
			Wait = input.ReadValueF32(endianess);
			FadeIn = input.ReadValueF32(endianess);
			Duration = input.ReadValueF32(endianess);
			FadeOut = input.ReadValueF32(endianess);
			WaitRand = input.ReadValueF32(endianess);
			FadeInRand = input.ReadValueF32(endianess);
			DurationRand = input.ReadValueF32(endianess);
			FadeOutRand = input.ReadValueF32(endianess);
			IntensityStart = input.ReadValueF32(endianess);
			IntensityEnd = input.ReadValueF32(endianess);
			SizeStart = input.ReadValueF32(endianess);
			SizeEnd = input.ReadValueF32(endianess);
			FalloffStart = input.ReadValueF32(endianess);
			FalloffEnd = input.ReadValueF32(endianess);
			FlickerIntensityFreq = input.ReadValueF32(endianess);
			FlickerIntensityFreqRand = input.ReadValueF32(endianess);
			FlickerIntensityMag = input.ReadValueF32(endianess);
			FlickerIntensityMagRand = input.ReadValueF32(endianess);
			FlickerSizeFreq = input.ReadValueF32(endianess);
			FlickerSizeFreqRand = input.ReadValueF32(endianess);
			FlickerSizeMag = input.ReadValueF32(endianess);
			FlickerSizeMagRand = input.ReadValueF32(endianess);
			FlickerFalloffFreq = input.ReadValueF32(endianess);
			FlickerFalloffFreqRand = input.ReadValueF32(endianess);
			FlickerFalloffMag = input.ReadValueF32(endianess);
			FlickerFalloffMagRand = input.ReadValueF32(endianess);
			Offset = new Vector(input, endianess);
			AttachSpace = BaseProperty.DeserializePropertyEnum<AttachSpaceType>(input, endianess);
			AttachJoint = input.ReadValueU64(endianess);
			Patch = input.ReadStringAlignedU32(endianess);
			InGameCameraOnly = input.ReadValueB32(endianess);
		}
	}
}
