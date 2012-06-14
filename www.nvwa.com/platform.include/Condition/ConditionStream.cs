namespace platform.include
{
    public class ConditionStream : Stream
    {
        public override void _serialize(ISerialize nSerialize)
        {
            nSerialize._serialize(ref mName, @"name");
            nSerialize._serialize(ref mType, @"type");
            nSerialize._serialize(ref mValue, @"value");
        }

        public string _getName()
        {
            return mName;
        }

        public string _getType()
        {
            return mType;
        }

        public string _getValue()
        {
            return mValue;
        }

        public ConditionStream()
        {
            mName = null;
            mType = null;
            mValue = null;
        }

        string mName;
        string mType;
        string mValue;
    }
}
