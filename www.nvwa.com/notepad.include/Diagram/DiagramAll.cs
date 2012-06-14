using window.include;
using platform.include;

namespace notepad.include
{
    public abstract class DiagramAll : DiagramDockUrl, ITreeNode
    {
        public override ITreeNode _getTreeNode()
        {
            return this;
        }

        public virtual void _addTreeNode(ITreeContain nTreeContain)
        {
        }

        public event _RunSlot m_tExpandSlot;

        public void _expand()
        {
            if (null != m_tExpandSlot)
            {
                this.m_tExpandSlot();
            }
        }

        public void _treeNodeDoubleClick(TreeNodeMouseClickEventParams nTreeNodeMouseClickEventParams)
        {
            WorkbenchSingleton workbenchSingleton_ = __singleton<WorkbenchSingleton>._instance();
            workbenchSingleton_._showDockUrl(this);
        }

        public virtual void _treeNodeClick(TreeNodeMouseClickEventParams nTreeNodeMouseClickEventParams)
        {
        }

        public virtual void _treeNodeRightClick(TreeNodeMouseClickEventParams nTreeNodeMouseClickEventParams)
        {
        }

        public event _SetStringSlot m_tTreeNodeNameChange;

        public void _setTreeNodeName(string nTreeNodeName)
        {
            if (null != m_tTreeNodeNameChange)
            {
                m_tTreeNodeNameChange(nTreeNodeName);
            }
        }

        public abstract string _getTreeNodeName();

        public abstract string _getTreeNodeImage();

        public event _SetTreeNodeSlot m_tNewChildTreeNode;

        protected void _newChild(ITreeNode nTreeNode)
        {
            if (null != m_tNewChildTreeNode)
            {
                this.m_tNewChildTreeNode(nTreeNode);
            }
        }

        public DiagramAll()
        {
            m_tTreeNodeNameChange = null;
            m_tNewChildTreeNode = null;
            m_tExpandSlot = null;
        }
    }
}
