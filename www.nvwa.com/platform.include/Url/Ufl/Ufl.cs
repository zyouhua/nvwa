namespace platform.include
{
    public class Ufl : Url, IUfl
    {
        public override void _runCreate(string nUrl, string nName)
        {
            string url_ = nUrl.TrimEnd(new char[] { '/', '\\' });
            url_ += "*";
            url_ += nName;
            this._runCreate(url_);
        }

        public override void _runDel()
        {
            string uflUrl_ = this._getUrl();
            if (null == uflUrl_)
            {
                return;
            }
            base._runDel();
            PlatformSingleton platformSingleton_ = __singleton<PlatformSingleton>._instance();
            platformSingleton_._delHeadstream(uflUrl_);
            base._endDel();
        }
    }
}
