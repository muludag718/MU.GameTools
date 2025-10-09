using System;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using MU.GameTools.IO;
using MU.GameTools.Prototype.FileFormats;

namespace MU.GameTools.Edit3D.Tools
{
	public class RCFTool : Form
	{
		private static RCFTool myWindow;

		private IContainer components;

		private TabControl tabControl1;

		private TabPage unpackTabPage;

		private Button unpack_startButton;

		private Button unpack_outputBrowseButton;

		private TextBox unpack_outputTextPath;

		private Label unpack_outputLabel;

		private Button unpack_inputBrowseButton;

		private TextBox unpack_inputTextPath;

		private Label unpack_inputLabel;

		private TabPage packTabPage;

		private Button pack_startButton;

		private Button pack_outputBrowseButton;

		private TextBox pack_outputTextPath;

		private Label pack_outputLabel;

		private Button pack_inputBrowseButton;

		private TextBox pack_inputTextPath;

		private Label pack_inputLabel;

		public static bool IsOpen => myWindow != null;

		public RCFTool()
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

		private void OnUnpackInputBrowse_Click(object sender, EventArgs e)
		{
			OpenFileDialog openFileDialog = new OpenFileDialog
			{
				Filter = "RCF file (*.rcf)|*.rcf"
			};
			if (DialogResult.OK == openFileDialog.ShowDialog())
			{
				unpack_inputTextPath.Text = openFileDialog.FileName;
			}
		}

		private void OnUnpackOutputBrowse_Click(object sender, EventArgs e)
		{
			FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();
			if (DialogResult.OK == folderBrowserDialog.ShowDialog())
			{
				unpack_outputTextPath.Text = folderBrowserDialog.SelectedPath;
			}
		}

