using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace MU.GameTools.Edit3D.Tools
{
	public class FindWindow : Form
	{
		private static FindWindow myWindow;

		private IContainer components;

		private Label label1;

		private Label label2;

		private TextBox textBox1;

		private Button button1;

		private Button button2;

		private CheckBox checkBox1;

		public static bool IsOpen => myWindow != null;

		public FindWindow()
		{
			InitializeComponent();
			base.Load += delegate
			{
				myWindow = this;
			};
			base.Closed += delegate
			{
				myWindow = null;
			};
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
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.textBox1 = new System.Windows.Forms.TextBox();
			this.button1 = new System.Windows.Forms.Button();
			this.button2 = new System.Windows.Forms.Button();
			this.checkBox1 = new System.Windows.Forms.CheckBox();
			base.SuspendLayout();
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(9, 16);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(56, 13);
			this.label1.TabIndex = 0;
			this.label1.Text = "Find what:";
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(6, 49);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(59, 13);
			this.label2.TabIndex = 1;
			this.label2.Text = "Node type:";
			this.textBox1.Location = new System.Drawing.Point(71, 13);
			this.textBox1.Name = "textBox1";
			this.textBox1.Size = new System.Drawing.Size(210, 20);
			this.textBox1.TabIndex = 2;
			this.button1.Location = new System.Drawing.Point(287, 12);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(75, 23);
			this.button1.TabIndex = 3;
			this.button1.Text = "Find Next";
			this.button1.UseVisualStyleBackColor = true;
			this.button2.Location = new System.Drawing.Point(287, 49);
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size(75, 23);
			this.button2.TabIndex = 4;
			this.button2.Text = "Find All";
			this.button2.UseVisualStyleBackColor = true;
			this.checkBox1.AutoSize = true;
			this.checkBox1.Location = new System.Drawing.Point(12, 89);
			this.checkBox1.Name = "checkBox1";
			this.checkBox1.Size = new System.Drawing.Size(82, 17);
			this.checkBox1.TabIndex = 5;
			this.checkBox1.Text = "Match case";
			this.checkBox1.UseVisualStyleBackColor = true;
			base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			base.ClientSize = new System.Drawing.Size(374, 136);
			base.Controls.Add(this.checkBox1);
			base.Controls.Add(this.button2);
			base.Controls.Add(this.button1);
			base.Controls.Add(this.textBox1);
			base.Controls.Add(this.label2);
			base.Controls.Add(this.label1);
			base.MaximizeBox = false;
			base.MinimizeBox = false;
			base.Name = "FindWindow";
			this.Text = "Find";
			base.ResumeLayout(false);
			base.PerformLayout();
		}
	}
}
