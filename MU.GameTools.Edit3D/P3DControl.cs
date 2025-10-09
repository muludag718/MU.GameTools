// EditP3D, Version=0.9.0.0, Culture=neutral, PublicKeyToken=null
// EditP3d.UI.P3DControlV2

using System.Collections.ObjectModel;
using System.ComponentModel;

using Aga.Controls.Tree;
using Aga.Controls.Tree.NodeControls;
using MU.GameTools.IO;


using MU.GameTools.Prototype.FileFormats;
using MU.GameTools.Prototype.FileFormats.Pure3D;
using MU.GameTools.Common;
using MU.GameTools.Edit3D.Tools.Viewer;

namespace MU.GameTools.Edit3D;

public class P3DControl : UserControl
{
    public string FileName;

    protected Pure3DFile _file;

    protected bool _isDirty;

    protected Node _rootNode;

    private static readonly string[] GameIdentifier = new string[3] { "[P1]", "[P2]", "[Any]" };

    protected ToolStripItem openContextMenuButton;

    protected ToolStripMenuItem addContextMenuButton;

    protected ToolStripItem addNewContextMenuButton;

    protected ToolStripItem addFromFileContextMenuButton;

    protected ToolStripItem saveContextMenuButton;

    protected ToolStripItem replaceContextMenuButton;

    protected ToolStripItem removeContextMenuButton;

    protected ToolStripMenuItem dataContextMenuButton;

    protected ToolStripItem importDataContextMenuButton;

    protected ToolStripItem exportDataContextMenuButton;

    private IContainer components;

    private SplitContainer mainSplitContainer;

    private PropertyGrid propertyGrid;

    private NodeTextBox _nodeTextBox;

    private TreeViewAdv nodeTreeView;

    private BackgroundWorker backgroundWorker1;

    private ContextMenuStrip nodeContextMenuStrip;

    private ToolStripMenuItem addToolStripMenuItem;

    private ToolStripMenuItem saveToolStripMenuItem;

    private ToolStripMenuItem replaceToolStripMenuItem;

    private ToolStripMenuItem dataToolStripMenuItem;

    private ToolStripMenuItem importToolStripMenuItem;

    private ToolStripMenuItem exportToolStripMenuItem;

    private OpenFileDialog importFileDialog;

    private SaveFileDialog exportFileDialog;

    private ToolStripMenuItem removeStripMenuItem;

    private ToolStripMenuItem newNodeToolStripMenuItem;

    private ToolStripMenuItem fromFileToolStripMenuItem;

    private ToolStripMenuItem openToolStripMenuItem;

    public Pure3DFile ActiveFile => _file;

    public bool IsRZ => Utils.IsRZFile(FileName);

    public PrototypeGame Game => _file.GamePicked;

    public bool IsMultipleSelect => nodeTreeView.SelectedNodes.Count > 1;

    public bool IsDirty
    {
        get
        {
            return _isDirty;
        }
        set
        {
            _isDirty = value;
            if (Tab.Text.EndsWith("*"))
            {
                Tab.Text = Tab.Text.Substring(0, Tab.Text.Length - 1);
            }
            if (value)
            {
                Tab.Text += "*";
            }
            Tab.Font = new Font(Tab.Font, value ? FontStyle.Bold : FontStyle.Regular);
        }
    }

    public TreeViewAdv TreeView => nodeTreeView;

    public TreeModel TreeModel => nodeTreeView.Model as TreeModel;

    protected Editor Editor => Application.OpenForms[0] as Editor;

    protected TabPage Tab => base.Parent as TabPage;

    public P3DControl(Pure3DFile p3d)
    {
        InitializeComponent();
        _file = p3d;
        nodeTreeView.Model = new TreeModel();
        openContextMenuButton = nodeContextMenuStrip.Items[0];
        addContextMenuButton = (ToolStripMenuItem)nodeContextMenuStrip.Items[1];
        addNewContextMenuButton = addContextMenuButton.DropDownItems[0];
        addFromFileContextMenuButton = addContextMenuButton.DropDownItems[1];
        saveContextMenuButton = nodeContextMenuStrip.Items[2];
        replaceContextMenuButton = nodeContextMenuStrip.Items[3];
        removeContextMenuButton = nodeContextMenuStrip.Items[4];
        dataContextMenuButton = (ToolStripMenuItem)nodeContextMenuStrip.Items[5];
        importDataContextMenuButton = dataContextMenuButton.DropDownItems[0];
        exportDataContextMenuButton = dataContextMenuButton.DropDownItems[1];
        UpdateNodeTree();
    }

