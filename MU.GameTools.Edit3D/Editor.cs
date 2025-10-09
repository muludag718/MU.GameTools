// EditP3D, Version=0.9.0.0, Culture=neutral, PublicKeyToken=null
// EditP3d.UI.EditorV2
using System.ComponentModel;
using Aga.Controls.Tree;
using MU.GameTools.IO;
using MU.GameTools.Edit3D.Tools;
using MU.GameTools.Prototype.FileFormats;
using MU.GameTools.Prototype.FileFormats.Pure3D;
using MU.GameTools.Common;
using MU.GameTools.Edit3D.Tools.Viewer;

namespace MU.GameTools.Edit3D;

public class Editor : Form
{
    private class MyRenderer : ToolStripProfessionalRenderer
    {
        protected override void OnRenderMenuItemBackground(ToolStripItemRenderEventArgs e)
        {
            if (e.Item.Enabled)
            {
                base.OnRenderMenuItemBackground(e);
            }
        }
    }

    private ViewerTool _viewer;

    private ToolStripDropDown dropdownOpen;

    private ToolStripDropDown dropdownClose;

    private IContainer components;

    private MenuStrip editorMenuStrip;

    private ToolStripMenuItem fileMenuItem;

    private ToolStripMenuItem newToolStripMenuItem;

    private ToolStripMenuItem saveToolStripMenuItem;

    private ToolStripMenuItem saveAsToolStripMenuItem;

    private ToolStripMenuItem toolsMenuItem;

    private ToolStripMenuItem openToolStripMenuItem;

    private ToolStripSeparator toolStripSeparator1;

    private ToolStripSeparator toolStripSeparator2;

    private ToolStripMenuItem exitToolStripMenuItem;

    private ToolStripMenuItem rcfMenuItem;

    private ToolStripMenuItem rzMenuItem;

    private ToolStripMenuItem aboutMenuItem;

    private ToolStripMenuItem optionsMenuItem;

    private ToolStripComboBox gameComboBox;

    private ToolStripSeparator toolStripSeparator3;

    private ToolStripMenuItem endianessLabelMenuItem;

    private ToolStripComboBox endiannessComboBox;

    private ToolStripMenuItem gameLabelMenuItem;

    private ToolStripMenuItem testsMenuItem;

    private ChromeLikeTabControl tabControl;

    private ToolStripMenuItem saveAllToolStripMenuItem;

    private ToolStripMenuItem editMenuItem;

    private ToolStripMenuItem viewerMenuItem;

    private ToolStripMenuItem undoEditMenuItem;

    private ToolStripMenuItem redoEditMenuItem;

    private ToolStripSeparator toolStripSeparator6;

    private ToolStripMenuItem findEditMenuItem;

    private ToolStripSeparator toolStripSeparator5;

    private ToolStripMenuItem expandEditMenuItem;

    private ToolStripMenuItem collapseEditMenuItem;

    internal SaveFileDialog saveP3DFileDialog;

    internal OpenFileDialog openP3DFileDialog;

    internal FolderBrowserDialog folderBrowserDialog;

    private ToolStripSeparator toolStripSeparator4;

    private ToolStripMenuItem viewerLabelMenuItem;

    private ToolStripMenuItem autofocusMenuItem;

    private ToolStripMenuItem prototype1ToolStripMenuItem;

    private ToolStripMenuItem prototype2ToolStripMenuItem;

    private ToolStripMenuItem prototype1ToolStripMenuItem1;

    private ToolStripMenuItem prototype2ToolStripMenuItem1;
    private ToolStripMenuItem folderToolStripMenuItem;
    private ToolStripMenuItem moddingMenuItem;

    public Endian Endianess
    {
        get
        {
            if (endiannessComboBox.SelectedIndex != 0)
            {
                return Endian.Big;
            }
            return Endian.Little;
        }
    }

    public PrototypeGame Game => (PrototypeGame)gameComboBox.SelectedIndex;

    public P3DControl SelectedTab => tabControl.SelectedTab?.Controls[0] as P3DControl;

    public ViewerTool Viewer => _viewer;

    public bool Viewer_Autofocus => autofocusMenuItem.Checked;

