using System.Drawing;
using WeifenLuo.WinFormsUI.Docking;

using window.include;
using platform.include;

namespace window.optimal
{
    public class DockPad : Contain, IKeyStr, IDockPad
    {
        public override void _serialize(ISerialize nSerialize)
        {
            nSerialize._serialize(ref mIcon, @"icon");
            nSerialize._serialize(ref mCaption, @"caption");
            nSerialize._serialize(ref mDockStyle, @"dockStyle");
            nSerialize._serialize(ref mPadName, @"padName");
            base._serialize(nSerialize);
        }

        public string _keyStr()
        {
            return mPadName;
        }

        public override void _initControl()
        {
            if (null == mDockFrame || mDockFrame.IsDisposed)
            {
                PlatformSingleton platformSingleton_ = __singleton<PlatformSingleton>._instance();
                mDockFrame = new DockFrame(null);
                mDockFrame.Text = mCaption;
                mDockFrame.Icon = platformSingleton_._findIcon(mIcon) as Icon;
                if (string.Compare(mDockStyle, @"DockBottom") == 0)
                {
                    mDockFrame.DockAreas = DockAreas.DockBottom;
                }
                else if (string.Compare(mDockStyle, @"DockLeft") == 0)
                {
                    mDockFrame.DockAreas = DockAreas.DockLeft;
                }
                else if (string.Compare(mDockStyle, @"DockRight") == 0)
                {
                    mDockFrame.DockAreas = DockAreas.DockRight;
                }
                else if (string.Compare(mDockStyle, @"DockTop") == 0)
                {
                    mDockFrame.DockAreas = DockAreas.DockTop;
                }
                else
                {
                    mDockFrame.DockAreas = DockAreas.DockLeft;
                }
                base._initControl();
            }
        }

        public override void _addControl(object nControl)
        {
            System.Windows.Forms.Control control_ = nControl as System.Windows.Forms.Control;
            mDockFrame.Controls.Add(control_);
        }

        public override IContain _contain(int nLevel = 0)
        {
            if (null == mContain)
            {
                return null;
            }
            if (nLevel <= 0)
            {
                return mContain;
            }
            return mContain._contain(nLevel - 1);
        }

        public void _setContain(IContain nContain)
        {
            mContain = nContain;
        }

        public DockFrame _getDockFrame()
        {
            return mDockFrame;
        }

        public void _setText(string nText)
        {
            mCaption = nText;
        }

        public string _getText()
        {
            return mCaption;
        }

        public void _setIcon(string nIcon)
        {
            mIcon = nIcon;
        }

        public string _getIcon()
        {
            return mIcon;
        }

        public void _setDockStyle(string nDockStyle)
        {
            mDockStyle = nDockStyle;
        }

        public string _getDockStyle()
        {
            return mDockStyle;
        }

        public DockPad()
        {
            mDockStyle = @"None";
            mDockFrame = null;
            mCaption = null;
            mContain = null;
            mIcon = null;
            mPadName = null;
        }

        DockFrame mDockFrame;
        string mDockStyle;
        IContain mContain;
        string mCaption;
        string mPadName;
        string mIcon;
    }
}
