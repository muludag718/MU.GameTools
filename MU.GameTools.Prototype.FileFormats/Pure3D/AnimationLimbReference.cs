using System.IO;
using MU.GameTools.IO;

namespace MU.GameTools.Prototype.FileFormats.Pure3D
{
	[KnownType(1184769u)]
	public class AnimationLimbReference : BaseNode
	{
		public string Limb { get; set; }

		public byte[] Unknown { get; set; }

		public override string ToString()
		{
			if (string.IsNullOrEmpty(Limb))
			{
				return base.ToString();
			}
			return base.ToString() + " (" + Limb + ")";
		}

		public override void Serialize(Stream output, Endian endian)
		{
			output.WriteStringAlignedU8(Limb);
			output.WriteBytes(Unknown);
		}

		public override void Deserialize(Stream input, Endian endian)
		{
			Limb = input.ReadStringAlignedU8();
			Unknown = input.ReadBytes(24);
		}
	}
}
