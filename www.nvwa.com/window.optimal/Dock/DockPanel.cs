using System;
using System.Collections.Generic;

using window.include;
using platform.include;

namespace window.optimal
{
    public class DockPanel : Control, IDockPanel
    {
        public override void _serialize(ISerialize nSerialize)
        {
            nSerialize._serialize(ref mDockStyle, @"dockStyle");
            nSerialize._serialize(ref mDockPads, @"dockPads");
            nSerialize._serialize(ref mDBClickTabCmd, "dBClickTab");
            base._serialize(nSerialize);
        }

        public override string _virstream()
        {
            return @"dockPanel";
        }

        public override void _runInit()
        {
            if (null != mDBClickTabCmd)
            {
                PlatformSingleton platformSingleton_ = __singleton<PlatformSingleton>._instance();
                mDBClickTabCommand = platformSingleton_._findInterface<ICommand>(mDBClickTabCmd);
                if (null != mDBClickTabCommand)
                {
                    mDBClickTabCommand._setOwner(this);
                }
            }
            foreach (KeyValuePair<string, DockPad> i in mDockPads)
            {
                DockPad dockPad_ = i.Value;
                dockPad_._setContain(this);
                dockPad_._runInit();
            }
            base._runInit();
        }

        public override void _initControl()
        {
            if (null == mDockPanel || mDockPanel.IsDisposed)
            {
                mDockPanel = new WeifenLuo.WinFormsUI.Docking.DockPanel();
                mDockPanel.DocumentStyle = WeifenLuo.WinFormsUI.Docking.DocumentStyle.DockingWindow;
                mDockPanel.m_tDockTabDBClicked += this._dBClickTab;
                mDockPanel.ActiveDocumentChanged += this._activeDocumentChanged;
                if (string.Compare(mDockStyle, @"Top") == 0)
                {
                    mDockPanel.Dock = System.Windows.Forms.DockStyle.Top;
                }
                else if (string.Compare(mDockStyle, @"Bottom") == 0)
                {
                    mDockPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
                }
                else if (string.Compare(mDockStyle, @"Fill") == 0)
                {
                    mDockPanel.Dock = System.Windows.Forms.DockStyle.Fill;
                }
                else if (string.Compare(mDockStyle, @"Left") == 0)
                {
                    mDockPanel.Dock = System.Windows.Forms.DockStyle.Left;
                }
                else if (string.Compare(mDockStyle, @"Right") == 0)
                {
                    mDockPanel.Dock = System.Windows.Forms.DockStyle.Right;
                }
                else
                {
                    mDockPanel.Dock = System.Windows.Forms.DockStyle.None;
                }
            }
            base._initControl();
        }

        public override IWidget _createControl()
        {
            return new DockPanel();
        }

        public override object _getControl()
        {
            return mDockPanel;
        }

        public override void _addControl(object nControl)
        {
            System.Windows.Forms.Control control_ = nControl as System.Windows.Forms.Control;
            mDockPanel.Controls.Add(control_);
        }

        public IDockPad _getDockPad(string nPadName)
        {
            if (mDockPads.ContainsKey(nPadName))
            {
                return mDockPads[nPadName];
            }
            return null;
        }

        public void _showDockUrl(IDockUrl nDockUrl)
        {
            DockContent dockContent_ = nDockUrl._getDockContent() as DockContent;
            if (null == dockContent_)
            {
                dockContent_ = new DockContent();
                dockContent_._setDockUrl(nDockUrl);
                nDockUrl._setDockContent(dockContent_);
            }
            dockContent_._initControl();
            DockFrame dockFrame_ = dockContent_._getDockFrame();
            dockFrame_.Show(mDockPanel);
        }

        public void _showPad(string nName)
        {
            if (mDockPads.ContainsKey(nName))
            {
                DockPad dockPad_ = mDockPads[nName];
                dockPad_._initControl();
                DockFrame dockFrame_ = dockPad_._getDockFrame();
                dockFrame_.Show(mDockPanel);
            }
        }

        public bool _padsInHide()
        {
            if (null == mDockPanel || mDockPanel.IsDisposed)
            {
                return true;
            }
            foreach (KeyValuePair<string, DockPad> i in mDockPads)
            {
                DockPad dockPad_ = i.Value;
                DockFrame dockFrame_ = dockPad_._getDockFrame();
                if (null == dockFrame_ || dockFrame_.IsDisposed)
                {
                    continue;
                }
                int dockState_ = (int)dockFrame_.DockState;
                if (dockState_ < 2 || dockState_ > 5 || dockState_ == 11)
                {
                    return false;
                }
            }
            return true;
        }

        public void _padsHide()
        {
            foreach (KeyValuePair<string, DockPad> i in mDockPads)
            {
                DockPad dockPad_ = i.Value;
                DockFrame dockFrame_ = dockPad_._getDockFrame();
                if (null == dockFrame_ || dockFrame_.IsDisposed)
                {
                    continue;
                }
                int dockState_ = (int)dockFrame_.DockState;
                if (dockState_ == 11)
                {
                    continue;
                }
                if (dockState_ < 2 || dockState_ == 6)
                {
                    dockState_ = 11;
                }
                if (dockState_ > 6 && dockState_ < 11)
                {
                    dockState_ -= 5;
                }
                dockFrame_.DockState = (WeifenLuo.WinFormsUI.Docking.DockState)dockState_;
            }
        }

        public void _padsShow()
        {
            foreach (KeyValuePair<string, DockPad> i in mDockPads)
            {
                DockPad dockPad_ = i.Value;
                dockPad_._initControl();
                DockFrame dockFrame_ = dockPad_._getDockFrame();
                dockFrame_.Show(mDockPanel);
            }
        }

        public IDockUrl _getActiveDockUrl()
        {
            return mActiveDockUrl;
        }

        public void _setDockStyle(string nDockStyle)
        {
            mDockStyle = nDockStyle;
        }

        public string _getDockStyle()
        {
            return mDockStyle;
        }

        void _dBClickTab(object obj, EventArgs e)
        {
            if (null != mDBClickTabCommand)
            {
                mDBClickTabCommand._runCommand();
            }
        }

        void _activeDocumentChanged(object obj, EventArgs e)
        {
            DockFrame dockFrame_ = mDockPanel.ActiveDocument as DockFrame;
            if (null != dockFrame_ && !dockFrame_.IsDisposed)
            {
                if (null != mActiveDockUrl)
                {
                    mActiveDockUrl._runDeActive();
                }
                mActiveDockUrl = dockFrame_._getDockUrl();
                if (null != mActiveDockUrl)
                {
                    mActiveDockUrl._runActive();
                }
            }
            else
            {
                mActiveDockUrl = null;
            }
            UpdateSingleton updateSingleton_ = __singleton<UpdateSingleton>._instance();
            updateSingleton_._runUpdate();
        }

        public DockPanel()
        {
            mDockPads = new Dictionary<string, DockPad>();
            mDBClickTabCommand = null;
            mDBClickTabCmd = null;
            mDockPanel = null;
            mDockStyle = @"None";
            mActiveDockUrl = null;
        }

        Dictionary<string, DockPad> mDockPads;
        WeifenLuo.WinFormsUI.Docking.DockPanel mDockPanel;
        ICommand mDBClickTabCommand;
        string mDBClickTabCmd;
        string mDockStyle;
        IDockUrl mActiveDockUrl;
    }
}
