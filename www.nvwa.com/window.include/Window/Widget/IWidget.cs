using platform.include;

namespace window.include
{
    public interface IWidget : IVirstream
    {
        void _runInit();

        void _initControl();

        string _controlName();

        IWidget _createControl();

        object _getControl();

        bool _isContain();

        void _setContain(IContain nContain);
    }
}
