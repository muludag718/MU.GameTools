using System.IO;
using System.Text;
using MU.GameTools.IO;

namespace MU.GameTools.Prototype.FileFormats.Cement
{
	public class Metadata
	{
		public uint Date;

		public uint Alignment;

		public string Name;

		public int ByteSize => 16 + Encoding.ASCII.GetByteCount(Name) + 1 + 3;

		public void Serialize(Stream output, Endian endian)
		{
			output.WriteValueU32(Date, endian);
			output.WriteValueU32(2048u, endian);
			output.WriteValueU32(0u);
			output.WriteStringU32(Name, endian);
			output.Seek(3L, SeekOrigin.Current);
		}

		public void Deserialize(Stream input, Endian endian)
		{
			Date = input.ReadValueU32(endian);
			Alignment = input.ReadValueU32(endian);
			input.ReadValueU32(endian);
			Name = input.ReadString(input.ReadValueS32(endian));
			input.ReadBytes(3);
		}
	}
}
