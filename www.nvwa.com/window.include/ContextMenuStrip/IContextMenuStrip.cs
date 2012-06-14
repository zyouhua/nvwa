using platform.include;

namespace window.include
{
    public interface IContextMenuStrip : IHeadstream
    {
        void _runInit();

        void _initControl();

        void _setTag(object nTag);

        void _runShow(int nX, int nY);
    }
}
