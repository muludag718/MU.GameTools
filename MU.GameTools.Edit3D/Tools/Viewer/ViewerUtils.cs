using System.Drawing;
using MU.GameTools.Prototype.FileFormats.Pure3D;
using SharpGL;
using SharpGL.SceneGraph.Assets;
using SharpGL.SceneGraph.Primitives;

namespace MU.GameTools.Edit3D.Tools.Viewer
{
	internal static class ViewerUtils
	{
		private static Polygon CreateTexture(OpenGL gl, Image image)
		{
			Bitmap image2 = new Bitmap(image);
			SharpGL.SceneGraph.Assets.Texture texture = new SharpGL.SceneGraph.Assets.Texture();
			texture.Create(gl, image2);
			new Material().Texture = texture;
			return new TextureCube();
		}

		public static Polygon CreateTexture(OpenGL gl, BaseNode baseNode)
		{
			Image image = (Image)baseNode.Preview();
			return CreateTexture(gl, image);
		}

		public static bool IsTexture(BaseNode baseNode)
		{
			if (!(baseNode is MU.GameTools.Prototype.FileFormats.Pure3D.Texture))
			{
				return baseNode is TextureDDS;
			}
			return true;
		}
	}
}
