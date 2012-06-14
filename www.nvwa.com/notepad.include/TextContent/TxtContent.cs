namespace notepad.include
{
    public class TxtContent : TextContentDockUrl
    {
        protected override void _setUrl(string nUrl, string nName)
        {
            string url_ = nUrl.TrimEnd(new char[] { '/', '\\' });
            url_ += "*";
            url_ += nName;
            mUrl = url_;
        }

        protected override void _setUrl(string nUrl)
        {
            mUrl = nUrl;
        }

        public override string _getDockUrlName()
        {
            string result_ = null;
            if (null != mUrl)
            {
                int pos_ = mUrl.LastIndexOf("*");
                result_ = mUrl.Substring(pos_ + 1);
            }
            return result_;
        }

        public override string _getUrl()
        {
            return mUrl;
        }

        public TxtContent()
        {
            mUrl = null;
        }

        string mUrl;
    }
}
