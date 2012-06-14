using System;
using System.IO;
using System.Threading;
using System.Diagnostics;

using platform.include;

namespace platform.optimal
{
    public class Platform : IPlatform
    {
        public __t _findHeadstream<__t>(string nUrl) where __t : IHeadstream
        {
            __t result_ = Activator.CreateInstance<__t>();
            this._readHeadstream(result_, nUrl);
            return result_;
        }

        public void _newHeadstream<__t>(__t nT, string nUrl) where __t : IHeadstream
        {
            if (!this._isUfl(nUrl))
            {
                return;
            }
            if (this._haveUfl(nUrl))
            {
                return;
            }
            this._writeHeadstream(nT, nUrl);
        }

        public __t _loadHeadstream<__t>(string nHeadstream, string nUrl) where __t : IHeadstream
        {
            if (!this._isUfl(nUrl))
            {
                return default(__t);
            }
            if (!this._haveUfl(nUrl))
            {
                return default(__t);
            }
            __t result_ = this._findInterface<__t>(nHeadstream);
            this._readHeadstream(result_, nUrl);
            return result_;
        }

        public void _loadHeadstream<__t>(__t nT, string nUrl) where __t : IHeadstream
        {
            this._readHeadstream(nT, nUrl);
        }

        public void _saveHeadstream<__t>(__t nT, string nUrl) where __t : IHeadstream
        {
            if (!this._isUfl(nUrl))
            {
                return;
            }
            if (!this._haveUfl(nUrl))
            {
                return;
            }
            this._writeHeadstream(nT, nUrl);
        }

        public void _delHeadstream(string nUrl)
        {
            if (!this._isUfl(nUrl))
            {
                return;
            }
            if (!this._haveUfl(nUrl))
            {
                return;
            }
            UrlParser urlParser_ = new UrlParser(nUrl);
            string archivePath_ = urlParser_._returnResult();
            File.Delete(archivePath_);
        }

        public void _newUdl<__t>(__t nT, string nUrl) where __t : IUdl
        {
            if (!this._isUdl(nUrl))
            {
                return;
            }
            if (this._haveUdl(nUrl))
            {
                return;
            }
            UrlParser urlParser_ = new UrlParser(nUrl);
            string dirUrl_ = urlParser_._urlDir();
            Directory.CreateDirectory(dirUrl_);

            string udlHeadstreamUrl_ = nUrl + @"*$descriptor.xml";
            UdlHeadstream udlHeadstream_ = nT._getUdlHeadstream();
            this._writeHeadstream(udlHeadstream_, udlHeadstreamUrl_);
        }

        public void _loadUdl<__t>(__t nT, string nUrl) where __t : IUdl
        {
            if (!this._isUdl(nUrl))
            {
                return;
            }
            if (!this._haveUdl(nUrl))
            {
                return;
            }
            string udlHeadstreamUrl_ = nUrl + @"*$descriptor.xml";
            UdlHeadstream udlHeadstream_ = nT._getUdlHeadstream();
            this._readHeadstream(udlHeadstream_, udlHeadstreamUrl_);

            ICulture culture_ = this._currentCulture();
            string cultureName_ = culture_._cultureName();
            string stringTableUrl_ = nUrl + "*$";
            stringTableUrl_ += cultureName_;
            stringTableUrl_ += ".stringTable.xml";
            if (!this._haveUfl(stringTableUrl_))
            {
                stringTableUrl_ = nUrl + "*$stringTable.xml";
            }
            if (this._haveUfl(stringTableUrl_))
            {
                StringTable stringTable_ = nT._getStringTable();
                this._readHeadstream(stringTable_, stringTableUrl_);
            }
        }

        public void _saveUdl<__t>(__t nT, string nUrl) where __t : IUdl
        {
            if (!this._isUdl(nUrl))
            {
                return;
            }
            if (!this._haveUdl(nUrl))
            {
                return;
            }
            string udlHeadstreamUrl_ = nUrl + @"*$descriptor.xml";
            UdlHeadstream udlHeadstream_ = nT._getUdlHeadstream();
            if (udlHeadstream_._isDirty())
            {
                this._writeHeadstream(udlHeadstream_, udlHeadstreamUrl_);
            }
        }

