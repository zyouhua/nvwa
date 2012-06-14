using System.Collections.Generic;

namespace platform.include
{
    public class MemberStream : Stream
    {
        public override void _serialize(ISerialize nSerialize)
        {
            nSerialize._serialize(ref mConditionStreams, @"conditions");
            nSerialize._serialize(ref mValue, @"value");
            nSerialize._serialize(ref mName, @"name");
        }

        public string _getName()
        {
            return mName;
        }

        public string _getValue()
        {
            return mValue;
        }

        public IEnumerable<ConditionStream> _getConditionStreams()
        {
        	return mConditionStreams;
        }

        public MemberStream()
        {
            mConditionStreams = new List<ConditionStream>();
            mValue = null;
            mName = null;
        }

        List<ConditionStream> mConditionStreams;
        string mValue;
        string mName;
    }
}
