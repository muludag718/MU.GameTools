using System.IO;
using MU.GameTools.IO;

namespace MU.GameTools.Prototype.FileFormats.Pure3D
{
	[KnownType(65549u)]
	public class PrimitiveMatrix : BaseNode
	{
		public uint Count { get; set; }

		public uint[] Indices { get; set; }

		public override void Serialize(Stream output, Endian endian)
		{
			output.WriteValueU32(Count, endian);
			for (uint num = 0u; num < Count; num++)
			{
				output.WriteValueU32(Indices[num], endian);
			}
		}

		public override void Deserialize(Stream input, Endian endian)
		{
			Count = input.ReadValueU32(endian);
			Indices = new uint[Count];
			for (uint num = 0u; num < Count; num++)
			{
				Indices[num] = input.ReadValueU32(endian);
			}
		}
	}
}