        public void _deleteUdl<__t>(__t nT, string nUrl) where __t : IUdl
        {
            if (!this._isUdl(nUrl))
            {
                return;
            }
            if (!this._haveUdl(nUrl))
            {
                return;
            }
            if (this._udlHaveFile<IUdl>(nT, nUrl))
            {
                return;
            }
            string udlHeadstreamUrl_ = nUrl + @"*$descriptor.xml";
            this._delHeadstream(udlHeadstreamUrl_);

            UdlHeadstream udlHeadstream_ = nT._getUdlHeadstream();
            string udlUrl_ = nUrl + @"*";
            udlUrl_ += udlHeadstream_._getFileName();
            this._delHeadstream(udlUrl_);
        }

        public __t _findStdUdl<__t>(string nUrl) where __t : IStdUdl
        {
            if (!this._isUdl(nUrl))
            {
                return default(__t);
            }
            if (!this._haveUdl(nUrl))
            {
                return default(__t);
            }
            __t result_ = Activator.CreateInstance<__t>();

            string udlHeadstreamUrl_ = nUrl + @"*$descriptor.xml";
            UdlHeadstream udlHeadstream_ = result_._getUdlHeadstream();
            this._readHeadstream(udlHeadstream_, udlHeadstreamUrl_);

            ICulture culture_ = this._currentCulture();
            string cultureName_ = culture_._cultureName();
            string stringTableUrl_ = nUrl + "*$";
            stringTableUrl_ += cultureName_;
            stringTableUrl_ += ".stringTable.xml";
            if (!this._haveUfl(stringTableUrl_))
            {
                stringTableUrl_ = nUrl + "*$stringTable.xml";
            }
            if (this._haveUfl(stringTableUrl_))
            {
                StringTable stringTable_ = result_._getStringTable();
                this._readHeadstream(stringTable_, stringTableUrl_);
            }

            string udlUrl_ = nUrl + @"*";
            udlUrl_ += udlHeadstream_._getFileName();
            this._readHeadstream(result_, udlUrl_);

            return result_;
        }

        public void _newStdUdl<__t>(__t nT, string nUrl) where __t : IStdUdl
        {
            if (!this._isUdl(nUrl))
            {
                return;
            }
            if (this._haveUdl(nUrl))
            {
                return;
            }
            UrlParser urlParser_ = new UrlParser(nUrl);
            string dirUrl_ = urlParser_._urlDir();
            Directory.CreateDirectory(dirUrl_);

            string udlHeadstreamUrl_ = nUrl + @"*$descriptor.xml";
            UdlHeadstream udlHeadstream_ = nT._getUdlHeadstream();
            this._writeHeadstream(udlHeadstream_, udlHeadstreamUrl_);

            string udlUrl_ = nUrl + @"*";
            udlUrl_ += udlHeadstream_._getFileName();
            this._writeHeadstream(nT, udlUrl_);
        }

        public __t _loadStdUdl<__t>(string nStdUdl, string nUrl) where __t : IStdUdl
        {
            if (!this._isUdl(nUrl))
            {
                return default(__t);
            }
            if (!this._haveUdl(nUrl))
            {
                return default(__t);
            }
            __t result_ = this._findInterface<__t>(nStdUdl);

            string udlHeadstreamUrl_ = nUrl + @"*$descriptor.xml";
            UdlHeadstream udlHeadstream_ = result_._getUdlHeadstream();
            this._readHeadstream(udlHeadstream_, udlHeadstreamUrl_);

            ICulture culture_ = this._currentCulture();
            string cultureName_ = culture_._cultureName();
            string stringTableUrl_ = nUrl + "*$";
            stringTableUrl_ += cultureName_;
            stringTableUrl_ += ".stringTable.xml";
            if (!this._haveUfl(stringTableUrl_))
            {
                stringTableUrl_ = nUrl + "*$stringTable.xml";
            }
            if (this._haveUfl(stringTableUrl_))
            {
                StringTable stringTable_ = result_._getStringTable();
                this._readHeadstream(stringTable_, stringTableUrl_);
            }

            string udlUrl_ = nUrl + @"*";
            udlUrl_ += udlHeadstream_._getFileName();
            this._readHeadstream(result_, udlUrl_);

            return result_;
        }

