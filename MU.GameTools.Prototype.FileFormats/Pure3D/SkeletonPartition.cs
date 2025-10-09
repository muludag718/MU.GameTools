using System.IO;
using MU.GameTools.IO;
using MU.GameTools.Common;

namespace MU.GameTools.Prototype.FileFormats.Pure3D
{
	[KnownGame(PrototypeGame.Any)]
	[KnownType(143362u)]
	public class SkeletonPartition : BaseNode
	{
		public string Name { get; set; }

		public uint DataSize { get; set; }

		public byte[] Data { get; set; }

		public override string ToString()
		{
			if (string.IsNullOrEmpty(Name))
			{
				return base.ToString();
			}
			return base.ToString() + " (" + Name.Trim(default(char)) + ")";
		}

		public override void Serialize(Stream output, Endian endian)
		{
			output.WriteStringAlignedU8(Name);
			output.WriteValueU32(DataSize, endian);
			output.WriteBytes(Data);
		}

		public override void Deserialize(Stream input, Endian endian)
		{
			Name = input.ReadStringAlignedU8();
			DataSize = input.ReadValueU32(endian);
			Data = input.ReadBytes((int)(DataSize * 4));
		}
	}
}
