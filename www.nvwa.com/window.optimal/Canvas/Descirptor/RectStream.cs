using System.Drawing;

using platform.include;

namespace window.optimal
{
    public class RectStream : Stream, IKeyStr
    {
        public override void _serialize(ISerialize nSerialize)
        {
            nSerialize._serialize(ref mStreamName, @"streamName");
            nSerialize._serialize(ref mStyleName, @"styleName");
            nSerialize._serialize(ref mImageUrl, @"imageUrl");
            nSerialize._serialize(ref mDraw, @"draw");
            nSerialize._serialize(ref mFill, @"fill");
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

        public void _setFill(RGB nRGB)
        {
            mFill._setRGB(nRGB);
        }

        public RGB _getFill()
        {
            return mFill;
        }

        public Image _getImage()
        {
            return mImage;
        }

        public RectStream()
        {
            mStreamName = null;
            mStyleName = null;
            mImageUrl = null;
            mDraw = new RGB();
            mFill = new RGB();
            mImage = null;
        }

        string mStreamName;
        string mStyleName;
        string mImageUrl;
        Image mImage;
        RGB mDraw;
        RGB mFill;
    }
}
