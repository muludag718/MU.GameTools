using System;
using System.Collections.Generic;
using System.IO;
using MU.GameTools.IO;
using MU.GameTools.Prototype.FileFormats;
using MU.GameTools.Prototype.FileFormats.Pure3D.Prototype2;
using MU.GameTools.Common;

namespace MU.GameTools.Prototype2.Exporting
{
	public static class Mesh
	{
		public static P2Primitive CreatePrimitiveIndices(Endian endianess, string name, List<Vector3Int> faces)
		{
			P2Primitive p2Primitive = new P2Primitive();
			p2Primitive.ID = 65601u;
			p2Primitive.Version = 0u;
			p2Primitive.Name = name + "_indices";
			p2Primitive.Unknown1 = 0u;
			p2Primitive.Unknown2 = 1u;
			p2Primitive.NumberOfVertices = (uint)(faces.Count * 3);
			p2Primitive.Unknown3 = 0u;
			p2Primitive.Unknown4 = (uint)faces.Count;
			p2Primitive.Children.Add(CreateFaceDescriptor(faces.Count, MeshExportFlags.Group));
			List<BufferItem> list = new List<BufferItem>();
			for (int i = 0; i < faces.Count; i++)
			{
				BufferItem bufferItem = new BufferItem(endianess);
				bufferItem.Data = BitConverter.GetBytes((ushort)faces[i].X);
				list.Add(bufferItem);
				BufferItem bufferItem2 = new BufferItem(endianess);
				bufferItem2.Data = BitConverter.GetBytes((ushort)faces[i].Y);
				list.Add(bufferItem2);
				BufferItem bufferItem3 = new BufferItem(endianess);
				bufferItem3.Data = BitConverter.GetBytes((ushort)faces[i].Z);
				list.Add(bufferItem3);
			}
			P2Buffer p2Buffer = new P2Buffer();
			p2Buffer.BufferSize = p2Primitive.NumberOfVertices * 2;
			p2Buffer.BufferItems = list.ToArray();
			p2Primitive.Children.Add(p2Buffer);
			return p2Primitive;
		}

		public static P2Primitive CreatePrimitiveSkin(Endian endianess, string name, List<Vector3> position, List<Vector3> normal, List<float> weights, List<byte> groups)
		{
			P2Primitive p2Primitive = new P2Primitive();
			p2Primitive.ID = 65600u;
			p2Primitive.Version = 0u;
			p2Primitive.Name = name + "_skin";
			p2Primitive.Unknown1 = 1u;
			p2Primitive.Unknown2 = 1u;
			p2Primitive.NumberOfVertices = (uint)position.Count;
			p2Primitive.Unknown3 = 4u;
			p2Primitive.Unknown4 = (uint)position.Count;
			MeshExportFlags meshExportFlags = MeshExportFlags.Position;
			MeshExportData meshExportData = new MeshExportData();
			meshExportData.vertices = position.Count;
			meshExportData.position = position;
			if (weights != null)
			{
				meshExportFlags |= MeshExportFlags.Weight;
				List<Vector4> list = new List<Vector4>();
				for (int i = 0; i < weights.Count; i += 4)
				{
					Vector4 vector = new Vector4();
					vector.X = weights[i];
					vector.Y = weights[i + 1];
					vector.Z = weights[i + 2];
					vector.W = weights[i + 3];
					list.Add(vector);
				}
				meshExportData.weight = list;
			}
			if (groups != null)
			{
				meshExportFlags |= MeshExportFlags.Group;
				List<byte[]> list2 = new List<byte[]>();
				for (int j = 0; j < groups.Count; j += 4)
				{
					byte[] array = new byte[8]
					{
						groups[j],
						0,
						groups[j + 1],
						0,
						groups[j + 2],
						0,
						groups[j + 3],
						0
					};
					if (array[4] <= 0)
					{
						array[4] = array[0];
					}
					if (array[6] <= 0)
					{
						array[6] = array[0];
					}
					list2.Add(array);
				}
				meshExportData.group = list2;
			}
			if (normal != null)
			{
				meshExportFlags |= MeshExportFlags.Normal;
				meshExportData.normal = normal;
			}
			meshExportFlags = meshExportFlags | MeshExportFlags.Padding | MeshExportFlags.Tangent;
			P2BufferDescriptor p2BufferDescriptor = CreateVertexDescriptor(position.Count, meshExportFlags);
			p2Primitive.Children.Add(p2BufferDescriptor);
			p2Primitive.Children.Add(CreateVertexBuffer(endianess, meshExportFlags, meshExportData, p2BufferDescriptor));
			return p2Primitive;
		}

