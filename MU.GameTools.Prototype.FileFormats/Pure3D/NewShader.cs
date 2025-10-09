using System.IO;
using MU.GameTools.IO;
using MU.GameTools.Common;

namespace MU.GameTools.Prototype.FileFormats.Pure3D
{
	[KnownGame(PrototypeGame.Any)]
	[KnownType(69653u)]
	public class NewShader : BaseNode
	{
		public string Name { get; set; }

		public uint Version { get; set; }

		public string ShaderName { get; set; }

		public uint Unknown4 { get; set; }

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
			output.WriteValueU32(Version, endian);
			output.WriteStringAlignedU8(ShaderName);
			output.WriteValueU32(Unknown4, endian);
		}

		public override void Deserialize(Stream input, Endian endian)
		{
			Name = input.ReadStringAlignedU8();
			Version = input.ReadValueU32(endian);
			ShaderName = input.ReadStringAlignedU8();
			Unknown4 = input.ReadValueU32(endian);
		}
	}
}
