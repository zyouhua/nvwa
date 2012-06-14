using System.Windows.Forms;

using window.include;
using platform.include;

namespace window.optimal
{
    public class Canvas : Widget, ICanvas
    {
        public override void _serialize(ISerialize nSerialize)
        {
            nSerialize._serialize(ref mSizeMode, @"sizeMode");
            nSerialize._serialize(ref mDockStyle, @"dockStyle");
            base._serialize(nSerialize);
        }

        public override string _virstream()
        {
            return @"canvas";
        }

        public override void _initControl()
        {
            if (null == mCanvasControl || mCanvasControl.IsDisposed)
            {
                mCanvasControl = new CanvasControl(mCanvasCore);
                if (string.Compare(mDockStyle, @"Top") == 0)
                {
                    mCanvasControl.Dock = DockStyle.Top;
                }
                else if (string.Compare(mDockStyle, @"Bottom") == 0)
                {
                    mCanvasControl.Dock = DockStyle.Bottom;
                }
                else if (string.Compare(mDockStyle, @"Fill") == 0)
                {
                    mCanvasControl.Dock = DockStyle.Fill;
                }
                else if (string.Compare(mDockStyle, @"Left") == 0)
                {
                    mCanvasControl.Dock = DockStyle.Left;
                }
                else if (string.Compare(mDockStyle, @"Right") == 0)
                {
                    mCanvasControl.Dock = DockStyle.Right;
                }
                else
                {
                    mCanvasControl.Dock = DockStyle.None;
                }
                if (string.Compare(mSizeMode, @"StretchImage") == 0)
                {
                    mCanvasControl.SizeMode = PictureBoxSizeMode.StretchImage;
                }
                else if (string.Compare(mSizeMode, @"AutoSize") == 0)
                {
                    mCanvasControl.SizeMode = PictureBoxSizeMode.AutoSize;
                }
                else if (string.Compare(mSizeMode, @"CenterImage") == 0)
                {
                    mCanvasControl.SizeMode = PictureBoxSizeMode.CenterImage;
                }
                else if (string.Compare(mSizeMode, @"Zoom") == 0)
                {
                    mCanvasControl.SizeMode = PictureBoxSizeMode.Zoom;
                }
                else
                {
                    mCanvasControl.SizeMode = PictureBoxSizeMode.Normal;
                }
            }
        }

        public override IWidget _createControl()
        {
            return new Canvas();
        }

        public override object _getControl()
        {
            return mCanvasControl;
        }

        public void _regLabel(ILabel nLabel)
        {
            mCanvasCore._regLabel(nLabel);
        }

        public void _regLine(ILine nLine)
        {
            mCanvasCore._regLine(nLine);
        }

        public void _setObject(object nObject)
        {
            mCanvasCore._setObject(nObject);
        }

        public void _setSideBar(ISideBar nSideBar)
        {
            mCanvasCore._setSideBar(nSideBar);
        }

        public void _setSizeMode(string nSizeMode)
        {
            mSizeMode = nSizeMode;
        }

        public string _getSizeMode()
        {
            return mSizeMode;
        }

        public void _setDockStyle(string nDockStyle)
        {
            mDockStyle = nDockStyle;
        }

        public string _getDockStyle()
        {
            return mDockStyle;
        }

        public Canvas()
        {
            mCanvasCore = new CanvasCore();
            mCanvasControl = null;
            mSizeMode = @"Normal";
            mDockStyle = @"None";
        }

        CanvasControl mCanvasControl;
        string mDockStyle;
        string mSizeMode;
        CanvasCore mCanvasCore;
    }
}
