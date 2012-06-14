using System.Collections.Generic;

using platform.include;

namespace platform.optimal
{
    public class AssemblyDescriptor : Headstream
    {
        public override void _headSerialize(ISerialize nSerialize)
        {
            nSerialize._serialize(ref mUids, @"uids");
            nSerialize._serialize(ref mRids, @"rids");
            nSerialize._serialize(ref mDependences, @"dependences");
        }

        public override string _streamName()
        {
            return @"assemblyDescriptor";
        }

        public IEnumerable<Uid> _getUids()
        {
            return mUids;
        }

        public IEnumerable<Rid> _getRids()
        {
            return mRids;
        }

        public IEnumerable<string> _getDependences()
        {
            return mDependences;
        }

        public AssemblyDescriptor()
        {
            mUids = new List<Uid>();
            mRids = new List<Rid>();
            mDependences = new List<string>();
        }

        List<Uid> mUids;
        List<Rid> mRids;
        List<string> mDependences;
    }
}
