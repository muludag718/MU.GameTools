using System.IO;
using MU.GameTools.IO;
using MU.GameTools.Common;

namespace MU.GameTools.Prototype.FileFormats.Pure3D
{
	[KnownGame(PrototypeGame.Any)]
	[KnownType(143361u)]
	public class SkeletonBone : BaseNode
	{
		public string Name { get; set; }

		public uint ParentID { get; set; }

		public JointMatrix Matrix { get; set; }

		public byte[] Unknown { get; set; }

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
			output.WriteStringAlignedU8(Name);
			output.WriteValueU32(ParentID, endian);
			Matrix.Serialize(output, endian);
			output.WriteBytes(Unknown);
		}

		public override void Deserialize(Stream input, Endian endian)
		{
			Name = input.ReadStringAlignedU8();
			Name = Name.Trim(default(char));
			ParentID = input.ReadValueU32(endian);
			Matrix = new JointMatrix(input, endian, 4u, 4u);
			Unknown = input.ReadBytes(54);
		}
	}
}
