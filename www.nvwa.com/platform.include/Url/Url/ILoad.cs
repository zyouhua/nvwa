namespace platform.include
{
    public interface ILoad
    {
        void _runLoad(string nUrl);

        event _RunSlot m_tLoadInit;

        void _loadInit();
    }
}
