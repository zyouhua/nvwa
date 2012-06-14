using System.Drawing;

using platform.include;

namespace window.optimal
{
    public class RectStream : Stream, IKeyStr
    {
        public override void _serialize(ISerialize nSerialize)
        {
            nSerialize._serialize(ref mStreamName, @"streamName");
            nSerialize._serialize(ref mImageUrl, @"imageUrl");
            nSerialize._serialize(ref mDraw, @"draw");
            nSerialize._serialize(ref mFill, @"fill");
            nSerialize._serialize(ref mMoveDraw, @"moveDraw");
            nSerialize._serialize(ref mMoveFill, @"moveFill");
            nSerialize._serialize(ref mCreateDraw, @"createDraw");
            nSerialize._serialize(ref mCreateFill, @"createFill");
            nSerialize._serialize(ref mImagePos, "imagePos");
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

        public void _setImageUrl(string nImageUrl)
        {
            mImageUrl = nImageUrl;
        }

        public string _getImageUrl()
        {
            return mImageUrl;
        }

        public void _setMoveDraw(RGB nRGB)
        {
            mMoveDraw._setRGB(nRGB);
        }

        public RGB _getMoveDraw()
        {
            return mMoveDraw;
        }

        public void _setCreateDraw(RGB nRGB)
        {
            mCreateDraw._setRGB(nRGB);
        }

        public RGB _getCreateDraw()
        {
            return mCreateDraw;
        }

        public void _setCreateFill(RGB nRGB)
        {
            mCreateFill._setRGB(nRGB);
        }

        public RGB _getCreateFill()
        {
            return mCreateFill;
        }

        public void _setMoveFill(RGB nRGB)
        {
            mMoveFill._setRGB(nRGB);
        }

        public RGB _getMoveFill()
        {
            return mMoveFill;
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

        public ImagePos_ _getImagePos()
        {
            if (mImagePos == "rectLeftTop")
            {
                return ImagePos_.mRectLeftTop_;
            }
            else
            {
                return ImagePos_.mBegInRect_;
            }
        }

        public FONT _getFont()
        {
            return mFont;
        }

        public RectStream()
        {
            mStreamName = null;
            mImageUrl = null;
            mDraw = new RGB();
            mFill = new RGB();
            mMoveDraw = new RGB();
            mMoveFill = new RGB();
            mCreateDraw = new RGB();
            mCreateFill = new RGB();
            mImage = null;
            mImagePos = "begInRect";
            mFont = null;
        }

        string mStreamName;
        string mImagePos;
        string mImageUrl;
        Image mImage;
        FONT mFont;
        RGB mDraw;
        RGB mFill;
        RGB mMoveDraw;
        RGB mMoveFill;
        RGB mCreateDraw;
        RGB mCreateFill;
    }
}
