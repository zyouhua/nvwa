namespace platform.include
{
    public interface IProcess
    {
        void _waitForExit(int nMilliseconds);

        void _startRun();
    }
}
