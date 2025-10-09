using System.IO;
using MU.GameTools.IO;

namespace MU.GameTools.Prototype.FileFormats.Pure3D
{
	[KnownType(1184517u)]
	public class ExpressionAnimation : BaseNode
	{
		public uint Unknown1 { get; set; }

		public uint AmountOfFrames { get; set; }

		public byte[] Unknown2 { get; set; }

		public override void Serialize(Stream output, Endian endian)
		{
			output.WriteValueU32(Unknown1, endian);
			output.WriteValueU32(AmountOfFrames, endian);
			output.WriteBytes(Unknown2);
		}

		public override void Deserialize(Stream input, Endian endian)
		{
			Unknown1 = input.ReadValueU32(endian);
			AmountOfFrames = input.ReadValueU32(endian);
			Unknown2 = input.ReadBytes((int)(AmountOfFrames * 8));
		}
	}
}
