using System.IO;
using System.Text;
using MU.GameTools.IO;

namespace MU.GameTools.Prototype.FileFormats.Pure3D
{
	public class Registry2 : BaseNode
	{
		public uint Unknown1 { get; set; }

		public string Unknown2 { get; set; }

		public uint Unknown3 { get; set; }

		public string Unknown4 { get; set; }

		public override void Serialize(Stream output, Endian endian)
		{
			output.WriteValueU32(Unknown1, endian);
			output.WriteString(Unknown2, Encoding.ASCII);
			output.WriteValueU32(Unknown3, endian);
			output.WriteString(Unknown4, Encoding.ASCII);
		}

		public override void Deserialize(Stream input, Endian endian)
		{
			Unknown1 = input.ReadValueU32(endian);
			Unknown2 = input.ReadString((int)(input.ReadValueU32() + 1), trailingNull: true, Encoding.ASCII);
			Unknown3 = input.ReadValueU32(endian);
			Unknown4 = input.ReadString((int)(input.ReadValueU32() + 1), trailingNull: true, Encoding.ASCII);
		}
	}
}
