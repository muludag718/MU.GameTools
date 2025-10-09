using System.IO;
using MU.GameTools.IO;
using MU.GameTools.Common;

namespace MU.GameTools.Prototype.FileFormats.Pure3D
{
	[KnownGame(PrototypeGame.Any)]
	[KnownType(69657u)]
	public class ShaderPropertyColor : BaseNode
	{
		public string Name { get; set; }

		public float R { get; set; }

		public float G { get; set; }

		public float B { get; set; }

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
			output.WriteValueF32(R);
			output.WriteValueF32(G);
			output.WriteValueF32(B);
		}

		public override void Deserialize(Stream input, Endian endian)
		{
			Name = input.ReadStringAlignedU8();
			R = input.ReadValueF32(endian);
			G = input.ReadValueF32(endian);
			B = input.ReadValueF32(endian);
		}
	}
}
