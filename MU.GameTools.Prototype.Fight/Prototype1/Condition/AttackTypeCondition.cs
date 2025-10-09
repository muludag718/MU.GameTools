using System.IO;
using MU.GameTools.IO;

namespace MU.GameTools.Prototype.Fight.Prototype1.Condition
{
	[KnownCondition(ConditionHash.AttackType)]
	public class AttackTypeCondition : P1Condition
	{
		public AttackType AttackType { get; set; }

		public override void Serialize(Stream output, Endian endianess)
		{
			base.Serialize(output, endianess);
			BaseProperty.SerializePropertyEnum(output, endianess, AttackType);
		}

		public override void Deserialize(Stream input, Endian endianess)
		{
			base.Deserialize(input, endianess);
			AttackType = BaseProperty.DeserializePropertyEnum<AttackType>(input, endianess);
		}
	}
}
