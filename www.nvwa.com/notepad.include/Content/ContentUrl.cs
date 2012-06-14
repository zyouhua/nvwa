using platform.include;

namespace notepad.include
{
    public abstract class ContentUrl : Content
    {
        public override void _openUrl(string nUrl)
        {
            mUrl._runLoad(nUrl);
        }

        public override void _createUrl(string nUrl, string nName)
        {
            mUrl._runCreate(nUrl, nName);
        }

        public override string _getUrl()
        {
            return mUrl._getUrl();
        }

        public abstract IUrl _createUrl();

        public ContentUrl()
        {
            mUrl = this._createUrl();
        }

        IUrl mUrl;
    }
}
