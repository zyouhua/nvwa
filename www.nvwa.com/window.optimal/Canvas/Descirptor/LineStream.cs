using System.Drawing;

using platform.include;

namespace window.optimal
{
    public class LineStream : Stream, IKeyStr
    {
        public override void _serialize(ISerialize nSerialize)
        {
            nSerialize._serialize(ref mStreamName, @"streamName");
            nSerialize._serialize(ref mStyleName, @"styleName");
            nSerialize._serialize(ref mImageUrl, @"imageUrl");
            nSerialize._serialize(ref mDraw, @"draw");
        }

        public string _keyStr()
        {
            return mStreamName;
        }

        public void _runInit()
        {
            ImageSingleton imageSingleton_ = __singleton<ImageSingleton>._instance();
            Image image_ = imageSingleton_._getImage(mImageUrl);
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

        public void _setImageUrl(string nImageUrl)
        {
            mImageUrl = nImageUrl;
        }

        public string _getImageUrl()
        {
            return mImageUrl;
        }

        public void _setDraw(RGB nRGB)
        {
            mDraw._setRGB(nRGB);
        }

        public RGB _getDraw()
        {
            return mDraw;
        }

        public Image _getImage()
        {
            return mImage;
        }

        public LineStream()
        {
            mStreamName = null;
            mStyleName = null;
            mImageUrl = null;
            mDraw = new RGB();
            mImage = null;
        }

        string mStreamName;
        string mStyleName;
        string mImageUrl;
        Image mImage;
        RGB mDraw;
    }
}
