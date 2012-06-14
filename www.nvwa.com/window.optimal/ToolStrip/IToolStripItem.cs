using window.include;
using platform.include;

namespace window.optimal
{
    public interface IToolStripItem : IStream, IUpdate
    {
        void _runInit();

        void _initControl();

        void _setContain(IContain nContain);

        System.Windows.Forms.ToolStripItem _getToolStripItem();
    }
}
