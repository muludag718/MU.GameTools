using System.Collections.Generic;
using System.IO;
using MU.GameTools.IO;
using MU.GameTools.Prototype.FileFormats;
using MU.GameTools.Prototype.FileFormats.Pure3D;
using MU.GameTools.Prototype.FileFormats.Pure3D.Prototype1;
using MU.GameTools.Common;

namespace MU.GameTools.Prototype1.Exporting
{
	public static class Mesh
	{
		public static PrimitiveGroup CreatePrimitiveGroup(Endian endian, List<Vector3> position, List<Vector3Int> faces, List<Vector3> normal, List<float> weights, List<byte> groups, List<UVCoordinate> uvs, List<uint> skeletonGroups)
		{
			PrimitiveGroup primitiveGroup = new PrimitiveGroup();
			primitiveGroup.MemoryImaged = 1u;
			primitiveGroup.Optimized = 1u;
			primitiveGroup.Version = 0u;
			primitiveGroup.VertexAnimated = 0u;
			primitiveGroup.VertexAnimationMask = 0u;
			primitiveGroup.VertexType = 45489u;
			primitiveGroup.NumIndices = (uint)(faces.Count * 3);
			primitiveGroup.NumVertices = (uint)position.Count;
			primitiveGroup.NumMatrices = (uint)skeletonGroups.Count;
			MeshExportFlags meshExportFlags = MeshExportFlags.Position;
			MeshData meshData = new MeshData();
			meshData.position = position;
			if (weights != null)
			{
				meshExportFlags |= MeshExportFlags.Weight;
				List<Vector3> list = new List<Vector3>();
				for (int i = 0; i < weights.Count; i += 3)
				{
					Vector3 vector = new Vector3();
					vector.X = weights[i];
					vector.Y = weights[i + 1];
					vector.Z = weights[i + 2];
					list.Add(vector);
				}
				meshData.weight = list;
			}
			if (groups != null)
			{
				meshExportFlags |= MeshExportFlags.Group;
				List<byte[]> list2 = new List<byte[]>();
				for (int j = 0; j < groups.Count; j += 4)
				{
					list2.Add(new byte[4]
					{
						groups[j],
						groups[j + 1],
						groups[j + 2],
						groups[j + 2]
					});
				}
				meshData.group = list2;
			}
			if (uvs != null)
			{
				meshData.uv = uvs;
			}
			if (normal != null)
			{
				meshExportFlags |= MeshExportFlags.Normal;
				meshData.normal = normal;
			}
			primitiveGroup.Children.Add(CreateVertexDescriptor(position.Count, meshExportFlags, uv: false));
			primitiveGroup.Children.Add(CreateVertexDescriptor(position.Count, MeshExportFlags.UV | MeshExportFlags.Padding, uv: true));
			primitiveGroup.Children.Add(CreateVertexBuffer(meshExportFlags, meshData, uv: false, endian));
			primitiveGroup.Children.Add(CreateVertexBuffer(MeshExportFlags.UV | MeshExportFlags.Padding, meshData, uv: true, endian));
			primitiveGroup.Children.Add(CreateIndexBuffer(faces));
			primitiveGroup.Children.Add(CreatePrimitiveMatrix(skeletonGroups));
			return primitiveGroup;
		}

		public static PrimitiveGroup CreatePrimitiveGroupGeometry(Endian endian, List<Vector3> position, List<Vector3Int> faces, List<Vector3> normal, List<UVCoordinate> uvs)
		{
			PrimitiveGroup obj = new PrimitiveGroup
			{
				MemoryImaged = 1u,
				Optimized = 1u,
				Version = 0u,
				VertexAnimated = 0u,
				VertexAnimationMask = 0u,
				VertexType = 45489u,
				NumIndices = (uint)(faces.Count * 3),
				NumVertices = (uint)position.Count,
				NumMatrices = 0u
			};
			MeshExportFlags meshExportFlags = MeshExportFlags.Position;
			MeshData meshData = new MeshData
			{
				position = position
			};
			if (uvs != null)
			{
				meshExportFlags |= MeshExportFlags.UV;
				meshData.uv = uvs;
			}
			if (normal != null)
			{
				meshExportFlags |= MeshExportFlags.Normal;
				meshData.normal = normal;
			}
			obj.Children.Add(CreateVertexDescriptor4(position.Count, meshExportFlags, uv: false));
			obj.Children.Add(CreateVertexBuffer4(meshExportFlags, meshData, uv: false, endian));
			obj.Children.Add(CreateIndexBuffer(faces));
			return obj;
		}

