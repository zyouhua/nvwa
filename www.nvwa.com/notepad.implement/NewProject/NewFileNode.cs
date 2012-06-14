using System.Collections.Generic;

using window.include;
using platform.include;

namespace notepad.implement
{
    public class NewFileNode : TreeNode, IStream
    {
        public void _serialize(ISerialize nSerialize)
        {
            nSerialize._serialize(ref mNodeName, @"nodeName");
            nSerialize._serialize(ref mNodeImage, @"nodeImage");
            nSerialize._serialize(ref mNewFileNodes, @"newFileNodes");
            nSerialize._serialize(ref mNewFileNodeContents, @"newFileNodeContents");
        }

        public void _runInit()
        {
            foreach (NewFileNodeContent i in mNewFileNodeContents)
            {
                i._runInit();
            }
            foreach (NewFileNode i in mNewFileNodes)
            {
                i._runInit();
            }
        }

        public void _runDirty()
        {
            mDirty = true;
        }

        public event _GetBoolSlot m_tIsDirty;

        public virtual bool _isDirty()
        {
            if (mDirty)
            {
                return true;
            }
            if (null == m_tIsDirty)
            {
                return false;
            }
            return this.m_tIsDirty();
        }

        public event _RunSlot m_tRunSave;

        public virtual void _runSave()
        {
            if (null == m_tRunSave)
            {
                this.m_tRunSave();
            }
            mDirty = false;
        }

        public override void _addTreeNode(ITreeContain nTreeContain)
        {
            foreach (NewFileNode i in mNewFileNodes)
            {
                nTreeContain._addTreeNode(i);
            }
            base._addTreeNode(nTreeContain);
        }

        public override void _treeNodeClick(TreeNodeMouseClickEventParams nTreeNodeMouseClickEventParams)
        {
            IContain contain_ = nTreeNodeMouseClickEventParams._getcontain();
            IListView listView_ = contain_._childControl("listView1") as IListView;
            listView_._clearListItem();
            foreach (NewFileNodeContent i in mNewFileNodeContents)
            {
                listView_._addListItem(i);
            }
        }

        public override string _getTreeNodeName()
        {
            return mNodeName;
        }

        public override string _getTreeNodeImage()
        {
            return mNodeImage;
        }

        public NewFileNode()
        {
            mNewFileNodeContents = new List<NewFileNodeContent>();
            mNewFileNodes = new List<NewFileNode>();
            mNodeImage = null;
            mNodeName = null;
            mDirty = false;
        }

        List<NewFileNodeContent> mNewFileNodeContents;
        List<NewFileNode> mNewFileNodes;
        string mNodeImage;
        string mNodeName;
        bool mDirty;
    }
}
