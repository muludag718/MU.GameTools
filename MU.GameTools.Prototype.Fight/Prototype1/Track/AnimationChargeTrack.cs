using System.IO;
using MU.GameTools.IO;

namespace MU.GameTools.Prototype.Fight.Prototype1.Track
{
	[KnownTrack(TrackHash.AnimationCharge)]
	public class AnimationChargeTrack : P1Track
	{
		public enum AnimationChargeType : ulong
		{
			Invalid = 4122290943349627157uL,
			Jump = 20889331387467136uL,
			Attack = 17648781240126830036uL,
			Throw = 5973634341500805012uL,
			Dive = 19195657991545670uL,
			Glide = 5015188191654984259uL
		}

		public float TimeBegin { get; set; }

		public float TimeEnd { get; set; }

		public ulong Animation { get; set; }

		public AnimationChargeType Type { get; set; }

		public float StartFrame { get; set; }

		public float EndFrame { get; set; }

		public bool Reverse { get; set; }

		public ulong Partition { get; set; }

		public int Priority { get; set; }

		public float BlendInTime { get; set; }

		public float BlendOutTime { get; set; }

		public override void Serialize(Stream output, Endian endianess)
		{
			base.Serialize(output, endianess);
			output.WriteValueF32(TimeBegin, endianess);
			output.WriteValueF32(TimeEnd, endianess);
			output.WriteValueU64(Animation, endianess);
			BaseProperty.SerializePropertyEnum(output, endianess, Type);
			output.WriteValueF32(StartFrame, endianess);
			output.WriteValueF32(EndFrame, endianess);
			output.WriteValueB32(Reverse, endianess);
			output.WriteValueU64(Partition, endianess);
			output.WriteValueS32(Priority, endianess);
			output.WriteValueF32(BlendInTime, endianess);
			output.WriteValueF32(BlendOutTime, endianess);
		}

		public override void Deserialize(Stream input, Endian endianess)
		{
			base.Deserialize(input, endianess);
			TimeBegin = input.ReadValueF32(endianess);
			TimeEnd = input.ReadValueF32(endianess);
			Animation = input.ReadValueU64(endianess);
			Type = BaseProperty.DeserializePropertyEnum<AnimationChargeType>(input, endianess);
			StartFrame = input.ReadValueF32(endianess);
			EndFrame = input.ReadValueF32(endianess);
			Reverse = input.ReadValueB32(endianess);
			Partition = input.ReadValueU64(endianess);
			Priority = input.ReadValueS32(endianess);
			BlendInTime = input.ReadValueF32(endianess);
			BlendOutTime = input.ReadValueF32(endianess);
		}
	}
}