		private void OnUnpackButton_Click(object sender, EventArgs e)
		{
			if (string.IsNullOrWhiteSpace(unpack_inputTextPath.Text))
			{
				MessageBox.Show("Invalid input", "RCF Tool", MessageBoxButtons.OK, MessageBoxIcon.Hand);
				return;
			}
			if (string.IsNullOrWhiteSpace(unpack_outputTextPath.Text))
			{
				MessageBox.Show("Invalid output", "RCF Tool", MessageBoxButtons.OK, MessageBoxIcon.Hand);
				return;
			}
			try
			{
				using FileStream input = File.OpenRead(unpack_inputTextPath.Text);
				new CementFile(input).Unpack(unpack_outputTextPath.Text);
			}
			catch (Exception ex)
			{
				MessageBox.Show("Error unpacking: " + ex.Message, "RCF Tool", MessageBoxButtons.OK, MessageBoxIcon.Hand);
				return;
			}
			MessageBox.Show("Unpacking successful", "RCF Tool", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
		}

		private void OnPackInputBrowse_Click(object sender, EventArgs e)
		{
			FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();
			if (DialogResult.OK == folderBrowserDialog.ShowDialog())
			{
				pack_inputTextPath.Text = folderBrowserDialog.SelectedPath;
			}
		}

		private void OnPackOutputBrowse_Click(object sender, EventArgs e)
		{
			SaveFileDialog saveFileDialog = new SaveFileDialog
			{
				Filter = "RCF file (*.rcf)|*.rcf"
			};
			if (DialogResult.OK == saveFileDialog.ShowDialog())
			{
				pack_outputTextPath.Text = saveFileDialog.FileName;
			}
		}

		private void OnPackButton_Click(object sender, EventArgs e)
		{
			if (string.IsNullOrWhiteSpace(pack_inputTextPath.Text))
			{
				MessageBox.Show("Invalid input", "RCF Tool", MessageBoxButtons.OK, MessageBoxIcon.Hand);
				return;
			}
			if (string.IsNullOrWhiteSpace(pack_outputTextPath.Text))
			{
				MessageBox.Show("Invalid output", "RCF Tool", MessageBoxButtons.OK, MessageBoxIcon.Hand);
				return;
			}
			try
			{
				CementFile cementFile = new CementFile
				{
					Endian = Endian.Little,
					MajorVersion = 2,
					MinorVersion = 1
				};
				cementFile.Pack(pack_inputTextPath.Text);
				using FileStream output = File.Create(pack_outputTextPath.Text);
				cementFile.Serialize(output);
			}
			catch (Exception ex)
			{
				MessageBox.Show("Error packing: " + ex.Message, "RCF Tool", MessageBoxButtons.OK, MessageBoxIcon.Hand);
				return;
			}
			MessageBox.Show("Packing successful", "RCF Tool", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
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
			this.unpackTabPage = new System.Windows.Forms.TabPage();
			this.unpack_startButton = new System.Windows.Forms.Button();
			this.unpack_outputBrowseButton = new System.Windows.Forms.Button();
			this.unpack_outputTextPath = new System.Windows.Forms.TextBox();
			this.unpack_outputLabel = new System.Windows.Forms.Label();
			this.unpack_inputBrowseButton = new System.Windows.Forms.Button();
			this.unpack_inputTextPath = new System.Windows.Forms.TextBox();
			this.unpack_inputLabel = new System.Windows.Forms.Label();
			this.packTabPage = new System.Windows.Forms.TabPage();
			this.pack_startButton = new System.Windows.Forms.Button();
			this.pack_outputBrowseButton = new System.Windows.Forms.Button();
			this.pack_outputTextPath = new System.Windows.Forms.TextBox();
			this.pack_outputLabel = new System.Windows.Forms.Label();
			this.pack_inputBrowseButton = new System.Windows.Forms.Button();
			this.pack_inputTextPath = new System.Windows.Forms.TextBox();
			this.pack_inputLabel = new System.Windows.Forms.Label();
			this.tabControl1.SuspendLayout();
			this.unpackTabPage.SuspendLayout();
			this.packTabPage.SuspendLayout();
			base.SuspendLayout();
			this.tabControl1.Controls.Add(this.unpackTabPage);
			this.tabControl1.Controls.Add(this.packTabPage);
			this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tabControl1.Location = new System.Drawing.Point(0, 0);
			this.tabControl1.Name = "tabControl1";
			this.tabControl1.SelectedIndex = 0;
			this.tabControl1.Size = new System.Drawing.Size(364, 181);
			this.tabControl1.TabIndex = 0;
			this.unpackTabPage.Controls.Add(this.unpack_startButton);
			this.unpackTabPage.Controls.Add(this.unpack_outputBrowseButton);
			this.unpackTabPage.Controls.Add(this.unpack_outputTextPath);
			this.unpackTabPage.Controls.Add(this.unpack_outputLabel);
			this.unpackTabPage.Controls.Add(this.unpack_inputBrowseButton);
			this.unpackTabPage.Controls.Add(this.unpack_inputTextPath);
			this.unpackTabPage.Controls.Add(this.unpack_inputLabel);
			this.unpackTabPage.Location = new System.Drawing.Point(4, 22);
			this.unpackTabPage.Name = "unpackTabPage";
			this.unpackTabPage.Padding = new System.Windows.Forms.Padding(3);
			this.unpackTabPage.Size = new System.Drawing.Size(356, 155);
			this.unpackTabPage.TabIndex = 0;
			this.unpackTabPage.Text = "Unpack";
			this.unpackTabPage.UseVisualStyleBackColor = true;
			this.unpack_startButton.Location = new System.Drawing.Point(14, 124);
			this.unpack_startButton.Name = "unpack_startButton";
			this.unpack_startButton.Size = new System.Drawing.Size(75, 23);
			this.unpack_startButton.TabIndex = 21;
			this.unpack_startButton.Text = "Unpack";
			this.unpack_startButton.UseVisualStyleBackColor = true;
			this.unpack_startButton.Click += new System.EventHandler(OnUnpackButton_Click);
			this.unpack_outputBrowseButton.Location = new System.Drawing.Point(270, 86);
			this.unpack_outputBrowseButton.Name = "unpack_outputBrowseButton";
			this.unpack_outputBrowseButton.Size = new System.Drawing.Size(75, 23);
			this.unpack_outputBrowseButton.TabIndex = 20;
			this.unpack_outputBrowseButton.Text = "Browse";
			this.unpack_outputBrowseButton.UseVisualStyleBackColor = true;
			this.unpack_outputBrowseButton.Click += new System.EventHandler(OnUnpackOutputBrowse_Click);
			this.unpack_outputTextPath.Location = new System.Drawing.Point(14, 88);
			this.unpack_outputTextPath.Name = "unpack_outputTextPath";
			this.unpack_outputTextPath.ReadOnly = true;
			this.unpack_outputTextPath.Size = new System.Drawing.Size(250, 20);
			this.unpack_outputTextPath.TabIndex = 19;
			this.unpack_outputLabel.AutoSize = true;
			this.unpack_outputLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			this.unpack_outputLabel.Location = new System.Drawing.Point(11, 64);
			this.unpack_outputLabel.Name = "unpack_outputLabel";
			this.unpack_outputLabel.Size = new System.Drawing.Size(49, 15);
			this.unpack_outputLabel.TabIndex = 18;
			this.unpack_outputLabel.Text = "Output";
			this.unpack_inputBrowseButton.Location = new System.Drawing.Point(270, 25);
			this.unpack_inputBrowseButton.Name = "unpack_inputBrowseButton";
			this.unpack_inputBrowseButton.Size = new System.Drawing.Size(75, 23);
			this.unpack_inputBrowseButton.TabIndex = 17;
			this.unpack_inputBrowseButton.Text = "Browse";
			this.unpack_inputBrowseButton.UseVisualStyleBackColor = true;
			this.unpack_inputBrowseButton.Click += new System.EventHandler(OnUnpackInputBrowse_Click);
			this.unpack_inputTextPath.Location = new System.Drawing.Point(14, 27);
			this.unpack_inputTextPath.Name = "unpack_inputTextPath";
			this.unpack_inputTextPath.ReadOnly = true;
			this.unpack_inputTextPath.Size = new System.Drawing.Size(250, 20);
			this.unpack_inputTextPath.TabIndex = 16;
			this.unpack_inputLabel.AutoSize = true;
			this.unpack_inputLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			this.unpack_inputLabel.Location = new System.Drawing.Point(11, 3);
			this.unpack_inputLabel.Name = "unpack_inputLabel";
			this.unpack_inputLabel.Size = new System.Drawing.Size(39, 15);
			this.unpack_inputLabel.TabIndex = 15;
			this.unpack_inputLabel.Text = "Input";
			this.packTabPage.Controls.Add(this.pack_startButton);
			this.packTabPage.Controls.Add(this.pack_outputBrowseButton);
			this.packTabPage.Controls.Add(this.pack_outputTextPath);
			this.packTabPage.Controls.Add(this.pack_outputLabel);
			this.packTabPage.Controls.Add(this.pack_inputBrowseButton);
			this.packTabPage.Controls.Add(this.pack_inputTextPath);
			this.packTabPage.Controls.Add(this.pack_inputLabel);
			this.packTabPage.Location = new System.Drawing.Point(4, 22);
			this.packTabPage.Name = "packTabPage";
			this.packTabPage.Padding = new System.Windows.Forms.Padding(3);
			this.packTabPage.Size = new System.Drawing.Size(356, 155);
			this.packTabPage.TabIndex = 1;
			this.packTabPage.Text = "Pack";
			this.packTabPage.UseVisualStyleBackColor = true;
			this.pack_startButton.Location = new System.Drawing.Point(14, 124);
			this.pack_startButton.Name = "pack_startButton";
			this.pack_startButton.Size = new System.Drawing.Size(75, 23);
			this.pack_startButton.TabIndex = 28;
			this.pack_startButton.Text = "Pack";
			this.pack_startButton.UseVisualStyleBackColor = true;
			this.pack_startButton.Click += new System.EventHandler(OnPackButton_Click);
			this.pack_outputBrowseButton.Location = new System.Drawing.Point(270, 86);
			this.pack_outputBrowseButton.Name = "pack_outputBrowseButton";
			this.pack_outputBrowseButton.Size = new System.Drawing.Size(75, 23);
			this.pack_outputBrowseButton.TabIndex = 27;
			this.pack_outputBrowseButton.Text = "Browse";
			this.pack_outputBrowseButton.UseVisualStyleBackColor = true;
			this.pack_outputBrowseButton.Click += new System.EventHandler(OnPackOutputBrowse_Click);
			this.pack_outputTextPath.Location = new System.Drawing.Point(14, 88);
			this.pack_outputTextPath.Name = "pack_outputTextPath";
			this.pack_outputTextPath.ReadOnly = true;
			this.pack_outputTextPath.Size = new System.Drawing.Size(250, 20);
			this.pack_outputTextPath.TabIndex = 26;
			this.pack_outputLabel.AutoSize = true;
			this.pack_outputLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			this.pack_outputLabel.Location = new System.Drawing.Point(11, 64);
			this.pack_outputLabel.Name = "pack_outputLabel";
			this.pack_outputLabel.Size = new System.Drawing.Size(49, 15);
			this.pack_outputLabel.TabIndex = 25;
			this.pack_outputLabel.Text = "Output";
			this.pack_inputBrowseButton.Location = new System.Drawing.Point(270, 25);
			this.pack_inputBrowseButton.Name = "pack_inputBrowseButton";
			this.pack_inputBrowseButton.Size = new System.Drawing.Size(75, 23);
			this.pack_inputBrowseButton.TabIndex = 24;
			this.pack_inputBrowseButton.Text = "Browse";
			this.pack_inputBrowseButton.UseVisualStyleBackColor = true;
			this.pack_inputBrowseButton.Click += new System.EventHandler(OnPackInputBrowse_Click);
			this.pack_inputTextPath.Location = new System.Drawing.Point(14, 27);
			this.pack_inputTextPath.Name = "pack_inputTextPath";
			this.pack_inputTextPath.ReadOnly = true;
			this.pack_inputTextPath.Size = new System.Drawing.Size(250, 20);
			this.pack_inputTextPath.TabIndex = 23;
			this.pack_inputLabel.AutoSize = true;
			this.pack_inputLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			this.pack_inputLabel.Location = new System.Drawing.Point(11, 3);
			this.pack_inputLabel.Name = "pack_inputLabel";
			this.pack_inputLabel.Size = new System.Drawing.Size(39, 15);
			this.pack_inputLabel.TabIndex = 22;
			this.pack_inputLabel.Text = "Input";
			base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.SystemColors.Window;
			base.ClientSize = new System.Drawing.Size(364, 181);
			base.Controls.Add(this.tabControl1);
			base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			base.MaximizeBox = false;
			base.Name = "RCFTool";
			this.Text = "RCF Tool";
			this.tabControl1.ResumeLayout(false);
			this.unpackTabPage.ResumeLayout(false);
			this.unpackTabPage.PerformLayout();
			this.packTabPage.ResumeLayout(false);
			this.packTabPage.PerformLayout();
			base.ResumeLayout(false);
		}
	}
}
