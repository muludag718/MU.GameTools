using System.IO;
using MU.GameTools.IO;

namespace MU.GameTools.Prototype.Fight.Prototype1.Track
{
	[KnownNodeForContext(ContextHash.Scenario)]
	[KnownTrack(TrackHash.FMV)]
	public class FMVTrack : P1Track
	{
		public float TimeBegin { get; set; }

		public float TimeEnd { get; set; }

		public string Filename { get; set; }

		public bool UseFMVState { get; set; }

		public bool ClearSubtitles { get; set; }

		public bool IsPreLoaded { get; set; }

		public bool UseBlackFades { get; set; }

		public bool FadeInOnEnter { get; set; }

		public bool StayFadedOnExit { get; set; }

		public bool FadeUpOnExit { get; set; }

		public bool DelayUninstall { get; set; }

		public float UninstallDelayTime { get; set; }

		public float WhiteFadeTime { get; set; }

		public float Timer { get; set; }

		public override void Serialize(Stream output, Endian endianess)
		{
			base.Serialize(output, endianess);
			output.WriteValueF32(TimeBegin, endianess);
			output.WriteValueF32(TimeEnd, endianess);
			output.WriteStringAlignedU32(Filename, endianess);
			output.WriteValueB32(UseFMVState, endianess);
			output.WriteValueB32(ClearSubtitles, endianess);
			output.WriteValueB32(IsPreLoaded, endianess);
			output.WriteValueB32(UseBlackFades, endianess);
			output.WriteValueB32(FadeInOnEnter, endianess);
			output.WriteValueB32(StayFadedOnExit, endianess);
			output.WriteValueB32(FadeUpOnExit, endianess);
			output.WriteValueB32(DelayUninstall, endianess);
			output.WriteValueF32(UninstallDelayTime, endianess);
			output.WriteValueF32(WhiteFadeTime, endianess);
			output.WriteValueF32(Timer, endianess);
		}

		public override void Deserialize(Stream input, Endian endianess)
		{
			base.Deserialize(input, endianess);
			TimeBegin = input.ReadValueF32(endianess);
			TimeEnd = input.ReadValueF32(endianess);
			Filename = input.ReadStringAlignedU32(endianess);
			UseFMVState = input.ReadValueB32(endianess);
			ClearSubtitles = input.ReadValueB32(endianess);
			IsPreLoaded = input.ReadValueB32(endianess);
			UseBlackFades = input.ReadValueB32(endianess);
			FadeInOnEnter = input.ReadValueB32(endianess);
			StayFadedOnExit = input.ReadValueB32(endianess);
			FadeUpOnExit = input.ReadValueB32(endianess);
			DelayUninstall = input.ReadValueB32(endianess);
			UninstallDelayTime = input.ReadValueF32(endianess);
			WhiteFadeTime = input.ReadValueF32(endianess);
			Timer = input.ReadValueF32(endianess);
		}
	}
}
