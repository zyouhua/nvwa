using System.Collections.Generic;

using window.include;
using platform.include;

namespace window.optimal
{
    public class ShapeDescriptorSingleton : Headstream
    {
        public override void _headSerialize(ISerialize nSerialize)
        {
            nSerialize._serialize(ref mSelectRGB, @"selectRGB");
        }

        public override string _streamName()
        {
            return @"shapeDescriptorSingleton";
        }

        public LabelStream _labelDescriptor(string nLabelDescriptor)
        {
            if (mLabelDescriptors.ContainsKey(nLabelDescriptor))
            {
                return mLabelDescriptors[nLabelDescriptor];
            }
            return null;
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
            List<LabelStream> labelDescriptors_ = shapeDescriptorManager_._labelStreams();
            foreach (LabelStream i in labelDescriptors_)
            {
                mLabelDescriptors[i._getStreamName()] = i;
            }
            List<RectStream> rectDescriptors_ = shapeDescriptorManager_._rectStreams();
            foreach (RectStream i in rectDescriptors_)
            {
                mRectDescriptors[i._getStreamName()] = i;
            }
            List<LineStream> lineDescriptors_ = shapeDescriptorManager_._lineStreams();
            foreach (LineStream i in lineDescriptors_)
            {
                mLineDescriptors[i._getStreamName()] = i;
            }
        }

        public RGB _selectRGB()
        {
            return mSelectRGB;
        }

        public ShapeDescriptorSingleton()
        {
            mLabelDescriptors = new Dictionary<string, LabelStream>();
            mRectDescriptors = new Dictionary<string, RectStream>();
            mLineDescriptors = new Dictionary<string, LineStream>();
            mSelectRGB = null;
        }

        Dictionary<string, LineStream> mLineDescriptors;
        Dictionary<string, LabelStream> mLabelDescriptors;
        Dictionary<string, RectStream> mRectDescriptors;
        RGB mSelectRGB;
    }
}
