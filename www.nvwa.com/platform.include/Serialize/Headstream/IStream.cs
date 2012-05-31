namespace platform.include
{
    public interface IStream : IDirty
    {
        void _serialize(ISerialize nSerialize);
    }
}
