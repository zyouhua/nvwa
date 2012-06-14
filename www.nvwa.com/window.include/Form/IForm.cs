using platform.include;

namespace window.include
{
    public interface IForm : IContain, IHeadstream
    {
        void _setTag(object nTag);

        object _getTag();

        void _appShow();

        void _runShow();

        void _showDialog();

        void _runClose();
    }
}
