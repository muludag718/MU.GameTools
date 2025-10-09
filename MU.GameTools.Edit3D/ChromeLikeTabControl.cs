

using MU.GameTools.Edit3D.Properties;
using System.Drawing.Drawing2D;
using System.Drawing.Text;

namespace MU.GameTools.Edit3D;

public class ChromeLikeTabControl : TabControl
{
	private const int CLOSE_SIZE = 32;

	public override Rectangle DisplayRectangle
	{
		get
		{
			Rectangle displayRectangle = base.DisplayRectangle;
			return new Rectangle(displayRectangle.Left - 8, displayRectangle.Top - 1, displayRectangle.Width + 12, displayRectangle.Height + 8);
		}
	}

	public ChromeLikeTabControl()
	{
		SetStyles();
		base.SizeMode = TabSizeMode.Fixed;
		Dock = DockStyle.Fill;
		Font = new Font("Segoe UI", 9f);
		base.ItemSize = new Size(245, 35);
	}

	private void SetStyles()
	{
		SetStyle(ControlStyles.UserPaint | ControlStyles.ResizeRedraw | ControlStyles.SupportsTransparentBackColor | ControlStyles.AllPaintingInWmPaint | ControlStyles.DoubleBuffer | ControlStyles.OptimizedDoubleBuffer, value: true);
		UpdateStyles();
	}

	protected override void OnResize(EventArgs e)
	{
		base.OnResize(e);
		Refresh();
		Update();
	}

	protected override void OnPaint(PaintEventArgs e)
	{
		base.OnPaint(e);
		Rectangle clientRectangle = base.ClientRectangle;
		e.Graphics.SmoothingMode = SmoothingMode.HighQuality;
		e.Graphics.InterpolationMode = InterpolationMode.HighQualityBilinear;
		using BufferedGraphics bufferedGraphics = BufferedGraphicsManager.Current.Allocate(e.Graphics, clientRectangle);
		bufferedGraphics.Graphics.FillRectangle(new SolidBrush(Color.FromArgb(230, 232, 236)), clientRectangle);
		for (int i = 0; i < base.TabCount; i++)
		{
			DrawTabPage(bufferedGraphics.Graphics, GetTabRect(i), i);
		}
		bufferedGraphics.Render(e.Graphics);
	}

	private void DrawTabPage(Graphics graphics, Rectangle rectangle, int index)
	{
		graphics.SmoothingMode = SmoothingMode.HighQuality;
		graphics.InterpolationMode = InterpolationMode.HighQualityBilinear;
		graphics.TextRenderingHint = TextRenderingHint.AntiAlias;
		StringFormat stringFormat = new StringFormat();
		stringFormat.Trimming = StringTrimming.EllipsisCharacter;
		stringFormat.FormatFlags = StringFormatFlags.NoWrap;
		Rectangle rectangle2 = new Rectangle(rectangle.X + 20, rectangle.Y + 7, rectangle.Width, base.TabPages[index].Font.Height);
		Rectangle closeRect = GetCloseRect(rectangle);
		new Point(rectangle.Left, 7);
		Point point = new Point(closeRect.X - 12, 12);
		try
		{
			if (index == base.SelectedIndex)
			{
				graphics.FillPath(new SolidBrush(Color.FromArgb(255, 255, 255)), CreateTabPath(rectangle));
				graphics.DrawString(base.TabPages[index].Text, base.TabPages[index].Font, new SolidBrush(Color.SlateGray), rectangle2, stringFormat);
				if (base.ImageList != null)
				{
					int ımageIndex = base.TabPages[index].ImageIndex;
					string ımageKey = base.TabPages[index].ImageKey;
					Image image = new Bitmap(32, 32);
					if (ımageIndex > -1)
					{
						image = base.ImageList.Images[ımageIndex];
					}
					if (!string.IsNullOrEmpty(ımageKey))
					{
						image = base.ImageList.Images[ımageKey];
					}
					graphics.DrawImage(image, rectangle.Left + 22, rectangle.Top + 9);
				}
				using Bitmap image2 = Resources.CloseTab;
				graphics.DrawImage(image2, point);
				return;
			}
			graphics.FillPath(new SolidBrush(Color.FromArgb(230, 232, 236)), CreateTabPath(rectangle));
			graphics.DrawString(base.TabPages[index].Text, base.TabPages[index].Font, new SolidBrush(Color.Gray), rectangle2, stringFormat);
			if (base.ImageList != null)
			{
				int ımageIndex2 = base.TabPages[index].ImageIndex;
				string ımageKey2 = base.TabPages[index].ImageKey;
				Image image3 = new Bitmap(32, 32);
				if (ımageIndex2 > -1)
				{
					image3 = base.ImageList.Images[ımageIndex2];
				}
				if (!string.IsNullOrEmpty(ımageKey2))
				{
					image3 = base.ImageList.Images[ımageKey2];
				}
				graphics.DrawImage(image3, rectangle.Left + 22, rectangle.Top + 9);
			}
			using Bitmap image4 = Resources.CloseTab;
			graphics.DrawImage(image4, point);
		}
		catch (NullReferenceException)
		{
		}
	}

