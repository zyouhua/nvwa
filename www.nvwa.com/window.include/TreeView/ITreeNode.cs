using platform.include;

namespace window.include
{
    public interface ITreeNode
    {
        void _addTreeNode(ITreeContain nTreeContain);

        event _RunSlot m_tExpandSlot;

        void _expand();

        void _treeNodeDoubleClick(TreeNodeMouseClickEventParams nTreeNodeMouseClickEventParams);

        void _treeNodeClick(TreeNodeMouseClickEventParams nTreeNodeMouseClickEventParams);

        void _treeNodeRightClick(TreeNodeMouseClickEventParams nTreeNodeMouseClickEventParams);

        event _SetStringSlot m_tTreeNodeNameChange;

        void _setTreeNodeName(string nTreeNodeName);

        string _getTreeNodeName();

        string _getTreeNodeImage();

        event _SetTreeNodeSlot m_tNewChildTreeNode;
    }
}
