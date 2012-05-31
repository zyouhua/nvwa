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
                return;
            }
            PlatformSingleton platformSingleton_ = __singleton<PlatformSingleton>._instance();
            platformSingleton_._newStdUdl<StdUdl>(this, nUrl);
            base._runCreate(nUrl);
        }

        public override void _runCreate(string nUrl, string nName)
        {
            string url_ = nUrl.TrimEnd(new char[] { '/', '\\' });
            url_ += @"\";
            url_ += nName;
            mUdlHeadstream._setFileName(nName);
            this._runCreate(url_);
        }

        public override void _runLoad(string nUrl)
        {
            string url_ = this._getUrl();
            if (null != url_)
            {
                return;
            }
            PlatformSingleton platformSingleton_ = __singleton<PlatformSingleton>._instance();
            platformSingleton_._loadStdUdl<StdUdl>(this, nUrl);
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
            platformSingleton_._saveAsStdUdl<StdUdl>(this, nUrl);
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
            platformSingleton_._saveStdUdl<StdUdl>(this, udlUrl_);
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
            platformSingleton_._deleteStdUdl<StdUdl>(this, udlUrl_);
            base._runDelete();
        }

        public UdlHeadstream _getUdlHeadstream()
        {
            return mUdlHeadstream;
        }

        public StdUdl()
        {
            mUdlHeadstream = new UdlHeadstream();
            m_tHeadSerializeSlot = null;
            m_tSerializeTypeSlot = null;
            m_tStreamNameSlot = null;
        }

        UdlHeadstream mUdlHeadstream;
    }
}