	protected override void OnMouseDown(MouseEventArgs e)
	{
		base.OnMouseDown(e);
		if (e.Button == MouseButtons.Left)
		{
			int num = e.X;
			int num2 = e.Y;
			Rectangle tabRect = GetTabRect(base.SelectedIndex);
			tabRect.Offset(tabRect.Width - 55, 5);
			tabRect.Width = 32;
			tabRect.Height = 32;
			if (num > tabRect.X && num < tabRect.Right && num2 > tabRect.Y && num2 < tabRect.Bottom)
			{
				if (base.TabPages.Count > 1)
				{
					TabPage selectedTab = base.SelectedTab;
					base.TabPages.Remove(selectedTab);
					base.SelectedIndex = base.TabPages.Count - 1;
					base.SelectedTab.Refresh();
					selectedTab.Dispose();
					GC.Collect();
					GC.WaitForPendingFinalizers();
				}
				else
				{
					TabPage selectedTab2 = base.SelectedTab;
					base.TabPages.Remove(selectedTab2);
					base.SelectedIndex = -1;
					selectedTab2.Dispose();
					GC.Collect();
					GC.WaitForPendingFinalizers();
				}
			}
		}
		else if (e.Button == MouseButtons.Middle)
		{
			if (base.TabPages.Count > 1)
			{
				TabPage selectedTab3 = base.SelectedTab;
				base.TabPages.Remove(selectedTab3);
				base.SelectedIndex = base.TabPages.Count - 1;
				base.SelectedTab.Refresh();
				selectedTab3.Dispose();
				GC.Collect();
				GC.WaitForPendingFinalizers();
			}
			else
			{
				TabPage selectedTab4 = base.SelectedTab;
				base.TabPages.Remove(selectedTab4);
				base.SelectedIndex = -1;
				selectedTab4.Dispose();
				GC.Collect();
				GC.WaitForPendingFinalizers();
			}
		}
	}

	private GraphicsPath CreateTabPath(Rectangle tabBounds)
	{
		GraphicsPath graphicsPath = new GraphicsPath();
		int num = (int)Math.Floor((decimal)tabBounds.Height);
		int num2 = (int)Math.Floor((decimal)tabBounds.Height * 1m / 11m);
		int num3 = (int)Math.Floor((decimal)tabBounds.Height * 3m / 10m);
		int num4 = (int)Math.Floor((decimal)tabBounds.Height * 2m / 3m);
		graphicsPath.AddCurve(new Point[4]
		{
			new Point(tabBounds.X, tabBounds.Bottom + 2),
			new Point(tabBounds.X + num3, tabBounds.Bottom - num2),
			new Point(tabBounds.X + num - num4, tabBounds.Y + num2),
			new Point(tabBounds.X + num, tabBounds.Y)
		});
		graphicsPath.AddLine(tabBounds.X + num, tabBounds.Y, tabBounds.Right - num, tabBounds.Y);
		graphicsPath.AddCurve(new Point[4]
		{
			new Point(tabBounds.Right - num, tabBounds.Y),
			new Point(tabBounds.Right - num + num4, tabBounds.Y + num2),
			new Point(tabBounds.Right - num3, tabBounds.Bottom - num2),
			new Point(tabBounds.Right + 2, tabBounds.Bottom + 2)
		});
		graphicsPath.CloseFigure();
		return graphicsPath;
	}

	private Rectangle GetCloseRect(Rectangle myTabRect)
	{
		myTabRect.Offset(myTabRect.Width - 42, 5);
		myTabRect.Width = 32;
		myTabRect.Height = 32;
		return myTabRect;
	}
}
