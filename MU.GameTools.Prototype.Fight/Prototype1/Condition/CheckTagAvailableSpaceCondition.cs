using System.IO;
using MU.GameTools.IO;

namespace MU.GameTools.Prototype.Fight.Prototype1.Condition
{
	[KnownCondition(ConditionHash.CheckTagAvailableSpace)]
	public class CheckTagAvailableSpaceCondition : P1Condition
	{
		public ulong Tag { get; set; }

		public int Limit { get; set; }

		public bool TryDespawnIfFull { get; set; }

		public float MinDespawnDistance { get; set; }

		public float ObjRadius { get; set; }

		public override void Serialize(Stream output, Endian endianess)
		{
			base.Serialize(output, endianess);
			output.WriteValueU64(Tag, endianess);
			output.WriteValueS32(Limit, endianess);
			output.WriteValueB32(TryDespawnIfFull, endianess);
			output.WriteValueF32(MinDespawnDistance, endianess);
			output.WriteValueF32(ObjRadius, endianess);
		}

		public override void Deserialize(Stream input, Endian endianess)
		{
			base.Deserialize(input, endianess);
			Tag = input.ReadValueU64(endianess);
			Limit = input.ReadValueS32(endianess);
			TryDespawnIfFull = input.ReadValueB32(endianess);
			MinDespawnDistance = input.ReadValueF32(endianess);
			ObjRadius = input.ReadValueF32(endianess);
		}
	}
}
