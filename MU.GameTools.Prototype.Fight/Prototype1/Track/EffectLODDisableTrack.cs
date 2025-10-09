using System.IO;
using MU.GameTools.IO;

namespace MU.GameTools.Prototype.Fight.Prototype1.Track
{
	[KnownTrack(TrackHash.EffectLODDisable)]
	public class EffectLODDisableTrack : P1Track
	{
		public float LodStartDistance { get; set; }

		public override void Serialize(Stream output, Endian endianess)
		{
			base.Serialize(output, endianess);
			output.WriteValueF32(LodStartDistance, endianess);
		}

		public override void Deserialize(Stream input, Endian endianess)
		{
			base.Deserialize(input, endianess);
			LodStartDistance = input.ReadValueF32(endianess);
		}
	}
}
