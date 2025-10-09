using System.IO;
using MU.GameTools.IO;

namespace MU.GameTools.Prototype.FileFormats.Pure3D
{
	[KnownType(135169u)]
	public class ExpressionGroup : BaseNode
	{
		public uint Version { get; set; }

		public string Name { get; set; }

		public string CompositeDrawableName { get; set; }

		public int Count { get; set; }

		public uint[] Unknown4 { get; set; }

		public override string ToString()
		{
			if (string.IsNullOrEmpty(Name))
			{
				return base.ToString();
			}
			return base.ToString() + " (" + Name + ")";
		}

		public override void Serialize(Stream output, Endian endian)
		{
			output.WriteValueU32(Version, endian);
			output.WriteStringAlignedU8(Name);
			output.WriteStringAlignedU8(CompositeDrawableName);
			output.WriteValueS32(Unknown4.Length, endian);
			for (int i = 0; i < Unknown4.Length; i++)
			{
				output.WriteValueU32(Unknown4[i], endian);
			}
		}

		public override void Deserialize(Stream input, Endian endian)
		{
			Version = input.ReadValueU32(endian);
			Name = input.ReadStringAlignedU8();
			CompositeDrawableName = input.ReadStringAlignedU8();
			Count = input.ReadValueS32(endian);
			Unknown4 = new uint[Count];
			for (int i = 0; i < Count; i++)
			{
				Unknown4[i] = input.ReadValueU32(endian);
			}
		}
	}
}
