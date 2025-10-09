using System.IO;
using MU.GameTools.IO;
using MU.GameTools.Common;

namespace MU.GameTools.Prototype.FileFormats.Pure3D
{
	[KnownGame(PrototypeGame.Any)]
	[KnownType(536872705u)]
	public class FightDefinition : BaseNode
	{
		public string Name { get; set; }

		public ushort Unknown2 { get; set; }

		public string Context { get; set; }

		public uint Unknown4 { get; set; }

		public override string ToString()
		{
			if (string.IsNullOrEmpty(Name))
			{
				return base.ToString();
			}
			return base.ToString() + " (" + Name.Trim(default(char)) + ")";
		}

		public override void Serialize(Stream output, Endian endian)
		{
			output.WriteStringAlignedU8(Name);
			output.WriteValueU16(Unknown2, endian);
			output.WriteStringAlignedU8(Context);
			output.WriteValueU32(Unknown4, endian);
		}

		public override void Deserialize(Stream input, Endian endian)
		{
			Name = input.ReadStringAlignedU8();
			Unknown2 = input.ReadValueU16(endian);
			Context = input.ReadStringAlignedU8();
			Unknown4 = input.ReadValueU32(endian);
		}
	}
}
