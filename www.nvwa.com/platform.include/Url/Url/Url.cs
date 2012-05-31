namespace platform.include
{
    public class Url : IUrl
    {
        public virtual void _runCreate(string nUrl)
        {
            mIsDirtied = false;
            mUrl = nUrl;
        }

        public virtual void _runCreate(string nUrl, string nName)
        {
        }

        public virtual void _runLoad(string nUrl)
        {
            this._loadInit();
            mIsDirtied = false;
            mUrl = nUrl;
        }

        public virtual void _loadInit()
        {
            SaveSingleton saveSingleton_ = __singleton<SaveSingleton>._instance();
            saveSingleton_._addSave(this);
        }

        public virtual void _runSave(string nUrl)
        {
            mIsDirtied = false;
            mUrl = nUrl;
        }

        public virtual void _runSave()
        {
            mIsDirtied = false;
        }

        public void _runDirty()
        {
            mIsDirtied = true;
        }

        public virtual bool _isDirty()
        {
            return mIsDirtied;
        }

        public virtual void _beforeDelete()
        {
        }

        public virtual void _runDelete()
        {
            mIsDirtied = false;
            mUrl = null;
        }

        public string _getUrl()
        {
            return mUrl;
        }

        public Url()
        {
            mIsDirtied = false;
            mUrl = null;
        }

        bool mIsDirtied;
        string mUrl;
    }
}
