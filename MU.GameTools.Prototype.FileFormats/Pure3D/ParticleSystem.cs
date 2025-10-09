using System.IO;
using MU.GameTools.IO;
using MU.GameTools.Common;

namespace MU.GameTools.Prototype.FileFormats.Pure3D
{
	[KnownType(88192u)]
	public class ParticleSystem : BaseNode
	{
		public uint Version { get; set; }

		public string Name { get; set; }

		public uint Unknown3 { get; set; }

		public uint Unknown4 { get; set; }

		public uint Unknown5 { get; set; }

		public Vector4 Rotation { get; set; }

		public Vector3 Translation { get; set; }

		public uint NumEmitters { get; set; }

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
			output.WriteValueU32(Unknown3, endian);
			output.WriteValueU32(Unknown4, endian);
			output.WriteValueU32(Unknown5, endian);
			Rotation.Serialize(output, endian);
			Translation.Serialize(output, endian);
			output.WriteValueU32(NumEmitters, endian);
		}

		public override void Deserialize(Stream input, Endian endian)
		{
			Version = input.ReadValueU32(endian);
			Name = input.ReadStringAlignedU8();
			Unknown3 = input.ReadValueU32(endian);
			Unknown4 = input.ReadValueU32(endian);
			Unknown5 = input.ReadValueU32(endian);
			Rotation = new Vector4(input, endian);
			Translation = new Vector3(input, endian);
			NumEmitters = input.ReadValueU32(endian);
		}
	}
}
