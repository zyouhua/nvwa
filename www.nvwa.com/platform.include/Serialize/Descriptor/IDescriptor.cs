namespace platform.include
{
    public interface IDescriptor : IStdUdl
    {
        string _getString(string nName);

        StringTable _getStringTable();
    }
}
