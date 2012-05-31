using System.Windows.Forms;
using System.Collections.Generic;

using window.include;
using platform.include;

namespace window.optimal
{
    public class MenuStrip : Widget
    {
        public override void _serialize(ISerialize nSerialize)
        {
            nSerialize._serialize(ref mDockStyle, @"dockStyle");
            nSerialize._serialize(ref mMenuItems, @"menuItems");
            base._serialize(nSerialize);
        }

        public override string _virstream()
        {
            return @"menuStrip";
        }

        public override void _runInit()
        {
            foreach (MenuItem i in mMenuItems)
            {
                i._setContain(mContain);
                i._runInit();
            }
            base._runInit();
        }

        public override void _initControl()
        {
            if (null == mMenuStrip || mMenuStrip.IsDisposed)
            {
                mMenuStrip = new System.Windows.Forms.MenuStrip();
                if (string.Compare(mDockStyle, @"Top") == 0)
                {
                    mMenuStrip.Dock = DockStyle.Top;
                }
                else if (string.Compare(mDockStyle, @"Bottom") == 0)
                {
                    mMenuStrip.Dock = DockStyle.Bottom;
                }
                else if (string.Compare(mDockStyle, @"Fill") == 0)
                {
                    mMenuStrip.Dock = DockStyle.Fill;
                }
                else if (string.Compare(mDockStyle, @"Left") == 0)
                {
                    mMenuStrip.Dock = DockStyle.Left;
                }
                else if (string.Compare(mDockStyle, @"Right") == 0)
                {
                    mMenuStrip.Dock = DockStyle.Right;
                }
                else
                {
                    mMenuStrip.Dock = DockStyle.None;
                }
                foreach (MenuItem i in mMenuItems)
                {
                    i._initControl();
                }
                foreach (MenuItem i in mMenuItems)
                {
                    ToolStripMenuItem toolStripMenuItem_ = i._getToolStripMenuItem();
                    mMenuStrip.Items.Add(toolStripMenuItem_);
                }
            }
        }

        public override IWidget _createControl()
        {
            return new MenuStrip();
        }

        public override object _getControl()
        {
            return mMenuStrip;
        }

        public override void _setContain(IContain nContain)
        {
            mContain = nContain;
        }

        public void _setDockStyle(string nDockStyle)
        {
            mDockStyle = nDockStyle;
        }

        public string _getDockStyle()
        {
            return mDockStyle;
        }

        public MenuStrip()
        {
            mMenuItems = new List<MenuItem>();
            mDockStyle = @"None";
            mMenuStrip = null;
            mContain = null;
        }

        System.Windows.Forms.MenuStrip mMenuStrip;
        List<MenuItem> mMenuItems;
        string mDockStyle;
        IContain mContain;
    }
}
