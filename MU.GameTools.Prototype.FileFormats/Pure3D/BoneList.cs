using System.IO;
using MU.GameTools.IO;
using MU.GameTools.Common;

namespace MU.GameTools.Prototype.FileFormats.Pure3D
{
	[KnownGame(PrototypeGame.Any)]
	[KnownType(1183746u)]
	public class BoneList : BaseNode
	{
		public uint Version { get; set; }

		public uint NumberOfBones { get; set; }

		public override void Serialize(Stream output, Endian endian)
		{
			output.WriteValueU32(Version);
			output.WriteValueU32(NumberOfBones);
		}

		public override void Deserialize(Stream input, Endian endian)
		{
			Version = input.ReadValueU32();
			NumberOfBones = input.ReadValueU32();
		}
	}
}