		public static P2Primitive CreatePrimitiveVertices(Endian endianess, string name, List<UVCoordinate> uvs)
		{
			P2Primitive obj = new P2Primitive
			{
				ID = 65600u,
				Version = 0u,
				Name = name + "_vertices",
				Unknown1 = 0u,
				Unknown2 = 1u,
				NumberOfVertices = (uint)uvs.Count,
				Unknown3 = 4u,
				Unknown4 = (uint)uvs.Count
			};
			MeshExportFlags flags = (MeshExportFlags)288;
			MeshExportData data = new MeshExportData
			{
				vertices = uvs.Count,
				uv = uvs
			};
			P2BufferDescriptor p2BufferDescriptor = CreateVertexDescriptor(uvs.Count, flags);
			obj.Children.Add(p2BufferDescriptor);
			obj.Children.Add(CreateVertexBuffer(endianess, flags, data, p2BufferDescriptor));
			return obj;
		}

		public static P2BufferDescriptor CreateFaceDescriptor(int vertices, MeshExportFlags flags)
		{
			uint num = 0u;
			uint num2 = 0u;
			List<P2Description> list = new List<P2Description>();
			if ((flags & MeshExportFlags.Group) == MeshExportFlags.Group)
			{
				P2Description p2Description = new P2Description();
				p2Description.Offset = num;
				p2Description.BufferType = new DescriptionType(DescriptionTypeEnum.Group);
				p2Description.BufferSize = (uint)(vertices * 3);
				p2Description.Unknown1 = 3u;
				p2Description.Unknown2 = 1u;
				p2Description.Unknown5 = 0u;
				p2Description.Unknown6 = 0u;
				list.Add(p2Description);
				num += 2;
				num2 += 2;
			}
			foreach (P2Description item in list)
			{
				item.ItemSize = num2;
			}
			return new P2BufferDescriptor
			{
				AmountOfDescriptions = (uint)list.Count,
				DescriptionSize = num2,
				Descriptions = list.ToArray()
			};
		}

