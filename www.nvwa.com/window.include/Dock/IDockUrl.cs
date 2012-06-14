using System.Collections.Generic;

using platform.include;

namespace window.include
{
    public interface IDockUrl : ISave
    {
        event _SetStringSlot m_tDockUrlNameChange;

        void _setDockUrlName(string nDockUrlName);

        string _getDockUrlName();

        void _setDockContent(IDockContent nDockContent);

        IDockContent _getDockContent();

        void _initDockWidgets();

        void _runActive();

        void _runDeActive();

        event _GetWidgetSlot m_tActiveWidget;

        IWidget _getActiveWidget();

        List<IDockWidget> _getControl();
    }
}
