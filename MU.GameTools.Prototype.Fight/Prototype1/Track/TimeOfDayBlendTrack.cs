using System.IO;
using MU.GameTools.IO;

namespace MU.GameTools.Prototype.Fight.Prototype1.Track
{
	[KnownNodeForContext(ContextHash.Scenario)]
	[KnownTrack(TrackHash.FX_TimeOfDayBlend)]
	public class TimeOfDayBlendTrack : P1Track
	{
		public enum LevelHash : ulong
		{
			AtmosphereLevel = 4344160273227135606uL,
			FXLevel = 13433670759597913104uL,
			PowersLevel = 1642107883378848372uL
		}

		public ulong GroupName { get; set; }

		public ulong VariationName { get; set; }

		public float FadeIn { get; set; }

		public float Duration { get; set; }

		public float FadeOut { get; set; }

		public LevelHash Level { get; set; }

		public bool Sky { get; set; }

		public bool GlobalLighting { get; set; }

		public bool Lighting { get; set; }

		public bool Bloom { get; set; }

		public bool ColourMatrix { get; set; }

		public bool Shaders { get; set; }

		public bool Clouds { get; set; }

		public bool Fogs { get; set; }

		public bool Abortable { get; set; }

		public bool DynamicDuration { get; set; }

		public float TimeBegin { get; set; }

		public float TimeEnd { get; set; }

		public override void Serialize(Stream output, Endian endianess)
		{
			base.Serialize(output, endianess);
			output.WriteValueU64(GroupName, endianess);
			output.WriteValueU64(VariationName, endianess);
			output.WriteValueF32(FadeIn, endianess);
			output.WriteValueF32(Duration, endianess);
			output.WriteValueF32(FadeOut, endianess);
			BaseProperty.SerializePropertyEnum(output, endianess, Level);
			output.WriteValueB32(Sky, endianess);
			output.WriteValueB32(GlobalLighting, endianess);
			output.WriteValueB32(Lighting, endianess);
			output.WriteValueB32(Bloom, endianess);
			output.WriteValueB32(ColourMatrix, endianess);
			output.WriteValueB32(Shaders, endianess);
			output.WriteValueB32(Clouds, endianess);
			output.WriteValueB32(Fogs, endianess);
			output.WriteValueB32(Abortable, endianess);
			output.WriteValueB32(DynamicDuration, endianess);
			output.WriteValueF32(TimeBegin, endianess);
			output.WriteValueF32(TimeEnd, endianess);
		}

		public override void Deserialize(Stream input, Endian endianess)
		{
			base.Deserialize(input, endianess);
			GroupName = input.ReadValueU64(endianess);
			VariationName = input.ReadValueU64(endianess);
			FadeIn = input.ReadValueF32(endianess);
			Duration = input.ReadValueF32(endianess);
			FadeOut = input.ReadValueF32(endianess);
			Level = BaseProperty.DeserializePropertyEnum<LevelHash>(input, endianess);
			Sky = input.ReadValueB32(endianess);
			GlobalLighting = input.ReadValueB32(endianess);
			Lighting = input.ReadValueB32(endianess);
			Bloom = input.ReadValueB32(endianess);
			ColourMatrix = input.ReadValueB32(endianess);
			Shaders = input.ReadValueB32(endianess);
			Clouds = input.ReadValueB32(endianess);
			Fogs = input.ReadValueB32(endianess);
			Abortable = input.ReadValueB32(endianess);
			DynamicDuration = input.ReadValueB32(endianess);
			TimeBegin = input.ReadValueF32(endianess);
			TimeEnd = input.ReadValueF32(endianess);
		}
	}
}
