using System;
using System.Drawing;
using System.Windows.Forms;

namespace window.optimal
{
    public class SideTabContent : UserControl
    {
        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);
            SideTab sideTab_ = mSideBar._getActiveTab();
            if (e.Button == MouseButtons.Left && null != sideTab_)
            {
                sideTab_._selectToChoosed();
            }
            Refresh();
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);
            SideTab sideTab_ = mSideBar._getActiveTab();
            if (null == sideTab_) return;
            SideTabItem oldItem_ = sideTab_._getSelectedItem();
            sideTab_._setSelectedItem(null);
            SideTabItem item_ = sideTab_._getItemAt(e.X, e.Y);
            if (null != item_)
            {
                sideTab_._setSelectedItem(item_);
            }
            if (oldItem_ != sideTab_._getSelectedItem())
            {
                this.Refresh();
            }
        }

        protected override void OnMouseLeave(EventArgs e)
        {
            base.OnMouseLeave(e);
            SideTab sideTab_ = mSideBar._getActiveTab();
            if (null != sideTab_)
            {
                sideTab_._setSelectedItem(null);
            }
            Refresh();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            SideTab sideTab_ = mSideBar._getActiveTab();
            if (null != sideTab_)
            {
                sideTab_._drawTabContent(e.Graphics, Font, new Rectangle(0, 0, Width, Height));
            }
            base.OnPaint(e);
        }

        public SideTabContent(SideBar nSideBar)
        {
            SetStyle(ControlStyles.UserPaint, true);
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            SetStyle(ControlStyles.CacheText, true);
            ResizeRedraw = true;
            AllowDrop = true;
            mSideBar = nSideBar;
        }

        SideBar mSideBar;
    }
}