		public static VertexDescriptionList CreateVertexDescriptor(int vertices, MeshExportFlags flags, bool uv)
		{
			uint num = 0u;
			uint num2 = 0u;
			List<VertexDescription> list = new List<VertexDescription>();
			if ((flags & MeshExportFlags.Padding) == MeshExportFlags.Padding)
			{
				VertexDescription vertexDescription = new VertexDescription();
				vertexDescription.Offset = num;
				vertexDescription.BufferType = new DescriptionType(DescriptionTypeEnum.UVPadding1);
				vertexDescription.Unknown1 = 7u;
				vertexDescription.Unknown2 = 16778240u;
				list.Add(vertexDescription);
				num += 4;
				num2 += 4;
			}
			if ((flags & MeshExportFlags.Position) == MeshExportFlags.Position)
			{
				VertexDescription vertexDescription2 = new VertexDescription();
				vertexDescription2.Offset = num;
				vertexDescription2.BufferType = new DescriptionType(DescriptionTypeEnum.Position);
				vertexDescription2.Unknown1 = 0u;
				vertexDescription2.Unknown2 = 0u;
				list.Add(vertexDescription2);
				num += 12;
				num2 += 12;
			}
			if ((flags & MeshExportFlags.UV) == MeshExportFlags.UV)
			{
				VertexDescription vertexDescription3 = new VertexDescription();
				vertexDescription3.Offset = num;
				vertexDescription3.BufferType = new DescriptionType(DescriptionTypeEnum.UV);
				vertexDescription3.Unknown1 = 0u;
				vertexDescription3.Unknown2 = 512u;
				list.Add(vertexDescription3);
				num += 8;
				num2 += 8;
			}
			if ((flags & MeshExportFlags.Normal) == MeshExportFlags.Normal)
			{
				VertexDescription vertexDescription4 = new VertexDescription();
				vertexDescription4.Offset = num;
				vertexDescription4.BufferType = new DescriptionType(DescriptionTypeEnum.Normal);
				vertexDescription4.Unknown1 = 0u;
				vertexDescription4.Unknown2 = 16777984u;
				list.Add(vertexDescription4);
				num += 12;
				num2 += 12;
			}
			if ((flags & MeshExportFlags.Weight) == MeshExportFlags.Weight)
			{
				VertexDescription vertexDescription5 = new VertexDescription();
				vertexDescription5.Offset = num;
				vertexDescription5.BufferType = new DescriptionType(DescriptionTypeEnum.Weight);
				vertexDescription5.Unknown1 = 0u;
				vertexDescription5.Unknown2 = 0u;
				list.Add(vertexDescription5);
				num += 12;
				num2 += 12;
			}
			if ((flags & MeshExportFlags.Group) == MeshExportFlags.Group)
			{
				VertexDescription vertexDescription6 = new VertexDescription();
				vertexDescription6.Offset = num;
				vertexDescription6.BufferType = new DescriptionType(DescriptionTypeEnum.Group);
				vertexDescription6.Unknown1 = 0u;
				vertexDescription6.Unknown2 = 0u;
				list.Add(vertexDescription6);
				num += 4;
				num2 += 4;
			}
			foreach (VertexDescription item in list)
			{
				item.VertexObjectSize = num2;
			}
			VertexDescriptionList obj = new VertexDescriptionList
			{
				Version = 131073u,
				Param = (uv ? 1u : 2u),
				AmountOfDescriptions = (uint)list.Count
			};
			obj.DescriptionSize = obj.AmountOfDescriptions * 17;
			obj.BufferSize = (uint)(num2 * vertices);
			obj.Descriptions = list.ToArray();
			return obj;
		}

