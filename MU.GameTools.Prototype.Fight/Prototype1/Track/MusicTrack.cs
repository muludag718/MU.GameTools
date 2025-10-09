using System.IO;
using MU.GameTools.IO;

namespace MU.GameTools.Prototype.Fight.Prototype1.Track
{
	[KnownNodeForContext(ContextHash.Scenario)]
	[KnownTrack(7730007216425001953uL)]
	public class MusicTrack : P1Track
	{
		public enum MusicPriority : ulong
		{
			Global = 12096938440000755089uL,
			Mission = 13148182856864167966uL
		}

		public float TimeBegin { get; set; }

		public ulong GroupHash { get; set; }

		public ulong CueHash { get; set; }

		public ulong PartHash { get; set; }

		public MusicPriority Priority { get; set; }

		public bool ResetPriority { get; set; }

		public bool OverrideFadeOut { get; set; }

		public int FadeoutStartBar { get; set; }

		public int FadeoutStartBeat { get; set; }

		public int FadeoutStartNote { get; set; }

		public int FadeoutLengthBar { get; set; }

		public int FadeoutLengthBeat { get; set; }

		public int FadeoutLengthNote { get; set; }

		public bool OverrideFadeIn { get; set; }

		public int FadeinStartBar { get; set; }

		public int FadeinStartBeat { get; set; }

		public int FadeinStartNote { get; set; }

		public int FadeinLengthBar { get; set; }

		public int FadeinLengthBeat { get; set; }

		public int FadeinLengthNote { get; set; }

		public override void Serialize(Stream output, Endian endianess)
		{
			base.Serialize(output, endianess);
			output.WriteValueF32(TimeBegin, endianess);
			output.WriteValueU64(GroupHash, endianess);
			output.WriteValueU64(CueHash, endianess);
			output.WriteValueU64(PartHash, endianess);
			BaseProperty.SerializePropertyEnum(output, endianess, Priority);
			output.WriteValueB32(ResetPriority, endianess);
			output.WriteValueB32(OverrideFadeOut, endianess);
			output.WriteValueS32(FadeoutStartBar, endianess);
			output.WriteValueS32(FadeoutStartBeat, endianess);
			output.WriteValueS32(FadeoutStartNote, endianess);
			output.WriteValueS32(FadeoutLengthBar, endianess);
			output.WriteValueS32(FadeoutLengthBeat, endianess);
			output.WriteValueS32(FadeoutLengthNote, endianess);
			output.WriteValueB32(OverrideFadeIn, endianess);
			output.WriteValueS32(FadeinStartBar, endianess);
			output.WriteValueS32(FadeinStartBeat, endianess);
			output.WriteValueS32(FadeinStartNote, endianess);
			output.WriteValueS32(FadeinLengthBar, endianess);
			output.WriteValueS32(FadeinLengthBeat, endianess);
			output.WriteValueS32(FadeinLengthNote, endianess);
		}

		public override void Deserialize(Stream input, Endian endianess)
		{
			base.Deserialize(input, endianess);
			TimeBegin = input.ReadValueF32(endianess);
			GroupHash = input.ReadValueU64(endianess);
			CueHash = input.ReadValueU64(endianess);
			PartHash = input.ReadValueU64(endianess);
			Priority = BaseProperty.DeserializePropertyEnum<MusicPriority>(input, endianess);
			ResetPriority = input.ReadValueB32(endianess);
			OverrideFadeOut = input.ReadValueB32(endianess);
			FadeoutStartBar = input.ReadValueS32(endianess);
			FadeoutStartBeat = input.ReadValueS32(endianess);
			FadeoutStartNote = input.ReadValueS32(endianess);
			FadeoutLengthBar = input.ReadValueS32(endianess);
			FadeoutLengthBeat = input.ReadValueS32(endianess);
			FadeoutLengthNote = input.ReadValueS32(endianess);
			OverrideFadeIn = input.ReadValueB32(endianess);
			FadeinStartBar = input.ReadValueS32(endianess);
			FadeinStartBeat = input.ReadValueS32(endianess);
			FadeinStartNote = input.ReadValueS32(endianess);
			FadeinLengthBar = input.ReadValueS32(endianess);
			FadeinLengthBeat = input.ReadValueS32(endianess);
			FadeinLengthNote = input.ReadValueS32(endianess);
		}
	}
}
