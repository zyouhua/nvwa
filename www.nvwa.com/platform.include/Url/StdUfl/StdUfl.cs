namespace platform.include
{
    public class StdUfl : Ufl, IStdUfl
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
            platformSingleton_._newHeadstream<StdUfl>(this, nUrl);
            base._runCreate(nUrl);
        }

        public override void _runLoad(string nUrl)
        {
            string url_ = this._getUrl();
            if (null != url_)
            {
                throw new LoadHaveUrlException();
            }
            PlatformSingleton platformSingleton_ = __singleton<PlatformSingleton>._instance();
            platformSingleton_._loadHeadstream<StdUfl>(this, nUrl);
            base._runLoad(nUrl);
        }

        public override void _runSave()
        {
            string uflUrl_ = this._getUrl();
            if (null == uflUrl_)
            {
                return;
            }
            PlatformSingleton platformSingleton_ = __singleton<PlatformSingleton>._instance();
            platformSingleton_._saveHeadstream<StdUfl>(this, uflUrl_);
            base._runSave();
        }

        public StdUfl()
        {
            m_tHeadSerializeSlot = null;
            m_tSerializeTypeSlot = null;
            m_tStreamNameSlot = null;
        }
    }
}