		public static VertexDescriptionList CreateVertexDescriptor4(int vertices, MeshExportFlags flags, bool uv)
		{
			uint num = 0u;
			uint num2 = 0u;
			List<VertexDescription> list = new List<VertexDescription>();
			if ((flags & MeshExportFlags.Padding) == MeshExportFlags.Padding)
			{
				VertexDescription vertexDescription = new VertexDescription();
				vertexDescription.Offset = num;
				vertexDescription.BufferType = new DescriptionType(DescriptionTypeEnum.UVPadding1);
				vertexDescription.Unknown1 = 7u;
				vertexDescription.Unknown2 = 16778240u;
				list.Add(vertexDescription);
				num += 4;
				num2 += 4;
			}
			if ((flags & MeshExportFlags.Position) == MeshExportFlags.Position)
			{
				VertexDescription vertexDescription2 = new VertexDescription();
				vertexDescription2.Offset = num;
				vertexDescription2.BufferType = new DescriptionType(DescriptionTypeEnum.Position);
				vertexDescription2.Unknown1 = 0u;
				vertexDescription2.Unknown2 = 1024u;
				list.Add(vertexDescription2);
				num += 16;
				num2 += 16;
			}
			if ((flags & MeshExportFlags.UV) == MeshExportFlags.UV)
			{
				VertexDescription vertexDescription3 = new VertexDescription();
				vertexDescription3.Offset = num;
				vertexDescription3.BufferType = new DescriptionType(DescriptionTypeEnum.UV);
				vertexDescription3.Unknown1 = 0u;
				vertexDescription3.Unknown2 = 512u;
				list.Add(vertexDescription3);
				num += 8;
				num2 += 8;
			}
			if ((flags & MeshExportFlags.Normal) == MeshExportFlags.Normal)
			{
				VertexDescription vertexDescription4 = new VertexDescription();
				vertexDescription4.Offset = num;
				vertexDescription4.BufferType = new DescriptionType(DescriptionTypeEnum.Normal);
				vertexDescription4.Unknown1 = 0u;
				vertexDescription4.Unknown2 = 16777984u;
				list.Add(vertexDescription4);
				num += 12;
				num2 += 12;
			}
			if ((flags & MeshExportFlags.Weight) == MeshExportFlags.Weight)
			{
				VertexDescription vertexDescription5 = new VertexDescription();
				vertexDescription5.Offset = num;
				vertexDescription5.BufferType = new DescriptionType(DescriptionTypeEnum.Weight);
				vertexDescription5.Unknown1 = 0u;
				vertexDescription5.Unknown2 = 0u;
				list.Add(vertexDescription5);
				num += 12;
				num2 += 12;
			}
			if ((flags & MeshExportFlags.Group) == MeshExportFlags.Group)
			{
				VertexDescription vertexDescription6 = new VertexDescription();
				vertexDescription6.Offset = num;
				vertexDescription6.BufferType = new DescriptionType(DescriptionTypeEnum.Group);
				vertexDescription6.Unknown1 = 0u;
				vertexDescription6.Unknown2 = 0u;
				list.Add(vertexDescription6);
				num += 4;
				num2 += 4;
			}
			foreach (VertexDescription item in list)
			{
				item.VertexObjectSize = num2;
			}
			VertexDescriptionList obj = new VertexDescriptionList
			{
				Version = 131073u,
				Param = (uv ? 1u : 2u),
				AmountOfDescriptions = (uint)list.Count
			};
			obj.DescriptionSize = obj.AmountOfDescriptions * 17;
			obj.BufferSize = (uint)(num2 * vertices);
			obj.Descriptions = list.ToArray();
			return obj;
		}

		public static VertexBuffer CreateVertexBuffer4(MeshExportFlags flags, MeshData data, bool uv, Endian endian)
		{
			List<BufferItem> list = new List<BufferItem>();
			uint num = 0u;
			for (int i = 0; i < data.position.Count; i++)
			{
				if ((flags & MeshExportFlags.Padding) == MeshExportFlags.Padding)
				{
					BufferItem bufferItem = new BufferItem(endian);
					bufferItem.Data = new byte[4] { 255, 255, 255, 255 };
					list.Add(bufferItem);
					num += 4;
				}
				if ((flags & MeshExportFlags.Position) == MeshExportFlags.Position)
				{
					BufferItem bufferItem2 = new BufferItem(endian);
					MemoryStream memoryStream = new MemoryStream();
					data.position[i].Serialize(memoryStream, endian);
					byte[] array = new byte[16];
					array[15] = 0;
					array[14] = 0;
					array[13] = 0;
					array[12] = 0;
					byte[] array2 = memoryStream.ToArray();
					for (int j = 0; j < array2.Length; j++)
					{
						array[j] = array2[j];
					}
					bufferItem2.Data = array;
					list.Add(bufferItem2);
					num += 16;
				}
				if ((flags & MeshExportFlags.UV) == MeshExportFlags.UV)
				{
					BufferItem bufferItem3 = new BufferItem(endian);
					MemoryStream memoryStream2 = new MemoryStream();
					data.uv[i].Serialize(memoryStream2, endian);
					bufferItem3.Data = memoryStream2.ToArray();
					list.Add(bufferItem3);
					num += 8;
				}
				if ((flags & MeshExportFlags.Normal) == MeshExportFlags.Normal)
				{
					BufferItem bufferItem4 = new BufferItem(endian);
					MemoryStream memoryStream3 = new MemoryStream();
					data.normal[i].Serialize(memoryStream3, endian);
					bufferItem4.Data = memoryStream3.ToArray();
					list.Add(bufferItem4);
					num += 12;
				}
				if ((flags & MeshExportFlags.Weight) == MeshExportFlags.Weight)
				{
					BufferItem bufferItem5 = new BufferItem(endian);
					MemoryStream memoryStream4 = new MemoryStream();
					data.weight[i].Serialize(memoryStream4, endian);
					bufferItem5.Data = memoryStream4.ToArray();
					list.Add(bufferItem5);
					num += 12;
				}
				if ((flags & MeshExportFlags.Group) == MeshExportFlags.Group)
				{
					BufferItem bufferItem6 = new BufferItem(endian);
					bufferItem6.Data = data.group[i];
					list.Add(bufferItem6);
					num += 4;
				}
			}
			return new VertexBuffer
			{
				Version = 131073u,
				Param = (uv ? 1u : 2u),
				BufferSize = num,
				BufferItems = list.ToArray()
			};
		}

