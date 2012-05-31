using window.include;

namespace notepad.include
{
    public interface ITextDockWidget : IDockWidget
    {
        ITextEdit _getTextEdit();
    }
}
