using platform.include;

namespace window.include
{
    public interface IDockPanel : IControl
    {
        IDockPad _getDockPad(string nPadName);

        void _showDockUrl(IDockUrl nDockUrl);

        void _showPad(string nName);

        bool _padsInHide();

        void _padsHide();

        void _padsShow();

        IDockUrl _getActiveDockUrl();
    }
}
