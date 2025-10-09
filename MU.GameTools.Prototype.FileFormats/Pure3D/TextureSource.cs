using System.ComponentModel;
using System.IO;
using MU.GameTools.IO;
using MU.GameTools.Common;

namespace MU.GameTools.Prototype.FileFormats.Pure3D
{
	[KnownGame(PrototypeGame.Any)]
	[KnownType(102403u)]
	public class TextureSource : BaseNode
	{
		[Category("Image")]
		public string FileName { get; set; }

		public override void Serialize(Stream output, Endian endian)
		{
			output.WriteStringAlignedU8(FileName);
		}

		public override void Deserialize(Stream input, Endian endian)
		{
			FileName = input.ReadStringAlignedU8();
		}
	}
}
