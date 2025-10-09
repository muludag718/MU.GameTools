using System;
using System.ComponentModel;
using System.IO;
using System.Linq;
using MU.GameTools.IO;
using MU.GameTools.Common;

namespace MU.GameTools.Prototype.FileFormats.Pure3D
{
	[KnownGame(PrototypeGame.Any)]
	[KnownType(102400u)]
	public class Texture : BaseNode
	{
		public string Name { get; set; }

		public uint Version { get; set; }

		[Category("Image")]
		public uint Width { get; set; }

		[Category("Image")]
		public uint Height { get; set; }

		[Category("Image")]
		public uint Bpp { get; set; }

		public uint AlphaDepth { get; set; }

		public uint NumMipMaps { get; set; }

		public uint TextureType { get; set; }

		public uint Usage { get; set; }

		public uint Priority { get; set; }

		public override bool Exportable => GetSubImageNode()?.Exportable ?? false;

		public override string ExportExtension => "dds";

		public override bool Importable => GetSubImageNode()?.Exportable ?? false;

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
			output.WriteValueU32(Version, endian);
			output.WriteValueU32(Width, endian);
			output.WriteValueU32(Height, endian);
			output.WriteValueU32(Bpp, endian);
			output.WriteValueU32(AlphaDepth, endian);
			output.WriteValueU32(NumMipMaps, endian);
			output.WriteValueU32(TextureType, endian);
			output.WriteValueU32(Usage, endian);
			output.WriteValueU32(Priority, endian);
		}

		public override void Deserialize(Stream input, Endian endian)
		{
			Name = input.ReadStringAlignedU8();
			Version = input.ReadValueU32(endian);
			Width = input.ReadValueU32(endian);
			Height = input.ReadValueU32(endian);
			Bpp = input.ReadValueU32(endian);
			AlphaDepth = input.ReadValueU32(endian);
			NumMipMaps = input.ReadValueU32(endian);
			TextureType = input.ReadValueU32(endian);
			Usage = input.ReadValueU32(endian);
			Priority = input.ReadValueU32(endian);
		}

		private BaseNode GetSubImageNode()
		{
			return Children.SingleOrDefault((BaseNode candidate) => candidate is TextureDDS || candidate is TexturePNG);
		}

		public override object Preview()
		{
			return GetSubImageNode()?.Preview();
		}

		public override void Export(Stream output)
		{
			(GetSubImageNode() ?? throw new InvalidOperationException()).Export(output);
		}

		public override void Import(Stream input)
		{
			(GetSubImageNode() ?? throw new InvalidOperationException()).Import(input);
		}
	}
}
