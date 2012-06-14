namespace platform.include
{
    public class Udl : Url, IUdl
    {
        public override void _runCreate(string nUrl)
        {
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
            PlatformSingleton platformSingleton_ = __singleton<PlatformSingleton>._instance();
            platformSingleton_._loadUdl<Udl>(this, nUrl);
            base._runLoad(nUrl);
        }

        public override void _runSave()
        {
            PlatformSingleton platformSingleton_ = __singleton<PlatformSingleton>._instance();
            string udlUrl_ = this._getUrl();
            platformSingleton_._saveUdl<Udl>(this, udlUrl_);
            base._runSave();
        }

        public override void _runDel()
        {
            PlatformSingleton platformSingleton_ = __singleton<PlatformSingleton>._instance();
            string udlUrl_ = this._getUrl();
            platformSingleton_._deleteUdl<Udl>(this, udlUrl_);
            base._runDel();
            base._endDel();
        }

        public UdlHeadstream _getUdlHeadstream()
        {
            return mUdlHeadstream;
        }

        public string _getString(string nName)
        {
            return mStringTable._getString(nName);
        }

        public StringTable _getStringTable()
        {
            return mStringTable;
        }

        public Udl()
        {
            mUdlHeadstream = new UdlHeadstream();
            mStringTable = new StringTable();
        }

        UdlHeadstream mUdlHeadstream;
        StringTable mStringTable;
    }
}
