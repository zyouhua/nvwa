using window.include;
using platform.include;

namespace notepad.include
{
    public class TextDockWidget : ITextDockWidget
    {
        public void _initControl()
        {
            PlatformSingleton platformSingleton_ = __singleton<PlatformSingleton>._instance();
            string textEditUrl_ = @"uid://notepad.include.window:window.optimal.TextEdit";
            mTextEdit = platformSingleton_._findInterface<ITextEdit>(textEditUrl_);
            mTextEdit._setHighlighting(@"C#");
            mTextEdit._setDockStyle("Fill");
        }

        public ITextEdit _getTextEdit()
        {
            return mTextEdit;
        }

        public IWidget _getControl()
        {
            return mTextEdit;
        }

        public string _dockName()
        {
            return @"textEdit";
        }

        public TextDockWidget()
        {
            mTextEdit = null;
        }

        ITextEdit mTextEdit;
    }
}
