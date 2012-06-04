using System.Drawing;

using window.include;
using platform.include;

namespace window.optimal
{
    public class TextBox : Widget, ITextBox
    {
        public override void _serialize(ISerialize nSerialize)
        {
            nSerialize._serialize(ref mPoint, @"point");
            nSerialize._serialize(ref mSize, @"size");
            nSerialize._serialize(ref mText, @"default");
            base._serialize(nSerialize);
        }

        public override string _virstream()
        {
            return @"textBox";
        }

        public override void _initControl()
        {
            if (null == mTextBox || mTextBox.IsDisposed)
            {
                mTextBox = new System.Windows.Forms.TextBox();
                mTextBox.Location = new Point(mPoint._getX(), mPoint._getY());
                mTextBox.Size = new Size(mSize._getWidth(), mSize._getHeight());
                mTextBox.Text = mText;
            }
        }

        public override IWidget _createControl()
        {
            return new TextBox();
        }

        public override object _getControl()
        {
            return mTextBox;
        }

        public void _setText(string nText)
        {
            mTextBox.Text = nText;
        }

        public string _getText()
        {
            return mTextBox.Text;
        }

        public TextBox()
        {
            mTextBox = null;
            mPoint = null;
            mSize = null;
            mText = null;
        }

        System.Windows.Forms.TextBox mTextBox;
        Point2I mPoint;
        Size2I mSize;
        string mText;
    }
}
