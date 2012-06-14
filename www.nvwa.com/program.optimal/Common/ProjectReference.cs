using window.include;
using platform.include;

namespace program.optimal
{
    public class ProjectReference : TreeNode, IStream
    {
        public void _serialize(ISerialize nSerialize)
        {
            nSerialize._serialize(ref mProjectName, @"projectName");
            nSerialize._serialize(ref mProjectUrl, "projectUrl");
        }

        public override string _getTreeNodeName()
        {
            return @"reference";
        }

        static readonly string mReferenceImage = @"rid://program.optimal.referenceImageUrl";
        public override string _getTreeNodeImage()
        {
            return mReferenceImage;
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

        public ProjectReference()
        {
            mProjectName = null;
            mProjectUrl = null;
            mDirty = false;
        }

        string mProjectName;
        string mProjectUrl;
        bool mDirty;
    }
}