    private void UpdateNode(BaseNode node, Collection<Node> list, int index = -1)
    {
        nodeTreeView.BeginUpdate();
        Node node2 = new Node
        {
            Text = node.ToString(),
            Tag = node
        };
        foreach (BaseNode child in node.Children)
        {
            UpdateNode(child, node2.Nodes);
        }
        var t = node.TypeId;
        if (index > -1)
        {
            list[index] = node2;
        }
        else
        {
            list.Add(node2);
        }
        nodeTreeView.EndUpdate();
    }

    public void UpdateNodeTree()
    {
        nodeTreeView.BeginUpdate();
        TreeModel.Nodes.Clear();
        foreach (BaseNode node in ActiveFile.Nodes)
        {
            UpdateNode(node, TreeModel.Nodes);
        }
        nodeTreeView.EndUpdate();
    }

    private void SelectNothing()
    {
        propertyGrid.SelectedObject = null;
        nodeTreeView.SelectedNode = null;
    }

    private void SelectNode(BaseNode node)
    {
        propertyGrid.SelectedObject = node;
        if (Editor.Viewer_Autofocus && ViewerTool.IsOpen)
        {
            Editor.Viewer.LoadNode(Game, _file, node);
        }
    }

    public void SetName(string path, bool dirty = false)
    {
        FileName = path;
        string text = GameIdentifier[(int)Game];
        Tab.Text = text + " " + Path.GetFileName(path);
        IsDirty = dirty;
        Tab.ToolTipText = path;
    }

    private void OnTreeSelectionChanged(object sender, EventArgs e)
    {
        ReadOnlyCollection<TreeNodeAdv> selectedNodes = ((TreeViewAdv)sender).SelectedNodes;
        if (selectedNodes == null || selectedNodes.Count <= 0)
        {
            SelectNothing();
            return;
        }
        if (IsMultipleSelect)
        {
            propertyGrid.SelectedObject = null;
            return;
        }
        Node node = (Node)selectedNodes[0].Tag;
        SelectNode((BaseNode)node.Tag);
    }

    private void OnTreeItemDrag(object sender, ItemDragEventArgs e)
    {
        ((TreeViewAdv)sender).DoDragDropSelectedNodes(DragDropEffects.Move);
    }

    private void nodeTreeView_DragDrop(object sender, DragEventArgs e)
    {
        TreeView.BeginUpdate();
        TreeNodeAdv[] array = (TreeNodeAdv[])e.Data.GetData(typeof(TreeNodeAdv[]));
        Node node = TreeView.DropPosition.Node.Tag as Node;
        if (TreeView.DropPosition.Position == NodePosition.Inside)
        {
            TreeNodeAdv[] array2 = array;
            for (int i = 0; i < array2.Length; i++)
            {
                (array2[i].Tag as Node).Parent = node;
            }
            TreeView.DropPosition.Node.IsExpanded = true;
        }
        else
        {
            Node node2 = node.Parent;
            Node item = node;
            if (TreeView.DropPosition.Position == NodePosition.After)
            {
                item = node.NextNode;
            }
            TreeNodeAdv[] array2 = array;
            for (int i = 0; i < array2.Length; i++)
            {
                (array2[i].Tag as Node).Parent = null;
            }
            int num = -1;
            num = node2.Nodes.IndexOf(item);
            array2 = array;
            for (int i = 0; i < array2.Length; i++)
            {
                Node item2 = array2[i].Tag as Node;
                if (num == -1)
                {
                    node2.Nodes.Add(item2);
                    continue;
                }
                node2.Nodes.Insert(num, item2);
                num++;
            }
        }
        TreeView.EndUpdate();
    }

    private void nodeTreeView_DragOver(object sender, DragEventArgs e)
    {
        if (!e.Data.GetDataPresent(typeof(TreeNodeAdv[])) || TreeView.DropPosition.Node == null)
        {
            return;
        }
        TreeNodeAdv[] obj = e.Data.GetData(typeof(TreeNodeAdv[])) as TreeNodeAdv[];
        TreeNodeAdv node = TreeView.DropPosition.Node;
        if (TreeView.DropPosition.Position != NodePosition.Inside)
        {
            node = node.Parent;
        }
        TreeNodeAdv[] array = obj;
        foreach (TreeNodeAdv node2 in array)
        {
            if (!CheckNodeParent(node, node2))
            {
                e.Effect = DragDropEffects.None;
                return;
            }
        }
        e.Effect = e.AllowedEffect;
    }

