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
            return "reference";
        }
        static readonly string mReferenceClose = @"rid://program.optimal.referenceCloseImageUrl";
        public override string _getTreeNodeImage()
        {
            return mReferenceClose;
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
