using System;
using System.Drawing;
using System.Windows.Forms;
using System.Collections.Generic;

using window.include;
using platform.include;

namespace window.optimal
{
    public class SideBar : Widget, ISideBar
    {
        public override void _serialize(ISerialize nSerialize)
        {
            nSerialize._serialize(ref mSideBarUrl, @"sideBarUrl");
            nSerialize._serialize(ref mDockStyle, @"dockStyle");
            nSerialize._serialize(ref mInitCmd, @"initCommand");
            base._serialize(nSerialize);
        }

        public override string _virstream()
        {
            return @"sideBar";
        }

        public override void _runInit()
        {
            PlatformSingleton platformSingleton_ = __singleton<PlatformSingleton>._instance();
            SideBarUrl sideBarUrl_ = platformSingleton_._findHeadstream<SideBarUrl>(mSideBarUrl);
            List<string> sideTabUrls_ = sideBarUrl_._sideTabUrls();
            foreach (string i in sideTabUrls_)
            {
                SideTab sideTab_ = platformSingleton_._findHeadstream<SideTab>(i);
                sideTab_._setSideBar(this);
                mSideTabs.Add(sideTab_);
            }
            foreach (SideTab i in mSideTabs)
            {
                i._runInit();
            }
            mInitCommand = platformSingleton_._findInterface<ICommand>(mInitCmd);
            if (null != mInitCommand)
            {
                mInitCommand._setOwner(mContain);
                mInitCommand._runCommand();
            }
            base._runInit();
        }

        public override void _initControl()
        {
            if (null == mSideBarControl || mSideBarControl.IsDisposed)
            {
                mSideBarControl = new SideBarControl(this);
                if (string.Compare(mDockStyle, @"Top") == 0)
                {
                    mSideBarControl.Dock = DockStyle.Top;
                }
                else if (string.Compare(mDockStyle, @"Bottom") == 0)
                {
                    mSideBarControl.Dock = DockStyle.Bottom;
                }
                else if (string.Compare(mDockStyle, @"Fill") == 0)
                {
                    mSideBarControl.Dock = DockStyle.Fill;
                }
                else if (string.Compare(mDockStyle, @"Left") == 0)
                {
                    mSideBarControl.Dock = DockStyle.Left;
                }
                else if (string.Compare(mDockStyle, @"Right") == 0)
                {
                    mSideBarControl.Dock = DockStyle.Right;
                }
                else
                {
                    mSideBarControl.Dock = DockStyle.None;
                }
            }
        }

        public override IWidget _createControl()
        {
            return new SideBar();
        }

        public override object _getControl()
        {
            return mSideBarControl;
        }

        public override void _setContain(IContain nContain)
        {
            mContain = nContain;
            base._setContain(nContain);
        }

        public SideItem _getChooseSideItem()
        {
            if (null != mActiveTab)
            {
                return mActiveTab._getChoosedItem();
            }
            return null;
        }

        public void _resetActiveTab()
        {
            if (null == mActiveTab)
            {
                return;
            }
            mActiveTab._runReset();
            bool visible_ = mActiveTab._isVisible();
            if (!visible_)
            {
                mActiveTab = null;
            }
        }

        public void _reflashControl()
        {
            if (null != mSideBarControl)
            {
                mSideBarControl._reflashControl();
            }
        }

        public List<SideTab> _sideTabs()
        {
            return mSideTabs;
        }

        public void _setActiveTab(SideTab nSideTab)
        {
            nSideTab._runReset();
            if (null != mActiveTab)
            {
                mActiveTab._runReset();
            }
            mActiveTab = nSideTab;
        }

        public SideTab _getActiveTab()
        {
            return mActiveTab;
        }

        public SideTab _getTabAt(int nX, int nY, int nHeight, int nItemHeight)
        {
            int y_ = 0;
            int i = 0;
            int k_ = 0;
            for (; i < mSideTabs.Count; ++i)
            {
                SideTab sidetab_ = mSideTabs[i];
                bool visible_ = sidetab_._isVisible();
                if (!visible_)
                {
                    continue;
                }
                int yPos_ = k_ * nItemHeight;
                k_++;
                y_ = yPos_ + nItemHeight;
                if (nY >= yPos_ && nY < y_)
                    return sidetab_;
                if (sidetab_ == mActiveTab)
                {
                    break;
                }
            }
            int h_ = 1;
            for (int j = mSideTabs.Count - 1; j > i; --j)
            {
                SideTab sidetab_ = mSideTabs[j];
                bool visible_ = sidetab_._isVisible();
                if (!visible_)
                {
                    continue;
                }
                int yPos_ = nHeight - h_ * nItemHeight;
                h_++;
                if (yPos_ < y_)
                    break;
                if (nY >= yPos_ && nY < yPos_ + nItemHeight)
                    return sidetab_;
            }
            return null;
        }

        public SideBar()
        {
            mSideTabs = new List<SideTab>();
            mSideBarControl = null;
            mDockStyle = @"None";
            mSideBarUrl = null;
            mActiveTab = null;
            mInitCommand = null;
            mInitCmd = null;
            mContain = null;
        }

        SideBarControl mSideBarControl;
        List<SideTab> mSideTabs;
        string mSideBarUrl;
        string mDockStyle;
        SideTab mActiveTab;
        ICommand mInitCommand;
        string mInitCmd;
        IContain mContain;
    }
}