    private void OnOpeningContextMenu(object sender, CancelEventArgs e)
    {
        ReadOnlyCollection<TreeNodeAdv> selectedNodes = nodeTreeView.SelectedNodes;
        for (int i = 0; i < nodeContextMenuStrip.Items.Count; i++)
        {
            nodeContextMenuStrip.Items[i].Enabled = false;
        }
        for (int j = 0; j < dataContextMenuButton.DropDownItems.Count; j++)
        {
            dataContextMenuButton.DropDownItems[j].Enabled = false;
        }
        if (selectedNodes == null || selectedNodes.Count <= 0)
        {
            addContextMenuButton.Enabled = true;
        }
        else if (IsMultipleSelect)
        {
            saveContextMenuButton.Enabled = true;
            replaceContextMenuButton.Enabled = false;
            removeContextMenuButton.Enabled = true;
            exportDataContextMenuButton.Enabled = true;
            foreach (TreeNodeAdv item in selectedNodes)
            {
                if (!((item.Tag as Node).Tag as BaseNode).Exportable)
                {
                    exportDataContextMenuButton.Enabled = false;
                    break;
                }
            }
            dataContextMenuButton.Enabled = exportDataContextMenuButton.Enabled;
        }
        else
        {
            addContextMenuButton.Enabled = true;
            replaceContextMenuButton.Enabled = true;
            removeContextMenuButton.Enabled = true;
            saveContextMenuButton.Enabled = true;
            BaseNode baseNode = (BaseNode)((Node)selectedNodes[0].Tag).Tag;
            if (baseNode.Exportable || baseNode.Importable)
            {
                dataContextMenuButton.Enabled = true;
                dataContextMenuButton.DropDownItems[0].Enabled = baseNode.Importable;
                dataContextMenuButton.DropDownItems[1].Enabled = baseNode.Exportable;
            }
            openContextMenuButton.Enabled = baseNode.Runnable;
        }
    }

    private void OnAddFromFileContext_Click(object sender, EventArgs e)
    {
        importFileDialog.Multiselect = false;
        if (importFileDialog.ShowDialog() != DialogResult.OK)
        {
            return;
        }
        using (Stream input = importFileDialog.OpenFile())
        {
            Pure3DFile pure3DFile = new Pure3DFile();
            pure3DFile.Deserialize(input, Editor.Endianess);
            List<BaseNode> list = ((BaseNode)propertyGrid.SelectedObject)?.Children;
            if (list == null)
            {
                list = _file.Nodes;
            }
            Node node = ((nodeTreeView.SelectedNode != null) ? TreeModel.FindNode(TreeView.GetPath(nodeTreeView.SelectedNode)) : TreeModel.Root);
            foreach (BaseNode node2 in pure3DFile.Nodes)
            {
                list.Add(node2);
                UpdateNode(node2, node.Nodes);
            }
        }
        importFileDialog.Multiselect = true;
    }

    private void OnOpenContext_Click(object sender, EventArgs e)
    {
        if (propertyGrid.SelectedObject != null && propertyGrid.SelectedObject is BaseNode)
        {
            BaseNode obj = (BaseNode)propertyGrid.SelectedObject;
            if (!obj.Runnable)
            {
                throw new InvalidOperationException();
            }
            obj.RunNode();
            _ = obj.RunTool;
        }
    }

