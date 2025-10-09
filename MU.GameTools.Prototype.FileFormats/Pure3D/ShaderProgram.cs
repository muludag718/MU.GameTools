using System.IO;
using MU.GameTools.IO;

namespace MU.GameTools.Prototype.FileFormats.Pure3D
{
	[KnownType(69643u)]
	public class ShaderProgram : BaseNode
	{
		public enum ShaderProgramType : uint
		{
			VertexShader,
			PixelShader
		}

		public string Name { get; set; }

		public uint Unknown02 { get; set; }

		public ShaderProgramType ShaderType { get; set; }

		public uint ChildCount2 { get; set; }

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
			output.WriteStringAlignedU8(Name);
			output.WriteValueU32(Unknown02, endian);
			output.WriteValueU32((uint)ShaderType, endian);
			output.WriteValueU32(ChildCount2, endian);
		}

		public override void Deserialize(Stream input, Endian endian)
		{
			Name = input.ReadStringAlignedU8();
			Unknown02 = input.ReadValueU32(endian);
			ShaderType = (ShaderProgramType)input.ReadValueU32(endian);
			ChildCount2 = input.ReadValueU32(endian);
		}
	}
}
