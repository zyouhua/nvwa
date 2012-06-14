namespace platform.include
{
    public interface IPlatform
    {
        __t _findHeadstream<__t>(string nUrl) where __t : IHeadstream;
        
        void _newHeadstream<__t>(__t nT, string nUrl) where __t : IHeadstream;
        
        __t _loadHeadstream<__t>(string nHeadstream, string nUrl) where __t : IHeadstream;
        
        void _loadHeadstream<__t>(__t nT, string nUrl) where __t : IHeadstream;
        
        void _saveHeadstream<__t>(__t nT, string nUrl) where __t : IHeadstream;
        
        void _delHeadstream(string nUrl);
        
        void _newUdl<__t>(__t nT, string nUrl) where __t : IUdl;
        
        void _loadUdl<__t>(__t nT, string nUrl) where __t : IUdl;
        
        void _saveUdl<__t>(__t nT, string nUrl) where __t : IUdl;
        
        void _deleteUdl<__t>(__t nT, string nUrl) where __t : IUdl;
        
        __t _findStdUdl<__t>(string nUrl) where __t : IStdUdl;
        
        void _newStdUdl<__t>(__t nT, string nUrl) where __t : IStdUdl;
        
        __t _loadStdUdl<__t>(string nStdUdl, string nUrl) where __t : IStdUdl;
        
        void _loadStdUdl<__t>(__t nT, string nUrl) where __t : IStdUdl;
        
        void _saveStdUdl<__t>(__t nT, string nUrl) where __t : IStdUdl;
        
        void _deleteStdUdl<__t>(__t nT, string nUrl) where __t : IStdUdl;

        __t _findContent<__t>(string nUrl);

        string _findContentImage(string nName);

        void _loadBindingManager(string nUrl);
        
        string[] _rootUrls();
        
        string[] _files(string nUrl);
        
        string[] _arcs(string nUrl);
        
        string[] _dirUrls(string nUrl);
        
        string[] _fileUrls(string nUrl);
        
        string _findUrl(string nUrl);
        
        __t _findInterface<__t>(string nUrl);
        
        object _findIcon(string nUrl);
        
        object _findPng(string nUrl);
        
        ICulture _currentCulture();
       
        void _sleep(int nSecond);

        IThread _createThread();

        IProcess _createProcess(string nCommand, string nArguments);

        ISerialize _getReader(SerializeType_ nSerializeType);
        
        ISerialize _getWriter(SerializeType_ nSerializeType);
    }
}