        public void _loadStdUdl<__t>(__t nT, string nUrl) where __t : IStdUdl
        {
            if (!this._isUdl(nUrl))
            {
                return;
            }
            if (!this._haveUdl(nUrl))
            {
                return;
            }
            string udlHeadstreamUrl_ = nUrl + @"*$descriptor.xml";
            UdlHeadstream udlHeadstream_ = nT._getUdlHeadstream();
            this._readHeadstream(udlHeadstream_, udlHeadstreamUrl_);

            ICulture culture_ = this._currentCulture();
            string cultureName_ = culture_._cultureName();
            string stringTableUrl_ = nUrl + "*$";
            stringTableUrl_ += cultureName_;
            stringTableUrl_ += ".stringTable.xml";
            if (!this._haveUfl(stringTableUrl_))
            {
                stringTableUrl_ = nUrl + "*$stringTable.xml";
            }
            if (this._haveUfl(stringTableUrl_))
            {
                StringTable stringTable_ = nT._getStringTable();
                this._readHeadstream(stringTable_, stringTableUrl_);
            }

            string udlUrl_ = nUrl + @"*";
            udlUrl_ += udlHeadstream_._getFileName();
            this._readHeadstream(nT, udlUrl_);
        }

        public void _saveStdUdl<__t>(__t nT, string nUrl) where __t : IStdUdl
        {
            if (!this._isUdl(nUrl))
            {
                return;
            }
            if (!this._haveUdl(nUrl))
            {
                return;
            }
            string udlHeadstreamUrl_ = nUrl + @"*$descriptor.xml";
            UdlHeadstream udlHeadstream_ = nT._getUdlHeadstream();
            if (udlHeadstream_._isDirty())
            {
                this._writeHeadstream(udlHeadstream_, udlHeadstreamUrl_);
                udlHeadstream_._runSave();
            }

            string udlUrl_ = nUrl + @"*";
            udlUrl_ += udlHeadstream_._getFileName();
            if (nT._isDirty())
            {
                this._writeHeadstream(nT, udlUrl_);
            }
        }

        public void _deleteStdUdl<__t>(__t nT, string nUrl) where __t : IStdUdl
        {
            if (!this._isUdl(nUrl))
            {
                return;
            }
            if (!this._haveUdl(nUrl))
            {
                return;
            }
            if (this._udlHaveFile<IStdUdl>(nT, nUrl))
            {
                return;
            }
            string udlHeadstreamUrl_ = nUrl + @"*$descriptor.xml";
            this._delHeadstream(udlHeadstreamUrl_);

            UdlHeadstream udlHeadstream_ = nT._getUdlHeadstream();
            string udlUrl_ = nUrl + @"*";
            udlUrl_ += udlHeadstream_._getFileName();
            this._delHeadstream(udlUrl_);
        }

        bool _isUfl(string nUrl)
        {
            UrlParser urlParser_ = new UrlParser(nUrl);
            if (!urlParser_._isFile())
            {
                return false;
            }
            return true;
        }

        bool _haveUfl(string nUrl)
        {
            UrlParser urlParser_ = new UrlParser(nUrl);
            string archivePath_ = urlParser_._returnResult();
            if (File.Exists(archivePath_))
            {
                return true;
            }
            return false;
        }

        void _readHeadstream<__t>(__t nT, string nUrl) where __t : IHeadstream
        {
            SerializeType_ serializeType_ = nT._serializeType();
            ISerialize serialize_ = this._getReader(serializeType_);
            if (null == serialize_)
            {
                return;
            }
            serialize_._openUrl(nUrl);
            serialize_._selectStream(nT._streamName());
            nT._headSerialize(serialize_);
            serialize_._runClose();
        }

