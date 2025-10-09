using System.ComponentModel;
using System.IO;
using MU.GameTools.IO;
using MU.GameTools.Common;

namespace MU.GameTools.Prototype.FileFormats.Pure3D.Prototype1
{
	[TypeConverter(typeof(MyTypeConverter))]
	public class VertexDescription
	{
		[Descriptable(true)]
		public DescriptionType BufferType { get; set; }

		[Descriptable(true)]
		public uint Unknown1 { get; set; }

		[Descriptable(true)]
		public uint Offset { get; set; }

		[Descriptable(true)]
		public uint VertexObjectSize { get; set; }

		[Descriptable(true)]
		public uint Unknown2 { get; set; }

		[Descriptable(true)]
		protected uint UnknownType { get; set; }

		public override string ToString()
		{
			return "Vertex Description";
		}

		public VertexDescription()
		{
		}

		public VertexDescription(Stream input, Endian endian)
		{
			Deserialize(input, endian);
		}

		public void Serialize(Stream output, Endian endian)
		{
			output.WriteValueU32(BufferType.ToP1Type(), endian);
			output.WriteValueU32(Unknown1, endian);
			output.WriteValueU32(Offset, endian);
			output.WriteByte((byte)VertexObjectSize);
			output.WriteValueU32(Unknown2, endian);
		}

		public void Deserialize(Stream input, Endian endian)
		{
			BufferType = new DescriptionType(input.ReadValueU32(endian));
			Unknown1 = input.ReadValueU32(endian);
			Offset = input.ReadValueU32(endian);
			VertexObjectSize = (uint)input.ReadByte();
			Unknown2 = input.ReadValueU32(endian);
		}
	}
}
