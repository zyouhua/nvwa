using window.include;
using notepad.include;
using platform.include;

namespace notepad.implement
{
    public class Workbench : IWorkbench
    {
        public void _showGraceful(string nWindowUrl, string nFormDescriptorUrl)
        {
            WindowSingleton windowSingleton_ = __singleton<WindowSingleton>._instance();
            windowSingleton_._loadWindow(nWindowUrl);
            mForm = windowSingleton_._loadForm(nFormDescriptorUrl);
            mDockPanel = mForm._childControl("dockPanel1") as IDockPanel;
            mForm._appShow();
        }

        public void _showDockUrl(IDockUrl nDockUrl)
        {
            mDockPanel._showDockUrl(nDockUrl);
        }

        public void _showTreeNode(ITreeNode nTreeNode)
        {
            if (null == nTreeNode)
            {
                return;
            }
            IDockPad solutionPad_ = mDockPanel._getDockPad(@"solutionPad");
            ITreeView treeView_ = solutionPad_._childControl(@"treeView1") as ITreeView;
            treeView_._addTreeNode(nTreeNode);
        }

        public IDockUrl _getActiveDockUrl()
        {
            return mDockPanel._getActiveDockUrl();
        }

        public Workbench()
        {
            mDockPanel = null;
            mForm = null;
        }

        IDockPanel mDockPanel;
        IForm mForm;
    }
}
