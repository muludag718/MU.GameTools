using System.IO;
using MU.GameTools.IO;

namespace MU.GameTools.Prototype.Fight.Prototype1.Condition
{
	[KnownCondition(ConditionHash.HaveToken)]
	public class HaveTokenCondition : P1Condition
	{
		public enum SomethingTokenType : ulong
		{
			hunter = 6865395180375055270uL,
			fireClearRequest = 7926183158331532086uL
		}

		public enum OwnerType : ulong
		{
			Me = 7150262uL,
			Anyone = 11551537155431939438uL
		}

		public SomethingTokenType Type { get; set; }

		public OwnerType Owner { get; set; }

		public override void Serialize(Stream output, Endian endianess)
		{
			base.Serialize(output, endianess);
			BaseProperty.SerializePropertyEnum(output, endianess, Type);
			BaseProperty.SerializePropertyEnum(output, endianess, Owner);
		}

		public override void Deserialize(Stream input, Endian endianess)
		{
			base.Deserialize(input, endianess);
			Type = BaseProperty.DeserializePropertyEnum<SomethingTokenType>(input, endianess);
			Owner = BaseProperty.DeserializePropertyEnum<OwnerType>(input, endianess);
		}
	}
}
