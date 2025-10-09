using System.IO;
using MU.GameTools.IO;

namespace MU.GameTools.Prototype.Fight.Prototype1.Track
{
	[KnownTrack(TrackHash.ConfigureScaryMonster)]
	public class ConfigureScaryMonsterBehaviourTrack : P1Track
	{
		public float TimeBegin { get; set; }

		public float TimeEnd { get; set; }

		public float Intensity { get; set; }

		public float VelocityOffset { get; set; }

		public int Frequency { get; set; }

		public override void Serialize(Stream output, Endian endianess)
		{
			base.Serialize(output, endianess);
			output.WriteValueF32(TimeBegin, endianess);
			output.WriteValueF32(TimeEnd, endianess);
			output.WriteValueF32(Intensity, endianess);
			output.WriteValueF32(VelocityOffset, endianess);
			output.WriteValueS32(Frequency, endianess);
		}

		public override void Deserialize(Stream input, Endian endianess)
		{
			base.Deserialize(input, endianess);
			TimeBegin = input.ReadValueF32(endianess);
			TimeEnd = input.ReadValueF32(endianess);
			Intensity = input.ReadValueF32(endianess);
			VelocityOffset = input.ReadValueF32(endianess);
			Frequency = input.ReadValueS32(endianess);
		}
	}
}
