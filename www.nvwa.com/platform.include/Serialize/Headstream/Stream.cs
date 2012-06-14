namespace platform.include
{
    public abstract class Stream : IStream
    {
        public abstract void _serialize(ISerialize nSerialize);

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

        public Stream()
        {
            m_tIsDirty = null;
            m_tRunSave = null;
            mIsDirtied = false;
        }

        bool mIsDirtied;
    }
}
