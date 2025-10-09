using System.IO;
using MU.GameTools.IO;

namespace MU.GameTools.Prototype.Fight.Prototype1.Track
{
	[KnownNodeForContext(ContextHash.Scenario)]
	[KnownTrack(TrackHash.Mixer)]
	public class MixerTrack : P1Track
	{
		public float TimeBegin { get; set; }

		public float FadeTime { get; set; }

		public ulong MixerHash { get; set; }

		public ulong CategoryHash { get; set; }

		public bool FadeIn { get; set; }

		public bool UninstallOnExit { get; set; }

		public override void Serialize(Stream output, Endian endianess)
		{
			base.Serialize(output, endianess);
			output.WriteValueF32(TimeBegin, endianess);
			output.WriteValueF32(FadeTime, endianess);
			output.WriteValueU64(MixerHash, endianess);
			output.WriteValueU64(CategoryHash, endianess);
			output.WriteValueB32(FadeIn, endianess);
			output.WriteValueB32(UninstallOnExit, endianess);
		}

		public override void Deserialize(Stream input, Endian endianess)
		{
			base.Deserialize(input, endianess);
			TimeBegin = input.ReadValueF32(endianess);
			FadeTime = input.ReadValueF32(endianess);
			MixerHash = input.ReadValueU64(endianess);
			CategoryHash = input.ReadValueU64(endianess);
			FadeIn = input.ReadValueB32(endianess);
			UninstallOnExit = input.ReadValueB32(endianess);
		}
	}
}
