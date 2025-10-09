using System.IO;
using MU.GameTools.IO;

namespace MU.GameTools.Prototype.Fight.Prototype1.Track
{
	[KnownTrack(TrackHash.FX_BulletTracer)]
	public class BulletTracerTrack : P1Track
	{
		public float TimeBegin { get; set; }

		public float TimeEnd { get; set; }

		public float Wait { get; set; }

		public int HeadParameters { get; set; }

		public ulong HeadParametersShader { get; set; }

		public float HeadParametersGenerateTime { get; set; }

		public float HeadParametersFadeInTime { get; set; }

		public float HeadParametersFadeOutTime { get; set; }

		public float HeadParametersFadeInTrailTime { get; set; }

		public float HeadParametersFadeOutTrailTime { get; set; }

		public float HeadParametersShrinkInTime { get; set; }

		public float HeadParametersShrinkOutTime { get; set; }

		public float HeadParametersThickness { get; set; }

		public float HeadParametersTextureLength { get; set; }

		public float HeadParametersTextureScrollRate { get; set; }

		public Color HeadParametersStartColour { get; set; } = new Color();

		public Color HeadParametersEndColour { get; set; } = new Color();

		public int TailParameters { get; set; }

		public ulong TailParametersShader { get; set; }

		public float TailParametersGenerateTime { get; set; }

		public float TailParametersFadeInTime { get; set; }

		public float TailParametersFadeOutTime { get; set; }

		public float TailParametersFadeInTrailTime { get; set; }

		public float TailParametersFadeOutTrailTime { get; set; }

		public float TailParametersShrinkInTime { get; set; }

		public float TailParametersShrinkOutTime { get; set; }

		public float TailParametersThickness { get; set; }

		public float TailParametersTextureLength { get; set; }

		public float TailParametersTextureScrollRate { get; set; }

		public Color TailParametersStartColour { get; set; } = new Color();

		public Color TailParametersEndColour { get; set; } = new Color();

		public Vector Offset { get; set; } = new Vector();

		public ulong AttachJoint { get; set; }

		public override void Serialize(Stream output, Endian endianess)
		{
			base.Serialize(output, endianess);
			output.WriteValueF32(TimeBegin, endianess);
			output.WriteValueF32(TimeEnd, endianess);
			output.WriteValueF32(Wait, endianess);
			output.WriteValueS32(HeadParameters, endianess);
			output.WriteValueU64(HeadParametersShader, endianess);
			output.WriteValueF32(HeadParametersGenerateTime, endianess);
			output.WriteValueF32(HeadParametersFadeInTime, endianess);
			output.WriteValueF32(HeadParametersFadeOutTime, endianess);
			output.WriteValueF32(HeadParametersFadeInTrailTime, endianess);
			output.WriteValueF32(HeadParametersFadeOutTrailTime, endianess);
			output.WriteValueF32(HeadParametersShrinkInTime, endianess);
			output.WriteValueF32(HeadParametersShrinkOutTime, endianess);
			output.WriteValueF32(HeadParametersThickness, endianess);
			output.WriteValueF32(HeadParametersTextureLength, endianess);
			output.WriteValueF32(HeadParametersTextureScrollRate, endianess);
			HeadParametersStartColour.Serialize(output, endianess);
			HeadParametersEndColour.Serialize(output, endianess);
			output.WriteValueS32(TailParameters, endianess);
			output.WriteValueU64(TailParametersShader, endianess);
			output.WriteValueF32(TailParametersGenerateTime, endianess);
			output.WriteValueF32(TailParametersFadeInTime, endianess);
			output.WriteValueF32(TailParametersFadeOutTime, endianess);
			output.WriteValueF32(TailParametersFadeInTrailTime, endianess);
			output.WriteValueF32(TailParametersFadeOutTrailTime, endianess);
			output.WriteValueF32(TailParametersShrinkInTime, endianess);
			output.WriteValueF32(TailParametersShrinkOutTime, endianess);
			output.WriteValueF32(TailParametersThickness, endianess);
			output.WriteValueF32(TailParametersTextureLength, endianess);
			output.WriteValueF32(TailParametersTextureScrollRate, endianess);
			TailParametersStartColour.Serialize(output, endianess);
			TailParametersEndColour.Serialize(output, endianess);
			Offset.Serialize(output, endianess);
			output.WriteValueU64(AttachJoint, endianess);
		}

		public override void Deserialize(Stream input, Endian endianess)
		{
			base.Deserialize(input, endianess);
			TimeBegin = input.ReadValueF32(endianess);
			TimeEnd = input.ReadValueF32(endianess);
			Wait = input.ReadValueF32(endianess);
			HeadParameters = input.ReadValueS32(endianess);
			HeadParametersShader = input.ReadValueU64(endianess);
			HeadParametersGenerateTime = input.ReadValueF32(endianess);
			HeadParametersFadeInTime = input.ReadValueF32(endianess);
			HeadParametersFadeOutTime = input.ReadValueF32(endianess);
			HeadParametersFadeInTrailTime = input.ReadValueF32(endianess);
			HeadParametersFadeOutTrailTime = input.ReadValueF32(endianess);
			HeadParametersShrinkInTime = input.ReadValueF32(endianess);
			HeadParametersShrinkOutTime = input.ReadValueF32(endianess);
			HeadParametersThickness = input.ReadValueF32(endianess);
			HeadParametersTextureLength = input.ReadValueF32(endianess);
			HeadParametersTextureScrollRate = input.ReadValueF32(endianess);
			HeadParametersStartColour.Deserialize(input, endianess);
			HeadParametersEndColour.Deserialize(input, endianess);
			TailParameters = input.ReadValueS32(endianess);
			TailParametersShader = input.ReadValueU64(endianess);
			TailParametersGenerateTime = input.ReadValueF32(endianess);
			TailParametersFadeInTime = input.ReadValueF32(endianess);
			TailParametersFadeOutTime = input.ReadValueF32(endianess);
			TailParametersFadeInTrailTime = input.ReadValueF32(endianess);
			TailParametersFadeOutTrailTime = input.ReadValueF32(endianess);
			TailParametersShrinkInTime = input.ReadValueF32(endianess);
			TailParametersShrinkOutTime = input.ReadValueF32(endianess);
			TailParametersThickness = input.ReadValueF32(endianess);
			TailParametersTextureLength = input.ReadValueF32(endianess);
			TailParametersTextureScrollRate = input.ReadValueF32(endianess);
			TailParametersStartColour.Deserialize(input, endianess);
			TailParametersEndColour.Deserialize(input, endianess);
			Offset.Deserialize(input, endianess);
			AttachJoint = input.ReadValueU64(endianess);
		}
	}
}
