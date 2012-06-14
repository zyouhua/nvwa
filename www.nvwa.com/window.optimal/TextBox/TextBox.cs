using System;
using System.Drawing;

using window.include;
using platform.include;

namespace window.optimal
{
    public class TextBox : Widget, ITextBox
    {
        public override void _serialize(ISerialize nSerialize)
        {
            nSerialize._serialize(ref mTextChangedCmd, "textChangedCommand");
            nSerialize._serialize(ref mPoint, @"point");
            nSerialize._serialize(ref mSize, @"size");
            nSerialize._serialize(ref mText, @"default");
            base._serialize(nSerialize);
        }

        public override string _virstream()
        {
            return @"textBox";
        }

        public override void _runInit()
        {
            PlatformSingleton platformSingleton_ = __singleton<PlatformSingleton>._instance();
            mTextChangedCommand = platformSingleton_._findInterface<ICommand>(mTextChangedCmd);
            if (null != mTextChangedCommand)
            {
                mTextChangedCommand._setOwner(mContain);
            }
            base._runInit();
        }

        public override void _initControl()
        {
            if (null == mTextBox || mTextBox.IsDisposed)
            {
                mTextBox = new System.Windows.Forms.TextBox();
                mTextBox.Location = new Point(mPoint._getX(), mPoint._getY());
                mTextBox.Size = new Size(mSize._getWidth(), mSize._getHeight());
                mTextBox.Text = mText;
                mTextBox.TextChanged += this._textBoxTextChanged;
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

        public override void _setContain(IContain nContain)
        {
            mContain = nContain;
        }

        void _textBoxTextChanged(object sender, EventArgs e)
        {
            if (null != mTextChangedCommand)
            {
                mTextChangedCommand._runCommand();
            }
        }

        public TextBox()
        {
            mTextChangedCommand = null;
            mTextChangedCmd = null;
            mTextBox = null;
            mPoint = null;
            mSize = null;
            mText = null;
        }

        System.Windows.Forms.TextBox mTextBox;
        ICommand mTextChangedCommand;
        string mTextChangedCmd;
        IContain mContain;
        Point2I mPoint;
        Size2I mSize;
        string mText;
    }
}
