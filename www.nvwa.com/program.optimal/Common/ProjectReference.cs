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

        public void _runDirty()
        {
            mDirty = true;
        }

        public bool _isDirty()
        {
            return mDirty;
        }

        public void _runSave()
        {
            mDirty = false;
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
