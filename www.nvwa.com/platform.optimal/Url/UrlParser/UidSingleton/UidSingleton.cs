using System.Collections.Generic;

using platform.include;

namespace platform.optimal
{
    public class UidSingleton
    {
        public void _addUid(Uid nUid)
        {
            string name_ = nUid._getName();
            if (mUids.ContainsKey(name_))
            {
                throw new UidOverlapException();
            }
            mUids[name_] = nUid;
            if (!nUid._isInclude())
            {
                return;
            }
            if (nUid._forceUsed())
            {
                return;
            }
            string include_ = nUid._getInclude();
            foreach (KeyValuePair<string, Uid> i in mUids)
            {
                Uid uid_ = i.Value;
                string uidInclude_ = uid_._getInclude();
                if (uidInclude_ == include_)
                {
                    nUid._setUid(uid_._getUid());
                }
            }
        }

        public void _addRid(Rid nRid)
        {
            string name_ = nRid._getId();
            if (mRids.ContainsKey(name_))
            {
                throw new RidOverlapException();
            }
            mRids[name_] = nRid;
        }

        public Uid _getUid(string nUid)
        {
            if (!mUids.ContainsKey(nUid))
            {
                return null;
            }
            Uid uid_ = mUids[nUid];
            return uid_._getUid();
        }

        public Rid _getRid(string nRid)
        {
            if (!mRids.ContainsKey(nRid))
            {
                return null;
            }
            Rid result_ = mRids[nRid];
            return result_;
        }

        public UidSingleton()
        {
            mUids = new Dictionary<string, Uid>();
            mRids = new Dictionary<string, Rid>();
        }

        Dictionary<string, Uid> mUids;
        Dictionary<string, Rid> mRids;
    }
}
