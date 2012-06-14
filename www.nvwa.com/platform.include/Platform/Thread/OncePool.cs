using System.Collections.Generic;

namespace platform.include
{
    public class OncePool
    {
        public IRunnable _popFront()
        {
            if (false == mInit)
            {
                throw new InitException();
            }
            IRunnable result_ = null;
            lock (mLockRunnable)
            {
                if (mRunnables.Count > 0)
                {
                    result_ = mRunnables.Dequeue();
                }
            }
            return result_;
        }

        public void _pushBack(IRunnable nRunnable)
        {
            if (false == mInit)
            {
                throw new InitException();
            }
            bool status_ = false;
            foreach (Once once_ in mOnces)
            {
                status_ = once_._runRunnable(nRunnable);
                if (true == status_)
                {
                    break;
                }
            }
            if (true == status_)
            {
                return;
            }
            lock (mLockOnce)
            {
                if (mOnces.Count < mSize)
                {
                    Once once_ = new Once(this);
                    once_._runRunnable(nRunnable);
                    mOnces.Add(once_);
                    status_ = true;
                }
            }
            if (true == status_)
            {
                return;
            }
            lock (mLockRunnable)
            {
                mRunnables.Enqueue(nRunnable);
            }
        }

        public void _runInit(int nSize = 5)
        {
            mInit = true;
            mSize = nSize;
            mLockOnce = new object();
            mLockRunnable = new object();
            mOnces = new List<Once>(nSize);
            mRunnables = new Queue<IRunnable>();
        }

        public OncePool()
        {
            mInit = false;
            mSize = -1;
            mLockOnce = null;
            mLockRunnable = null;
            mOnces = null;
            mRunnables = null;
        }

        bool mInit;
        int mSize;
        object mLockOnce;
        object mLockRunnable;
        List<Once> mOnces;
        Queue<IRunnable> mRunnables;
    }
}
