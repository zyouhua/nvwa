namespace platform.include
{
    public class StdUdl : Url, IStdUdl
    {
        public event _SerializeSlot m_tHeadSerializeSlot;

        public virtual void _headSerialize(ISerialize nSerialize)
        {
            if (null != m_tHeadSerializeSlot)
            {
                this.m_tHeadSerializeSlot(nSerialize);
            }
        }

        public event _SerializeTypeSlot m_tSerializeTypeSlot;

        public virtual SerializeType_ _serializeType()
        {
            if (null != m_tSerializeTypeSlot)
            {
                return this.m_tSerializeTypeSlot();
            }
            return SerializeType_.mXml_;
        }

        public event _GetStringSlot m_tStreamNameSlot;

        public virtual string _streamName()
        {
            if (null != m_tStreamNameSlot)
            {
                return this.m_tStreamNameSlot();
            }
            return null;
        }

        public override void _runCreate(string nUrl)
        {
            string url_ = this._getUrl();
            if (null != url_)
            {
                throw new CreateHaveUrlException();
            }
            PlatformSingleton platformSingleton_ = __singleton<PlatformSingleton>._instance();
            platformSingleton_._newStdUdl<StdUdl>(this, nUrl);
            base._runCreate(nUrl);
        }

        public override void _runCreate(string nUrl, string nName)
        {
            string url_ = nUrl.TrimEnd(new char[] { '/', '\\' });
            url_ += "\\";
            url_ += nName;
            this._runCreate(url_);
        }

        public override void _runLoad(string nUrl)
        {
            string url_ = this._getUrl();
            if (null != url_)
            {
                throw new LoadHaveUrlException();
            }
            PlatformSingleton platformSingleton_ = __singleton<PlatformSingleton>._instance();
            platformSingleton_._loadStdUdl<StdUdl>(this, nUrl);
            base._runLoad(nUrl);
        }

        public override void _runSave()
        {
            string udlUrl_ = this._getUrl();
            if (null == udlUrl_)
            {
                return;
            }
            PlatformSingleton platformSingleton_ = __singleton<PlatformSingleton>._instance();
            platformSingleton_._saveStdUdl<StdUdl>(this, udlUrl_);
            base._runSave();
        }

        public override void _runDel()
        {
            string udlUrl_ = this._getUrl();
            if (null == udlUrl_)
            {
                return;
            }
            PlatformSingleton platformSingleton_ = __singleton<PlatformSingleton>._instance();
            platformSingleton_._deleteStdUdl<StdUdl>(this, udlUrl_);
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

        public StdUdl()
        {
            mUdlHeadstream = new UdlHeadstream();
            mStringTable = new StringTable();
        }

        UdlHeadstream mUdlHeadstream;
        StringTable mStringTable;
    }
}