        void _writeHeadstream<__t>(__t nT, string nUrl) where __t : IHeadstream
        {
            SerializeType_ serializeType_ = nT._serializeType();
            ISerialize serialize_ = this._getWriter(serializeType_);
            if (null == serialize_)
            {
                return;
            }
            serialize_._openUrl(nUrl);
            serialize_._selectStream(nT._streamName());
            nT._headSerialize(serialize_);
            serialize_._runClose();
        }

        bool _isUdl(string nUrl)
        {
            UrlParser urlParser_ = new UrlParser(nUrl);
            return urlParser_._isUdl();
        }

        bool _haveUdl(string nUrl)
        {
            UrlParser urlParser_ = new UrlParser(nUrl);
            string archiveDir_ = urlParser_._urlDir();
            return Directory.Exists(archiveDir_);
        }

        bool _udlHaveFile<__t>(__t nT, string nUrl) where __t : IUdl
        {
            UdlHeadstream udlHeadstream_ = nT._getUdlHeadstream();
            string fileName_ = udlHeadstream_._getFileName();
            UrlParser urlParser_ = new UrlParser(nUrl);
            string archiveDir_ = urlParser_._urlDir();
            string[] files_ = Directory.GetFiles(archiveDir_);
            if (files_.Length > 3)
            {
                return true;
            }
            foreach (string i in files_)
            {
                int pos_ = i.LastIndexOf("\\");
                string temp_ = i.Substring(pos_ + 1);
                if (temp_ != "$descriptor.xml" && temp_ != fileName_ && temp_ != "$stringTable.xml")
                {
                    return true;
                }
            }
            return false;

        }
        public __t _findContent<__t>(string nUrl)
        {
            UrlParser urlParser_ = new UrlParser(nUrl);
            string urlId_ = null;
            if (urlParser_._isFile())
            {
                string fileName_ = urlParser_._fileName();
                int pos_ = fileName_.LastIndexOf(@".");
                if (pos_ <= 0)
                {
                    urlId_ = "txt";
                }
                else
                {
                    urlId_ = fileName_.Substring(pos_ + 1);
                }
            }
            else
            {
                string udlHeadstreamUrl_ = nUrl + @"*$descriptor.xml";
                UdlHeadstream udlHeadstream_ = new UdlHeadstream();
                ISerialize serialize_ = this._getReader(SerializeType_.mXml_);
                serialize_._openUrl(udlHeadstreamUrl_);
                serialize_._selectStream(udlHeadstream_._streamName());
                udlHeadstream_._headSerialize(serialize_);
                serialize_._runClose();
                urlId_ = udlHeadstream_._getId();
            }
            BindingSingleton bindingSingleton_ = __singleton<BindingSingleton>._instance();
            __t result_ = bindingSingleton_._createContent<__t>(urlId_);
            return result_;
        }

        public string _findContentImage(string nName)
        {
            BindingSingleton bindingSingleton_ = __singleton<BindingSingleton>._instance();
            return bindingSingleton_._findImage(nName);
        }

        public void _loadBindingManager(string nUrl)
        {
            BindingManager bindingManager_ = new BindingManager();
            ISerialize serialize_ = this._getReader(SerializeType_.mXml_);
            serialize_._openUrl(nUrl);
            serialize_._selectStream(bindingManager_._streamName());
            bindingManager_._headSerialize(serialize_);
            serialize_._runClose();
            BindingSingleton bindingSingleton_ = __singleton<BindingSingleton>._instance();
            bindingSingleton_._pushBindingManager(bindingManager_);
        }

        public string[] _rootUrls()
        {
            return UrlParser._rootUrls();
        }

        public string[] _files(string nUrl)
        {
            return UrlParser._files(nUrl);
        }

        public string[] _arcs(string nUrl)
        {
            return UrlParser._arcs(nUrl);
        }

        public string[] _dirUrls(string nUrl)
        {
            return UrlParser._dirUrls(nUrl);
        }

