namespace platform.include
{
    public interface IThread
    {
        void _startRun();

        void _interrupt();

        event _RunSlot m_tRunSlot;
    }
}
