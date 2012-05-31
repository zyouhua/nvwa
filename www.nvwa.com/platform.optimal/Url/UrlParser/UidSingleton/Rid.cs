using platform.include;

namespace platform.optimal
{
    public class Rid : Stream
    {
        public override void _serialize(ISerialize nSerialize)
        {
            nSerialize._serialize(ref mId, @"id");
            nSerialize._serialize(ref mUrl, @"url");
        }

        public void _setUrl(string nUrl)
        {
            mUrl = nUrl;
            base._runDirty();
        }

        public string _getUrl()
        {
            return mUrl;
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

        public Rid()
        {
            mId = null;
            mUrl = null;
        }

        string mId;
        string mUrl;
    }
}
