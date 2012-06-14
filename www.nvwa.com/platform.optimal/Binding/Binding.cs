using platform.include;

namespace platform.optimal
{
    public class Binding : Stream, IKeyStr
    {
        public override void _serialize(ISerialize nSerialize)
        {
            nSerialize._serialize(ref mClass, @"class");
            nSerialize._serialize(ref mName, @"name");
            nSerialize._serialize(ref mUid, @"uid");
            nSerialize._serialize(ref mImage, @"image");
        }

        public string _keyStr()
        {
            return mName;
        }

        public Uid _getUid()
        {
            return mUid;
        }

        public string _getName()
        {
            return mName;
        }

        public string _getClass()
        {
            return mClass;
        }

        public string _getImage()
        {
            return mImage;
        }

        public Binding()
        {
            mUid = new Uid();
            mClass = null;
            mName = null;
            mImage = null;
        }

        string mImage;
        string mClass;
        string mName;
        Uid mUid;
    }
}
