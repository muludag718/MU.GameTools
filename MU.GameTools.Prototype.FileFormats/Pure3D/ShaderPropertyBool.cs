using System.IO;
using MU.GameTools.IO;
using MU.GameTools.Common;

namespace MU.GameTools.Prototype.FileFormats.Pure3D
{
	[KnownGame(PrototypeGame.Any)]
	[KnownType(69661u)]
	public class ShaderPropertyBool : BaseNode
	{
		public string Name { get; set; }

		public bool Enabled { get; set; }

		public override string ToString()
		{
			if (!string.IsNullOrEmpty(Name))
			{
				return base.ToString() + " (" + Name.Trim(default(char)) + ")";
			}
			return base.ToString();
		}

		public override void Serialize(Stream output, Endian endian)
		{
			output.WriteStringAlignedU8(Name);
			output.WriteValueB8(Enabled);
		}

		public override void Deserialize(Stream input, Endian endian)
		{
			Name = input.ReadStringAlignedU8();
			Enabled = input.ReadValueB8();
		}
	}
}