    private void OnSaveContext_Click(object sender, EventArgs e)
    {
        if (IsMultipleSelect)
        {
            if (DialogResult.OK != Editor.folderBrowserDialog.ShowDialog())
            {
                return;
            }
            {
                foreach (TreeNodeAdv selectedNode in TreeView.SelectedNodes)
                {
                    BaseNode baseNode = (selectedNode.Tag as Node).Tag as BaseNode;
                    Pure3DFile pure3DFile = new Pure3DFile();
                    pure3DFile.Nodes.Add(baseNode);
                    Editor.SaveP3DFile(pure3DFile, Path.Combine(Editor.folderBrowserDialog.SelectedPath, baseNode.ToString() + ".p3d"));
                }
                return;
            }
        }
        BaseNode item = (BaseNode)propertyGrid.SelectedObject;
        Editor.saveP3DFileDialog.FileName = propertyGrid.SelectedObject.ToString();
        if (Editor.saveP3DFileDialog.ShowDialog() == DialogResult.OK)
        {
            Pure3DFile pure3DFile2 = new Pure3DFile();
            pure3DFile2.Nodes.Add(item);
            Editor.SaveP3DFile(pure3DFile2, Editor.saveP3DFileDialog.FileName);
        }
    }

    private void OnReplaceContext_Click(object sender, EventArgs e)
    {
        if (propertyGrid.SelectedObject == null || !(propertyGrid.SelectedObject is BaseNode))
        {
            return;
        }
        BaseNode baseNode = (BaseNode)propertyGrid.SelectedObject;
        Editor.openP3DFileDialog.FileName = "";
        if (Editor.openP3DFileDialog.ShowDialog() != DialogResult.OK)
        {
            return;
        }
        using Stream stream = Editor.openP3DFileDialog.OpenFile();
        stream.ReadBytes(12);
        BaseNode baseNode2 = Pure3DFile.DeserializeNode(stream, Endian.Little, baseNode.ParentNode, ActiveFile.GamePicked);
        nodeTreeView.BeginUpdate();
        Node node = (Node)TreeView.SelectedNode.Tag;
        node.Text = baseNode2.ToString();
        node.Tag = baseNode2;
        node.Nodes.Clear();
        foreach (BaseNode child in baseNode2.Children)
        {
            UpdateNode(child, node.Nodes);
        }
        nodeTreeView.EndUpdate();
        propertyGrid.SelectedObject = node.Tag;
    }

    private void OnRemoveContext_Click(object sender, EventArgs e)
    {
        foreach (TreeNodeAdv item in TreeView.SelectedNodes.ToList())
        {
            (item.Tag as Node).Parent = null;
        }
    }

    private void OnDataImportContext_Click(object sender, EventArgs e)
    {
        if (IsMultipleSelect || propertyGrid.SelectedObject == null || !(propertyGrid.SelectedObject is BaseNode))
        {
            return;
        }
        BaseNode baseNode = (BaseNode)propertyGrid.SelectedObject;
        if (!baseNode.Importable)
        {
            throw new InvalidOperationException();
        }
        if (importFileDialog.ShowDialog() != DialogResult.OK)
        {
            return;
        }
        using Stream input = importFileDialog.OpenFile();
        baseNode.Import(input);
    }

    private void OnDataExportContext_Click(object sender, EventArgs e)
    {
        if (IsMultipleSelect)
        {
            if (DialogResult.OK != Editor.folderBrowserDialog.ShowDialog())
            {
                return;
            }
            {
                foreach (TreeNodeAdv selectedNode in TreeView.SelectedNodes)
                {
                    BaseNode baseNode = (selectedNode.Tag as Node).Tag as BaseNode;
                    if (!baseNode.Exportable)
                    {
                        throw new InvalidOperationException();
                    }
                    using FileStream output = File.Create(Path.Combine(Editor.folderBrowserDialog.SelectedPath, baseNode.ToString() + "." + baseNode.ExportExtension));
                    baseNode.Export(output);
                }
                return;
            }
        }
        BaseNode baseNode2 = (BaseNode)propertyGrid.SelectedObject;
        if (!baseNode2.Exportable)
        {
            throw new InvalidOperationException();
        }
        exportFileDialog.DefaultExt = baseNode2.ExportExtension;
        exportFileDialog.Filter = baseNode2.ExportExtension.ToUpper() + " File (*." + baseNode2.ExportExtension + ")|*." + baseNode2.ExportExtension;
        if (exportFileDialog.ShowDialog() != DialogResult.OK)
        {
            return;
        }
        using Stream output2 = exportFileDialog.OpenFile();
        baseNode2.Export(output2);
    }

    private void RemoveNode()
    {

    }

