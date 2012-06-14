namespace platform.include
{
    public class Headstream : IHeadstream
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


        public void _runDirty()
        {
            mIsDirtied = true;
        }

        public event _GetBoolSlot m_tIsDirty;

        public virtual bool _isDirty()
        {
            if (mIsDirtied)
            {
                return true;
            }
            if (null == m_tIsDirty)
            {
                return false;
            }
            return this.m_tIsDirty();
        }

        public event _RunSlot m_tRunSave;

        public virtual void _runSave()
        {
            if (null != m_tRunSave)
            {
                this.m_tRunSave();
            }
            mIsDirtied = false;
        }

        public Headstream()
        {
            m_tHeadSerializeSlot = null;
            m_tSerializeTypeSlot = null;
            m_tStreamNameSlot = null;
            m_tIsDirty = null;
            m_tRunSave = null;
            mIsDirtied = false;
        }
        bool mIsDirtied;
    }
}
