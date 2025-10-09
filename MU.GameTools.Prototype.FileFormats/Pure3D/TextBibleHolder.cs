using System.Collections.Generic;
using System.IO;
using MU.GameTools.IO;

namespace MU.GameTools.Prototype.FileFormats.Pure3D
{
	[KnownType(98818u)]
	public class TextBibleHolder : BaseNode
	{
		public string Language { get; set; }

		public uint Version { get; set; }

		public uint Count { get; set; }

		public List<string> Keys { get; set; }

		public List<uint> StringStarts { get; set; }

		public List<uint> StringStops { get; set; }

		public override void Serialize(Stream output, Endian endian)
		{
			output.WriteStringAlignedU8(Language);
			output.WriteValueU32(Version, endian);
			output.WriteValueU32(Count, endian);
			for (int i = 0; i < Count; i++)
			{
				output.WriteStringAlignedU8(Keys[i]);
			}
			for (int j = 0; j < Count; j++)
			{
				output.WriteValueU32(StringStarts[j], endian);
			}
			for (int k = 0; k < Count; k++)
			{
				output.WriteValueU32(StringStops[k], endian);
			}
		}

		public override void Deserialize(Stream input, Endian endian)
		{
			Language = input.ReadStringAlignedU8();
			Version = input.ReadValueU32(endian);
			Count = input.ReadValueU32(endian);
			Keys = new List<string>();
			for (uint num = 0u; num < Count; num++)
			{
				Keys.Add(input.ReadStringAlignedU8());
			}
			StringStarts = new List<uint>();
			for (uint num2 = 0u; num2 < Count; num2++)
			{
				StringStarts.Add(input.ReadValueU32(endian));
			}
			StringStops = new List<uint>();
			for (uint num3 = 0u; num3 < Count; num3++)
			{
				StringStops.Add(input.ReadValueU32(endian));
			}
		}
	}
}
