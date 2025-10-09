using System.ComponentModel;
using System.IO;
using MU.GameTools.IO;
using MU.GameTools.Common;

namespace MU.GameTools.Prototype.FileFormats.Pure3D
{
	[KnownGame(PrototypeGame.Any)]
	[KnownType(133169152u)]
	public class MetaObjectDefinition : BaseNode
	{
		public string Name { get; set; }

		[ReadOnly(true)]
		public string TypeName { get; set; }

		public ushort Flag1 { get; set; }

		public ushort Flag2 { get; set; }

		[Browsable(false)]
		public string FullName => $"{TypeName.Trim(default(char))}(1):{Name.Trim(default(char))}";

		public override string ToString()
		{
			return base.ToString() + " (" + $"{TypeName.Trim(default(char))}: {Name.Trim(default(char))}" + ")";
		}

		public override void Serialize(Stream output, Endian endian)
		{
			output.WriteStringAlignedU8(FullName);
			output.WriteStringAlignedU8(Name);
			output.WriteStringAlignedU8(TypeName);
			output.WriteValueU16(Flag1, endian);
			output.WriteValueU16(Flag2, endian);
			output.WriteValueS32(916723515, endian);
		}

		public override void Deserialize(Stream input, Endian endian)
		{
			input.ReadStringAlignedU8();
			Name = input.ReadStringAlignedU8();
			TypeName = input.ReadStringAlignedU8();
			Flag1 = input.ReadValueU16(endian);
			Flag2 = input.ReadValueU16(endian);
			input.ReadValueS32(endian);
		}
	}
}
