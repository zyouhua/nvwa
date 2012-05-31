using System.Collections.Generic;

using platform.include;

namespace window.optimal
{
    public class ShapeDescriptorManager : Headstream
    {
        public override void _headSerialize(ISerialize nSerialize)
        {
            nSerialize._serialize(ref mRectStreams, @"rectDescriptors");
            nSerialize._serialize(ref mLineStreams, @"lineDescriptors");
        }

        public override string _streamName()
        {
            return @"shapeDescriptorManager";
        }

        public void _runInit()
        {
            foreach (RectStream i in mRectStreams)
            {
                i._runInit();
            }
            foreach (LineStream i in mLineStreams)
            {
                i._runInit();
            }
        }

        public List<RectStream> _rectStreams()
        {
            return mRectStreams;
        }

        public List<LineStream> _lineStreams()
        {
            return mLineStreams;
        }

        public ShapeDescriptorManager()
        {
            mLineStreams = new List<LineStream>();
            mRectStreams = new List<RectStream>();
        }

        List<LineStream> mLineStreams;
        List<RectStream> mRectStreams;
    }
}
