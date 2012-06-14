using System;
using System.Drawing;

using window.include;
using platform.include;

namespace window.optimal
{
    public class Button : Widget, IButton
    {
        public override void _serialize(ISerialize nSerialize)
        {
            nSerialize._serialize(ref mOnClick, @"onClick");
            nSerialize._serialize(ref mEnable, "enable", true);
            nSerialize._serialize(ref mPoint, @"point");
            nSerialize._serialize(ref mSize, "size");
            nSerialize._serialize(ref mText, @"text");
            base._serialize(nSerialize);
        }

        public override string _virstream()
        {
            return "button";
        }

        public override void _runInit()
        {
            PlatformSingleton platformSingleton_ = __singleton<PlatformSingleton>._instance();
            mCommand = platformSingleton_._findInterface<ICommand>(mOnClick);
            if (null != mCommand)
            {
                mCommand._setOwner(mContain);
            }
            base._runInit();
        }

        public override void _initControl()
        {
            if (null == mButton || mButton.IsDisposed)
            {
                mButton = new System.Windows.Forms.Button();
                mButton.Enabled = mEnable;
                mButton.Text = mText;
                int x_ = mPoint._getX();
                int y_ = mPoint._getY();
                mButton.Location = new Point(x_, y_);
                if (null != mSize)
                {
                    mButton.Size = new Size(mSize._getWidth(), mSize._getHeight());
                }
                mButton.Click += _onClick;
            }
        }

        public override IWidget _createControl()
        {
            return new Button();
        }

        public override object _getControl()
        {
            return mButton;
        }

        public override void _setContain(IContain nContain)
        {
            mContain = nContain;
        }

        public void _setEnable(bool nEnable)
        {
            mButton.Enabled = nEnable;
        }

        void _onClick(object sender, EventArgs e)
        {
            if (null != mCommand)
            {
                mCommand._runCommand();
            }
        }

        public Button()
        {
            mPoint = new Point2I();
            mSize = new Size2I();
            mCommand = null;
            mOnClick = null;
            mButton = null;
            mContain = null;
            mText = null;
            mEnable = true;
        }

        System.Windows.Forms.Button mButton;
        ICommand mCommand;
        IContain mContain;
        string mOnClick;
        Point2I mPoint;
        Size2I mSize;
        string mText;
        bool mEnable;
    }
}
