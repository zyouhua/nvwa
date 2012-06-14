namespace platform.include
{
    public class StringElement : Stream, IKeyStr
    {
        public override void _serialize(ISerialize nSerialize)
        {
            nSerialize._serialize(ref mValue, "value");
            nSerialize._serialize(ref mName, "name");
        }

        public string _keyStr()
        {
            return mName;
        }

        public string _getValue()
        {
            return mValue;
        }

        public string _getName()
        {
            return mName;
        }

        public StringElement()
        {
            mValue = null;
            mName = null;
        }

        string mValue;
        string mName;
    }
}
