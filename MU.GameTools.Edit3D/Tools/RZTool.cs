using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using MU.GameTools.Common;

namespace MU.GameTools.Edit3D.Tools
{
	public class RZTool : Form
	{
		private static RZTool myWindow;

		private IContainer components;

		private TabControl tabControl1;

		private TabPage uncompressTabPage;

		private Button uncompress_startButton;

		private Button uncompress_outputBrowseButton;

		private TextBox uncompress_outputTextPath;

		private Label uncompress_outputLabel;

		private Button uncompress_inputBrowseButton;

		private TextBox uncompress_inputTextPath;

		private Label uncompress_inputLabel;

		private TabPage compressTabPage;

		private Button compress_startButton;

		private Button compress_outputBrowseButton;

		private TextBox compress_outputTextPath;

		private Label compress_outputLabel;

		private Button compress_inputBrowseButton;

		private TextBox compress_inputTextPath;

		private Label compress_inputLabel;

		private CheckBox uncompress_openOnFinishCheckBox;

		public static bool IsOpen => myWindow != null;

		public RZTool()
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

		private void OnUncompressInputBrowse_Click(object sender, EventArgs e)
		{
			OpenFileDialog openFileDialog = new OpenFileDialog
			{
				Filter = "RZ files (*.p3d.rz)|*.p3d.rz",
				Multiselect = true
			};
			if (DialogResult.OK == openFileDialog.ShowDialog())
			{
				uncompress_inputTextPath.Text = Utils.ListToString(openFileDialog.FileNames.ToList());
			}
		}

		private void OnUncompressOutputBrowse_Click(object sender, EventArgs e)
		{
			FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();
			if (DialogResult.OK == folderBrowserDialog.ShowDialog())
			{
				uncompress_outputTextPath.Text = folderBrowserDialog.SelectedPath;
			}
		}

