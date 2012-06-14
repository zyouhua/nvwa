using System.Collections.Generic;

using window.include;
using platform.include;

namespace program.optimal
{
    public class TextDir : TreeNode, IStream
    {
        public void _serialize(ISerialize nSerialize)
        {
            nSerialize._serialize(ref mTextClass, "files");
            nSerialize._serialize(ref mName, "name");
        }

        public override string _getTreeNodeName()
        {
            return mName;
        }

        static readonly string mTextDirImageUrl = "rid://program.optimal.closeFolderImageUrl";
        public override string _getTreeNodeImage()
        {
            return mTextDirImageUrl;
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

        public TextDir()
        {
            mTextClass = new List<TextClass>();
            mDirty = false;
            mName = null;
        }

        List<TextClass> mTextClass;
        string mName;
        bool mDirty;
    }
}
