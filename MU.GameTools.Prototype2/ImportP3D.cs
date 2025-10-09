using System.Collections.Generic;
using System.IO;
using MU.GameTools.IO;
using MU.GameTools.Prototype.FileFormats;
using MU.GameTools.Prototype.FileFormats.Pure3D.Prototype2;
using MU.GameTools.Common;
using MU.GameTools.Prototype2.Importing;

namespace MU.GameTools.Prototype2
{
	public static class ImportP3D
	{
		public static Pure3DFile ReadP3DFile(string path, bool bigEndian = false)
		{
			Pure3DFile pure3DFile = new Pure3DFile();
			using FileStream input = File.OpenRead(path);
			pure3DFile.Deserialize(input, bigEndian ? Endian.Big : Endian.Little);
			return pure3DFile;
		}

		public static List<MeshImportData> GetDrawables(Pure3DFile p3d)
		{
			return Mesh.GetDrawables(p3d);
		}

		public static MeshImportData GetDrawable(Pure3DFile p3d, P2PolySkin polySkin)
		{
			return Mesh.GetDrawable(p3d, polySkin);
		}

		public static List<Vector3> GetVertices(P2Primitive primitive)
		{
			return Mesh.GetBuffer<Vector3>(DescriptionTypeEnum.Position, primitive);
		}

		public static List<Face> GetFaces(P2Primitive primitive)
		{
			return Mesh.GetFaces(primitive);
		}

		public static List<UVCoordinate> GetUVs(P2Primitive primitive)
		{
			return Mesh.GetBuffer<UVCoordinate>(DescriptionTypeEnum.UV, primitive, isUV: true);
		}

		public static List<Vector3> GetNormals(P2Primitive primitive)
		{
			return Mesh.GetBuffer<Vector3>(DescriptionTypeEnum.Normal, primitive);
		}

		public static List<Vector4> GetWeights(P2Primitive primitive)
		{
			return Mesh.GetBuffer<Vector4>(DescriptionTypeEnum.Weight, primitive);
		}

		public static List<byte[]> GetGroups(P2Primitive primitive)
		{
			return Mesh.GetBuffer<byte[]>(DescriptionTypeEnum.Group, primitive);
		}
	}
}
