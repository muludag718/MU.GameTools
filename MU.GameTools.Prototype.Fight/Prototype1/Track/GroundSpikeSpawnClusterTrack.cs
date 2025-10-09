using System.IO;
using MU.GameTools.IO;

namespace MU.GameTools.Prototype.Fight.Prototype1.Track
{
	[KnownNodeForContext(ContextHash.Motion)]
	[KnownTrack(TrackHash.GroundSpikeSpawnCluster)]
	public class GroundSpikeSpawnClusterTrack : P1Track
	{
		public ulong LargeType { get; set; }

		public ulong MidType { get; set; }

		public ulong SmallType { get; set; }

		public float LargeFrac { get; set; }

		public float MidFrac { get; set; }

		public float SmallFrac { get; set; }

		public int MinShards { get; set; }

		public int MaxShards { get; set; }

		public float SpawnRadius { get; set; }

		public float SpreadRadius { get; set; }

		public float TimingRandomizerFrac { get; set; }

		public float AscendTimeMin { get; set; }

		public float AscendTimeMax { get; set; }

		public float TwistMin { get; set; }

		public float TwistMax { get; set; }

		public float TimeBegin { get; set; }

		public float TimeEnd { get; set; }

		public override void Serialize(Stream output, Endian endianess)
		{
			base.Serialize(output, endianess);
			output.WriteValueU64(LargeType, endianess);
			output.WriteValueU64(MidType, endianess);
			output.WriteValueU64(SmallType, endianess);
			output.WriteValueF32(LargeFrac, endianess);
			output.WriteValueF32(MidFrac, endianess);
			output.WriteValueF32(SmallFrac, endianess);
			output.WriteValueS32(MinShards, endianess);
			output.WriteValueS32(MaxShards, endianess);
			output.WriteValueF32(SpawnRadius, endianess);
			output.WriteValueF32(SpreadRadius, endianess);
			output.WriteValueF32(TimingRandomizerFrac, endianess);
			output.WriteValueF32(AscendTimeMin, endianess);
			output.WriteValueF32(AscendTimeMax, endianess);
			output.WriteValueF32(TwistMin, endianess);
			output.WriteValueF32(TwistMax, endianess);
			output.WriteValueF32(TimeBegin, endianess);
			output.WriteValueF32(TimeEnd, endianess);
		}

		public override void Deserialize(Stream input, Endian endianess)
		{
			base.Deserialize(input, endianess);
			LargeType = input.ReadValueU64(endianess);
			MidType = input.ReadValueU64(endianess);
			SmallType = input.ReadValueU64(endianess);
			LargeFrac = input.ReadValueF32(endianess);
			MidFrac = input.ReadValueF32(endianess);
			SmallFrac = input.ReadValueF32(endianess);
			MinShards = input.ReadValueS32(endianess);
			MaxShards = input.ReadValueS32(endianess);
			SpawnRadius = input.ReadValueF32(endianess);
			SpreadRadius = input.ReadValueF32(endianess);
			TimingRandomizerFrac = input.ReadValueF32(endianess);
			AscendTimeMin = input.ReadValueF32(endianess);
			AscendTimeMax = input.ReadValueF32(endianess);
			TwistMin = input.ReadValueF32(endianess);
			TwistMax = input.ReadValueF32(endianess);
			TimeBegin = input.ReadValueF32(endianess);
			TimeEnd = input.ReadValueF32(endianess);
		}
	}
}
