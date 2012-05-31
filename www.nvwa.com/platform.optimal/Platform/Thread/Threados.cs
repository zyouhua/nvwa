using System.Threading;

using platform.include;

namespace platform.optimal
{
    public class Threados : IThread
    {
        public void _startRun()
        {
            mThread.Start();
        }

        public void _interrupt()
        {
            mThread.Interrupt();
        }

        void _runRunnable()
        {
            if (null != m_tRunSlot)
            {
                this.m_tRunSlot();
            }
        }

        public Threados()
        {
            mThread = new Thread(new ThreadStart(_runRunnable));
        }

        public event _RunSlot m_tRunSlot;
        Thread mThread;
    }
}
