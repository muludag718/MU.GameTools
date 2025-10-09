using System.IO;
using System.Runtime.Serialization;
using MU.GameTools.IO;
using MU.GameTools.Common;

namespace MU.GameTools.Prototype.FileFormats
{
	public class BufferItem
	{
		public Endian endianess;

		[DataMember(Name = "Buffer Type", Order = 1)]
		public DescriptionType BufferType { get; set; }

		[DataMember(Name = "Data", Order = 1)]
		public byte[] Data { get; set; }

		public override string ToString()
		{
			return "Buffer Item (" + BufferType.EnumValue.ToString() + ")";
		}

		public BufferItem(Endian endianess)
		{
			this.endianess = endianess;
		}

		public object GetValue()
		{
			Stream input = new MemoryStream(Data);
			switch (BufferType.EnumValue)
			{
			case DescriptionTypeEnum.Position:
			case DescriptionTypeEnum.Normal:
				return new Vector3(input, endianess);
			case DescriptionTypeEnum.Tangent:
				return new Vector4(input, endianess);
			case DescriptionTypeEnum.UV:
			case DescriptionTypeEnum.UV1:
				return new UVCoordinate(input, endianess);
			case DescriptionTypeEnum.Weight:
			case DescriptionTypeEnum.Group:
			case DescriptionTypeEnum.Colour0:
				return Data;
			case DescriptionTypeEnum.Padding1:
				return new Vector2(input, endianess);
			default:
				return Data;
			}
		}

		public object GetValueP1()
		{
			Stream input = new MemoryStream(Data);
			switch (BufferType.EnumValue)
			{
			case DescriptionTypeEnum.Position:
			case DescriptionTypeEnum.Normal:
			case DescriptionTypeEnum.Weight:
				return new Vector3(input, endianess);
			case DescriptionTypeEnum.Tangent:
				return new Vector4(input, endianess);
			case DescriptionTypeEnum.UV:
				return new UVCoordinate(input, endianess);
			case DescriptionTypeEnum.Group:
				return Data;
			case DescriptionTypeEnum.Padding1:
				return new Vector2(input, endianess);
			default:
				return Data;
			}
		}

		public object GetValueP2()
		{
			Stream input = new MemoryStream(Data);
			switch (BufferType.EnumValue)
			{
			case DescriptionTypeEnum.Position:
			case DescriptionTypeEnum.Normal:
				return new Vector3(input, endianess);
			case DescriptionTypeEnum.Tangent:
			case DescriptionTypeEnum.Weight:
				return new Vector4(input, endianess);
			case DescriptionTypeEnum.UV:
			case DescriptionTypeEnum.UV1:
				return new UVCoordinate(input, endianess);
			case DescriptionTypeEnum.Group:
			case DescriptionTypeEnum.Colour0:
				return Data;
			case DescriptionTypeEnum.Padding1:
				return new Vector2(input, endianess);
			default:
				return Data;
			}
		}
	}
}
