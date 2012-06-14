using System.Diagnostics;

using platform.include;

namespace platform.optimal
{
    public class Processos : Process, IProcess
    {
        public void _waitForExit(int nMilliseconds)
        {
            base.WaitForExit(nMilliseconds);
        }

        public void _startRun()
        {
            this.Start();
        }
    }
}
