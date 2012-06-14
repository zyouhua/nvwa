using window.include;
using platform.include;

namespace notepad.include
{
    public abstract class TextContentDockUrl : ContentDockUrl
    {
        public override void _runInit()
        {
            SaveSingleton saveSingleton_ = __singleton<SaveSingleton>._instance();
            saveSingleton_._addSave(this);
            base._runInit();
        }

        public override void _initDockWidgets()
        {
            mTextDockWidget._initControl();
            base._regDockWidget(mTextDockWidget);
            base._initDockWidgets();
        }

        public override void _openUrl(string nUrl)
        {
            this._initDockWidgets();
            ITextEdit textEdit_ = mTextDockWidget._getTextEdit();
            textEdit_._openUrl(nUrl);
            this._setUrl(nUrl);
        }

        public override void _createUrl(string nUrl, string nName)
        {
            string url_ = nUrl.TrimEnd(new char[] { '/', '\\' });
            url_ += "*";
            url_ += nName;
            ITextEdit textEdit_ = mTextDockWidget._getTextEdit();
            textEdit_._createUrl(url_);
            this._setUrl(nUrl, nName);
        }

        protected abstract void _setUrl(string nUrl, string nName);

        protected abstract void _setUrl(string nUrl);

        public override void _runSave()
        {
            ITextEdit textEdit_ = mTextDockWidget._getTextEdit();
            textEdit_._runSave();
            base._runSave();
        }

        public TextContentDockUrl()
        {
            mTextDockWidget = new TextDockWidget();
        }

        ITextDockWidget mTextDockWidget;
    }
}