        public string[] _fileUrls(string nUrl)
        {
            return UrlParser._fileUrls(nUrl);
        }

        public string _findUrl(string nUrl)
        {
            UrlParser urlParser_ = new UrlParser();
            return urlParser_._findUrl(nUrl);
        }

        public __t _findInterface<__t>(string nUrl)
        {
            if (null == nUrl || "" == nUrl)
            {
                return default(__t);
            }
            __t result_ = default(__t);
            UrlParser urlParser_ = new UrlParser(nUrl);
            string assemblyUrl_ = urlParser_._noClassUrl();
            string className_ = urlParser_._className();
            if (urlParser_._isFile())
            {
                AssemblyUfl assemblyUfl_ = new AssemblyUfl();
                assemblyUfl_._runLoad(assemblyUrl_);
                result_ = (__t)assemblyUfl_._findClass(className_);
            }
            else
            {
                AssemblyUdl assemblyUdl_ = new AssemblyUdl();
                assemblyUdl_._runLoad(assemblyUrl_);
                result_ = (__t)assemblyUdl_._findClass(className_);
            }
            return result_;
        }

        public object _findIcon(string nUrl)
        {
            if (null == nUrl || "" == nUrl)
            {
                return null;
            }
            object result_ = default(object);
            UrlParser urlParser_ = new UrlParser(nUrl);
            if (urlParser_._isFile())
            {
                IconUfl iconUfl_ = new IconUfl();
                iconUfl_._runLoad(nUrl);
                result_ = iconUfl_._getImage();
            }
            return result_;
        }

        public object _findPng(string nUrl)
        {
            if (null == nUrl || "" == nUrl)
            {
                return null;
            }
            object result_ = default(object);
            UrlParser urlParser_ = new UrlParser(nUrl);
            if (urlParser_._isFile())
            {
                PngUfl pngUfl_ = new PngUfl();
                pngUfl_._runLoad(nUrl);
                result_ = pngUfl_._getImage();
            }
            return result_;
        }

        public ICulture _currentCulture()
        {
            Culture culture_ = new Culture();
            return culture_;
        }

        public void _sleep(int nSecond)
        {
            try
            {
                Thread.Sleep(nSecond);
            }
            catch (ThreadInterruptedException)
            {
            }
            finally
            {
            }
        }

        public IThread _createThread()
        {
            Threados result_ = new Threados();
            return result_;
        }

        public IProcess _createProcess(string nCommand, string nArguments)
        {
            ProcessStartInfo startInfo_ = null;
            if (String.IsNullOrEmpty(nArguments))
            {
                startInfo_ = new ProcessStartInfo(nCommand);
            }
            else
            {
                startInfo_ = new ProcessStartInfo(nCommand, nArguments);
            }
            startInfo_.CreateNoWindow = false;
            startInfo_.UseShellExecute = false;
            startInfo_.RedirectStandardOutput = true;
            startInfo_.RedirectStandardError = true;
            startInfo_.RedirectStandardInput = false;
            Processos result_ = new Processos();
            result_.StartInfo = startInfo_;
            return result_;
        }

        public ISerialize _getReader(SerializeType_ nSerializeType)
        {
            if (nSerializeType == SerializeType_.mXml_)
            {
                return new XmlISerialize();
            }
            else if (nSerializeType == SerializeType_.mBin_)
            {
                return new BinISerialize();
            }
            else if (nSerializeType == SerializeType_.mTxt_)
            {
                return new TextISerialize();
            }
            else
            {
                return null;
            }
        }

        public ISerialize _getWriter(SerializeType_ nSerializeType)
        {
            if (nSerializeType == SerializeType_.mXml_)
            {
                return new XmlOSerialize();
            }
            else if (nSerializeType == SerializeType_.mBin_)
            {
                return new BinOSerialize();
            }
            else if (nSerializeType == SerializeType_.mTxt_)
            {
                return new TextOSerialize();
            }
            else
            {
                return null;
            }
        }
    }
}
