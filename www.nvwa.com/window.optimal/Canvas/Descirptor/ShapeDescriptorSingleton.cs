using System.Collections.Generic;

using platform.include;

namespace window.optimal
{
    public class ShapeDescriptorSingleton : Headstream
    {
        public override void _headSerialize(ISerialize nSerialize)
        {
            nSerialize._serialize(ref mNormalRGB, @"mNormalRGB");
            nSerialize._serialize(ref mSelectRGB, @"selectRGB");
            nSerialize._serialize(ref mRectFont, @"rectFont");
            nSerialize._serialize(ref mLabelFont, @"labelFont");
        }

        public override string _streamName()
        {
            return @"shapeDescriptorSingleton";
        }

        public RectStream _rectDescriptor(string nRectDescriptor)
        {
            if (mRectDescriptors.ContainsKey(nRectDescriptor))
            {
                return mRectDescriptors[nRectDescriptor];
            }
            return null;
        }

        public LineStream _lineDescriptor(string nLineDescriptor)
        {
            if (mLineDescriptors.ContainsKey(nLineDescriptor))
            {
                return mLineDescriptors[nLineDescriptor];
            }
            return null;
        }

        public void _regDescriptor(string nDescriptorUrl)
        {
            PlatformSingleton platformSingleton_ = __singleton<PlatformSingleton>._instance();
            ShapeDescriptorManager shapeDescriptorManager_ = platformSingleton_._findHeadstream<ShapeDescriptorManager>(nDescriptorUrl);
            shapeDescriptorManager_._runInit();
            List<RectStream> rectDescriptors_ = shapeDescriptorManager_._rectStreams();
            foreach (RectStream i in rectDescriptors_)
            {
                mRectDescriptors[i._getStreamName()] = i;
            }
            List<LineStream> lineDescriptor_ = shapeDescriptorManager_._lineStreams();
            foreach (LineStream i in lineDescriptor_)
            {
                mLineDescriptors[i._getStreamName()] = i;
            }
        }

        public RGB _normalRGB()
        {
            return mNormalRGB;
        }

        public RGB _selectRGB()
        {
            return mSelectRGB;
        }

        public FONT _rectFont()
        {
            return mRectFont;
        }

        public FONT _labelFont()
        {
            return mLabelFont;
        }

        public ShapeDescriptorSingleton()
        {
            mLineDescriptors = new Dictionary<string, LineStream>();
            mRectDescriptors = new Dictionary<string, RectStream>();
            mNormalRGB = null;
            mSelectRGB = null;
            mRectFont = null;
            mLabelFont = null;
        }

        Dictionary<string, LineStream> mLineDescriptors;
        Dictionary<string, RectStream> mRectDescriptors;
        RGB mNormalRGB;
        RGB mSelectRGB;
        FONT mRectFont;
        FONT mLabelFont;
    }
}
