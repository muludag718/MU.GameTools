using System.IO;
using MU.GameTools.IO;

namespace MU.GameTools.Prototype.Fight.Prototype1.Condition
{
	[KnownCondition(ConditionHash.PackageReady)]
	public class PackageReadyCondition : P1Condition
	{
		public string PackageName { get; set; }

		public override void Serialize(Stream output, Endian endianess)
		{
			base.Serialize(output, endianess);
			output.WriteStringAlignedU32(PackageName, endianess);
		}

		public override void Deserialize(Stream input, Endian endianess)
		{
			base.Deserialize(input, endianess);
			PackageName = input.ReadStringAlignedU32(endianess);
		}
	}
}