    private bool CheckNodeParent(TreeNodeAdv parent, TreeNodeAdv node)
    {
        while (parent != null)
        {
            if (node == parent)
            {
                return false;
            }
            parent = parent.Parent;
        }
        return true;
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
        this.components = new System.ComponentModel.Container();
        this.mainSplitContainer = new System.Windows.Forms.SplitContainer();
        this.nodeTreeView = new Aga.Controls.Tree.TreeViewAdv();
        this.nodeContextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
        this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
        this.addToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
        this.newNodeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
        this.fromFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
        this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
        this.replaceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
        this.removeStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
        this.dataToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
        this.importToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
        this.exportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
        this._nodeTextBox = new Aga.Controls.Tree.NodeControls.NodeTextBox();
        this.propertyGrid = new System.Windows.Forms.PropertyGrid();
        this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
        this.importFileDialog = new System.Windows.Forms.OpenFileDialog();
        this.exportFileDialog = new System.Windows.Forms.SaveFileDialog();
        ((System.ComponentModel.ISupportInitialize)this.mainSplitContainer).BeginInit();
        this.mainSplitContainer.Panel1.SuspendLayout();
        this.mainSplitContainer.Panel2.SuspendLayout();
        this.mainSplitContainer.SuspendLayout();
        this.nodeContextMenuStrip.SuspendLayout();
        base.SuspendLayout();
        this.mainSplitContainer.BackColor = System.Drawing.SystemColors.Window;
        this.mainSplitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
        this.mainSplitContainer.Location = new System.Drawing.Point(0, 0);
        this.mainSplitContainer.Name = "mainSplitContainer";
        this.mainSplitContainer.Panel1.Controls.Add(this.nodeTreeView);
        this.mainSplitContainer.Panel1.Padding = new System.Windows.Forms.Padding(10, 5, 0, 0);
        this.mainSplitContainer.Panel2.Controls.Add(this.propertyGrid);
        this.mainSplitContainer.Panel2.Padding = new System.Windows.Forms.Padding(0, 0, 2, 5);
        this.mainSplitContainer.Size = new System.Drawing.Size(1280, 720);
        this.mainSplitContainer.SplitterDistance = 414;
        this.mainSplitContainer.TabIndex = 0;
        this.nodeTreeView.AllowDrop = true;
        this.nodeTreeView.BackColor = System.Drawing.SystemColors.Window;
        this.nodeTreeView.BorderStyle = System.Windows.Forms.BorderStyle.None;
        this.nodeTreeView.ColumnHeaderHeight = 0;
        this.nodeTreeView.ContextMenuStrip = this.nodeContextMenuStrip;
        this.nodeTreeView.DefaultToolTipProvider = null;
        this.nodeTreeView.DisplayDraggingNodes = true;
        this.nodeTreeView.Dock = System.Windows.Forms.DockStyle.Fill;
        this.nodeTreeView.DragDropMarkColor = System.Drawing.Color.Black;
        this.nodeTreeView.FullRowSelectActiveColor = System.Drawing.Color.Empty;
        this.nodeTreeView.FullRowSelectInactiveColor = System.Drawing.Color.Empty;
        this.nodeTreeView.LineColor = System.Drawing.SystemColors.ControlDark;
        this.nodeTreeView.Location = new System.Drawing.Point(10, 5);
        this.nodeTreeView.Model = null;
        this.nodeTreeView.Name = "nodeTreeView";
        this.nodeTreeView.NodeControls.Add(this._nodeTextBox);
        this.nodeTreeView.NodeFilter = null;
        this.nodeTreeView.SelectedNode = null;
        this.nodeTreeView.SelectionMode = Aga.Controls.Tree.TreeSelectionMode.Multi;
        this.nodeTreeView.Size = new System.Drawing.Size(404, 715);
        this.nodeTreeView.TabIndex = 2;
        this.nodeTreeView.ItemDrag += new System.Windows.Forms.ItemDragEventHandler(OnTreeItemDrag);
        this.nodeTreeView.SelectionChanged += new System.EventHandler(OnTreeSelectionChanged);
        this.nodeTreeView.DragDrop += new System.Windows.Forms.DragEventHandler(nodeTreeView_DragDrop);
        this.nodeTreeView.DragOver += new System.Windows.Forms.DragEventHandler(nodeTreeView_DragOver);
        this.nodeContextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[6] { this.openToolStripMenuItem, this.addToolStripMenuItem, this.saveToolStripMenuItem, this.replaceToolStripMenuItem, this.removeStripMenuItem, this.dataToolStripMenuItem });
        this.nodeContextMenuStrip.Name = "nodeContextMenuStrip";
        this.nodeContextMenuStrip.Size = new System.Drawing.Size(181, 158);
        this.nodeContextMenuStrip.Opening += new System.ComponentModel.CancelEventHandler(OnOpeningContextMenu);
        this.openToolStripMenuItem.Name = "openToolStripMenuItem";
        this.openToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
        this.openToolStripMenuItem.Text = "Open";
        this.openToolStripMenuItem.Click += new System.EventHandler(OnOpenContext_Click);
        this.addToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[2] { this.newNodeToolStripMenuItem, this.fromFileToolStripMenuItem });
        this.addToolStripMenuItem.Name = "addToolStripMenuItem";
        this.addToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
        this.addToolStripMenuItem.Text = "Add";
        this.newNodeToolStripMenuItem.Name = "newNodeToolStripMenuItem";
        this.newNodeToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
        this.newNodeToolStripMenuItem.Text = "New node";
        this.fromFileToolStripMenuItem.Name = "fromFileToolStripMenuItem";
        this.fromFileToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
        this.fromFileToolStripMenuItem.Text = "From file";
        this.fromFileToolStripMenuItem.Click += new System.EventHandler(OnAddFromFileContext_Click);
        this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
        this.saveToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
        this.saveToolStripMenuItem.Text = "Save";
        this.saveToolStripMenuItem.Click += new System.EventHandler(OnSaveContext_Click);
        this.replaceToolStripMenuItem.Name = "replaceToolStripMenuItem";
        this.replaceToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
        this.replaceToolStripMenuItem.Text = "Replace";
        this.replaceToolStripMenuItem.Click += new System.EventHandler(OnReplaceContext_Click);
        this.removeStripMenuItem.Name = "removeStripMenuItem";
        this.removeStripMenuItem.Size = new System.Drawing.Size(180, 22);
        this.removeStripMenuItem.Text = "Remove";
        this.removeStripMenuItem.Click += new System.EventHandler(OnRemoveContext_Click);
        this.dataToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[2] { this.importToolStripMenuItem, this.exportToolStripMenuItem });
        this.dataToolStripMenuItem.Name = "dataToolStripMenuItem";
        this.dataToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
        this.dataToolStripMenuItem.Text = "Data";
        this.importToolStripMenuItem.Name = "importToolStripMenuItem";
        this.importToolStripMenuItem.Size = new System.Drawing.Size(110, 22);
        this.importToolStripMenuItem.Text = "Import";
        this.importToolStripMenuItem.Click += new System.EventHandler(OnDataImportContext_Click);
        this.exportToolStripMenuItem.Name = "exportToolStripMenuItem";
        this.exportToolStripMenuItem.Size = new System.Drawing.Size(110, 22);
        this.exportToolStripMenuItem.Text = "Export";
        this.exportToolStripMenuItem.Click += new System.EventHandler(OnDataExportContext_Click);
        this._nodeTextBox.DataPropertyName = "Text";
        this._nodeTextBox.EditEnabled = true;
        this._nodeTextBox.IncrementalSearchEnabled = true;
        this._nodeTextBox.LeftMargin = 3;
        this._nodeTextBox.ParentColumn = null;
        this.propertyGrid.Dock = System.Windows.Forms.DockStyle.Fill;
        this.propertyGrid.HelpVisible = false;
        this.propertyGrid.Location = new System.Drawing.Point(0, 0);
        this.propertyGrid.Name = "propertyGrid";
        this.propertyGrid.PropertySort = System.Windows.Forms.PropertySort.Categorized;
        this.propertyGrid.Size = new System.Drawing.Size(860, 715);
        this.propertyGrid.TabIndex = 0;
        this.propertyGrid.ToolbarVisible = false;
        base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
        base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        base.Controls.Add(this.mainSplitContainer);
        base.Name = "P3DControlV2";
        base.Size = new System.Drawing.Size(1280, 720);
        this.mainSplitContainer.Panel1.ResumeLayout(false);
        this.mainSplitContainer.Panel2.ResumeLayout(false);
        ((System.ComponentModel.ISupportInitialize)this.mainSplitContainer).EndInit();
        this.mainSplitContainer.ResumeLayout(false);
        this.nodeContextMenuStrip.ResumeLayout(false);
        base.ResumeLayout(false);
    }
}
