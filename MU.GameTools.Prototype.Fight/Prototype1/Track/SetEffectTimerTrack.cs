using System.IO;
using MU.GameTools.IO;

namespace MU.GameTools.Prototype.Fight.Prototype1.Track
{
	[KnownTrack(TrackHash.SetEffectTimer)]
	public class SetEffectTimerTrack : P1Track
	{
		public ulong Name { get; set; }

		public float Time { get; set; }

		public override void Serialize(Stream output, Endian endianess)
		{
			base.Serialize(output, endianess);
			output.WriteValueU64(Name, endianess);
			output.WriteValueF32(Time, endianess);
		}

		public override void Deserialize(Stream input, Endian endianess)
		{
			base.Deserialize(input, endianess);
			Name = input.ReadValueU64(endianess);
			Time = input.ReadValueF32(endianess);
		}
	}
}
