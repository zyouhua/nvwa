namespace platform.include
{
    public interface IDirty
    {
        void _runDirty();

        bool _isDirty();

        void _runSave();
    }
}
