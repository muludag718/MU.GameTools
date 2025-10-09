using System;
using System.Collections.Generic;
using System.IO;
using MU.GameTools.IO;
using MU.GameTools.Prototype.FileFormats;
using MU.GameTools.Prototype.FileFormats.Pure3D;
using MU.GameTools.Common;
using MU.GameTools.Prototype1.Importing;

namespace MU.GameTools.Prototype1
{
	public class ImportP3D
	{
		public static Pure3DFile ReadP3DFile(string path, bool bigEndian = false)
		{
			Pure3DFile pure3DFile = new Pure3DFile();
			using FileStream input = File.OpenRead(path);
			pure3DFile.Deserialize(input, bigEndian ? Endian.Big : Endian.Little);
			return pure3DFile;
		}

		public static List<Vector3> GetPositionVertices(PrimitiveGroup primitiveGroup)
		{
			List<Vector3> list = ((!Utils.IsRawBuffer(primitiveGroup)) ? Mesh.GetBuffer<Vector3>(DescriptionTypeEnum.Position, primitiveGroup) : Mesh.GetRawPositionBuffer(primitiveGroup));
			if (list.Count <= 0)
			{
				throw new Exception("Vertex buffer is empty.");
			}
			return list;
		}

		public static List<Face> GetFaces(PrimitiveGroup primitiveGroup)
		{
			List<Face> list = ((!Utils.IsRawBuffer(primitiveGroup)) ? Mesh.GetFaces(primitiveGroup) : Mesh.GetRawFaceBuffer(primitiveGroup));
			if (list.Count <= 0)
			{
				throw new Exception("Face buffer is empty.");
			}
			return list;
		}

		public static List<UVCoordinate> GetUVs(PrimitiveGroup primitiveGroup)
		{
			List<UVCoordinate> list = ((!Utils.IsRawBuffer(primitiveGroup)) ? Mesh.GetBuffer<UVCoordinate>(DescriptionTypeEnum.UV, primitiveGroup, isUV: true) : Mesh.GetRawUVBuffer(primitiveGroup));
			if (list.Count <= 0)
			{
				throw new Exception("UV buffer is empty.");
			}
			return list;
		}

		public static List<Vector3> GetNormals(PrimitiveGroup primitiveGroup)
		{
			return Mesh.GetBuffer<Vector3>(DescriptionTypeEnum.Normal, primitiveGroup);
		}

		public static List<Vector3> GetWeights(PrimitiveGroup primitiveGroup)
		{
			return Mesh.GetBuffer<Vector3>(DescriptionTypeEnum.Weight, primitiveGroup);
		}

		public static List<byte[]> GetGroups(PrimitiveGroup primitiveGroup)
		{
			return Mesh.GetBuffer<byte[]>(DescriptionTypeEnum.Group, primitiveGroup);
		}

		public static List<uint> GetMatrixIndices(PrimitiveGroup primitiveGroup)
		{
			return Mesh.GetMatrixIndices(primitiveGroup);
		}

		public static byte[] UncompressAnimationData(AnimationData animationData)
		{
			return Anim.UncompressAnimationData(animationData);
		}

		public static Dictionary<ushort, FrameData> GetFrameData(AnimationBone bone, byte[] animationData)
		{
			return Anim.GetFrameData(bone, animationData);
		}
	}
}
