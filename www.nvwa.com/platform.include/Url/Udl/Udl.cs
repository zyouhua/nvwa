namespace platform.include
{
    public class Udl : Url, IUdl
    {
        public override void _runCreate(string nUrl)
        {
            string url_ = this._getUrl();
            if (null != url_)
            {
                return;
            }
            PlatformSingleton platformSingleton_ = __singleton<PlatformSingleton>._instance();
            platformSingleton_._newUdl<Udl>(this, nUrl);
            base._runCreate(nUrl);
        }

        public override void _runCreate(string nUrl, string nName)
        {
            string url_ = nUrl.TrimEnd(new char[] { '/', '\\' });
            url_ += "\\";
            url_ += nName;
            this._runCreate(nUrl);
        }

        public override void _runLoad(string nUrl)
        {
            string url_ = this._getUrl();
            if (null != url_)
            {
                return;
            }
            PlatformSingleton platformSingleton_ = __singleton<PlatformSingleton>._instance();
            platformSingleton_._loadUdl<Udl>(this, nUrl);
            base._runLoad(nUrl);
        }

        public override void _runSave(string nUrl)
        {
            string url_ = this._getUrl();
            if (null == url_)
            {
                this._runCreate(nUrl);
                return;
            }
            PlatformSingleton platformSingleton_ = __singleton<PlatformSingleton>._instance();
            platformSingleton_._saveAsUdl<Udl>(this, nUrl);
            base._runSave(nUrl);
        }

        public override void _runSave()
        {
            string url_ = this._getUrl();
            if (null == url_)
            {
                return;
            }
            PlatformSingleton platformSingleton_ = __singleton<PlatformSingleton>._instance();
            string udlUrl_ = this._getUrl();
            platformSingleton_._saveUdl<Udl>(this, udlUrl_);
            base._runSave();
        }

        public override void _runDelete()
        {
            string url_ = this._getUrl();
            if (null == url_)
            {
                return;
            }
            PlatformSingleton platformSingleton_ = __singleton<PlatformSingleton>._instance();
            string udlUrl_ = this._getUrl();
            platformSingleton_._deleteUdl<Udl>(this, udlUrl_);
            base._runDelete();
        }

        public UdlHeadstream _getUdlHeadstream()
        {
            return mUdlHeadstream;
        }

        public Udl()
        {
            mUdlHeadstream = new UdlHeadstream();
        }

        UdlHeadstream mUdlHeadstream;
    }
}
