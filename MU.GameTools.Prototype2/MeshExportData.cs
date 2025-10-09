using System.Collections.Generic;
using MU.GameTools.Prototype.FileFormats;
using MU.GameTools.Common;

namespace MU.GameTools.Prototype2
{
	public class MeshExportData
	{
		public int vertices;

		public List<Vector3> position;

		public List<Vector3> normal;

		public List<Vector4> tangent;

		public List<Vector4> weight;

		public List<UVCoordinate> uv;

		public List<byte[]> group;

		public List<byte[]> colour;
	}
}
