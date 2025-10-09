using System.IO;
using MU.GameTools.IO;
using MU.GameTools.Common;

namespace MU.GameTools.Prototype.FileFormats.Pure3D
{
	[KnownGame(PrototypeGame.P1)]
	[KnownType(65555u)]
	public class IndexBuffer : BaseNode
	{
		public uint Version { get; set; }

		public uint Param { get; set; }

		public uint BufferSize { get; set; }

		public Face[] Faces { get; set; }

		public override bool Importable => true;

		public override void Serialize(Stream output, Endian endian)
		{
			output.WriteValueU32(Version, endian);
			output.WriteValueU32(Param, endian);
			output.WriteValueU32(BufferSize, endian);
			for (int i = 0; i < Faces.Length; i++)
			{
				Faces[i].Serialize(output, endian);
			}
		}

		public override void Deserialize(Stream input, Endian endian)
		{
			Version = input.ReadValueU32(endian);
			Param = input.ReadValueU32(endian);
			BufferSize = input.ReadValueU32(endian);
			uint num = BufferSize / 6;
			Faces = new Face[num];
			for (int i = 0; i < num; i++)
			{
				Faces[i] = new Face(input, endian);
			}
		}

		public override void Import(Stream input)
		{
			using StreamReader streamReader = new StreamReader(input);
			for (int i = 0; i < 1666; i++)
			{
				string[] array = streamReader.ReadLine().Split(',');
				Faces[i].Point1 = ushort.Parse(array[0]);
				Faces[i].Point2 = ushort.Parse(array[1]);
				Faces[i].Point3 = ushort.Parse(array[2]);
			}
		}
	}
}