		private void OnUncompressButton_Click(object sender, EventArgs e)
		{
			if (string.IsNullOrWhiteSpace(uncompress_inputTextPath.Text))
			{
				MessageBox.Show("Invalid input", "RZ Tool", MessageBoxButtons.OK, MessageBoxIcon.Hand);
				return;
			}
			if (string.IsNullOrWhiteSpace(uncompress_outputTextPath.Text))
			{
				MessageBox.Show("Invalid output", "RZ Tool", MessageBoxButtons.OK, MessageBoxIcon.Hand);
				return;
			}
			try
			{
				List<string> list = Utils.StringToList(uncompress_inputTextPath.Text);
				List<string> list2 = new List<string>();
				for (int i = 0; i < list.Count; i++)
				{
					list2.Add(Path.Combine(uncompress_outputTextPath.Text, Path.GetFileNameWithoutExtension(list[i])));
					using FileStream input = File.OpenRead(list[i]);
					using FileStream output = File.Create(list2[i]);
					Utils.DecompressRZ(input, output);
				}
				if (uncompress_openOnFinishCheckBox.Checked)
				{
					Editor editorV = (Editor)base.Owner;
					foreach (string item in list2)
					{
						editorV.LoadP3DFile(item, (editorV.Game != PrototypeGame.Any) ? PrototypeGame.P2 : PrototypeGame.P1);
					}
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show("Error uncompressing: " + ex.Message, "RZ Tool", MessageBoxButtons.OK, MessageBoxIcon.Hand);
				return;
			}
			MessageBox.Show("Decompression successful", "RZ Tool", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
		}

		private void OnCompressInputBrowse_Click(object sender, EventArgs e)
		{
			OpenFileDialog openFileDialog = new OpenFileDialog
			{
				Filter = "P3D files (*.p3d)|*.p3d",
				Multiselect = true
			};
			if (DialogResult.OK == openFileDialog.ShowDialog())
			{
				compress_inputTextPath.Text = Utils.ListToString(openFileDialog.FileNames.ToList());
			}
		}

		private void OnCompressOutputBrowse_Click(object sender, EventArgs e)
		{
			FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();
			if (DialogResult.OK == folderBrowserDialog.ShowDialog())
			{
				compress_outputTextPath.Text = folderBrowserDialog.SelectedPath;
			}
		}

		private void OnCompressButton_Click(object sender, EventArgs e)
		{
			if (string.IsNullOrWhiteSpace(compress_inputTextPath.Text))
			{
				MessageBox.Show("Invalid input", "RZ Tool", MessageBoxButtons.OK, MessageBoxIcon.Hand);
				return;
			}
			if (string.IsNullOrWhiteSpace(compress_outputTextPath.Text))
			{
				MessageBox.Show("Invalid output", "RZ Tool", MessageBoxButtons.OK, MessageBoxIcon.Hand);
				return;
			}
			try
			{
				List<string> list = Utils.StringToList(compress_inputTextPath.Text);
				for (int i = 0; i < list.Count; i++)
				{
					using FileStream input = File.OpenRead(list[i]);
					using FileStream destination = File.Create(Path.Combine(compress_outputTextPath.Text, Path.GetFileName(list[i]) + ".rz"));
					Stream stream = Utils.CompressRZ(input);
					stream.Position = 0L;
					stream.CopyTo(destination);
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show("Error compressing: " + ex.Message, "RZ Tool", MessageBoxButtons.OK, MessageBoxIcon.Hand);
				return;
			}
			MessageBox.Show("Compression successful", "RZ Tool", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
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
			this.tabControl1 = new System.Windows.Forms.TabControl();
			this.uncompressTabPage = new System.Windows.Forms.TabPage();
			this.uncompress_openOnFinishCheckBox = new System.Windows.Forms.CheckBox();
			this.uncompress_startButton = new System.Windows.Forms.Button();
			this.uncompress_outputBrowseButton = new System.Windows.Forms.Button();
			this.uncompress_outputTextPath = new System.Windows.Forms.TextBox();
			this.uncompress_outputLabel = new System.Windows.Forms.Label();
			this.uncompress_inputBrowseButton = new System.Windows.Forms.Button();
			this.uncompress_inputTextPath = new System.Windows.Forms.TextBox();
			this.uncompress_inputLabel = new System.Windows.Forms.Label();
			this.compressTabPage = new System.Windows.Forms.TabPage();
			this.compress_startButton = new System.Windows.Forms.Button();
			this.compress_outputBrowseButton = new System.Windows.Forms.Button();
			this.compress_outputTextPath = new System.Windows.Forms.TextBox();
			this.compress_outputLabel = new System.Windows.Forms.Label();
			this.compress_inputBrowseButton = new System.Windows.Forms.Button();
			this.compress_inputTextPath = new System.Windows.Forms.TextBox();
			this.compress_inputLabel = new System.Windows.Forms.Label();
			this.tabControl1.SuspendLayout();
			this.uncompressTabPage.SuspendLayout();
			this.compressTabPage.SuspendLayout();
			base.SuspendLayout();
			this.tabControl1.Controls.Add(this.uncompressTabPage);
			this.tabControl1.Controls.Add(this.compressTabPage);
			this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tabControl1.Location = new System.Drawing.Point(0, 0);
			this.tabControl1.Name = "tabControl1";
			this.tabControl1.SelectedIndex = 0;
			this.tabControl1.Size = new System.Drawing.Size(364, 181);
			this.tabControl1.TabIndex = 0;
			this.uncompressTabPage.Controls.Add(this.uncompress_openOnFinishCheckBox);
			this.uncompressTabPage.Controls.Add(this.uncompress_startButton);
			this.uncompressTabPage.Controls.Add(this.uncompress_outputBrowseButton);
			this.uncompressTabPage.Controls.Add(this.uncompress_outputTextPath);
			this.uncompressTabPage.Controls.Add(this.uncompress_outputLabel);
			this.uncompressTabPage.Controls.Add(this.uncompress_inputBrowseButton);
			this.uncompressTabPage.Controls.Add(this.uncompress_inputTextPath);
			this.uncompressTabPage.Controls.Add(this.uncompress_inputLabel);
			this.uncompressTabPage.Location = new System.Drawing.Point(4, 22);
			this.uncompressTabPage.Name = "uncompressTabPage";
			this.uncompressTabPage.Padding = new System.Windows.Forms.Padding(3);
			this.uncompressTabPage.Size = new System.Drawing.Size(356, 155);
			this.uncompressTabPage.TabIndex = 0;
			this.uncompressTabPage.Text = "Uncompress";
			this.uncompressTabPage.UseVisualStyleBackColor = true;
			this.uncompress_openOnFinishCheckBox.AutoSize = true;
			this.uncompress_openOnFinishCheckBox.Location = new System.Drawing.Point(95, 126);
			this.uncompress_openOnFinishCheckBox.Name = "uncompress_openOnFinishCheckBox";
			this.uncompress_openOnFinishCheckBox.Size = new System.Drawing.Size(174, 17);
			this.uncompress_openOnFinishCheckBox.TabIndex = 22;
			this.uncompress_openOnFinishCheckBox.Text = "Open P3D after decompression";
			this.uncompress_openOnFinishCheckBox.UseVisualStyleBackColor = true;
			this.uncompress_startButton.Location = new System.Drawing.Point(14, 122);
			this.uncompress_startButton.Name = "uncompress_startButton";
			this.uncompress_startButton.Size = new System.Drawing.Size(75, 23);
			this.uncompress_startButton.TabIndex = 21;
			this.uncompress_startButton.Text = "Uncompress";
			this.uncompress_startButton.UseVisualStyleBackColor = true;
			this.uncompress_startButton.Click += new System.EventHandler(OnUncompressButton_Click);
			this.uncompress_outputBrowseButton.Location = new System.Drawing.Point(270, 86);
			this.uncompress_outputBrowseButton.Name = "uncompress_outputBrowseButton";
			this.uncompress_outputBrowseButton.Size = new System.Drawing.Size(75, 23);
			this.uncompress_outputBrowseButton.TabIndex = 20;
			this.uncompress_outputBrowseButton.Text = "Browse";
			this.uncompress_outputBrowseButton.UseVisualStyleBackColor = true;
			this.uncompress_outputBrowseButton.Click += new System.EventHandler(OnUncompressOutputBrowse_Click);
			this.uncompress_outputTextPath.Location = new System.Drawing.Point(14, 88);
			this.uncompress_outputTextPath.Name = "uncompress_outputTextPath";
			this.uncompress_outputTextPath.ReadOnly = true;
			this.uncompress_outputTextPath.Size = new System.Drawing.Size(250, 20);
			this.uncompress_outputTextPath.TabIndex = 19;
			this.uncompress_outputLabel.AutoSize = true;
			this.uncompress_outputLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			this.uncompress_outputLabel.Location = new System.Drawing.Point(11, 64);
			this.uncompress_outputLabel.Name = "uncompress_outputLabel";
			this.uncompress_outputLabel.Size = new System.Drawing.Size(49, 15);
			this.uncompress_outputLabel.TabIndex = 18;
			this.uncompress_outputLabel.Text = "Output";
			this.uncompress_inputBrowseButton.Location = new System.Drawing.Point(270, 25);
			this.uncompress_inputBrowseButton.Name = "uncompress_inputBrowseButton";
			this.uncompress_inputBrowseButton.Size = new System.Drawing.Size(75, 23);
			this.uncompress_inputBrowseButton.TabIndex = 17;
			this.uncompress_inputBrowseButton.Text = "Browse";
			this.uncompress_inputBrowseButton.UseVisualStyleBackColor = true;
			this.uncompress_inputBrowseButton.Click += new System.EventHandler(OnUncompressInputBrowse_Click);
			this.uncompress_inputTextPath.Location = new System.Drawing.Point(14, 27);
			this.uncompress_inputTextPath.Name = "uncompress_inputTextPath";
			this.uncompress_inputTextPath.ReadOnly = true;
			this.uncompress_inputTextPath.Size = new System.Drawing.Size(250, 20);
			this.uncompress_inputTextPath.TabIndex = 16;
			this.uncompress_inputLabel.AutoSize = true;
			this.uncompress_inputLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			this.uncompress_inputLabel.Location = new System.Drawing.Point(11, 3);
			this.uncompress_inputLabel.Name = "uncompress_inputLabel";
			this.uncompress_inputLabel.Size = new System.Drawing.Size(39, 15);
			this.uncompress_inputLabel.TabIndex = 15;
			this.uncompress_inputLabel.Text = "Input";
			this.compressTabPage.Controls.Add(this.compress_startButton);
			this.compressTabPage.Controls.Add(this.compress_outputBrowseButton);
			this.compressTabPage.Controls.Add(this.compress_outputTextPath);
			this.compressTabPage.Controls.Add(this.compress_outputLabel);
			this.compressTabPage.Controls.Add(this.compress_inputBrowseButton);
			this.compressTabPage.Controls.Add(this.compress_inputTextPath);
			this.compressTabPage.Controls.Add(this.compress_inputLabel);
			this.compressTabPage.Location = new System.Drawing.Point(4, 22);
			this.compressTabPage.Name = "compressTabPage";
			this.compressTabPage.Padding = new System.Windows.Forms.Padding(3);
			this.compressTabPage.Size = new System.Drawing.Size(356, 155);
			this.compressTabPage.TabIndex = 1;
			this.compressTabPage.Text = "Compress";
			this.compressTabPage.UseVisualStyleBackColor = true;
			this.compress_startButton.Location = new System.Drawing.Point(14, 122);
			this.compress_startButton.Name = "compress_startButton";
			this.compress_startButton.Size = new System.Drawing.Size(75, 23);
			this.compress_startButton.TabIndex = 28;
			this.compress_startButton.Text = "Compress";
			this.compress_startButton.UseVisualStyleBackColor = true;
			this.compress_startButton.Click += new System.EventHandler(OnCompressButton_Click);
			this.compress_outputBrowseButton.Location = new System.Drawing.Point(270, 86);
			this.compress_outputBrowseButton.Name = "compress_outputBrowseButton";
			this.compress_outputBrowseButton.Size = new System.Drawing.Size(75, 23);
			this.compress_outputBrowseButton.TabIndex = 27;
			this.compress_outputBrowseButton.Text = "Browse";
			this.compress_outputBrowseButton.UseVisualStyleBackColor = true;
			this.compress_outputBrowseButton.Click += new System.EventHandler(OnCompressOutputBrowse_Click);
			this.compress_outputTextPath.Location = new System.Drawing.Point(14, 88);
			this.compress_outputTextPath.Name = "compress_outputTextPath";
			this.compress_outputTextPath.ReadOnly = true;
			this.compress_outputTextPath.Size = new System.Drawing.Size(250, 20);
			this.compress_outputTextPath.TabIndex = 26;
			this.compress_outputLabel.AutoSize = true;
			this.compress_outputLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			this.compress_outputLabel.Location = new System.Drawing.Point(11, 64);
			this.compress_outputLabel.Name = "compress_outputLabel";
			this.compress_outputLabel.Size = new System.Drawing.Size(49, 15);
			this.compress_outputLabel.TabIndex = 25;
			this.compress_outputLabel.Text = "Output";
			this.compress_inputBrowseButton.Location = new System.Drawing.Point(270, 25);
			this.compress_inputBrowseButton.Name = "compress_inputBrowseButton";
			this.compress_inputBrowseButton.Size = new System.Drawing.Size(75, 23);
			this.compress_inputBrowseButton.TabIndex = 24;
			this.compress_inputBrowseButton.Text = "Browse";
			this.compress_inputBrowseButton.UseVisualStyleBackColor = true;
			this.compress_inputBrowseButton.Click += new System.EventHandler(OnCompressInputBrowse_Click);
			this.compress_inputTextPath.Location = new System.Drawing.Point(14, 27);
			this.compress_inputTextPath.Name = "compress_inputTextPath";
			this.compress_inputTextPath.ReadOnly = true;
			this.compress_inputTextPath.Size = new System.Drawing.Size(250, 20);
			this.compress_inputTextPath.TabIndex = 23;
			this.compress_inputLabel.AutoSize = true;
			this.compress_inputLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			this.compress_inputLabel.Location = new System.Drawing.Point(11, 3);
			this.compress_inputLabel.Name = "compress_inputLabel";
			this.compress_inputLabel.Size = new System.Drawing.Size(39, 15);
			this.compress_inputLabel.TabIndex = 22;
			this.compress_inputLabel.Text = "Input";
			base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.SystemColors.Window;
			base.ClientSize = new System.Drawing.Size(364, 181);
			base.Controls.Add(this.tabControl1);
			base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			base.MaximizeBox = false;
			base.Name = "RZTool";
			this.Text = "RZ Tool";
			this.tabControl1.ResumeLayout(false);
			this.uncompressTabPage.ResumeLayout(false);
			this.uncompressTabPage.PerformLayout();
			this.compressTabPage.ResumeLayout(false);
			this.compressTabPage.PerformLayout();
			base.ResumeLayout(false);
		}
	}
}
