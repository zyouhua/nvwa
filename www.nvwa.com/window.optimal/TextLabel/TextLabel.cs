using System.Drawing;

using window.include;
using platform.include;

namespace window.optimal
{
    public class TextLabel : Widget
    {
        public override void _serialize(ISerialize nSerialize)
        {
            nSerialize._serialize(ref mSize, @"size");
            nSerialize._serialize(ref mName, @"text");
            nSerialize._serialize(ref mPoint, @"point");
            base._serialize(nSerialize);
        }

        public override string _virstream()
        {
            return @"textLabel";
        }

        public override void _initControl()
        {
            if (null == mLabel || mLabel.IsDisposed)
            {
                mLabel = new System.Windows.Forms.Label();
                mLabel.Text = mName;
                mLabel.Location = new Point(mPoint._getX(), mPoint._getY());
                mLabel.Size = new Size(mSize._getWidth(), mSize._getHeight());
            }
        }

        public override IWidget _createControl()
        {
            return new TextLabel();
        }

        public override object _getControl()
        {
            return mLabel;
        }

        public TextLabel()
        {
            mLabel = null;
            mSize = null;
            mName = null;
            mPoint = null;
        }
        System.Windows.Forms.Label mLabel;
        Size2I mSize;
        string mName;
        Point2I mPoint;
    }
}
