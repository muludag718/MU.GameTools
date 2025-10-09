using System;
using System.ComponentModel;
using System.IO;
using MU.GameTools.IO;

namespace MU.GameTools.Prototype.FileFormats.Pure3D
{
	[TypeConverter(typeof(ExpandableObjectConverter))]
	public class TextureGlyph
	{
		public uint TextureNum { get; set; }

		public Vector2 BottomLeft { get; set; }

		public Vector2 TopRight { get; set; }

		public float LeftBearing { get; set; }

		public float RightBearing { get; set; }

		public float Width { get; set; }

		public float Advance { get; set; }

		public uint Code { get; set; }

		public TextureGlyph()
		{
		}

		public TextureGlyph(Stream input, Endian endian)
		{
			Deserialize(input, endian);
		}

		public void Serialize(Stream output)
		{
			throw new NotImplementedException();
		}

		public void Deserialize(Stream input, Endian endian)
		{
			TextureNum = input.ReadValueU32();
			BottomLeft = new Vector2(input, endian);
			TopRight = new Vector2(input, endian);
			LeftBearing = input.ReadValueF32(endian);
			RightBearing = input.ReadValueF32(endian);
			Width = input.ReadValueF32(endian);
			Advance = input.ReadValueF32(endian);
			Code = input.ReadValueU32(endian);
		}
	}
}