    public Editor()
    {
        InitializeComponent();
        editorMenuStrip.Renderer = new MyRenderer();
        gameComboBox.SelectedIndex = 2;
        endiannessComboBox.SelectedIndex = 0;
        SetTabToolStrip(enabled: false);
        SetTabEditStrip(enabled: false);
        dropdownOpen = openToolStripMenuItem.DropDown;
        dropdownClose = newToolStripMenuItem.DropDown;
    }

    private void OnNewFileMenuItem_Click(object sender, EventArgs e)
    {
        if (Game != PrototypeGame.Any)
        {
            Pure3DFile p3d = new Pure3DFile
            {
                Endian = Endianess,
                GamePicked = Game
            };
            string text = ((Game == PrototypeGame.P2) ? "[P2]" : "[P1]");
            AddNewTab(text + " Untitled", p3d);
        }
    }

    private void OnNewP1FileMenuItem_Click(object sender, EventArgs e)
    {
        Pure3DFile p3d = new Pure3DFile
        {
            Endian = Endianess,
            GamePicked = PrototypeGame.P1
        };
        AddNewTab("[P1] Untitled", p3d);
    }

    private void OnNewP2FileMenuItem_Click(object sender, EventArgs e)
    {
        Pure3DFile p3d = new Pure3DFile
        {
            Endian = Endianess,
            GamePicked = PrototypeGame.P2
        };
        AddNewTab("[P2] Untitled", p3d);
    }

    private void OnOpenFileMenuItem_Click(object sender, EventArgs e)
    {
        if (Game != PrototypeGame.Any && openP3DFileDialog.ShowDialog() == DialogResult.OK)
        {
            LoadP3DFile(openP3DFileDialog.FileName, Game);
        }
    }
    private void folderToolStripMenuItem_Click(object sender, EventArgs e)
    {
        if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
        {
            LoadP3DFile(folderBrowserDialog.SelectedPath, PrototypeGame.P1);

        }

    }
    private void OnOpenP1FileMenuItem_Click(object sender, EventArgs e)
    {
        if (openP3DFileDialog.ShowDialog() == DialogResult.OK)
        {
            LoadP3DFile(openP3DFileDialog.FileName, PrototypeGame.P1);
        }

    }

    private void OnOpenP2FileMenuItem_Click(object sender, EventArgs e)
    {
        if (openP3DFileDialog.ShowDialog() == DialogResult.OK)
        {
            LoadP3DFile(openP3DFileDialog.FileName, PrototypeGame.P2);
        }
    }

