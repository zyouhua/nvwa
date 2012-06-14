namespace platform.include
{
    public interface IUdl : IUrl
    {
        UdlHeadstream _getUdlHeadstream();

        string _getString(string nName);

        StringTable _getStringTable();
    }
}
