namespace window.include
{
    public interface ITextEdit : IWidget
    {
        void _setHighlighting(string nHighlighting);

        void _setDockStyle(string nDockStyle);

        void _openUrl(string nUrl);

        void _createUrl(string nUrl);
    }
}
