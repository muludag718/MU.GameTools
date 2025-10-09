using System;
using System.Collections.Generic;
using System.Linq;
using MU.GameTools.Prototype.FileFormats;
using MU.GameTools.Prototype.FileFormats.Pure3D;
using MU.GameTools.Prototype.FileFormats.Pure3D.Prototype1;
using MU.GameTools.Common;

namespace MU.GameTools.Prototype1.Importing
{
	public static class Mesh
	{
		public static List<T> GetBuffer<T>(DescriptionTypeEnum descriptionType, PrimitiveGroup primitiveGroup, bool isUV = false)
		{
			List<T> list = new List<T>();
			List<VertexBuffer> childNodes = primitiveGroup.GetChildNodes<VertexBuffer>();
			VertexBuffer vertexBuffer = childNodes.Find((VertexBuffer x) => x.Param == (isUV ? 1 : 2));
			if (vertexBuffer == null && childNodes.Count > 0)
			{
				vertexBuffer = childNodes[0];
			}
			if (vertexBuffer != null)
			{
				int num = Utils.FindIndexOfDescription(descriptionType, vertexBuffer.Description);
				if (num == -1)
				{
					return list;
				}
				for (int num2 = 0; num2 < primitiveGroup.NumVertices; num2++)
				{
					int num3 = (int)(num2 * vertexBuffer.Description.AmountOfDescriptions + num);
					T item = (T)vertexBuffer.BufferItems[num3].GetValueP1();
					list.Add(item);
				}
			}
			return list;
		}

		public static List<Face> GetFaces(PrimitiveGroup primitiveGroup)
		{
			IndexBuffer childNode = primitiveGroup.GetChildNode<IndexBuffer>();
			if (childNode != null)
			{
				return childNode.Faces.ToList();
			}
			throw new Exception("No faces found");
		}

		public static List<uint> GetMatrixIndices(PrimitiveGroup primitiveGroup)
		{
			List<uint> list = new List<uint>();
			PrimitiveMatrix childNode = primitiveGroup.GetChildNode<PrimitiveMatrix>();
			if (childNode == null || childNode.Count < 1)
			{
				return list;
			}
			for (int i = 0; i < childNode.Count; i++)
			{
				list.Add(childNode.Indices[i]);
			}
			return list;
		}

		public static List<Vector3> GetRawPositionBuffer(PrimitiveGroup primitiveGroup)
		{
			RawPositionBuffer childNode = primitiveGroup.GetChildNode<RawPositionBuffer>();
			if (childNode != null)
			{
				return childNode.Position.ToList();
			}
			throw new Exception("No position vertices found");
		}

		public static List<UVCoordinate> GetRawUVBuffer(PrimitiveGroup primitiveGroup)
		{
			RawUVBuffer childNode = primitiveGroup.GetChildNode<RawUVBuffer>();
			if (childNode != null)
			{
				return childNode.UVs.ToList();
			}
			throw new Exception("No position vertices found");
		}

		public static List<Face> GetRawFaceBuffer(PrimitiveGroup primitiveGroup)
		{
			List<Face> list = new List<Face>();
			RawIndexBuffer childNode = primitiveGroup.GetChildNode<RawIndexBuffer>();
			if (childNode != null)
			{
				for (int i = 0; i < childNode.Faces.Length; i++)
				{
					Face face = new Face();
					face.Point1 = (ushort)childNode.Faces[i].X;
					face.Point2 = (ushort)childNode.Faces[i].Y;
					face.Point3 = (ushort)childNode.Faces[i].Z;
					list.Add(face);
				}
				return list;
			}
			throw new Exception("No faces found");
		}
	}
}
