namespace platform.include
{
    public interface ISave : IDirty
    {
        void _runSave(string nUrl);
    }
}
