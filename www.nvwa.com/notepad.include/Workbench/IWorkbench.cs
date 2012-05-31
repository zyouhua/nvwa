using window.include;

namespace notepad.include
{
    public interface IWorkbench
    {
        void _showGraceful(string nWindowUrl, string nFormDescriptorUrl);

        void _showDockUrl(IDockUrl nDockUrl);

        void _showTreeNode(ITreeNode nTreeNode);
    }
}
