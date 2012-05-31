using platform.include;

namespace notepad.include
{
    public abstract class UrlDiagramAll : DiagramAll
    {
        public override void _openUrl(string nUrl)
        {
            IUrl url_ = this._getIUrl();
            url_._runLoad(nUrl);
        }

        public override void _createUrl(string nUrl, string nName)
        {
            IUrl url_ = this._getIUrl();
            url_._runCreate(nUrl, nName);
        }

        public override string _getUrl()
        {
            IUrl url_ = this._getIUrl();
            return url_._getUrl();
        }

        public abstract IUrl _getIUrl();

        public override void _runSave()
        {
            IUrl url_ = this._getIUrl();
            base._runSave();
        }

        public UrlDiagramAll()
        {
        }
    }
}
