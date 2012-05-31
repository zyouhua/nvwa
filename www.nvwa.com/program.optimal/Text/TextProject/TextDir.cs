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

        public void _runDirty()
        {
            mDirty = true;
        }

        public virtual bool _isDirty()
        {
            return mDirty;
        }

        public virtual void _runSave()
        {
            mDirty = false;
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
