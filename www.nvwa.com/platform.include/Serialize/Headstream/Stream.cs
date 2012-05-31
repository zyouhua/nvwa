namespace platform.include
{
    public abstract class Stream : IStream
    {
        public abstract void _serialize(ISerialize nSerialize);

        public void _runDirty()
        {
            mDirty = true;
        }

        public virtual bool _isDirty()
        {
            return mDirty;
        }

        public virtual void _runSave()
        {
            mDirty = false;
        }

        public Stream()
        {
            mDirty = false;
        }
        bool mDirty;
    }
}
