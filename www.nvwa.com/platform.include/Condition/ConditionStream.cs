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

        public void _setName(string nName)
        {
            mName = nName;
            base._runDirty();
        }

        public string _getName()
        {
            return mName;
        }

        public void _setType(string nType)
        {
            mType = nType;
            base._runDirty();
        }

        public string _getType()
        {
            return mType;
        }

        public void _setValue(string nValue)
        {
            mValue = nValue;
            base._runDirty();
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
