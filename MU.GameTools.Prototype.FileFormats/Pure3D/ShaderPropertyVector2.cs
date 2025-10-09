using System.IO;
using MU.GameTools.IO;
using MU.GameTools.Common;

namespace MU.GameTools.Prototype.FileFormats.Pure3D
{
	[KnownGame(PrototypeGame.Any)]
	[KnownType(69656u)]
	public class ShaderPropertyVector2 : BaseNode
	{
		public string Name { get; set; }

		public Vector2 Value { get; set; }

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
			Value.Serialize(output, endian);
		}

		public override void Deserialize(Stream input, Endian endian)
		{
			Name = input.ReadStringAlignedU8();
			Value = new Vector2(input, endian);
		}
	}
}
