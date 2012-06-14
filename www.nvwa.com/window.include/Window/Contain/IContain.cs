using platform.include;

namespace window.include
{
    public interface IContain : IStream
    {
        void _runInit();

        void _initControl();

        IWidget _childControl(string nPath);

        void _addControl(object nControl);

        IContain _contain(int nLevel = 0);
    }
}
