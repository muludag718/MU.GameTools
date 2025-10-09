using System;
using System.Collections.Generic;
using System.Linq;
using MU.GameTools.Prototype.FileFormats;
using MU.GameTools.Prototype.FileFormats.Pure3D;
using MU.GameTools.Prototype.FileFormats.Pure3D.Prototype2;

namespace MU.GameTools.Prototype2.Importing
{
	public static class Mesh
	{
		public static List<MeshImportData> GetDrawables(Pure3DFile p3d)
		{
			List<P2PolySkinMetadata> list = new List<P2PolySkinMetadata>();
			foreach (CompositeDrawable item in p3d.Nodes.OfType<CompositeDrawable>())
			{
				List<P2PolySkinMetadata> childNodesRecursive = item.GetChildNodesRecursive<P2PolySkinMetadata>();
				list.AddRange(childNodesRecursive);
			}
			List<MeshImportData> list2 = new List<MeshImportData>();
			foreach (P2PolySkinMetadata item2 in list)
			{
				MeshImportData meshImportData = new MeshImportData();
				CompositeDrawable compositeDrawable = (CompositeDrawable)item2.ParentNode.ParentNode;
				meshImportData.name = compositeDrawable.Name;
				meshImportData.skeletonName = compositeDrawable.SkeletonName;
				foreach (P2Primitive item3 in p3d.Nodes.OfType<P2Primitive>())
				{
					if (item3.Name == item2.IndicesName)
					{
						meshImportData.indices = item3;
					}
					else if (item3.Name == item2.SkinName)
					{
						meshImportData.skin = item3;
					}
					else if (item3.Name == item2.VerticesName)
					{
						meshImportData.vertices = item3;
					}
				}
				if (meshImportData.skin == null)
				{
					meshImportData.skin = meshImportData.vertices;
				}
				list2.Add(meshImportData);
			}
			return list2;
		}

		public static MeshImportData GetDrawable(Pure3DFile p3d, P2PolySkin polySkin)
		{
			P2PolySkinMetadata childNode = polySkin.GetChildNode<P2PolySkinMetadata>();
			MeshImportData meshImportData = new MeshImportData();
			CompositeDrawable compositeDrawable = (CompositeDrawable)childNode.ParentNode.ParentNode;
			meshImportData.name = compositeDrawable.Name;
			meshImportData.skeletonName = compositeDrawable.SkeletonName;
			foreach (P2Primitive item in p3d.Nodes.OfType<P2Primitive>())
			{
				if (item.Name == childNode.IndicesName)
				{
					meshImportData.indices = item;
				}
				else if (item.Name == childNode.SkinName)
				{
					meshImportData.skin = item;
				}
				else if (item.Name == childNode.VerticesName)
				{
					meshImportData.vertices = item;
				}
			}
			if (meshImportData.skin == null)
			{
				meshImportData.skin = meshImportData.vertices;
			}
			return meshImportData;
		}

		public static List<T> GetBuffer<T>(DescriptionTypeEnum descriptionType, P2Primitive primitive, bool isUV = false)
		{
			List<T> list = new List<T>();
			P2Buffer childNode = primitive.GetChildNode<P2Buffer>();
			if (childNode != null)
			{
				int num = Utils.FindIndexOfDescription(descriptionType, childNode.Description);
				for (int i = 0; i < primitive.NumberOfVertices; i++)
				{
					int num2 = (int)(i * childNode.Description.AmountOfDescriptions + num);
					T item = (T)childNode.BufferItems[num2].GetValueP2();
					list.Add(item);
				}
				return list;
			}
			throw new Exception("Vertex buffer not found.");
		}

		public static List<Face> GetFaces(P2Primitive primitive)
		{
			List<Face> list = new List<Face>();
			P2Buffer childNode = primitive.GetChildNode<P2Buffer>();
			for (int i = 0; i < primitive.NumberOfVertices / 3; i++)
			{
				ushort[] array = new ushort[3];
				for (int j = 0; j < 3; j++)
				{
					BufferItem bufferItem = childNode.BufferItems[i * 3 + j];
					array[j] = BitConverter.ToUInt16(bufferItem.Data, 0);
				}
				Face face = new Face();
				face.Point1 = array[0];
				face.Point2 = array[1];
				face.Point3 = array[2];
				list.Add(face);
			}
			return list;
		}
	}
}
