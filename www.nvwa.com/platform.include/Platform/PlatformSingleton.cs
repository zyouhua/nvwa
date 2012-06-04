namespace platform.include
{
    public class PlatformSingleton : IPlatform
    {
        public string[] _rootUrls()
        {
            return mPlatform._rootUrls();
        }

        public string[] _files(string nUrl)
        {
            return mPlatform._files(nUrl);
        }

        public string[] _arcs(string nUrl)
        {
            return mPlatform._arcs(nUrl);
        }

        public string[] _dirUrls(string nUrl)
        {
            return mPlatform._dirUrls(nUrl);
        }

        public string[] _fileUrls(string nUrl)
        {
            return mPlatform._fileUrls(nUrl);
        }

        public void _newHeadstream<__t>(__t nT, string nUrl) where __t : IHeadstream
        {
            mPlatform._newHeadstream<__t>(nT, nUrl);
        }

        public __t _findHeadstream<__t>(string nUrl) where __t : IHeadstream
        {
            return mPlatform._findHeadstream<__t>(nUrl);
        }

        public __t _loadHeadstream<__t>(string nHeadstream, string nUrl) where __t : IHeadstream
        {
            return mPlatform._loadHeadstream<__t>(nHeadstream, nUrl);
        }

        public void _loadHeadstream<__t>(__t nT, string nUrl) where __t : IHeadstream
        {
            mPlatform._loadHeadstream<__t>(nT, nUrl);
        }

        public void _saveHeadstream<__t>(__t nT, string nUrl) where __t : IHeadstream
        {
            mPlatform._saveHeadstream<__t>(nT, nUrl);
        }

        public void _saveAsHeadstream<__t>(__t nT, string nUrl) where __t : IHeadstream
        {
            mPlatform._saveAsHeadstream<__t>(nT, nUrl);
        }

        public void _deleteHeadstream(string nUrl)
        {
            mPlatform._deleteHeadstream(nUrl);
        }

        public void _newStdUdl<__t>(__t nT, string nUrl) where __t : IStdUdl
        {
            mPlatform._newStdUdl<__t>(nT, nUrl);
        }

        public void _saveStdUdl<__t>(__t nT, string nUrl) where __t : IStdUdl
        {
            mPlatform._saveStdUdl<__t>(nT, nUrl);
        }

        public void _loadStdUdl<__t>(__t nT, string nUrl) where __t : IStdUdl
        {
            mPlatform._loadStdUdl<__t>(nT, nUrl);
        }

        public void _saveAsStdUdl<__t>(__t nT, string nUrl) where __t : IStdUdl
        {
            mPlatform._saveAsStdUdl<__t>(nT, nUrl);
        }

        public void _deleteStdUdl<__t>(__t nT, string nUrl) where __t : IStdUdl
        {
            mPlatform._deleteStdUdl(nT, nUrl);
        }

        public void _newUdl<__t>(__t nT, string nUrl) where __t : IUdl
        {
            mPlatform._newUdl<__t>(nT, nUrl);
        }

        public void _saveUdl<__t>(__t nT, string nUrl) where __t : IUdl
        {
            mPlatform._saveUdl<__t>(nT, nUrl);
        }

        public void _loadUdl<__t>(__t nT, string nUrl) where __t : IUdl
        {
            mPlatform._loadUdl<__t>(nT, nUrl);
        }

        public void _saveAsUdl<__t>(__t nT, string nUrl) where __t : IUdl
        {
            mPlatform._saveAsUdl<__t>(nT, nUrl);
        }

        public void _deleteUdl<__t>(__t nT, string nUrl) where __t : IUdl
        {
            mPlatform._deleteUdl(nT, nUrl);
        }

        public __t _findContent<__t>(string nUrl)
        {
            return mPlatform._findContent<__t>(nUrl);
        }

        public string _getContentImage(string nName)
        {
            return mPlatform._getContentImage(nName);
        }

        public void _loadBindingManager(string nBindingManagerUrl)
        {
            mPlatform._loadBindingManager(nBindingManagerUrl);
        }

        public __t _findDescriptor<__t>(string nUrl) where __t : IDescriptor
        {
            return mPlatform._findDescriptor<__t>(nUrl);
        }

        public __t _loadDescriptor<__t>(string nDescriptor, string nUrl) where __t : IDescriptor
        {
            return mPlatform._loadDescriptor<__t>(nDescriptor, nUrl);
        }

        public __t _findInterface<__t>(string nUrl)
        {
            return mPlatform._findInterface<__t>(nUrl);
        }

        public string _findUrl(string nUrl)
        {
            return mPlatform._findUrl(nUrl);
        }

        public object _findIcon(string nUrl)
        {
            return mPlatform._findIcon(nUrl);
        }

        public object _findPng(string nUrl)
        {
            return mPlatform._findPng(nUrl);
        }

        public ICulture _currentCulture()
        {
            return mPlatform._currentCulture();
        }

        public void _sleep(int mSecond)
        {
            mPlatform._sleep(mSecond);
        }

        public IThread _createThread()
        {
            return mPlatform._createThread();
        }

        public IProcess _createProcess(string nCommand, string nArguments)
        {
            return mPlatform._createProcess(nCommand, nArguments);
        }

        public ISerialize _getReader(SerializeType_ nSerializeType)
        {
            return mPlatform._getReader(nSerializeType);
        }

        public ISerialize _getWriter(SerializeType_ nSerializeType)
        {
            return mPlatform._getWriter(nSerializeType);
        }

        public void _setPlatform(IPlatform nPlatform)
        {
            mPlatform = nPlatform;
        }

        public PlatformSingleton()
        {
            mPlatform = null;
        }

        IPlatform mPlatform;
    }
}
