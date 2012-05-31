using platform.include;

namespace window.include
{
    public interface IWidget : IVirstream
    {
        string _controlName();

        void _runInit();

        void _initControl();

        IWidget _createControl();

        object _getControl();

        bool _isContain();

        void _setContain(IContain nContain);
    }
}
