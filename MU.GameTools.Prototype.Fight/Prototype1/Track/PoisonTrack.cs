using System.IO;
using MU.GameTools.IO;

namespace MU.GameTools.Prototype.Fight.Prototype1.Track
{
	[KnownTrack(TrackHash.Poison)]
	public class PoisonTrack : P1Track
	{
		public enum WhoType : ulong
		{
			Self = 23429428375025418uL,
			Target = 856854631462190855uL,
			GrabSlot = 7882620167033900854uL,
			GrabTarget = 1754404701201221985uL
		}

		public float TimeBegin { get; set; }

		public AttackType PoisonType { get; set; }

		public float DamageRate { get; set; }

		public float DamageSpikes { get; set; }

		public float TimeToHit { get; set; }

		public float ExtraRandomTime { get; set; }

		public int Priority { get; set; }

		public WhoType Who { get; set; }

		public ulong GrabSlot { get; set; }

		public override void Serialize(Stream output, Endian endianess)
		{
			base.Serialize(output, endianess);
			output.WriteValueF32(TimeBegin, endianess);
			BaseProperty.SerializePropertyEnum(output, endianess, PoisonType);
			output.WriteValueF32(DamageRate, endianess);
			output.WriteValueF32(DamageSpikes, endianess);
			output.WriteValueF32(TimeToHit, endianess);
			output.WriteValueF32(ExtraRandomTime, endianess);
			output.WriteValueS32(Priority, endianess);
			BaseProperty.SerializePropertyEnum(output, endianess, Who);
			output.WriteValueU64(GrabSlot, endianess);
		}

		public override void Deserialize(Stream input, Endian endianess)
		{
			base.Deserialize(input, endianess);
			TimeBegin = input.ReadValueF32(endianess);
			PoisonType = BaseProperty.DeserializePropertyEnum<AttackType>(input, endianess);
			DamageRate = input.ReadValueF32(endianess);
			DamageSpikes = input.ReadValueF32(endianess);
			TimeToHit = input.ReadValueF32(endianess);
			ExtraRandomTime = input.ReadValueF32(endianess);
			Priority = input.ReadValueS32(endianess);
			Who = BaseProperty.DeserializePropertyEnum<WhoType>(input, endianess);
			GrabSlot = input.ReadValueU64(endianess);
		}
	}
}
