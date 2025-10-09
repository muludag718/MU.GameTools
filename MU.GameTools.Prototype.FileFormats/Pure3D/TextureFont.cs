using System.IO;
using MU.GameTools.IO;

namespace MU.GameTools.Prototype.FileFormats.Pure3D
{
	[KnownType(139264u)]
	public class TextureFont : BaseNode
	{
		public uint Version { get; set; }

		public string Name { get; set; }

		public string ShaderName { get; set; }

		public float FontSize { get; set; }

		public float FontWidth { get; set; }

		public float FontHeight { get; set; }

		public float FontBaseLine { get; set; }

		public uint NumTextures { get; set; }

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
			output.WriteStringAlignedU8(ShaderName);
			output.WriteValueF32(FontSize, endian);
			output.WriteValueF32(FontWidth, endian);
			output.WriteValueF32(FontHeight, endian);
			output.WriteValueF32(FontBaseLine, endian);
			output.WriteValueU32(NumTextures, endian);
		}

		public override void Deserialize(Stream input, Endian endian)
		{
			Version = input.ReadValueU32(endian);
			Name = input.ReadStringAlignedU8();
			ShaderName = input.ReadStringAlignedU8();
			FontSize = input.ReadValueF32(endian);
			FontWidth = input.ReadValueF32(endian);
			FontHeight = input.ReadValueF32(endian);
			FontBaseLine = input.ReadValueF32(endian);
			NumTextures = input.ReadValueU32(endian);
		}
	}
}
