using System;
using System.IO;
using MU.GameTools.IO;

namespace MU.GameTools.Prototype.FileFormats.Pure3D
{
	[KnownType(139265u)]
	public class TextureGlyphList : BaseNode
	{
		public uint NumGlyphs { get; set; }

		public TextureGlyph[] Glyphs { get; set; }

		public override void Serialize(Stream output, Endian endian)
		{
			throw new NotImplementedException();
		}

		public override void Deserialize(Stream input, Endian endian)
		{
			NumGlyphs = input.ReadValueU32(endian);
			Glyphs = new TextureGlyph[NumGlyphs];
			for (int i = 0; i < NumGlyphs; i++)
			{
				Glyphs[i] = new TextureGlyph(input, endian);
			}
		}
	}
}
