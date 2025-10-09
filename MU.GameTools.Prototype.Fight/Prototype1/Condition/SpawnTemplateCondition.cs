using System.IO;
using MU.GameTools.IO;

namespace MU.GameTools.Prototype.Fight.Prototype1.Condition
{
	[KnownCondition(ConditionHash.SpawnTemplate)]
	public class SpawnTemplateCondition : P1Condition
	{
		public ulong TemplateName { get; set; }

		public CompareOperator Compare { get; set; }

		public override void Serialize(Stream output, Endian endianess)
		{
			base.Serialize(output, endianess);
			output.WriteValueU64(TemplateName, endianess);
			BaseProperty.SerializePropertyEnum(output, endianess, Compare);
		}

		public override void Deserialize(Stream input, Endian endianess)
		{
			base.Deserialize(input, endianess);
			TemplateName = input.ReadValueU64(endianess);
			Compare = BaseProperty.DeserializePropertyEnum<CompareOperator>(input, endianess);
		}
	}
}
