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
            nSerialize._serialize(ref mMoveDraw, @"moveDraw");
            nSerialize._serialize(ref mFont, "font");
        }

        public string _keyStr()
        {
            return mStreamName;
        }

        public void _runInit()
        {
            ImageSingleton imageSingleton_ = __singleton<ImageSingleton>._instance();
            mImage = imageSingleton_._getImage(mImageUrl);
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

        public void _setMoveDraw(RGB nRGB)
        {
            mMoveDraw._setRGB(nRGB);
        }

        public RGB _getMoveDraw()
        {
            return mMoveDraw;
        }
        
        public Image _getImage()
        {
            return mImage;
        }

        public FONT _getFont()
        {
            return mFont;
        }

        public LineStream()
        {
            mStreamName = null;
            mImageUrl = null;
            mDraw = new RGB();
            mMoveDraw = new RGB();
            mImage = null;
            mFont = null;
            mStyleName = null;
        }

        string mStreamName;
        string mImageUrl;
        Image mImage;
        FONT mFont;
        RGB mDraw;
        RGB mMoveDraw;
        string mStyleName;
    }
}
