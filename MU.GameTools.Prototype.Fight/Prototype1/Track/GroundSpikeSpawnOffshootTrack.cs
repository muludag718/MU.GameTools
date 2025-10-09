using System.IO;
using MU.GameTools.IO;

namespace MU.GameTools.Prototype.Fight.Prototype1.Track
{
	[KnownTrack(TrackHash.GroundSpikeSpawnOffshoot)]
	public class GroundSpikeSpawnOffshootTrack : P1Track
	{
		public ulong Type { get; set; }

		public int NumMin { get; set; }

		public int NumMax { get; set; }

		public bool IsForSuperSpike { get; set; }

		public float MaxArc { get; set; }

		public float AngleOffsetMin { get; set; }

		public float AngleOffsetMax { get; set; }

		public float TimeBegin { get; set; }

		public float TimeEnd { get; set; }

		public override void Serialize(Stream output, Endian endianess)
		{
			base.Serialize(output, endianess);
			output.WriteValueU64(Type, endianess);
			output.WriteValueS32(NumMin, endianess);
			output.WriteValueS32(NumMax, endianess);
			output.WriteValueB32(IsForSuperSpike, endianess);
			output.WriteValueF32(MaxArc, endianess);
			output.WriteValueF32(AngleOffsetMin, endianess);
			output.WriteValueF32(AngleOffsetMax, endianess);
			output.WriteValueF32(TimeBegin, endianess);
			output.WriteValueF32(TimeEnd, endianess);
		}

		public override void Deserialize(Stream input, Endian endianess)
		{
			base.Deserialize(input, endianess);
			Type = input.ReadValueU64(endianess);
			NumMin = input.ReadValueS32(endianess);
			NumMax = input.ReadValueS32(endianess);
			IsForSuperSpike = input.ReadValueB32(endianess);
			MaxArc = input.ReadValueF32(endianess);
			AngleOffsetMin = input.ReadValueF32(endianess);
			AngleOffsetMax = input.ReadValueF32(endianess);
			TimeBegin = input.ReadValueF32(endianess);
			TimeEnd = input.ReadValueF32(endianess);
		}
	}
}
