using System.IO;
using MU.GameTools.IO;

namespace MU.GameTools.Prototype.Fight
{
	public class BranchReference
	{
		public string Name { get; set; } = "";

		public int Index { get; set; } = -1;

		public BranchReference()
		{
		}

		public BranchReference(Stream input, Endian endianess)
		{
			Deserialize(input, endianess);
		}

		public void Deserialize(Stream input, Endian endianess)
		{
			Name = input.ReadStringAlignedU32(endianess);
			Index = input.ReadValueS32(endianess);
		}

		public void Serialize(Stream output, Endian endianess)
		{
			output.WriteStringAlignedU32(Name, endianess);
			output.WriteValueS32(Index, endianess);
		}
	}
}
