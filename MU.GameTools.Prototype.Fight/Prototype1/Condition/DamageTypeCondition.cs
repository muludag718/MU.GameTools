using System.IO;
using MU.GameTools.IO;

namespace MU.GameTools.Prototype.Fight.Prototype1.Condition
{
	[KnownCondition(ConditionHash.DamageType)]
	public class DamageTypeCondition : P1Condition
	{
		public DamageType DamageType { get; set; }

		public override void Serialize(Stream output, Endian endianess)
		{
			base.Serialize(output, endianess);
			BaseProperty.SerializePropertyEnum(output, endianess, DamageType);
		}

		public override void Deserialize(Stream input, Endian endianess)
		{
			base.Deserialize(input, endianess);
			DamageType = BaseProperty.DeserializePropertyEnum<DamageType>(input, endianess);
		}
	}
}
