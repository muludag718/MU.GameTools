using System.IO;
using MU.GameTools.IO;

namespace MU.GameTools.Prototype.Fight.Prototype1.Condition
{
	[KnownCondition(ConditionHash.GiverMaterialType)]
	public class GiverMaterialTypeCondition : P1Condition
	{
		public ulong GiverMaterialType { get; set; }

		public override void Serialize(Stream output, Endian endianess)
		{
			base.Serialize(output, endianess);
			output.WriteValueU64(GiverMaterialType, endianess);
		}

		public override void Deserialize(Stream input, Endian endianess)
		{
			base.Deserialize(input, endianess);
			GiverMaterialType = input.ReadValueU64(endianess);
		}
	}
}
