using platform.include;

namespace platform.optimal
{
    public class Uid : Stream
    {
        public override void _serialize(ISerialize nSerialize)
        {
            nSerialize._serialize(ref mForceUsed, @"forceUsed");
            nSerialize._serialize(ref mOptimal, @"optimal");
            nSerialize._serialize(ref mInclude, @"include");
            nSerialize._serialize(ref mName, @"id");
        }

        public void _setForceUsed(bool nForceUsed)
        {
            mForceUsed = nForceUsed;
            base._runDirty();
        }

        public bool _forceUsed()
        {
            return mForceUsed;
        }

        public void _setOptimal(string nOptimal)
        {
            mOptimal = nOptimal;
            base._runDirty();
        }

        public string _getOptimal()
        {
            return mOptimal;
        }

        public void _setInclude(string nInclude)
        {
            mInclude = nInclude;
            base._runDirty();
        }

        public string _getInclude()
        {
            return mInclude;
        }

        public void _setName(string nName)
        {
            mName = nName;
            base._runDirty();
        }

        public string _getName()
        {
            return mName;
        }

        public void _setUid(Uid nUid)
        {
            mUid = nUid;
        }

        public Uid _getUid()
        {
            if (mForceUsed)
            {
                return this;
            }
            if (null != mUid)
            {
                return mUid;
            }
            return this;
        }

        public Uid()
        {
            mForceUsed = false;
            mOptimal = null;
            mInclude = null;
            mName = null;
            mUid = null;
        }

        bool mForceUsed;
        string mOptimal;
        string mInclude;
        string mName;
        Uid mUid;
    }
}
