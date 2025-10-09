using SharpGL.SceneGraph;
using SharpGL.SceneGraph.Primitives;
using Index = SharpGL.SceneGraph.Index;

namespace MU.GameTools.Edit3D.Tools.Viewer
{
	internal class TextureCube : Polygon
	{
		public TextureCube()
		{
			CreateGeometry();
		}

		private void CreateGeometry()
		{
			base.UVs.Add(new UV(0f, 0f));
			base.UVs.Add(new UV(0f, 1f));
			base.UVs.Add(new UV(1f, 1f));
			base.UVs.Add(new UV(1f, 0f));
			base.Vertices.Add(new Vertex(-1000f, -1000f, -1000f));
			base.Vertices.Add(new Vertex(1000f, -1000f, -1000f));
			base.Vertices.Add(new Vertex(1000f, -1000f, 1000f));
			base.Vertices.Add(new Vertex(-1000f, -1000f, 1000f));
			base.Vertices.Add(new Vertex(-1000f, 1000f, -1000f));
			base.Vertices.Add(new Vertex(1000f, 1000f, -1000f));
			base.Vertices.Add(new Vertex(1000f, 1000f, 1000f));
			base.Vertices.Add(new Vertex(-1000f, 1000f, 1000f));
			Face face = new Face();
			face.Indices.Add(new Index(1, 0));
			face.Indices.Add(new Index(2, 1));
			face.Indices.Add(new Index(3, 2));
			face.Indices.Add(new Index(0, 3));
			base.Faces.Add(face);
			face = new Face();
			face.Indices.Add(new Index(7, 0));
			face.Indices.Add(new Index(6, 1));
			face.Indices.Add(new Index(5, 2));
			face.Indices.Add(new Index(4, 3));
			base.Faces.Add(face);
			face = new Face();
			face.Indices.Add(new Index(5, 0));
			face.Indices.Add(new Index(6, 1));
			face.Indices.Add(new Index(2, 2));
			face.Indices.Add(new Index(1, 3));
			base.Faces.Add(face);
			face = new Face();
			face.Indices.Add(new Index(7, 0));
			face.Indices.Add(new Index(4, 1));
			face.Indices.Add(new Index(0, 2));
			face.Indices.Add(new Index(3, 3));
			base.Faces.Add(face);
			face = new Face();
			face.Indices.Add(new Index(4, 0));
			face.Indices.Add(new Index(5, 1));
			face.Indices.Add(new Index(1, 2));
			face.Indices.Add(new Index(0, 3));
			base.Faces.Add(face);
			face = new Face();
			face.Indices.Add(new Index(6, 0));
			face.Indices.Add(new Index(7, 1));
			face.Indices.Add(new Index(3, 2));
			face.Indices.Add(new Index(2, 3));
			base.Faces.Add(face);
		}
	}
}
