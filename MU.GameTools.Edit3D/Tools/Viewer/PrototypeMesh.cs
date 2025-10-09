using MU.GameTools.Prototype.FileFormats;
using MU.GameTools.Prototype.FileFormats.Pure3D;
using MU.GameTools.Prototype.FileFormats.Pure3D.Prototype2;
using MU.GameTools.Common;
using MU.GameTools.Prototype2;
using SharpGL.SceneGraph;
using SharpGL.SceneGraph.Primitives;
using Index = SharpGL.SceneGraph.Index;

namespace MU.GameTools.Edit3D.Tools.Viewer
{
	internal class PrototypeMesh : Polygon
	{
		public PrototypeMesh()
		{
			base.Name = "Mesh";
			base.Material.Diffuse = Color.White;
		}

		public PrototypeMesh(string name)
		{
			base.Name = name;
		}

		public static PrototypeMesh CreateFromPrimitiveGroup(string name, PrimitiveGroup primitiveGroup)
		{
			PrototypeMesh prototypeMesh = new PrototypeMesh(name);
			foreach (Vector3 positionVertex in MU.GameTools.Prototype1.ImportP3D.GetPositionVertices(primitiveGroup))
			{
				prototypeMesh.Vertices.Add(new Vertex(positionVertex.X * 1000f, positionVertex.Z * -1000f, positionVertex.Y * 1000f));
			}
			foreach (MU.GameTools.Prototype.FileFormats.Face face2 in MU.GameTools.Prototype1.ImportP3D.GetFaces(primitiveGroup))
			{
				SharpGL.SceneGraph.Face face = new SharpGL.SceneGraph.Face();
				face.Indices.Add(new Index(face2.Point1));
				face.Indices.Add(new Index(face2.Point3));
				face.Indices.Add(new Index(face2.Point2));
				prototypeMesh.Faces.Add(face);
			}
			return prototypeMesh;
		}

		public static PrototypeMesh CreateFromP2Polyskin(Pure3DFile p3d, P2PolySkin polyskin)
		{
			PrototypeMesh prototypeMesh = new PrototypeMesh("MyMesh");
			MeshImportData drawable = MU.GameTools.Prototype2.ImportP3D.GetDrawable(p3d, polyskin);
			foreach (Vector3 vertex in MU.GameTools.Prototype2.ImportP3D.GetVertices(drawable.skin))
			{
				prototypeMesh.Vertices.Add(new Vertex(vertex.X * 1000f, vertex.Z * -1000f, vertex.Y * 1000f));
			}
			foreach (MU.GameTools.Prototype.FileFormats.Face face2 in MU.GameTools.Prototype2.ImportP3D.GetFaces(drawable.indices))
			{
				SharpGL.SceneGraph.Face face = new SharpGL.SceneGraph.Face();
				face.Indices.Add(new Index(face2.Point1));
				face.Indices.Add(new Index(face2.Point3));
				face.Indices.Add(new Index(face2.Point2));
				prototypeMesh.Faces.Add(face);
			}
			return prototypeMesh;
		}
	}
}
