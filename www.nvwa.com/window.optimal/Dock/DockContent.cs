using System.Windows.Forms;
using System.Collections.Generic;

using window.include;
using platform.include;

namespace window.optimal
{
    public class DockContent : IDockContent
    {
        public void _setDockUrl(IDockUrl nDockUrl)
        {
            nDockUrl.m_tActiveWidget += this._getActiveWidget;
            mDockUrl = nDockUrl;
        }

        public void _initControl()
        {
            if (null == mDockFrame || mDockFrame.IsDisposed)
            {
                mDockFrame = new DockFrame(mDockUrl);
                mDockFrame.DockAreas = WeifenLuo.WinFormsUI.Docking.DockAreas.Document;
                List<IDockWidget> dockWidgets_ = mDockUrl._getControl();
                if (dockWidgets_.Count > 1)
                {
                    TabControl tabControl_ = new TabControl();
                    tabControl_.Alignment = TabAlignment.Bottom;
                    tabControl_.Dock = DockStyle.Fill;
                    tabControl_.Selected += _dockTabPageSelected;
                    bool initWidget_ = false;
                    foreach (IDockWidget i in dockWidgets_)
                    {
                        IWidget widget_ = i._getControl();
                        widget_._initControl();
                        if (false == initWidget_)
                        {
                            mWidget = widget_;
                            initWidget_ = true;
                        }
                        DockTabPage dockTabPage_ = new DockTabPage(widget_);
                        dockTabPage_.Text = i._dockName();
                        System.Windows.Forms.Control control_ = widget_._getControl() as System.Windows.Forms.Control;
                        dockTabPage_.Controls.Add(control_);
                        tabControl_.Controls.Add(dockTabPage_);
                    }
                    mDockFrame.Controls.Add(tabControl_);
                }
                else if (dockWidgets_.Count == 1)
                {
                    IDockWidget dockWidget_ = dockWidgets_[0];
                    IWidget widget_ = dockWidget_._getControl();
                    mWidget = widget_;
                    widget_._initControl();
                    System.Windows.Forms.Control control_ = widget_._getControl() as System.Windows.Forms.Control;
                    mDockFrame.Controls.Add(control_);
                }
                else
                {
                }
            }
        }

        public DockFrame _getDockFrame()
        {
            return mDockFrame;
        }

        void _dockTabPageSelected(object sender, TabControlEventArgs e)
        {
            DockTabPage dockTabPage_ = e.TabPage as DockTabPage;
            mWidget = dockTabPage_._getWidget();
            UpdateSingleton updateSingleton_ = __singleton<UpdateSingleton>._instance();
            updateSingleton_._runUpdate();
        }

        IWidget _getActiveWidget()
        {
            return mWidget;
        }

        public DockContent()
        {
            mDockFrame = null;
            mDockUrl = null;
            mWidget = null;
        }

        DockFrame mDockFrame;
        IDockUrl mDockUrl;
        IWidget mWidget;
    }
}
