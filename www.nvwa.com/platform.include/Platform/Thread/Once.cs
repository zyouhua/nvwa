namespace platform.include
{
    public class Once
    {
        public bool _runRunnable(IRunnable nRunable)
        {
            bool result_ = false;
            lock (mLock)
            {
                if (false == mRunning)
                {
                    mRunnable = nRunable;
                    mRunning = true;
                    result_ = true;
                }
            }
            if (true == result_)
            {
                mThread._interrupt();
            }
            return result_;
        }

        void _runOnce()
        {
            PlatformSingleton platformSingleton_ = __singleton<PlatformSingleton>._instance();
            for ( ; ; )
            {
                if (null == mRunnable)
                {
                    platformSingleton_._sleep(-1);
                }
                if (null != mRunnable)
                {
                    mRunnable._runRunnable();
                }
                mRunnable = mOncePool._popFront();
            }
        }

        public Once(OncePool nOncePool)
        {
            mLock = new object();
            mRunning = false;
            mOncePool = nOncePool;
            mRunnable = null;
            PlatformSingleton platformSingleton_ = __singleton<PlatformSingleton>._instance();
            mThread = platformSingleton_._createThread();
            mThread.m_tRunSlot += _runOnce;
            mThread._startRun();
        }

        object mLock;
        bool mRunning;
        IThread mThread;
        OncePool mOncePool;
        IRunnable mRunnable;
    }
}
