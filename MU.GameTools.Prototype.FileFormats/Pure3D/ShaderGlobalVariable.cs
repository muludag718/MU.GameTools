using System.IO;
using MU.GameTools.IO;

namespace MU.GameTools.Prototype.FileFormats.Pure3D
{
	[KnownType(69645u)]
	public class ShaderGlobalVariable : BaseNode
	{
		public string Name { get; set; }

		public ShaderVariableType VariableType { get; set; }

		public uint Register { get; set; }

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
			output.WriteStringAlignedU8(Name);
			output.WriteValueU32((uint)VariableType, endian);
			output.WriteValueU32(Register, endian);
		}

		public override void Deserialize(Stream input, Endian endian)
		{
			Name = input.ReadStringAlignedU8();
			VariableType = (ShaderVariableType)input.ReadValueU32(endian);
			Register = input.ReadValueU32(endian);
		}
	}
}
