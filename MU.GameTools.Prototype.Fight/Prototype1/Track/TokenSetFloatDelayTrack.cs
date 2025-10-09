using System.IO;
using MU.GameTools.IO;

namespace MU.GameTools.Prototype.Fight.Prototype1.Track
{
	[KnownTrack(TrackHash.TokenSetFloatDelay)]
	public class TokenSetFloatDelayTrack : P1Track
	{
		public float TimeBegin { get; set; }

		public float FloatDelay { get; set; }

		public override void Serialize(Stream output, Endian endianess)
		{
			base.Serialize(output, endianess);
			output.WriteValueF32(TimeBegin, endianess);
			output.WriteValueF32(FloatDelay, endianess);
		}

		public override void Deserialize(Stream input, Endian endianess)
		{
			base.Deserialize(input, endianess);
			TimeBegin = input.ReadValueF32(endianess);
			FloatDelay = input.ReadValueF32(endianess);
		}
	}
}
