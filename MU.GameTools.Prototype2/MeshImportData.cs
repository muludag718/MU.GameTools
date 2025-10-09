using MU.GameTools.Prototype.FileFormats.Pure3D.Prototype2;

namespace MU.GameTools.Prototype2
{
	public class MeshImportData
	{
		public string name;

		public string skeletonName;

		public P2Primitive indices;

		public P2Primitive skin;

		public P2Primitive vertices;

		public MeshImportData()
		{
		}

		public MeshImportData(string name, string skeletonName, P2Primitive indices, P2Primitive skin, P2Primitive vertices)
		{
			this.name = name;
			this.skeletonName = skeletonName;
			this.indices = indices;
			this.skin = skin;
			this.vertices = vertices;
		}
	}
}
