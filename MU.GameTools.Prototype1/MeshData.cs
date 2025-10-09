using System.Collections.Generic;
using MU.GameTools.Prototype.FileFormats;
using MU.GameTools.Common;

namespace MU.GameTools.Prototype1
{
	public class MeshData
	{
		public List<Vector3> position;

		public List<Vector3> normal;

		public List<Vector3> weight;

		public List<Vector4> tangent;

		public List<byte[]> group;

		public List<UVCoordinate> uv;
	}
}
