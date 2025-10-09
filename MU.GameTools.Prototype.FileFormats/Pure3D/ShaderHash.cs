using System.IO;
using MU.GameTools.IO;
using MU.GameTools.Common;

namespace MU.GameTools.Prototype.FileFormats.Pure3D
{
	[KnownGame(PrototypeGame.Any)]
	[KnownType(150994954u)]
	public class ShaderHash : BaseNode
	{
		public string Hash { get; set; }

		public override string ToString()
		{
			if (string.IsNullOrEmpty(Hash))
			{
				return base.ToString();
			}
			return base.ToString() + " (" + Hash + ")";
		}

		public override void Serialize(Stream output, Endian endian)
		{
			output.WriteStringAlignedU8(Hash);
		}

		public override void Deserialize(Stream input, Endian endian)
		{
			Hash = input.ReadStringAlignedU8();
		}
	}
}
