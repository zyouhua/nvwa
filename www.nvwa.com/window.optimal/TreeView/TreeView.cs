using System.Drawing;
using System.Windows.Forms;
using System.Collections.Generic;

using window.include;
using platform.include;

namespace window.optimal
{
    public class TreeView : Widget, ITreeView
    {
        public override void _serialize(ISerialize nSerialize)
        {
            nSerialize._serialize(ref mShowRootLines, @"showRootLines");
            nSerialize._serialize(ref mDockStyle, @"dockStyle");
            nSerialize._serialize(ref mSize, @"size");
            nSerialize._serialize(ref mInitCmd, @"initCommand");
            nSerialize._serialize(ref mLoadCmd, @"loadCommand");
            base._serialize(nSerialize);
        }

        public override string _virstream()
        {
            return "treeView";
        }

        public override void _runInit()
        {
            PlatformSingleton platformSingleton_ = __singleton<PlatformSingleton>._instance();
            mInitCommand = platformSingleton_._findInterface<ICommand>(mInitCmd);
            if (null != mInitCommand)
            {
                mInitCommand._setOwner(mContain);
                mInitCommand._runCommand();
            }
            mLoadCommand = platformSingleton_._findInterface<ICommand>(mLoadCmd);
            if (null != mLoadCommand)
            {
                mLoadCommand._setOwner(mContain);
            }
            base._runInit();
        }

        public override void _initControl()
        {
            if (null == mTreeView || mTreeView.IsDisposed)
            {
                mTreeView = new System.Windows.Forms.TreeView();
                if (string.Compare(mDockStyle, @"Top") == 0)
                {
                    mTreeView.Dock = DockStyle.Top;
                }
                else if (string.Compare(mDockStyle, @"Bottom") == 0)
                {
                    mTreeView.Dock = DockStyle.Bottom;
                }
                else if (string.Compare(mDockStyle, @"Fill") == 0)
                {
                    mTreeView.Dock = DockStyle.Fill;
                }
                else if (string.Compare(mDockStyle, @"Left") == 0)
                {
                    mTreeView.Dock = DockStyle.Left;
                }
                else if (string.Compare(mDockStyle, @"Right") == 0)
                {
                    mTreeView.Dock = DockStyle.Right;
                }
                else
                {
                    mTreeView.Dock = DockStyle.None;
                }
                mTreeView.ShowRootLines = mShowRootLines;
                if (null != mSize)
                {
                    mTreeView.Width = mSize._getWidth();
                    mTreeView.Height = mSize._getHeight();
                }
                mTreeView.NodeMouseClick += this._nodeMouseClick;
                mTreeView.NodeMouseDoubleClick += this._nodeMouseDoubleClick;
                ImageSingleton imageSingleton_ = __singleton<ImageSingleton>._instance();
                mTreeView.ImageList = imageSingleton_._getImageList();
                if (null != mLoadCommand)
                {
                    mLoadCommand._runCommand();
                }
                foreach (ITreeNode i in mTreeNodes)
                {
                    TreeNodeWidget treeNodeWidget_ = new TreeNodeWidget();
                    treeNodeWidget_._setTreeNode(i);
                    i._addTreeNode(treeNodeWidget_);
                    mTreeView.Nodes.Add(treeNodeWidget_);
                }
            }
        }

        public override IWidget _createControl()
        {
            return new TreeView();
        }

        public override object _getControl()
        {
            return mTreeView;
        }

        public override void _setContain(IContain nContain)
        {
            mContain = nContain;
        }

        public void _addTreeNode(ITreeNode nTreeNode)
        {
            mTreeNodes.Add(nTreeNode);
            if (null == mTreeView || mTreeView.IsDisposed)
            {
                return;
            }
            TreeNodeWidget treeNodeWidget_ = new TreeNodeWidget();
            treeNodeWidget_._setTreeNode(nTreeNode);
            nTreeNode._addTreeNode(treeNodeWidget_);
            mTreeView.Nodes.Add(treeNodeWidget_);
        }

        public void _showContextMenuStrip(IContextMenuStrip nContextMenuStrip, int nX, int nY)
        {
            Point point_ = new Point(nX, nY);
            point_ = mTreeView.PointToScreen(point_);
            nContextMenuStrip._runShow(point_.X, point_.Y);
        }

        public void _setDockStyle(string nDockStyle)
        {
            mDockStyle = nDockStyle;
        }

        public string _getDockStyle()
        {
            return mDockStyle;
        }

        public void _setShowRootLines(bool nShowRootLines)
        {
            mShowRootLines = nShowRootLines;
        }

        public bool _getShowRootLines()
        {
            return mShowRootLines;
        }

        void _nodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            TreeNodeMouseClickEventParams treeNodeMouseClickEventParams_ = new TreeNodeMouseClickEventParams();
            treeNodeMouseClickEventParams_._setContain(mContain);
            treeNodeMouseClickEventParams_._setTreeView(this);
            treeNodeMouseClickEventParams_._setX(e.X);
            treeNodeMouseClickEventParams_._setY(e.Y);
            if (e.Button == MouseButtons.Left)
            {
                mTreeView.SelectedNode = e.Node;
                TreeNodeWidget treeNodeWidget_ = e.Node as TreeNodeWidget;
                ITreeNode treeNode_ = treeNodeWidget_._getTreeNode();
                treeNode_._treeNodeClick(treeNodeMouseClickEventParams_);
            }
            else if (e.Button == MouseButtons.Right)
            {
                mTreeView.SelectedNode = e.Node;
                TreeNodeWidget treeNodeWidget_ = e.Node as TreeNodeWidget;
                ITreeNode treeNode_ = treeNodeWidget_._getTreeNode();
                treeNode_._treeNodeRightClick(treeNodeMouseClickEventParams_);
            }
            else
            {
            }
        }

        void _nodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            TreeNodeMouseClickEventParams treeNodeMouseClickEventParams_ = new TreeNodeMouseClickEventParams();
            treeNodeMouseClickEventParams_._setContain(mContain);
            treeNodeMouseClickEventParams_._setTreeView(this);
            treeNodeMouseClickEventParams_._setX(e.X);
            treeNodeMouseClickEventParams_._setY(e.Y);
            TreeNodeWidget treeNodeWidget_ = e.Node as TreeNodeWidget;
            ITreeNode treeNode_ = treeNodeWidget_._getTreeNode();
            treeNode_._treeNodeDoubleClick(treeNodeMouseClickEventParams_);
        }

        public TreeView()
        {
            mShowRootLines = false;
            mDockStyle = @"None";
            mInitCommand = null;
            mInitCmd = null;
            mTreeView = null;
            mContain = null;
            mSize = null;
            mLoadCommand = null;
            mLoadCmd = null;
            mTreeNodes = new List<ITreeNode>();
        }

        System.Windows.Forms.TreeView mTreeView;
        bool mShowRootLines;
        string mDockStyle;
        IContain mContain;
        ICommand mInitCommand;
        string mInitCmd;
        ICommand mLoadCommand;
        string mLoadCmd;
        Size2I mSize;
        List<ITreeNode> mTreeNodes;
    }
}
