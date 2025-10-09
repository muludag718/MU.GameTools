using System.IO;
using MU.GameTools.IO;

namespace MU.GameTools.Prototype.FileFormats.Pure3D
{
	public class AnimationChannelHeader
	{
		public uint Type { get; set; }

		public uint Unknown1 { get; set; }

		public uint Unknown2 { get; set; }

		public uint Unknown3 { get; set; }

		public AnimationChannelHeader()
		{
		}

		public AnimationChannelHeader(Stream input, Endian endian)
		{
			Deserialize(input, endian);
		}

		public void Serialize(Stream output, Endian endian)
		{
			output.WriteValueU32(Type);
			output.WriteValueU32(Unknown1);
			output.WriteValueU32(Unknown2);
			output.WriteValueU32(Unknown3);
		}

		public void Deserialize(Stream input, Endian endian)
		{
			Type = input.ReadValueU32(endian);
			Unknown1 = input.ReadValueU32(endian);
			Unknown2 = input.ReadValueU32(endian);
			Unknown3 = input.ReadValueU32(endian);
		}
	}
}