    private void OnSaveFileMenuItem_Click(object sender, EventArgs e)
    {
        P3DControl p3DControlV = tabControl.SelectedTab.Controls[0] as P3DControl;
        string fileName = p3DControlV.FileName;
        if (string.IsNullOrEmpty(p3DControlV.FileName))
        {
            if (saveP3DFileDialog.ShowDialog() != DialogResult.OK)
            {
                return;
            }
            fileName = saveP3DFileDialog.FileName;
        }
        try
        {
            ExportP3D(p3DControlV, fileName);
            p3DControlV.IsDirty = false;
        }
        catch (Exception ex)
        {
            MessageBox.Show("Error: " + ex.Message, "EditP3D", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            return;
        }
        p3DControlV.SetName(fileName);
    }

    private void OnSaveAsFileMenuItem_Click(object sender, EventArgs e)
    {
        if (saveP3DFileDialog.ShowDialog() == DialogResult.OK)
        {
            P3DControl p3DControlV = tabControl.SelectedTab.Controls[0] as P3DControl;
            try
            {
                ExportP3D(p3DControlV, saveP3DFileDialog.FileName);
                p3DControlV.IsDirty = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "EditP3D", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                return;
            }
            p3DControlV.SetName(saveP3DFileDialog.FileName);
        }
    }

    private void OnSaveAllFileMenuItem_Click(object sender, EventArgs e)
    {
        try
        {
            foreach (TabPage tabPage in tabControl.TabPages)
            {
                P3DControl p3DControlV = tabPage.Controls[0] as P3DControl;
                if (string.IsNullOrWhiteSpace(p3DControlV.FileName))
                {
                    if (saveP3DFileDialog.ShowDialog() != DialogResult.OK)
                    {
                        break;
                    }
                    ExportP3D(p3DControlV, saveP3DFileDialog.FileName);
                    p3DControlV.SetName(saveP3DFileDialog.FileName);
                }
                else
                {
                    SaveP3DFile(p3DControlV.ActiveFile, p3DControlV.FileName);
                }
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show("Error: " + ex.Message, "EditP3D", MessageBoxButtons.OK, MessageBoxIcon.Hand);
        }
    }

    private void OnImportFileMenuItem_Click(object sender, EventArgs e)
    {
        if (openP3DFileDialog.ShowDialog() != DialogResult.OK)
        {
            return;
        }
        try
        {
            string[] fileNames = openP3DFileDialog.FileNames;
            foreach (string path in fileNames)
            {
                using FileStream fileStream = new FileStream(path, FileMode.Open);
                Pure3DFile obj = new Pure3DFile
                {
                    GamePicked = Game,
                    Endian = Endianess
                };
                Stream stream = new MemoryStream();
                if (Utils.IsRZFile(path))
                {
                    Utils.DecompressRZ(fileStream, stream);
                }
                else
                {
                    stream = fileStream;
                }
                stream.Position = 0L;
                obj.Deserialize(stream, Endianess);
                foreach (BaseNode node in obj.Nodes)
                {
                    SelectedTab.ActiveFile.Nodes.Add(node);
                    //SelectedTab.ActiveFile.Nodes.Add(node);
                }
                SelectedTab.UpdateNodeTree();
                stream.Close();
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show("Error: " + ex.Message, "EditP3D", MessageBoxButtons.OK, MessageBoxIcon.Hand);
        }
    }

    private void OnExitFileMenuItem_Click(object sender, EventArgs e)
    {
        Application.Exit();
    }

    private void OnFindMenuItem_Click(object sender, EventArgs e)
    {
    }

    private void OnExpandAllEditMenuItem_Click(object sender, EventArgs e)
    {
        SelectedTab.TreeView.ExpandAll();
    }

    private void OnCollapseAllEditMenuItem_Click(object sender, EventArgs e)
    {
        foreach (TreeNodeAdv child in SelectedTab.TreeView.Root.Children)
        {
            child.CollapseAll();
        }
    }

    private void OnRCFMenuItem_Click(object sender, EventArgs e)
    {
        if (!RCFTool.IsOpen)
        {
            RCFTool rCFTool = new RCFTool();
            rCFTool.Owner = this;
            rCFTool.Show();
        }
    }

    private void OnRZMenuItem_Click(object sender, EventArgs e)
    {
        if (!RZTool.IsOpen)
        {
            RZTool rZTool = new RZTool();
            rZTool.Owner = this;
            rZTool.Show();
        }
    }

    private void OnTODMenuItem_Click(object sender, EventArgs e)
    {
    }

    private void OnViewerMenuItem_Click(object sender, EventArgs e)
    {
        if (!ViewerTool.IsOpen)
        {
            _viewer = new ViewerTool
            {
                Owner = this
            };
            _viewer.Show();
        }
    }

    private void tabControl_SelectedIndexChanged(object sender, EventArgs e)
    {
        TabChanged();
    }

    private void TabChanged()
    {
        SetTabToolStrip(tabControl.SelectedTab != null);
        SetTabEditStrip(tabControl.SelectedTab != null);
    }

    private void OnGameSelectionChanged(object sender, EventArgs e)
    {
        if (dropdownOpen != null && dropdownClose != null)
        {
            if (Game != PrototypeGame.Any)
            {
                openToolStripMenuItem.DropDown = null;
                newToolStripMenuItem.DropDown = null;
            }
            else
            {
                openToolStripMenuItem.DropDown = dropdownOpen;
                newToolStripMenuItem.DropDown = dropdownClose;
            }
        }
    }

    private void OnDragDrop(object sender, DragEventArgs e)
    {
        string[] array = (string[])e.Data.GetData(DataFormats.FileDrop);
        foreach (string path in array)
        {
            LoadP3DFile(path, (Game != PrototypeGame.Any) ? PrototypeGame.P2 : PrototypeGame.P1);
        }
    }

    private void OnDragEnter(object sender, DragEventArgs e)
    {
        string[] array = (string[])e.Data.GetData(DataFormats.FileDrop);
        if (array == null)
        {
            return;
        }
        string[] array2 = array;
        for (int i = 0; i < array2.Length; i++)
        {
            if (!array2[i].EndsWith(".p3d"))
            {
                e.Effect = DragDropEffects.None;
                return;
            }
        }
        if (e.Data.GetDataPresent(DataFormats.FileDrop))
        {
            e.Effect = DragDropEffects.Copy;
        }
    }

    private void SetTabToolStrip(bool enabled)
    {
        saveToolStripMenuItem.Enabled = enabled;
        saveAsToolStripMenuItem.Enabled = enabled;
        saveAllToolStripMenuItem.Enabled = enabled;
    }

    private void SetTabEditStrip(bool enabled)
    {
        foreach (ToolStripItem dropDownItem in editMenuItem.DropDownItems)
        {
            dropDownItem.Enabled = enabled;
        }
    }

    private void ExportP3D(P3DControl control, string path)
    {
        control.ActiveFile.Nodes.Clear();
        foreach (Node node in control.TreeModel.Nodes)
        {
            BuildP3DTree(node, control.ActiveFile.Nodes);
        }
        SaveP3DFile(control.ActiveFile, path);
    }

    private void BuildP3DTree(Node treeNode, List<BaseNode> list)
    {
        BaseNode baseNode = (BaseNode)treeNode.Tag;
        baseNode.Children.Clear();
        list.Add(baseNode);
        foreach (Node node in treeNode.Nodes)
        {
            BuildP3DTree(node, baseNode.Children);
        }
    }

    public void LoadP3DFile(string path, PrototypeGame game)
    {
        using FileStream fileStream = new FileStream(path, FileMode.Open);
        Pure3DFile pure3DFile = new Pure3DFile
        {
            GamePicked = game,
            Endian = Endianess
        };
        Stream stream = new MemoryStream();
        if (Utils.IsRZFile(path))
        {
            Utils.DecompressRZ(fileStream, stream);
        }
        else
        {
            stream = fileStream;
        }
        stream.Position = 0L;
        pure3DFile.Deserialize(stream, Endianess);
        string text = ((game == PrototypeGame.P2) ? "[P2]" : "[P1]");
        AddNewTab(text + " " + Path.GetFileName(path), pure3DFile, path);
        stream.Close();
    }
    private void AddNewTab(string name, Pure3DFile p3d, string path = "")
    {
        P3DControl value = new P3DControl(p3d)
        {
            Dock = DockStyle.Fill,
            FileName = path
        };
        tabControl.TabPages.Add(name);
        int num = ((tabControl.TabCount > 0) ? (tabControl.TabCount - 1) : 0);
        tabControl.SelectedIndex = num;
        tabControl.SelectedTab.Controls.Add(value);
        tabControl.SelectedTab.ToolTipText = path;
        if (num == 0)
        {
            TabChanged();
        }
        SetTabToolStrip(enabled: true);
        SetTabEditStrip(enabled: true);
    }
    public void SaveP3DFile(Pure3DFile p3d, string path)
    {
        using FileStream destination = File.Create(path);
        Stream stream = new MemoryStream();
        p3d.Serialize(stream, Endianess);
        stream.Position = 0L;
        Stream stream2 = ((!Utils.IsRZFile(saveP3DFileDialog.FileName)) ? stream : Utils.CompressRZ(stream));
        stream2.Position = 0L;
        stream2.CopyTo(destination);
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
        editorMenuStrip = new MenuStrip();
        fileMenuItem = new ToolStripMenuItem();
        newToolStripMenuItem = new ToolStripMenuItem();
        prototype1ToolStripMenuItem1 = new ToolStripMenuItem();
        prototype2ToolStripMenuItem1 = new ToolStripMenuItem();
        openToolStripMenuItem = new ToolStripMenuItem();
        prototype1ToolStripMenuItem = new ToolStripMenuItem();
        prototype2ToolStripMenuItem = new ToolStripMenuItem();
        folderToolStripMenuItem = new ToolStripMenuItem();
        toolStripSeparator1 = new ToolStripSeparator();
        saveToolStripMenuItem = new ToolStripMenuItem();
        saveAsToolStripMenuItem = new ToolStripMenuItem();
        saveAllToolStripMenuItem = new ToolStripMenuItem();
        toolStripSeparator2 = new ToolStripSeparator();
        exitToolStripMenuItem = new ToolStripMenuItem();
        editMenuItem = new ToolStripMenuItem();
        undoEditMenuItem = new ToolStripMenuItem();
        redoEditMenuItem = new ToolStripMenuItem();
        toolStripSeparator6 = new ToolStripSeparator();
        findEditMenuItem = new ToolStripMenuItem();
        toolStripSeparator5 = new ToolStripSeparator();
        expandEditMenuItem = new ToolStripMenuItem();
        collapseEditMenuItem = new ToolStripMenuItem();
        toolsMenuItem = new ToolStripMenuItem();
        rcfMenuItem = new ToolStripMenuItem();
        rzMenuItem = new ToolStripMenuItem();
        viewerMenuItem = new ToolStripMenuItem();
        moddingMenuItem = new ToolStripMenuItem();
        optionsMenuItem = new ToolStripMenuItem();
        gameLabelMenuItem = new ToolStripMenuItem();
        gameComboBox = new ToolStripComboBox();
        toolStripSeparator3 = new ToolStripSeparator();
        endianessLabelMenuItem = new ToolStripMenuItem();
        endiannessComboBox = new ToolStripComboBox();
        toolStripSeparator4 = new ToolStripSeparator();
        viewerLabelMenuItem = new ToolStripMenuItem();
        autofocusMenuItem = new ToolStripMenuItem();
        testsMenuItem = new ToolStripMenuItem();
        aboutMenuItem = new ToolStripMenuItem();
        openP3DFileDialog = new OpenFileDialog();
        saveP3DFileDialog = new SaveFileDialog();
        folderBrowserDialog = new FolderBrowserDialog();
        tabControl = new ChromeLikeTabControl();
        editorMenuStrip.SuspendLayout();
        SuspendLayout();
        // 
        // editorMenuStrip
        // 
        editorMenuStrip.Items.AddRange(new ToolStripItem[] { fileMenuItem, editMenuItem, toolsMenuItem, moddingMenuItem, optionsMenuItem, testsMenuItem, aboutMenuItem });
        editorMenuStrip.Location = new Point(0, 0);
        editorMenuStrip.Name = "editorMenuStrip";
        editorMenuStrip.Padding = new Padding(7, 2, 0, 2);
        editorMenuStrip.Size = new Size(1370, 24);
        editorMenuStrip.TabIndex = 0;
        editorMenuStrip.Text = "menuStrip1";
        // 
        // fileMenuItem
        // 
        fileMenuItem.DropDownItems.AddRange(new ToolStripItem[] { newToolStripMenuItem, openToolStripMenuItem, toolStripSeparator1, saveToolStripMenuItem, saveAsToolStripMenuItem, saveAllToolStripMenuItem, toolStripSeparator2, exitToolStripMenuItem });
        fileMenuItem.Name = "fileMenuItem";
        fileMenuItem.Size = new Size(37, 20);
        fileMenuItem.Text = "File";
        fileMenuItem.Click += fileMenuItem_Click;
        // 
        // newToolStripMenuItem
        // 
        newToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { prototype1ToolStripMenuItem1, prototype2ToolStripMenuItem1 });
        newToolStripMenuItem.Name = "newToolStripMenuItem";
        newToolStripMenuItem.Size = new Size(180, 22);
        newToolStripMenuItem.Text = "New";
        newToolStripMenuItem.Click += OnNewFileMenuItem_Click;
        // 
        // prototype1ToolStripMenuItem1
        // 
        prototype1ToolStripMenuItem1.Name = "prototype1ToolStripMenuItem1";
        prototype1ToolStripMenuItem1.Size = new Size(135, 22);
        prototype1ToolStripMenuItem1.Text = "Prototype 1";
        prototype1ToolStripMenuItem1.Click += OnNewP1FileMenuItem_Click;
        // 
        // prototype2ToolStripMenuItem1
        // 
        prototype2ToolStripMenuItem1.Name = "prototype2ToolStripMenuItem1";
        prototype2ToolStripMenuItem1.Size = new Size(135, 22);
        prototype2ToolStripMenuItem1.Text = "Prototype 2";
        prototype2ToolStripMenuItem1.Click += OnNewP2FileMenuItem_Click;
        // 
        // openToolStripMenuItem
        // 
        openToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { prototype1ToolStripMenuItem, prototype2ToolStripMenuItem, folderToolStripMenuItem });
        openToolStripMenuItem.Name = "openToolStripMenuItem";
        openToolStripMenuItem.Size = new Size(180, 22);
        openToolStripMenuItem.Text = "Open";
        openToolStripMenuItem.Click += OnOpenFileMenuItem_Click;
        // 
        // prototype1ToolStripMenuItem
        // 
        prototype1ToolStripMenuItem.Name = "prototype1ToolStripMenuItem";
        prototype1ToolStripMenuItem.Size = new Size(135, 22);
        prototype1ToolStripMenuItem.Text = "Prototype 1";
        prototype1ToolStripMenuItem.Click += OnOpenP1FileMenuItem_Click;
        // 
        // prototype2ToolStripMenuItem
        // 
        prototype2ToolStripMenuItem.Name = "prototype2ToolStripMenuItem";
        prototype2ToolStripMenuItem.Size = new Size(135, 22);
        prototype2ToolStripMenuItem.Text = "Prototype 2";
        prototype2ToolStripMenuItem.Click += OnOpenP2FileMenuItem_Click;
        // 
        // folderToolStripMenuItem
        // 
        folderToolStripMenuItem.Name = "folderToolStripMenuItem";
        folderToolStripMenuItem.Size = new Size(135, 22);
        folderToolStripMenuItem.Text = "Folder";
        folderToolStripMenuItem.Click += folderToolStripMenuItem_Click;
        // 
        // toolStripSeparator1
        // 
        toolStripSeparator1.Name = "toolStripSeparator1";
        toolStripSeparator1.Size = new Size(177, 6);
        // 
        // saveToolStripMenuItem
        // 
        saveToolStripMenuItem.Name = "saveToolStripMenuItem";
        saveToolStripMenuItem.Size = new Size(180, 22);
        saveToolStripMenuItem.Text = "Save";
        saveToolStripMenuItem.Click += OnSaveFileMenuItem_Click;
        // 
        // saveAsToolStripMenuItem
        // 
        saveAsToolStripMenuItem.Name = "saveAsToolStripMenuItem";
        saveAsToolStripMenuItem.Size = new Size(180, 22);
        saveAsToolStripMenuItem.Text = "Save As";
        saveAsToolStripMenuItem.Click += OnSaveAsFileMenuItem_Click;
        // 
        // saveAllToolStripMenuItem
        // 
        saveAllToolStripMenuItem.Name = "saveAllToolStripMenuItem";
        saveAllToolStripMenuItem.Size = new Size(180, 22);
        saveAllToolStripMenuItem.Text = "Save All";
        saveAllToolStripMenuItem.Click += OnSaveAllFileMenuItem_Click;
        // 
        // toolStripSeparator2
        // 
        toolStripSeparator2.Name = "toolStripSeparator2";
        toolStripSeparator2.Size = new Size(177, 6);
        // 
        // exitToolStripMenuItem
        // 
        exitToolStripMenuItem.Name = "exitToolStripMenuItem";
        exitToolStripMenuItem.Size = new Size(180, 22);
        exitToolStripMenuItem.Text = "Exit";
        exitToolStripMenuItem.Click += OnExitFileMenuItem_Click;
        // 
        // editMenuItem
        // 
        editMenuItem.DropDownItems.AddRange(new ToolStripItem[] { undoEditMenuItem, redoEditMenuItem, toolStripSeparator6, findEditMenuItem, toolStripSeparator5, expandEditMenuItem, collapseEditMenuItem });
        editMenuItem.Name = "editMenuItem";
        editMenuItem.Size = new Size(39, 20);
        editMenuItem.Text = "Edit";
        // 
        // undoEditMenuItem
        // 
        undoEditMenuItem.Name = "undoEditMenuItem";
        undoEditMenuItem.Size = new Size(136, 22);
        undoEditMenuItem.Text = "Undo";
        undoEditMenuItem.Visible = false;
        // 
        // redoEditMenuItem
        // 
        redoEditMenuItem.Name = "redoEditMenuItem";
        redoEditMenuItem.Size = new Size(136, 22);
        redoEditMenuItem.Text = "Redo";
        redoEditMenuItem.Visible = false;
        // 
        // toolStripSeparator6
        // 
        toolStripSeparator6.Name = "toolStripSeparator6";
        toolStripSeparator6.Size = new Size(133, 6);
        // 
        // findEditMenuItem
        // 
        findEditMenuItem.Name = "findEditMenuItem";
        findEditMenuItem.Size = new Size(136, 22);
        findEditMenuItem.Text = "Find";
        findEditMenuItem.Visible = false;
        findEditMenuItem.Click += OnFindMenuItem_Click;
        // 
        // toolStripSeparator5
        // 
        toolStripSeparator5.Name = "toolStripSeparator5";
        toolStripSeparator5.Size = new Size(133, 6);
        // 
        // expandEditMenuItem
        // 
        expandEditMenuItem.Name = "expandEditMenuItem";
        expandEditMenuItem.Size = new Size(136, 22);
        expandEditMenuItem.Text = "Expand All";
        expandEditMenuItem.Click += OnExpandAllEditMenuItem_Click;
        // 
        // collapseEditMenuItem
        // 
        collapseEditMenuItem.Name = "collapseEditMenuItem";
        collapseEditMenuItem.Size = new Size(136, 22);
        collapseEditMenuItem.Text = "Collapse All";
        collapseEditMenuItem.Click += OnCollapseAllEditMenuItem_Click;
        // 
        // toolsMenuItem
        // 
        toolsMenuItem.DropDownItems.AddRange(new ToolStripItem[] { rcfMenuItem, rzMenuItem, viewerMenuItem });
        toolsMenuItem.Name = "toolsMenuItem";
        toolsMenuItem.Size = new Size(47, 20);
        toolsMenuItem.Text = "Tools";
        // 
        // rcfMenuItem
        // 
        rcfMenuItem.Name = "rcfMenuItem";
        rcfMenuItem.Size = new Size(109, 22);
        rcfMenuItem.Text = "RCF";
        rcfMenuItem.Click += OnRCFMenuItem_Click;
        // 
        // rzMenuItem
        // 
        rzMenuItem.Name = "rzMenuItem";
        rzMenuItem.Size = new Size(109, 22);
        rzMenuItem.Text = "RZ";
        rzMenuItem.Click += OnRZMenuItem_Click;
        // 
        // viewerMenuItem
        // 
        viewerMenuItem.Name = "viewerMenuItem";
        viewerMenuItem.Size = new Size(109, 22);
        viewerMenuItem.Text = "Viewer";
        viewerMenuItem.Click += OnViewerMenuItem_Click;
        // 
        // moddingMenuItem
        // 
        moddingMenuItem.Name = "moddingMenuItem";
        moddingMenuItem.Size = new Size(68, 20);
        moddingMenuItem.Text = "Modding";
        moddingMenuItem.Visible = false;
        // 
        // optionsMenuItem
        // 
        optionsMenuItem.DropDownItems.AddRange(new ToolStripItem[] { gameLabelMenuItem, gameComboBox, toolStripSeparator3, endianessLabelMenuItem, endiannessComboBox, toolStripSeparator4, viewerLabelMenuItem, autofocusMenuItem });
        optionsMenuItem.Name = "optionsMenuItem";
        optionsMenuItem.Size = new Size(61, 20);
        optionsMenuItem.Text = "Options";
        // 
        // gameLabelMenuItem
        // 
        gameLabelMenuItem.Enabled = false;
        gameLabelMenuItem.Margin = new Padding(0, 0, 20, 0);
        gameLabelMenuItem.Name = "gameLabelMenuItem";
        gameLabelMenuItem.Size = new Size(196, 22);
        gameLabelMenuItem.Text = "Game";
        // 
        // gameComboBox
        // 
        gameComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
        gameComboBox.Items.AddRange(new object[] { "Prototype 1", "Prototype 2", "Unspecified" });
        gameComboBox.Margin = new Padding(10, 2, 2, 2);
        gameComboBox.Name = "gameComboBox";
        gameComboBox.Size = new Size(121, 23);
        gameComboBox.SelectedIndexChanged += OnGameSelectionChanged;
        // 
        // toolStripSeparator3
        // 
        toolStripSeparator3.Name = "toolStripSeparator3";
        toolStripSeparator3.Size = new Size(193, 6);
        // 
        // endianessLabelMenuItem
        // 
        endianessLabelMenuItem.Enabled = false;
        endianessLabelMenuItem.Name = "endianessLabelMenuItem";
        endianessLabelMenuItem.Size = new Size(196, 22);
        endianessLabelMenuItem.Text = "Endianness";
        // 
        // endiannessComboBox
        // 
        endiannessComboBox.Items.AddRange(new object[] { "Little Endian", "Big Endian" });
        endiannessComboBox.Margin = new Padding(10, 2, 2, 2);
        endiannessComboBox.Name = "endiannessComboBox";
        endiannessComboBox.Size = new Size(121, 23);
        // 
        // toolStripSeparator4
        // 
        toolStripSeparator4.Name = "toolStripSeparator4";
        toolStripSeparator4.Size = new Size(193, 6);
        // 
        // viewerLabelMenuItem
        // 
        viewerLabelMenuItem.Enabled = false;
        viewerLabelMenuItem.Name = "viewerLabelMenuItem";
        viewerLabelMenuItem.Size = new Size(196, 22);
        viewerLabelMenuItem.Text = "Viewer";
        // 
        // autofocusMenuItem
        // 
        autofocusMenuItem.Checked = true;
        autofocusMenuItem.CheckOnClick = true;
        autofocusMenuItem.CheckState = CheckState.Checked;
        autofocusMenuItem.Name = "autofocusMenuItem";
        autofocusMenuItem.Size = new Size(196, 22);
        autofocusMenuItem.Text = "Autofocus on selection";
        // 
        // testsMenuItem
        // 
        testsMenuItem.Name = "testsMenuItem";
        testsMenuItem.Size = new Size(45, 20);
        testsMenuItem.Text = "Tests";
        testsMenuItem.Visible = false;
        // 
        // aboutMenuItem
        // 
        aboutMenuItem.Name = "aboutMenuItem";
        aboutMenuItem.Size = new Size(52, 20);
        aboutMenuItem.Text = "About";
        aboutMenuItem.Visible = false;
        // 
        // openP3DFileDialog
        // 
        openP3DFileDialog.DefaultExt = "p3d";
        openP3DFileDialog.Filter = "Supported files|*.p3d;*.p3d.rz|Pure3D file|*.p3d|RZ file|*.p3d.rz";
        openP3DFileDialog.Multiselect = true;
        openP3DFileDialog.Title = "Open P3D";
        // 
        // saveP3DFileDialog
        // 
        saveP3DFileDialog.DefaultExt = "p3d";
        saveP3DFileDialog.Filter = "Pure3D file|*.p3d|RZ file|*.p3d.rz";
        saveP3DFileDialog.Title = "Save P3D";
        // 
        // tabControl
        // 
        tabControl.Dock = DockStyle.Fill;
        tabControl.Font = new Font("Segoe UI", 9F);
        tabControl.ItemSize = new Size(245, 35);
        tabControl.Location = new Point(0, 24);
        tabControl.Margin = new Padding(4, 3, 4, 3);
        tabControl.Name = "tabControl";
        tabControl.SelectedIndex = 0;
        tabControl.ShowToolTips = true;
        tabControl.Size = new Size(1370, 725);
        tabControl.SizeMode = TabSizeMode.Fixed;
        tabControl.TabIndex = 1;
        tabControl.SelectedIndexChanged += tabControl_SelectedIndexChanged;
        // 
        // EditorV2
        // 
        AllowDrop = true;
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(1370, 749);
        Controls.Add(tabControl);
        Controls.Add(editorMenuStrip);
        MainMenuStrip = editorMenuStrip;
        Margin = new Padding(4, 3, 4, 3);
        MinimumSize = new Size(931, 686);
        Name = "EditorV2";
        SizeGripStyle = SizeGripStyle.Hide;
        Text = "EditP3D";
        DragDrop += OnDragDrop;
        DragEnter += OnDragEnter;
        editorMenuStrip.ResumeLayout(false);
        editorMenuStrip.PerformLayout();
        ResumeLayout(false);
        PerformLayout();
    }

    private void fileMenuItem_Click(object sender, EventArgs e)
    {

    }
}