		public static VertexBuffer CreateVertexBuffer(MeshExportFlags flags, MeshData data, bool uv, Endian endian)
		{
			List<BufferItem> list = new List<BufferItem>();
			uint num = 0u;
			for (int i = 0; i < data.position.Count; i++)
			{
				if ((flags & MeshExportFlags.Padding) == MeshExportFlags.Padding)
				{
					BufferItem bufferItem = new BufferItem(endian);
					bufferItem.Data = new byte[4] { 255, 255, 255, 255 };
					list.Add(bufferItem);
					num += 4;
				}
				if ((flags & MeshExportFlags.Position) == MeshExportFlags.Position)
				{
					BufferItem bufferItem2 = new BufferItem(endian);
					MemoryStream memoryStream = new MemoryStream();
					data.position[i].Serialize(memoryStream, endian);
					bufferItem2.Data = memoryStream.ToArray();
					list.Add(bufferItem2);
					num += 12;
				}
				if ((flags & MeshExportFlags.Normal) == MeshExportFlags.Normal)
				{
					BufferItem bufferItem3 = new BufferItem(endian);
					MemoryStream memoryStream2 = new MemoryStream();
					data.normal[i].Serialize(memoryStream2, endian);
					bufferItem3.Data = memoryStream2.ToArray();
					list.Add(bufferItem3);
					num += 12;
				}
				if ((flags & MeshExportFlags.Weight) == MeshExportFlags.Weight)
				{
					BufferItem bufferItem4 = new BufferItem(endian);
					MemoryStream memoryStream3 = new MemoryStream();
					data.weight[i].Serialize(memoryStream3, endian);
					bufferItem4.Data = memoryStream3.ToArray();
					list.Add(bufferItem4);
					num += 12;
				}
				if ((flags & MeshExportFlags.UV) == MeshExportFlags.UV)
				{
					BufferItem bufferItem5 = new BufferItem(endian);
					MemoryStream memoryStream4 = new MemoryStream();
					data.uv[i].Serialize(memoryStream4, endian);
					bufferItem5.Data = memoryStream4.ToArray();
					list.Add(bufferItem5);
					num += 8;
				}
				if ((flags & MeshExportFlags.Group) == MeshExportFlags.Group)
				{
					BufferItem bufferItem6 = new BufferItem(endian);
					bufferItem6.Data = data.group[i];
					list.Add(bufferItem6);
					num += 4;
				}
			}
			return new VertexBuffer
			{
				Version = 131073u,
				Param = (uv ? 1u : 2u),
				BufferSize = num,
				BufferItems = list.ToArray()
			};
		}

		public static IndexBuffer CreateIndexBuffer(List<Vector3Int> faces)
		{
			IndexBuffer ındexBuffer = new IndexBuffer();
			ındexBuffer.Version = 131073u;
			ındexBuffer.Param = 0u;
			ındexBuffer.BufferSize = (uint)(faces.Count * 6);
			ındexBuffer.Faces = new Face[faces.Count];
			for (int i = 0; i < faces.Count; i++)
			{
				Face face = new Face();
				face.Point1 = (ushort)faces[i].X;
				face.Point2 = (ushort)faces[i].Y;
				face.Point3 = (ushort)faces[i].Z;
				ındexBuffer.Faces[i] = face;
			}
			return ındexBuffer;
		}

		public static PrimitiveMatrix CreatePrimitiveMatrix(List<uint> skeletonGroups)
		{
			return new PrimitiveMatrix
			{
				Count = (uint)skeletonGroups.Count,
				Indices = skeletonGroups.ToArray()
			};
		}
	}
}
