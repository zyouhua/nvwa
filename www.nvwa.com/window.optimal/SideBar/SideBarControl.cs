using System;
using System.Drawing;
using System.Windows.Forms;
using System.Collections.Generic;

using window.include;
using platform.include;

namespace window.optimal
{
    public class SideBarControl : UserControl
    {
        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);
            if (e.Button == MouseButtons.Left)
            {
                int itemHeight_ = Font.Height + 5;
                SideTab sideTab_ = mSideBar._getTabAt(e.X, e.Y, Height, itemHeight_);
                if (null != sideTab_)
                {
                    mMouseDownTab = sideTab_;
                    sideTab_._setSideTabStatus(SideTabStatus_.mSelected_);
                    this.Refresh();
                }
            }
        }

        protected override void OnMouseWheel(MouseEventArgs e)
        {
            base.OnMouseWheel(e);
            if (mScrollBar.Visible)
            {
                mMouseWheelHandler.Scroll(mScrollBar, e);
                _scrollBarScrolled(null, null);
            }
        }

        protected override void OnMouseUp(MouseEventArgs e)
        {
            if (null != mMouseDownTab)
            {
                mSideBar._setActiveTab(mMouseDownTab);
                mMouseDownTab._setSideTabStatus(SideTabStatus_.mNormal_);
                mMouseDownTab = null;
            }
            this.Refresh();
            base.OnMouseUp(e);
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            SideTab sideTab_ = mSideBar._getActiveTab();
            if (null != sideTab_)
            {
                mScrollBar.LargeChange = mSideTabContent.Height / sideTab_._itemHeight();
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            int i = 0;
            int y_ = 0;
            int k_ = 0;
            Graphics graphics_ = e.Graphics;
            int tabHeight_ = Font.Height + 4;
            SideTab activeTab_ = mSideBar._getActiveTab();
            List<SideTab> sidetabs_ = mSideBar._sideTabs();
            for (; i < sidetabs_.Count; ++i)
            {
                SideTab sideTab_ = sidetabs_[i];
                bool visible_ = sideTab_._isVisible();
                if (!visible_)
                {
                    continue;
                }
                int yPos_ = k_ * tabHeight_;
                k_++;
                sideTab_._drawTabHeader(graphics_, Font, new Rectangle(0, yPos_, Width, tabHeight_));
                y_ = yPos_ + tabHeight_;
                if (sideTab_ == activeTab_)
                {
                    break;
                }
            }
            int h_ = 1;
            int bottom_ = Height;
            for (int j = sidetabs_.Count - 1; j > i; --j)
            {
                SideTab sidetab_ = sidetabs_[j];
                bool visible_ = sidetab_._isVisible();
                if (!visible_)
                {
                    continue;
                }
                int yPos_ = Height - h_ * tabHeight_;
                h_++;
                if (yPos_ < y_ + tabHeight_)
                    break;
                bottom_ = yPos_;
                sidetab_._drawTabHeader(graphics_, Font, new Rectangle(0, yPos_, Width, tabHeight_));
            }
            if (null != activeTab_)
            {
                bool b_ = mScrollBar.Maximum > (bottom_ - y_) / 20 || mScrollBar.Value != 0;
                mScrollBar.Visible = b_;
                mActiveTabArea = new Rectangle(0, y_, Width - (mScrollBar.Visible ? (SystemInformation.VerticalScrollBarWidth) : 0) - 4, bottom_ - y_);
                mSideTabContent.Bounds = mActiveTabArea;
                mScrollBar.Location = new Point(Width - SystemInformation.VerticalScrollBarWidth - 4, y_);
                mScrollBar.Width = SystemInformation.VerticalScrollBarWidth;
                mScrollBar.Height = mActiveTabArea.Height;
            }
            else
            {
                mScrollBar.Visible = false;
                mActiveTabArea = new Rectangle(0, y_, Width, bottom_ - y_);
                mSideTabContent.Bounds = mActiveTabArea;
            }
            base.OnPaint(e);
        }

        void _scrollBarScrolled(object sender, ScrollEventArgs e)
        {
            SideTab activeTab_ = mSideBar._getActiveTab();
            activeTab_._setScrollIndex(mScrollBar.Value);
            mSideTabContent.Refresh();
        }

        protected override void Dispose(bool disposing)
        {
            mSideBar._resetActiveTab();
            base.Dispose(disposing);
        }

        public void _reflashControl()
        {
            this.Invalidate();
            mSideTabContent.Refresh();
        }

        public SideBarControl(SideBar nSideBar)
        {
            SetStyle(ControlStyles.UserPaint, true);
            SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            SetStyle(ControlStyles.CacheText, true);
            AllowDrop = true;

            mMouseWheelHandler = new MouseWheelHandler();
            mSideTabContent = new SideTabContent(nSideBar);
            mScrollBar = new VScrollBar();
            mScrollBar.Scroll += new ScrollEventHandler(_scrollBarScrolled);
            mSideBar = nSideBar;
            mMouseDownTab = null;
            Controls.Add(mScrollBar);
            Controls.Add(mSideTabContent);
        }

        MouseWheelHandler mMouseWheelHandler;
        SideTabContent mSideTabContent;
        Rectangle mActiveTabArea;
        SideTab mMouseDownTab;
        ScrollBar mScrollBar;
        SideBar mSideBar;
    }
}
