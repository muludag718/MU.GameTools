using System;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using MU.GameTools.IO;

namespace MU.GameTools.Prototype.FileFormats.Pure3D
{
	[KnownType(102401u)]
	public class TexturePNG : BaseNode
	{
		public string Name { get; set; }

		public uint Unknown1 { get; set; }

		[Category("Image")]
		public uint Width { get; set; }

		[Category("Image")]
		public uint Height { get; set; }

		public uint Bpp { get; set; }

		public uint Palettized { get; set; }

		public uint HasAlpha { get; set; }

		public uint Format { get; set; }

		public override bool Exportable => GetChildNode<TextureData>()?.Exportable ?? false;

		public override bool Importable => GetChildNode<TextureData>()?.Exportable ?? false;

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
			output.WriteValueU32(Unknown1, endian);
			output.WriteValueU32(Width, endian);
			output.WriteValueU32(Height, endian);
			output.WriteValueU32(Bpp, endian);
			output.WriteValueU32(Palettized, endian);
			output.WriteValueU32(HasAlpha, endian);
			output.WriteValueU32(Format, endian);
		}

		public override void Deserialize(Stream input, Endian endian)
		{
			Name = input.ReadStringAlignedU8();
			Unknown1 = input.ReadValueU32(endian);
			Width = input.ReadValueU32(endian);
			Height = input.ReadValueU32(endian);
			Bpp = input.ReadValueU32(endian);
			Palettized = input.ReadValueU32(endian);
			HasAlpha = input.ReadValueU32(endian);
			Format = input.ReadValueU32(endian);
		}

		public override object Preview()
		{
			TextureData childNode = GetChildNode<TextureData>();
			if (childNode == null)
			{
				return null;
			}
			MemoryStream memoryStream = new MemoryStream();
			memoryStream.Write(childNode.Data, 0, childNode.Data.Length);
			memoryStream.Seek(0L, SeekOrigin.Begin);
			return Image.FromStream(memoryStream);
		}

		public override void Export(Stream output)
		{
			(GetChildNode<TextureData>() ?? throw new InvalidOperationException()).Export(output);
		}

		public override void Import(Stream input)
		{
			(GetChildNode<TextureData>() ?? throw new InvalidOperationException()).Import(input);
		}
	}
}
