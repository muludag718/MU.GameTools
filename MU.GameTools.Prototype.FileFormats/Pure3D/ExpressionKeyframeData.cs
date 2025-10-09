using System.IO;
using MU.GameTools.IO;

namespace MU.GameTools.Prototype.FileFormats.Pure3D
{
	[KnownType(69376u)]
	public class ExpressionKeyframeData : BaseNode
	{
		public uint Unknown1 { get; set; }

		public string Type { get; set; }

		public uint NumberOfVertices { get; set; }

		public VertexAnimBuffer[] AnimBuffers { get; set; }

		public override void Serialize(Stream output, Endian endian)
		{
			output.WriteValueU32(Unknown1, endian);
			output.WriteString(Type);
			output.WriteValueU32(NumberOfVertices, endian);
			for (int i = 0; i < NumberOfVertices; i++)
			{
				output.WriteValueU32(AnimBuffers[i].Index, endian);
				output.WriteBytes(AnimBuffers[i].Data);
			}
		}

		public override void Deserialize(Stream input, Endian endian)
		{
			Unknown1 = input.ReadValueU32(endian);
			Type = input.ReadString(4);
			NumberOfVertices = input.ReadValueU32(endian);
			AnimBuffers = new VertexAnimBuffer[NumberOfVertices];
			for (int i = 0; i < NumberOfVertices; i++)
			{
				AnimBuffers[i] = new VertexAnimBuffer();
				AnimBuffers[i].Index = input.ReadValueU32(endian);
				AnimBuffers[i].Data = input.ReadBytes(12);
			}
		}
	}
}
