using platform.include;

namespace platform.optimal
{
    public class Uid : Stream
    {
        public override void _serialize(ISerialize nSerialize)
        {
            nSerialize._serialize(ref mIsInclude, @"isInclude");
            nSerialize._serialize(ref mForceUsed, @"forceUsed");
            nSerialize._serialize(ref mOptimal, @"optimal");
            nSerialize._serialize(ref mInclude, @"include");
            nSerialize._serialize(ref mName, @"id");
        }

        public void _setIsInclude(bool nIsInclude)
        {
            mIsInclude = nIsInclude;
        }

        public bool _isInclude()
        {
            return mIsInclude;
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
            if (!mIsInclude)
            {
                return mInclude;
            }
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
            if (!mIsInclude)
            {
                return this;
            }
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
            mIsInclude = true;
            mForceUsed = false;
            mOptimal = null;
            mInclude = null;
            mName = null;
            mUid = null;
        }

        bool mIsInclude;
        bool mForceUsed;
        string mOptimal;
        string mInclude;
        string mName;
        Uid mUid;
    }
}
