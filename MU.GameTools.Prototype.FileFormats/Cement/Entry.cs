using System.IO;
using MU.GameTools.IO;

namespace MU.GameTools.Prototype.FileFormats.Cement
{
	public class Entry
	{
		public uint Hash;

		public uint Offset;

		public uint Size;

		public byte[] Data;

		public static int ByteSize => 12;

		public void Serialize(Stream output, Endian endian)
		{
			output.WriteValueU32(Hash, endian);
			output.WriteValueU32(Offset, endian);
			output.WriteValueU32(Size, endian);
		}

		public void Deserialize(Stream input, Endian endian)
		{
			Hash = input.ReadValueU32(endian);
			Offset = input.ReadValueU32(endian);
			Size = input.ReadValueU32(endian);
		}
	}
}
