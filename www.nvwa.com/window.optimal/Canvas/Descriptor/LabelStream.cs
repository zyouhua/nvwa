using platform.include;

namespace window.optimal
{
    public class LabelStream : Stream, IKeyStr
    {
        public override void _serialize(ISerialize nSerialize)
        {
            nSerialize._serialize(ref mStreamName, @"streamName");
            nSerialize._serialize(ref mStyleName, @"styleName");
        }

        public string _keyStr()
        {
            return mStreamName;
        }

        public void _setStreamName(string nStreamName)
        {
            mStreamName = nStreamName;
        }

        public string _getStreamName()
        {
            return mStreamName;
        }

        public void _setStyleName(string nStyleName)
        {
            mStyleName = nStyleName;
        }

        public string _getStyleName()
        {
            return mStyleName;
        }

        public LabelStream()
        {
            mStreamName = null;
            mStyleName = null;
        }

        string mStreamName;
        string mStyleName;
    }
}
