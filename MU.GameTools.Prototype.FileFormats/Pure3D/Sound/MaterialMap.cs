using System.IO;
using MU.GameTools.IO;

namespace MU.GameTools.Prototype.FileFormats.Pure3D.Sound
{
	public class MaterialMap : AudioType
	{
		public uint NumberOfMaterials { get; set; }

		public Material[] Materials { get; set; }

		public MaterialMap()
		{
		}

		public MaterialMap(Stream input, Endian endian)
			: base(input, endian)
		{
		}

		public override void Serialize(Stream output, Endian endian)
		{
			output.WriteValueU32(NumberOfMaterials, endian);
			for (int i = 0; i < NumberOfMaterials; i++)
			{
				Materials[i].Serialize(output, endian);
			}
		}

		public override void Deserialize(Stream input, Endian endian)
		{
			NumberOfMaterials = input.ReadValueU32(endian);
			Materials = new Material[NumberOfMaterials];
			for (int i = 0; i < NumberOfMaterials; i++)
			{
				Materials[i] = new Material(input, endian);
			}
		}
	}
}
