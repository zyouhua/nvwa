using window.include;
using platform.include;

namespace window.optimal
{
    public class TreeNodeWidget : System.Windows.Forms.TreeNode, ITreeContain
    {
        public void _addTreeNode(ITreeNode nTreeNode)
        {
            TreeNodeWidget treeNodeWidget_ = new TreeNodeWidget();
            treeNodeWidget_._setTreeNode(nTreeNode);
            nTreeNode._addTreeNode(treeNodeWidget_);
            this.Nodes.Add(treeNodeWidget_);
        }

        public void _setTreeNode(ITreeNode nTreeNode)
        {
            mTreeNode = nTreeNode;
            this.Text = nTreeNode._getTreeNodeName();
            ImageSingleton imageSingleton_ = __singleton<ImageSingleton>._instance();
            this.ImageIndex = imageSingleton_._getImageId(nTreeNode._getTreeNodeImage());
            this.SelectedImageIndex = this.ImageIndex;
            mTreeNode.m_tTreeNodeNameChange += this._setTreeNodeName;
            mTreeNode.m_tNewChildTreeNode += this._newChildTreeNode;
            nTreeNode.m_tExpandSlot += this._expand;
        }

        public ITreeNode _getTreeNode()
        {
            return mTreeNode;
        }

        void _setTreeNodeName(string nName)
        {
            this.Text = nName;
        }

        void _newChildTreeNode(ITreeNode nTreeNode)
        {
            TreeNodeWidget treeNodeWidget_ = new TreeNodeWidget();
            treeNodeWidget_._setTreeNode(nTreeNode);
            nTreeNode._addTreeNode(treeNodeWidget_);
            this.Nodes.Add(treeNodeWidget_);
        }

        void _expand()
        {
            this.Expand();
        }

        public TreeNodeWidget()
        {
            mTreeNode = null;
        }

        ITreeNode mTreeNode;
    }
}
