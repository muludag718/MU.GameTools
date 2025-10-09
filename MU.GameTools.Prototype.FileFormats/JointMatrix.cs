using System.ComponentModel;
using System.IO;
using System.Runtime.Serialization;
using MU.GameTools.IO;

namespace MU.GameTools.Prototype.FileFormats
{
	[TypeConverter(typeof(MatrixTypeConverter))]
	[DataContract(Namespace = "http://datacontract.gib.me/prototype")]
	public class JointMatrix
	{
		public uint Width { get; set; }

		public uint Height { get; set; }

		public float[,] Content { get; set; }

		public JointMatrix()
		{
		}

		public JointMatrix(Stream input, Endian endian, uint width, uint height)
		{
			Width = width;
			Height = height;
			Deserialize(input, endian);
		}

		public void Serialize(Stream output, Endian endian)
		{
			for (int i = 0; i < Height; i++)
			{
				for (int j = 0; j < Width; j++)
				{
					output.WriteValueF32(Content[i, j], endian);
				}
			}
		}

		public void Deserialize(Stream input, Endian endian)
		{
			Content = new float[Height, Width];
			for (int i = 0; i < Height; i++)
			{
				for (int j = 0; j < Width; j++)
				{
					Content[i, j] = input.ReadValueF32(endian);
				}
			}
		}
	}
}
