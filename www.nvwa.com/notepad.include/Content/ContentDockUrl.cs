using System.Collections.Generic;

using window.include;
using platform.include;

namespace notepad.include
{
    public abstract class ContentDockUrl : Content, IDockUrl
    {
        public event _SetStringSlot m_tDockUrlNameChange;

        public virtual void _setDockUrlName(string nDockUrlName)
        {
            if (null != m_tDockUrlNameChange)
            {
                this.m_tDockUrlNameChange(nDockUrlName);
            }
        }

        public abstract string _getDockUrlName();

        public virtual void _runSave(string nUrl)
        {

        }

        public void _setDockContent(IDockContent nDockContent)
        {
            mDockContent = nDockContent;
        }

        public IDockContent _getDockContent()
        {
            return mDockContent;
        }

        public override void _runInit()
        {
            this._initDockWidgets();
            base._runInit();
        }

        public virtual void _initDockWidgets()
        {
        }

        public virtual void _runActive()
        {
            WorkbenchSingleton workbenchSingleton_ = __singleton<WorkbenchSingleton>._instance();
            workbenchSingleton_._setActiveDockUrl(this);
        }

        public virtual void _runDeActive()
        {
        }

        public event _GetWidgetSlot m_tActiveWidget;

        public IWidget _getActiveWidget()
        {
            if (null != m_tActiveWidget)
            {
                return this.m_tActiveWidget();
            }
            return null;
        }

        protected void _regDockWidget(IDockWidget nDockWidget)
        {
            mDockWidgets.Add(nDockWidget);
        }

        public List<IDockWidget> _getControl()
        {
            return mDockWidgets;
        }

        public ContentDockUrl()
        {
            mDockWidgets = new List<IDockWidget>();
            m_tActiveWidget = null;
            mDockContent = null;
        }

        List<IDockWidget> mDockWidgets;
        IDockContent mDockContent;
    }
}
