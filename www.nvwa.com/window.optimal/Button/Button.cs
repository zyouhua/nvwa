using System;
using System.Drawing;

using window.include;
using platform.include;

namespace window.optimal
{
    public class Button : Widget
    {
        public override void _serialize(ISerialize nSerialize)
        {
            nSerialize._serialize(ref mOnClick, @"onClick");
            nSerialize._serialize(ref mPoint, @"point");
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
                mButton.Text = mText;
                int x_ = mPoint._getX();
                int y_ = mPoint._getY();
                mButton.Location = new Point(x_, y_);
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

        public void _setOnClick(string nOnClick)
        {
            mOnClick = nOnClick;
        }

        public string _getOnClick()
        {
            return mOnClick;
        }

        public void _setText(string nText)
        {
            mText = nText;
        }

        public string _getText()
        {
            return mText;
        }

        public void _setPoint(Point2I nPoint)
        {
            mPoint._setPoint(nPoint);
        }

        public Point2I _getPoint()
        {
            Point2I result_ = new Point2I(mPoint);
            return result_;
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
            mCommand = null;
            mOnClick = null;
            mButton = null;
            mContain = null;
            mText = null;
        }

        System.Windows.Forms.Button mButton;
        ICommand mCommand;
        IContain mContain;
        string mOnClick;
        Point2I mPoint;
        string mText;
    }
}
