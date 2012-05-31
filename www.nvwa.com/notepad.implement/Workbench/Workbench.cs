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
            mForm._appShow();
        }

        public void _showDockUrl(IDockUrl nDockUrl)
        {
            IDockPanel dockPanel_ = mForm._childControl("dockPanel1") as IDockPanel;
            dockPanel_._showDockUrl(nDockUrl);
        }

        public void _showTreeNode(ITreeNode nTreeNode)
        {
            if (null == nTreeNode)
            {
                return;
            }
            IDockPanel dockPanel_ = mForm._childControl("dockPanel1") as IDockPanel;
            IDockPad solutionPad_ = dockPanel_._getDockPad(@"solutionPad");
            ITreeView treeView_ = solutionPad_._childControl(@"treeView1") as ITreeView;
            treeView_._addTreeNode(nTreeNode);
        }

        public Workbench()
        {
            mForm = null;
        }

        IForm mForm;
    }
}
