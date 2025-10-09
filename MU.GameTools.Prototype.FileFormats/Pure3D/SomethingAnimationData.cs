using System.IO;
using MU.GameTools.IO;

namespace MU.GameTools.Prototype.FileFormats.Pure3D
{
	public class SomethingAnimationData
	{
		public string Type { get; set; }

		public AnimationChannelHeader Header { get; set; }

		public byte[] Data { get; set; }

		public SomethingAnimationData()
		{
		}

		public SomethingAnimationData(Stream input, Endian endian)
		{
			Deserialize(input, endian);
		}

		public void Serialize(Stream output, Endian endian)
		{
			Header.Serialize(output, endian);
			output.WriteStringAlignedU8(Type);
			output.WriteBytes(Data);
		}

		public void Deserialize(Stream input, Endian endian)
		{
			Header.Deserialize(input, endian);
			Type = input.ReadStringAlignedU8();
			Data = input.ReadBytes(16);
		}
	}
}
