using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using MU.GameTools.Prototype.FileFormats;
using MU.GameTools.Prototype.FileFormats.Pure3D;
using MU.GameTools.Common;
using SharpGL;
using SharpGL.SceneGraph;
using SharpGL.SceneGraph.Cameras;
using SharpGL.SceneGraph.Core;
using SharpGL.SceneGraph.Effects;
using SharpGL.SceneGraph.Primitives;

namespace MU.GameTools.Edit3D.Tools.Viewer
{
	public class ViewerTool : Form
	{
		private static ViewerTool myWindow;

		private bool isTexture;

		private ArcBallEffect arcBallEffect;

		private LinearTransformationEffect linearTransformationEffect;

		private Color clearColor;

		private SceneContainer container;

		private int prevMouseX;

		private int prevMouseY;

		private IContainer components;

		private MenuStrip menuStrip1;

		private SceneControl sceneControl;

		public static bool IsOpen => myWindow != null;

		private OpenGL GL => sceneControl.OpenGL;

		private Scene GLScene => sceneControl.Scene;

		private LookAtCamera SceneCamera => sceneControl.Scene.CurrentCamera as LookAtCamera;

		public ViewerTool()
		{
			InitializeComponent();
			GL.Enable(3553u);
			GLScene.RenderBoundingVolumes = false;
			clearColor = Color.FromArgb(60, 60, 60);
			GLScene.ClearColor = clearColor;
			CreateContainer();
			base.Load += delegate
			{
				myWindow = this;
			};
			base.Closed += delegate
			{
				myWindow = null;
			};
			sceneControl.MouseWheel += sceneControl_MouseScroll;
		}

		private void CreateContainer()
		{
			container = new SceneContainer();
			if (!isTexture)
			{
				container.AddChild(new Grid());
			}
			arcBallEffect = new ArcBallEffect(sceneControl.Scene.CurrentCamera as LookAtCamera);
			if (isTexture)
			{
				arcBallEffect.ArcBall.Scale = 1.4;
			}
			linearTransformationEffect = new LinearTransformationEffect();
			container.AddEffect(arcBallEffect);
			container.AddEffect(linearTransformationEffect);
			sceneControl.Scene.SceneContainer.AddChild(container);
			arcBallEffect.SetViewMode(isTexture ? ViewMode.VO : ViewMode.NO);
		}

		private void ClearScene()
		{
			GLScene.SceneContainer.RemoveChild(container);
			CreateContainer();
		}

		public bool LoadNode(PrototypeGame game, Pure3DFile p3d, BaseNode baseNode)
		{
			Polygon polygon = null;
			isTexture = ViewerUtils.IsTexture(baseNode);
			try
			{
				switch (game)
				{
				case PrototypeGame.P1:
					polygon = Prototype1Loader.LoadNode(GL, baseNode);
					break;
				case PrototypeGame.P2:
					polygon = Prototype2Loader.LoadNode(GL, p3d, baseNode);
					break;
				default:
					return false;
				}
			}
			catch (Exception)
			{
				MessageBox.Show("Error loading asset", "EditP3D", MessageBoxButtons.OK, MessageBoxIcon.Hand);
			}
			if (polygon == null)
			{
				return false;
			}
			ClearScene();
			container.AddChild(polygon);
			return true;
		}

		private void sceneControl_KeyDown(object sender, KeyEventArgs e)
		{
		}

		private void sceneControl_MouseUp(object sender, MouseEventArgs e)
		{
			arcBallEffect.ArcBall.MouseUp(e.X, e.Y);
		}

		private void sceneControl_MouseMove(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left && !isTexture)
			{
				arcBallEffect.ArcBall.MouseMove(e.X, e.Y);
			}
			if (e.Button == MouseButtons.Right)
			{
				linearTransformationEffect.LinearTransformation.TranslateZ += (e.Y - prevMouseY) * -5;
			}
			prevMouseX = e.X;
			prevMouseY = e.Y;
		}

		private void sceneControl_MouseDown(object sender, MouseEventArgs e)
		{
			arcBallEffect.ArcBall.MouseDown(e.X, e.Y, sceneControl.OpenGL);
		}

		private void sceneControl_MouseScroll(object sender, MouseEventArgs e)
		{
			arcBallEffect.ArcBall.MouseWheel(e.Delta);
		}

		protected override void Dispose(bool disposing)
		{
			if (disposing && components != null)
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		private void InitializeComponent()
		{
			this.menuStrip1 = new System.Windows.Forms.MenuStrip();
			this.sceneControl = new SharpGL.SceneControl();
			((System.ComponentModel.ISupportInitialize)this.sceneControl).BeginInit();
			base.SuspendLayout();
			this.menuStrip1.Location = new System.Drawing.Point(0, 0);
			this.menuStrip1.Name = "menuStrip1";
			this.menuStrip1.Size = new System.Drawing.Size(784, 24);
			this.menuStrip1.TabIndex = 1;
			this.menuStrip1.Text = "menuStrip1";
			this.menuStrip1.Visible = false;
			this.sceneControl.BackColor = System.Drawing.SystemColors.Control;
			this.sceneControl.Dock = System.Windows.Forms.DockStyle.Fill;
			this.sceneControl.DrawFPS = false;
			this.sceneControl.Location = new System.Drawing.Point(0, 0);
			this.sceneControl.Name = "sceneControl";
			this.sceneControl.OpenGLVersion = SharpGL.Version.OpenGLVersion.OpenGL2_1;
			this.sceneControl.RenderContextType = SharpGL.RenderContextType.NativeWindow;
			this.sceneControl.RenderTrigger = SharpGL.RenderTrigger.TimerBased;
			this.sceneControl.Size = new System.Drawing.Size(784, 561);
			this.sceneControl.TabIndex = 2;
			this.sceneControl.KeyDown += new System.Windows.Forms.KeyEventHandler(sceneControl_KeyDown);
			this.sceneControl.MouseDown += new System.Windows.Forms.MouseEventHandler(sceneControl_MouseDown);
			this.sceneControl.MouseMove += new System.Windows.Forms.MouseEventHandler(sceneControl_MouseMove);
			this.sceneControl.MouseUp += new System.Windows.Forms.MouseEventHandler(sceneControl_MouseUp);
			base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			base.ClientSize = new System.Drawing.Size(784, 561);
			base.Controls.Add(this.sceneControl);
			base.Controls.Add(this.menuStrip1);
			base.MainMenuStrip = this.menuStrip1;
			base.Name = "ViewerTool";
			this.Text = "Viewer";
			((System.ComponentModel.ISupportInitialize)this.sceneControl).EndInit();
			base.ResumeLayout(false);
			base.PerformLayout();
		}
	}
}
