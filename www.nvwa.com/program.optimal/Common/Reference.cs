using System.Collections.Generic;

using window.include;
using platform.include;

namespace program.optimal
{
    public class Reference : TreeNode, IStream
    {
        public void _serialize(ISerialize nSerialize)
        {
            nSerialize._serialize(ref mProjectReferences, "projectReferences");
        }

        public override string _getTreeNodeName()
        {
            return "reference";
        }

        static readonly string mReferenceClose = @"rid://program.optimal.referenceCloseImageUrl";
        public override string _getTreeNodeImage()
        {
            return mReferenceClose;
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

        public Reference()
        {
            mProjectReferences = new List<ProjectReference>();
            mDirty = false;
        }

        List<ProjectReference> mProjectReferences;
        bool mDirty;
    }
}
