using System;
using System.ComponentModel;
using System.IO;
using MU.GameTools.IO;
using MU.GameTools.Squish;
using MU.GameTools.Common;

namespace MU.GameTools.Prototype.FileFormats.Pure3D
{
	[KnownGame(PrototypeGame.Any)]
	[KnownType(102406u)]
	public class TextureDDS : BaseNode
	{
		public enum CompressionAlgorithm : uint
		{
			Unknown = 0u,
			DXT1 = 827611204u,
			DXT3 = 861165636u,
			DXT5 = 894720068u
		}

		public string Name { get; set; }

		public uint Version { get; set; }

		[Category("Image")]
		public uint Width { get; set; }

		[Category("Image")]
		public uint Height { get; set; }

		public uint Unknown4 { get; set; }

		public uint Unknown5 { get; set; }

		[Category("Image")]
		public uint NumMipMaps { get; set; }

		[Category("Image")]
		public CompressionAlgorithm Algorithm { get; set; }

		public override bool Exportable => GetChildNode<TextureData>()?.Exportable ?? false;

		public override string ExportExtension => "dds";

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
			output.WriteValueU32(Version, endian);
			output.WriteValueU32(Width, endian);
			output.WriteValueU32(Height, endian);
			output.WriteValueU32(Unknown4, endian);
			output.WriteValueU32(Unknown5, endian);
			output.WriteValueU32(NumMipMaps, endian);
			output.WriteValueU32((uint)Algorithm, endian);
		}

		public override void Deserialize(Stream input, Endian endian)
		{
			Name = input.ReadStringAlignedU8();
			Version = input.ReadValueU32(endian);
			Width = input.ReadValueU32(endian);
			Height = input.ReadValueU32(endian);
			Unknown4 = input.ReadValueU32(endian);
			Unknown5 = input.ReadValueU32(endian);
			NumMipMaps = input.ReadValueU32(endian);
			Algorithm = (CompressionAlgorithm)input.ReadValueU32(endian);
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
			try
			{
				DDSFile dDSFile = new DDSFile();
				dDSFile.Deserialize(memoryStream);
				return dDSFile.Image();
			}
			catch (FormatException)
			{
				return null;
			}
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
