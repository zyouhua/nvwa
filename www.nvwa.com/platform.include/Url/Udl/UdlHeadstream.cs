namespace platform.include
{
    public class UdlHeadstream : Headstream
    {
        public override void _headSerialize(ISerialize nSerialize)
        {
            nSerialize._serialize(ref mFileName, @"fileName");
            nSerialize._serialize(ref mId, @"id");
            base._headSerialize(nSerialize);
        }

        public override string _streamName()
        {
            return @"udlHeadstream";
        }

        public void _setFileName(string nFileName)
        {
            mFileName = nFileName;
            base._runDirty();
        }

        public string _getFileName()
        {
            return mFileName;
        }

        public void _setId(string nId)
        {
            mId = nId;
            base._runDirty();
        }

        public string _getId()
        {
            return mId;
        }

        public UdlHeadstream()
        {
            mFileName = null;
            mId = null;
        }

        string mFileName;
        string mId;
    }
}