		public static P2BufferDescriptor CreateVertexDescriptor(int vertices, MeshExportFlags flags)
		{
			uint num = 0u;
			uint num2 = 0u;
			List<P2Description> list = new List<P2Description>();
			if ((flags & MeshExportFlags.Position) == MeshExportFlags.Position)
			{
				P2Description p2Description = new P2Description();
				p2Description.Offset = num;
				p2Description.BufferSize = (uint)vertices;
				p2Description.BufferType = new DescriptionType(DescriptionTypeEnum.Position);
				p2Description.Unknown1 = 0u;
				p2Description.Unknown2 = 4u;
				p2Description.Unknown5 = 0u;
				p2Description.Unknown6 = 0u;
				list.Add(p2Description);
				num += 16;
				num2 += 16;
			}
			if ((flags & MeshExportFlags.Normal) == MeshExportFlags.Normal)
			{
				P2Description p2Description2 = new P2Description();
				p2Description2.Offset = num;
				p2Description2.BufferSize = (uint)vertices;
				p2Description2.BufferType = new DescriptionType(DescriptionTypeEnum.Normal);
				p2Description2.Unknown1 = 0u;
				p2Description2.Unknown2 = 4u;
				p2Description2.Unknown5 = 0u;
				p2Description2.Unknown6 = 0u;
				list.Add(p2Description2);
				num += 16;
				num2 += 16;
			}
			if ((flags & MeshExportFlags.Tangent) == MeshExportFlags.Tangent)
			{
				P2Description p2Description3 = new P2Description();
				p2Description3.Offset = num;
				p2Description3.BufferSize = (uint)vertices;
				p2Description3.BufferType = new DescriptionType(DescriptionTypeEnum.Tangent);
				p2Description3.Unknown1 = 0u;
				p2Description3.Unknown2 = 4u;
				p2Description3.Unknown5 = 0u;
				p2Description3.Unknown6 = 0u;
				list.Add(p2Description3);
				num += 16;
				num2 += 16;
			}
			if ((flags & MeshExportFlags.Weight) == MeshExportFlags.Weight)
			{
				P2Description p2Description4 = new P2Description();
				p2Description4.Offset = num;
				p2Description4.BufferSize = (uint)vertices;
				p2Description4.BufferType = new DescriptionType(DescriptionTypeEnum.Weight);
				p2Description4.Unknown1 = 0u;
				p2Description4.Unknown2 = 4u;
				p2Description4.Unknown5 = 0u;
				p2Description4.Unknown6 = 0u;
				list.Add(p2Description4);
				num += 16;
				num2 += 16;
			}
			if ((flags & MeshExportFlags.Colour) == MeshExportFlags.Colour)
			{
				P2Description p2Description5 = new P2Description();
				p2Description5.Offset = num;
				p2Description5.BufferSize = (uint)vertices;
				p2Description5.BufferType = new DescriptionType(DescriptionTypeEnum.Colour0);
				p2Description5.Unknown1 = 7u;
				p2Description5.Unknown2 = 4u;
				p2Description5.Unknown5 = 1u;
				p2Description5.Unknown6 = 0u;
				list.Add(p2Description5);
				num += 4;
				num2 += 4;
			}
			if ((flags & MeshExportFlags.UV) == MeshExportFlags.UV)
			{
				P2Description p2Description6 = new P2Description();
				p2Description6.Offset = num;
				p2Description6.BufferSize = (uint)vertices;
				p2Description6.BufferType = new DescriptionType(DescriptionTypeEnum.UV);
				p2Description6.Unknown1 = 0u;
				p2Description6.Unknown2 = 2u;
				p2Description6.Unknown5 = 0u;
				p2Description6.Unknown6 = 0u;
				list.Add(p2Description6);
				num += 8;
				num2 += 8;
			}
			if ((flags & MeshExportFlags.Group) == MeshExportFlags.Group)
			{
				P2Description p2Description7 = new P2Description();
				p2Description7.Offset = num;
				p2Description7.BufferSize = (uint)vertices;
				p2Description7.BufferType = new DescriptionType(DescriptionTypeEnum.Group);
				p2Description7.Unknown1 = 3u;
				p2Description7.Unknown2 = 4u;
				p2Description7.Unknown5 = 0u;
				p2Description7.Unknown6 = 0u;
				list.Add(p2Description7);
				num += 8;
				num2 += 8;
			}
			if ((flags & MeshExportFlags.Padding) == MeshExportFlags.Padding)
			{
				P2Description p2Description8 = new P2Description();
				p2Description8.Offset = num;
				p2Description8.BufferSize = (uint)vertices;
				p2Description8.BufferType = new DescriptionType(DescriptionTypeEnum.Padding1);
				p2Description8.Unknown1 = 3u;
				p2Description8.Unknown2 = 4u;
				p2Description8.Unknown5 = 0u;
				p2Description8.Unknown6 = 0u;
				list.Add(p2Description8);
				num += 8;
				num2 += 8;
			}
			foreach (P2Description item in list)
			{
				item.ItemSize = num2;
			}
			return new P2BufferDescriptor
			{
				AmountOfDescriptions = (uint)list.Count,
				DescriptionSize = num2,
				Descriptions = list.ToArray()
			};
		}

