using System.IO;
using MU.GameTools.IO;

namespace MU.GameTools.Prototype.FileFormats.Pure3D
{
	[KnownType(135168u)]
	public class Expression : BaseNode
	{
		public uint Version { get; set; }

		public string Name { get; set; }

		public uint Count { get; set; }

		public float[] Unknown3 { get; set; }

		public uint[] Unknown4 { get; set; }

		public override string ToString()
		{
			if (string.IsNullOrEmpty(Name))
			{
				return base.ToString();
			}
			return base.ToString() + " (" + Name + ")";
		}

		public override void Serialize(Stream output, Endian endian)
		{
			output.WriteValueU32(Version, endian);
			output.WriteStringAlignedU8(Name);
			output.WriteValueU32(Count, endian);
			for (uint num = 0u; num < Unknown3.Length; num++)
			{
				output.WriteValueF32(Unknown3[num], endian);
			}
			for (uint num2 = 0u; num2 < Unknown4.Length; num2++)
			{
				output.WriteValueU32(Unknown4[num2], endian);
			}
		}

		public override void Deserialize(Stream input, Endian endian)
		{
			Version = input.ReadValueU32(endian);
			Name = input.ReadStringAlignedU8();
			Count = input.ReadValueU32(endian);
			Unknown3 = new float[Count];
			for (uint num = 0u; num < Count; num++)
			{
				Unknown3[num] = input.ReadValueF32(endian);
			}
			Unknown4 = new uint[Count];
			for (uint num2 = 0u; num2 < Count; num2++)
			{
				Unknown4[num2] = input.ReadValueU32(endian);
			}
		}
	}
}
