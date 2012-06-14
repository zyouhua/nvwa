using System.Windows.Forms;

using window.include;

namespace window.optimal
{
    public class DockTabPage : TabPage
    {
        public IWidget _getWidget()
        {
            return mWidget;
        }

        public DockTabPage(IWidget nWidget)
        {
            mWidget = nWidget;
        }

        IWidget mWidget;
    }
}
