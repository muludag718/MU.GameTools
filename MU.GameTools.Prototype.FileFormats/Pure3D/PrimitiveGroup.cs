using System.IO;
using MU.GameTools.IO;
using MU.GameTools.Common;

namespace MU.GameTools.Prototype.FileFormats.Pure3D
{
	[KnownGame(PrototypeGame.P1)]
	[KnownType(65568u)]
	public class PrimitiveGroup : BaseNode
	{
		public uint Version { get; set; }

		public string ShaderName { get; set; }

		public uint PrimitiveType { get; set; }

		public uint VertexType { get; set; }

		public uint NumVertices { get; set; }

		public uint NumIndices { get; set; }

		public uint NumMatrices { get; set; }

		public uint MemoryImaged { get; set; }

		public uint Optimized { get; set; }

		public uint VertexAnimated { get; set; }

		public uint VertexAnimationMask { get; set; }

		public override void Serialize(Stream output, Endian endian)
		{
			output.WriteValueU32(Version, endian);
			output.WriteStringAlignedU8(ShaderName);
			output.WriteValueU32(PrimitiveType, endian);
			output.WriteValueU32(VertexType, endian);
			output.WriteValueU32(NumVertices, endian);
			output.WriteValueU32(NumIndices, endian);
			output.WriteValueU32(NumMatrices, endian);
			output.WriteValueU32(MemoryImaged, endian);
			output.WriteValueU32(Optimized, endian);
			output.WriteValueU32(VertexAnimated, endian);
			output.WriteValueU32(VertexAnimationMask, endian);
		}

		public override void Deserialize(Stream input, Endian endian)
		{
			Version = input.ReadValueU32(endian);
			ShaderName = input.ReadStringAlignedU8();
			PrimitiveType = input.ReadValueU32(endian);
			VertexType = input.ReadValueU32(endian);
			NumVertices = input.ReadValueU32(endian);
			NumIndices = input.ReadValueU32(endian);
			NumMatrices = input.ReadValueU32(endian);
			MemoryImaged = input.ReadValueU32(endian);
			Optimized = input.ReadValueU32(endian);
			VertexAnimated = input.ReadValueU32(endian);
			VertexAnimationMask = input.ReadValueU32(endian);
		}
	}
}
