using System.IO;
using MU.GameTools.IO;

namespace MU.GameTools.Prototype.Fight.Prototype1.Track
{
	[KnownNodeForContext(ContextHash.Motion)]
	[KnownTrack(TrackHash.FXLightPoint)]
	public class FXLightPointTrack : P1Track
	{
		public bool AbortWhenInterrupted { get; set; }

		public float TimeBegin { get; set; }

		public float TimeEnd { get; set; }

		public ulong ParentObjectName { get; set; }

		public float Wait { get; set; }

		public float FadeIn { get; set; }

		public float Duration { get; set; }

		public float FadeOut { get; set; }

		public float WaitRand { get; set; }

		public float FadeInRand { get; set; }

		public float DurationRand { get; set; }

		public float FadeOutRand { get; set; }

		public float Intensity { get; set; }

		public float Radius { get; set; }

		public float IntensityRand { get; set; }

		public float RadiusRand { get; set; }

		public float FlickerIntensityFreq { get; set; }

		public float FlickerIntensityFreqRand { get; set; }

		public float FlickerIntensityMag { get; set; }

		public float FlickerIntensityMagRand { get; set; }

		public float FlickerRadiusFreq { get; set; }

		public float FlickerRadiusFreqRand { get; set; }

		public float FlickerRadiusMag { get; set; }

		public float FlickerRadiusMagRand { get; set; }

		public Color StartColour { get; set; } = new Color();

		public Color EndColour { get; set; } = new Color();

		public SpaceType EmitSpace { get; set; }

		public Vector Offset { get; set; } = new Vector();

		public SpaceType AttachSpace { get; set; }

		public ulong AttachJoint { get; set; }

		public bool Falloff { get; set; }

		public override void Serialize(Stream output, Endian endianess)
		{
			base.Serialize(output, endianess);
			output.WriteValueB32(AbortWhenInterrupted, endianess);
			output.WriteValueF32(TimeBegin, endianess);
			output.WriteValueF32(TimeEnd, endianess);
			output.WriteValueU64(ParentObjectName, endianess);
			output.WriteValueF32(Wait, endianess);
			output.WriteValueF32(FadeIn, endianess);
			output.WriteValueF32(Duration, endianess);
			output.WriteValueF32(FadeOut, endianess);
			output.WriteValueF32(WaitRand, endianess);
			output.WriteValueF32(FadeInRand, endianess);
			output.WriteValueF32(DurationRand, endianess);
			output.WriteValueF32(FadeOutRand, endianess);
			output.WriteValueF32(Intensity, endianess);
			output.WriteValueF32(Radius, endianess);
			output.WriteValueF32(IntensityRand, endianess);
			output.WriteValueF32(RadiusRand, endianess);
			output.WriteValueF32(FlickerIntensityFreq, endianess);
			output.WriteValueF32(FlickerIntensityFreqRand, endianess);
			output.WriteValueF32(FlickerIntensityMag, endianess);
			output.WriteValueF32(FlickerIntensityMagRand, endianess);
			output.WriteValueF32(FlickerRadiusFreq, endianess);
			output.WriteValueF32(FlickerRadiusFreqRand, endianess);
			output.WriteValueF32(FlickerRadiusMag, endianess);
			output.WriteValueF32(FlickerRadiusMagRand, endianess);
			StartColour.Serialize(output, endianess);
			EndColour.Serialize(output, endianess);
			BaseProperty.SerializePropertyEnum(output, endianess, EmitSpace);
			Offset.Serialize(output, endianess);
			BaseProperty.SerializePropertyEnum(output, endianess, AttachSpace);
			output.WriteValueU64(AttachJoint, endianess);
			output.WriteValueB32(Falloff, endianess);
		}

		public override void Deserialize(Stream input, Endian endianess)
		{
			base.Deserialize(input, endianess);
			AbortWhenInterrupted = input.ReadValueB32(endianess);
			TimeBegin = input.ReadValueF32(endianess);
			TimeEnd = input.ReadValueF32(endianess);
			ParentObjectName = input.ReadValueU64(endianess);
			Wait = input.ReadValueF32(endianess);
			FadeIn = input.ReadValueF32(endianess);
			Duration = input.ReadValueF32(endianess);
			FadeOut = input.ReadValueF32(endianess);
			WaitRand = input.ReadValueF32(endianess);
			FadeInRand = input.ReadValueF32(endianess);
			DurationRand = input.ReadValueF32(endianess);
			FadeOutRand = input.ReadValueF32(endianess);
			Intensity = input.ReadValueF32(endianess);
			Radius = input.ReadValueF32(endianess);
			IntensityRand = input.ReadValueF32(endianess);
			RadiusRand = input.ReadValueF32(endianess);
			FlickerIntensityFreq = input.ReadValueF32(endianess);
			FlickerIntensityFreqRand = input.ReadValueF32(endianess);
			FlickerIntensityMag = input.ReadValueF32(endianess);
			FlickerIntensityMagRand = input.ReadValueF32(endianess);
			FlickerRadiusFreq = input.ReadValueF32(endianess);
			FlickerRadiusFreqRand = input.ReadValueF32(endianess);
			FlickerRadiusMag = input.ReadValueF32(endianess);
			FlickerRadiusMagRand = input.ReadValueF32(endianess);
			StartColour = new Color(input, endianess);
			EndColour = new Color(input, endianess);
			EmitSpace = BaseProperty.DeserializePropertyEnum<SpaceType>(input, endianess);
			Offset = new Vector(input, endianess);
			AttachSpace = BaseProperty.DeserializePropertyEnum<SpaceType>(input, endianess);
			AttachJoint = input.ReadValueU64(endianess);
			Falloff = input.ReadValueB32(endianess);
		}
	}
}
