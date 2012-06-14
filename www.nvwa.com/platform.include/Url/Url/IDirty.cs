namespace platform.include
{
    public interface IDirty
    {
        void _runDirty();

        event _GetBoolSlot m_tIsDirty;

        bool _isDirty();

        event _RunSlot m_tRunSave;

        void _runSave();
    }
}
