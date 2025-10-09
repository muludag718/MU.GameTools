using System.Collections.Generic;
using System.IO;
using MU.GameTools.IO;
using MU.GameTools.Common;

namespace MU.GameTools.Prototype.FileFormats.Pure3D
{
	[KnownGame(PrototypeGame.Any)]
	[KnownType(1183745u)]
	public class AnimationBone : BaseNode
	{
		public uint Pad { get; set; }

		public string Name { get; set; }

		public uint BoneID { get; set; }

		public uint NumberOfChannels { get; set; }

		public override string ToString()
		{
			if (string.IsNullOrEmpty(Name))
			{
				return base.ToString();
			}
			return base.ToString() + " (" + Name.Trim(default(char)) + ")";
		}

		public override void Serialize(Stream output, Endian endian)
		{
			output.WriteValueU32(Pad);
			output.WriteStringAlignedU8(Name);
			output.WriteValueU32(BoneID);
			List<AnimationChannel> childNodes = GetChildNodes<AnimationChannel>();
			output.WriteValueS32(childNodes.Count);
		}

		public override void Deserialize(Stream input, Endian endian)
		{
			Pad = input.ReadValueU32();
			Name = input.ReadStringAlignedU8();
			BoneID = input.ReadValueU32();
			NumberOfChannels = input.ReadValueU32();
		}
	}
}
