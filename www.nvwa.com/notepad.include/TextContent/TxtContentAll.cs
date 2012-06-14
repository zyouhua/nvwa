using platform.include;

namespace notepad.include
{
    public class TxtContentAll : TextContentAll
    {
        public override string _getTreeNodeName()
        {
            return mFileName;
        }

        public override string _getTreeNodeImage()
        {
            string suffix_ = "txt";
            int pos_ = mFileName.LastIndexOf(".");
            if (pos_ > 0)
            {
                suffix_ = mFileName.Substring(pos_ + 1);
            }
            PlatformSingleton platformSingleton_ = __singleton<PlatformSingleton>._instance();
            return platformSingleton_._findContentImage(suffix_);
        }

        protected override void _setUrl(string nUrl, string nName)
        {
            mFileName = nName;
            mUrl = nUrl;
        }

        protected override void _setUrl(string nUrl)
        {
            int pos_ = nUrl.LastIndexOf("*");
            if (pos_ > 0)
            {
                mFileName = nUrl.Substring(pos_ + 1);
                mUrl = nUrl.Substring(0, pos_);
            }
        }

        public override string _getDockUrlName()
        {
            return mFileName;
        }

        public override string _getUrl()
        {
            string result_ = mUrl.TrimEnd(new char[] { '/', '\\' });
            result_ += "*";
            result_ += mFileName;
            return result_;
        }

        public TxtContentAll()
        {
            mFileName = null;
            mUrl = null;
        }

        string mFileName;
        string mUrl;
    }
}
