using System.IO;
using MU.GameTools.IO;
using MU.GameTools.Common;

namespace MU.GameTools.Prototype.FileFormats.Pure3D
{
	[KnownGame(PrototypeGame.Any)]
	[KnownType(8704u)]
	public class Camera : BaseNode
	{
		public string Name { get; set; }

		public uint Version { get; set; }

		public float FOV { get; set; }

		public float AspectRatio { get; set; }

		public float NearClip { get; set; }

		public float FarClip { get; set; }

		public Vector3 Position { get; set; }

		public Vector3 Look { get; set; }

		public Vector3 Up { get; set; }

		public override string ToString()
		{
			if (!string.IsNullOrEmpty(Name))
			{
				return base.ToString() + " (" + Name.Trim(default(char)) + ")";
			}
			return base.ToString();
		}

		public override void Serialize(Stream output, Endian endian)
		{
			output.WriteStringAlignedU8(Name);
			output.WriteValueU32(Version, endian);
			output.WriteValueF32(FOV, endian);
			output.WriteValueF32(AspectRatio, endian);
			output.WriteValueF32(NearClip, endian);
			output.WriteValueF32(FarClip, endian);
			Position.Serialize(output, endian);
			Look.Serialize(output, endian);
			Up.Serialize(output, endian);
		}

		public override void Deserialize(Stream input, Endian endian)
		{
			Name = input.ReadStringAlignedU8();
			Version = input.ReadValueU32(endian);
			FOV = input.ReadValueF32(endian);
			AspectRatio = input.ReadValueF32(endian);
			NearClip = input.ReadValueF32(endian);
			FarClip = input.ReadValueF32(endian);
			Position = new Vector3(input, endian);
			Look = new Vector3(input, endian);
			Up = new Vector3(input, endian);
		}
	}
}
