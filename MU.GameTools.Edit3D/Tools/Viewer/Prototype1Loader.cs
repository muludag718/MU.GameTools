using System.Collections.Generic;
using MU.GameTools.Prototype.FileFormats.Pure3D;
using SharpGL;
using SharpGL.SceneGraph.Primitives;

namespace MU.GameTools.Edit3D.Tools.Viewer
{
	internal static class Prototype1Loader
	{
		private static Polygon CreateFromPolySkin(BaseNode baseNode)
		{
			List<PrimitiveGroup> childNodes = baseNode.GetChildNodes<PrimitiveGroup>();
			Polygon polygon = new Polygon();
			foreach (PrimitiveGroup item2 in childNodes)
			{
				PrototypeMesh item = PrototypeMesh.CreateFromPrimitiveGroup("MyMesh", item2);
				polygon.Children.Add(item);
			}
			return polygon;
		}

		public static Polygon LoadNode(OpenGL gl, BaseNode baseNode)
		{
			if (baseNode is PrimitiveGroup)
			{
				return PrototypeMesh.CreateFromPrimitiveGroup("MyMesh", (PrimitiveGroup)baseNode);
			}
			if (baseNode is PolySkin)
			{
				return CreateFromPolySkin(baseNode);
			}
			if (baseNode is Texture || baseNode is TextureDDS)
			{
				return ViewerUtils.CreateTexture(gl, baseNode);
			}
			return null;
		}
	}
}
