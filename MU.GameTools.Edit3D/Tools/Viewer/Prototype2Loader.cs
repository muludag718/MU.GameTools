using System.Collections.Generic;
using MU.GameTools.Prototype.FileFormats;
using MU.GameTools.Prototype.FileFormats.Pure3D;
using MU.GameTools.Prototype.FileFormats.Pure3D.Prototype2;
using SharpGL;
using SharpGL.SceneGraph.Primitives;

namespace MU.GameTools.Edit3D.Tools.Viewer
{
	internal static class Prototype2Loader
	{
		private static Polygon CreateFromCompositeDrawable(Pure3DFile p3d, CompositeDrawable baseNode)
		{
			List<P2PolySkin> childNodes = baseNode.GetChildNodes<P2PolySkin>();
			Polygon polygon = new Polygon();
			foreach (P2PolySkin item2 in childNodes)
			{
				PrototypeMesh item = PrototypeMesh.CreateFromP2Polyskin(p3d, item2);
				polygon.Children.Add(item);
			}
			return polygon;
		}

		public static Polygon LoadNode(OpenGL gl, Pure3DFile p3d, BaseNode baseNode)
		{
			if (baseNode is Texture || baseNode is TextureDDS)
			{
				return ViewerUtils.CreateTexture(gl, baseNode);
			}
			if (baseNode is P2PolySkin polyskin)
			{
				return PrototypeMesh.CreateFromP2Polyskin(p3d, polyskin);
			}
			if (baseNode is CompositeDrawable baseNode2)
			{
				return CreateFromCompositeDrawable(p3d, baseNode2);
			}
			return null;
		}
	}
}
