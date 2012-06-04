namespace platform.include
{
    public interface IPlatform
    {
        string[] _rootUrls();

        string[] _files(string nUrl);

        string[] _arcs(string nUrl);

        string[] _dirUrls(string nUrl);

        string[] _fileUrls(string nUrl);

        void _newHeadstream<__t>(__t nT, string nUrl) where __t : IHeadstream;

        __t _findHeadstream<__t>(string nUrl) where __t : IHeadstream;

        void _loadHeadstream<__t>(__t nT, string nUrl) where __t : IHeadstream;

        __t _loadHeadstream<__t>(string nHeadstream, string nUrl) where __t : IHeadstream;

        void _saveHeadstream<__t>(__t nT, string nUrl) where __t : IHeadstream;

        void _saveAsHeadstream<__t>(__t nT, string nUrl) where __t : IHeadstream;

        void _deleteHeadstream(string nUrl);

        void _newStdUdl<__t>(__t nT, string nUrl) where __t : IStdUdl;

        void _loadStdUdl<__t>(__t nT, string nUrl) where __t : IStdUdl;

        void _saveStdUdl<__t>(__t nT, string nUrl) where __t : IStdUdl;

        void _saveAsStdUdl<__t>(__t nT, string nUrl) where __t : IStdUdl;

        void _deleteStdUdl<__t>(__t nT, string nUrl) where __t : IStdUdl;

        void _newUdl<__t>(__t nT, string nUrl) where __t : IUdl;

        void _loadUdl<__t>(__t nT, string nUrl) where __t : IUdl;

        void _saveUdl<__t>(__t nT, string nUrl) where __t : IUdl;

        void _saveAsUdl<__t>(__t nT, string nUrl) where __t : IUdl;

        void _deleteUdl<__t>(__t nT, string nUrl) where __t : IUdl;

        __t _findContent<__t>(string nUrl);

        string _getContentImage(string nName);

        void _loadBindingManager(string nBindingManagerUrl);

        __t _findDescriptor<__t>(string nUrl) where __t : IDescriptor;

        __t _loadDescriptor<__t>(string nDescriptor, string nUrl) where __t : IDescriptor;

        __t _findInterface<__t>(string nUrl);

        string _findUrl(string nUrl);

        object _findIcon(string nUrl);

        object _findPng(string nUrl);

        IProcess _createProcess(string nCommand, string nArguments);

        ISerialize _getReader(SerializeType_ nSerializeType);

        ISerialize _getWriter(SerializeType_ nSerializeType);

        ICulture _currentCulture();

        void _sleep(int mSecond);

        IThread _createThread();
    }
}