		public static P2Buffer CreateVertexBuffer(Endian endianess, MeshExportFlags flags, MeshExportData data, P2BufferDescriptor desc)
		{
			List<BufferItem> list = new List<BufferItem>();
			uint num = 0u;
			for (int i = 0; i < data.vertices; i++)
			{
				if ((flags & MeshExportFlags.Position) == MeshExportFlags.Position)
				{
					BufferItem bufferItem = new BufferItem(endianess);
					MemoryStream memoryStream = new MemoryStream();
					Vector4 vector = new Vector4();
					vector.X = data.position[i].X;
					vector.Y = data.position[i].Y;
					vector.Z = data.position[i].Z;
					vector.W = 1f;
					vector.Serialize(memoryStream, endianess);
					bufferItem.Data = memoryStream.ToArray();
					bufferItem.BufferType = new DescriptionType(DescriptionTypeEnum.Position);
					list.Add(bufferItem);
					num += 16;
				}
				if ((flags & MeshExportFlags.Normal) == MeshExportFlags.Normal)
				{
					BufferItem bufferItem2 = new BufferItem(endianess);
					MemoryStream memoryStream2 = new MemoryStream();
					Vector4 vector2 = new Vector4();
					vector2.X = data.normal[i].X;
					vector2.Y = data.normal[i].Y;
					vector2.Z = data.normal[i].Z;
					vector2.W = 1f;
					vector2.Serialize(memoryStream2, endianess);
					bufferItem2.Data = memoryStream2.ToArray();
					bufferItem2.BufferType = new DescriptionType(DescriptionTypeEnum.Normal);
					list.Add(bufferItem2);
					num += 16;
				}
				if ((flags & MeshExportFlags.Tangent) == MeshExportFlags.Tangent)
				{
					BufferItem bufferItem3 = new BufferItem(endianess);
					MemoryStream memoryStream3 = new MemoryStream();
					Vector4 vector3 = new Vector4();
					vector3.X = 0f;
					vector3.Y = 0f;
					vector3.Z = 0f;
					vector3.W = 0f;
					vector3.Serialize(memoryStream3, endianess);
					bufferItem3.Data = memoryStream3.ToArray();
					bufferItem3.BufferType = new DescriptionType(DescriptionTypeEnum.Tangent);
					list.Add(bufferItem3);
					num += 16;
				}
				if ((flags & MeshExportFlags.Weight) == MeshExportFlags.Weight)
				{
					BufferItem bufferItem4 = new BufferItem(endianess);
					MemoryStream memoryStream4 = new MemoryStream();
					data.weight[i].Serialize(memoryStream4, endianess);
					bufferItem4.Data = memoryStream4.ToArray();
					bufferItem4.BufferType = new DescriptionType(DescriptionTypeEnum.Weight);
					list.Add(bufferItem4);
					num += 16;
				}
				if ((flags & MeshExportFlags.Colour) == MeshExportFlags.Colour)
				{
					BufferItem bufferItem5 = new BufferItem(endianess);
					bufferItem5.Data = new byte[4] { 255, 0, 255, 0 };
					bufferItem5.BufferType = new DescriptionType(DescriptionTypeEnum.Colour0);
					list.Add(bufferItem5);
					num += 4;
				}
				if ((flags & MeshExportFlags.UV) == MeshExportFlags.UV)
				{
					BufferItem bufferItem6 = new BufferItem(endianess);
					MemoryStream memoryStream5 = new MemoryStream();
					data.uv[i].Serialize(memoryStream5, endianess);
					bufferItem6.Data = memoryStream5.ToArray();
					bufferItem6.BufferType = new DescriptionType(DescriptionTypeEnum.UV);
					list.Add(bufferItem6);
					num += 8;
				}
				if ((flags & MeshExportFlags.Group) == MeshExportFlags.Group)
				{
					BufferItem bufferItem7 = new BufferItem(endianess);
					bufferItem7.Data = data.group[i];
					bufferItem7.BufferType = new DescriptionType(DescriptionTypeEnum.Group);
					list.Add(bufferItem7);
					num += 8;
				}
				if ((flags & MeshExportFlags.Padding) == MeshExportFlags.Padding)
				{
					BufferItem bufferItem8 = new BufferItem(endianess);
					MemoryStream memoryStream6 = new MemoryStream();
					Vector2 vector4 = new Vector2();
					vector4.X = 0f;
					vector4.Y = 0f;
					vector4.Serialize(memoryStream6, endianess);
					bufferItem8.Data = memoryStream6.ToArray();
					bufferItem8.BufferType = new DescriptionType(DescriptionTypeEnum.Padding1);
					list.Add(bufferItem8);
					num += 8;
				}
			}
			return new P2Buffer
			{
				BufferSize = (uint)(data.vertices * desc.DescriptionSize),
				BufferItems = list.ToArray()
			};
		}
	}
}
