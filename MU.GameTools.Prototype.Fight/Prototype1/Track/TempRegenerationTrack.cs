using System.IO;
using MU.GameTools.IO;

namespace MU.GameTools.Prototype.Fight.Prototype1.Track
{
	[KnownTrack(TrackHash.TempRegeneration)]
	public class TempRegenerationTrack : P1Track
	{
		public float TimeBegin { get; set; }

		public float RegenRate { get; set; }

		public float RegenMaxHealthPercentage { get; set; }

		public float Expiry { get; set; }

		public override void Serialize(Stream output, Endian endianess)
		{
			base.Serialize(output, endianess);
			output.WriteValueF32(TimeBegin, endianess);
			output.WriteValueF32(RegenRate, endianess);
			output.WriteValueF32(RegenMaxHealthPercentage, endianess);
			output.WriteValueF32(Expiry, endianess);
		}

		public override void Deserialize(Stream input, Endian endianess)
		{
			base.Deserialize(input, endianess);
			TimeBegin = input.ReadValueF32(endianess);
			RegenRate = input.ReadValueF32(endianess);
			RegenMaxHealthPercentage = input.ReadValueF32(endianess);
			Expiry = input.ReadValueF32(endianess);
		}
	}
}
