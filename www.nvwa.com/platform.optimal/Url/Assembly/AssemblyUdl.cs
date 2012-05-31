using System;
using System.Reflection;
using System.Collections.Generic;

using platform.include;

namespace platform.optimal
{
    public class AssemblyUdl : Udl
    {
        public override void _runLoad(string nUrl)
        {
            base._runLoad(nUrl);
            string assemblyInfoUrl_ = nUrl + @"*$assembly.xml";
            mAssemblyInfo._runLoad(assemblyInfoUrl_);
            UdlHeadstream udlHeadstream_ = this._getUdlHeadstream();
            string fileName_ = udlHeadstream_._getFileName();
            UrlParser urlParser_ = new UrlParser(nUrl);
            string assemblyPath_ = urlParser_._urlFile(fileName_);
            AssemblyName assemblyName_ = AssemblyName.GetAssemblyName(assemblyPath_);
            AppDomain appDomain_ = AppDomain.CurrentDomain;
            Assembly[] assemblies_ = appDomain_.GetAssemblies();
            foreach (Assembly i in assemblies_)
            {
                if (string.Compare(i.FullName, assemblyName_.FullName) == 0)
                {
                    mAssembly = i;
                    return;
                }
            }
            UidSingleton uidSingleton_ = __singleton<UidSingleton>._instance();
            IEnumerable<Uid> uids_ = mAssemblyDescriptor._getUids();
            foreach (Uid i in uids_)
            {
                uidSingleton_._addUid(i);
                Uid uid_ = i._getUid();
                string uidUrl_ = uid_._getOptimal();
                this._loadAssembly(uidUrl_);
            }
            IEnumerable<Rid> rids_ = mAssemblyDescriptor._getRids();
            foreach (Rid i in rids_)
            {
                uidSingleton_._addRid(i);
            }
            IEnumerable<string> dependences_ = mAssemblyDescriptor._getDependences();
            foreach (string i in dependences_)
            {
                this._loadAssembly(i);
            }
            mAssembly = Assembly.LoadFrom(assemblyPath_);
        }

        public object _findClass(string nId)
        {
            object result_ = mAssembly.CreateInstance(nId);
            return result_;
        }

        void _loadAssembly(string nUrl)
        {
            UrlParser urlParser_ = new UrlParser(nUrl);
            if (urlParser_._isFile())
            {
                AssemblyUfl assemblyUfl_ = new AssemblyUfl();
                assemblyUfl_._runLoad(nUrl);
            }
            else
            {
                AssemblyUdl assemblyUdl_ = new AssemblyUdl();
                assemblyUdl_._runLoad(nUrl);
            }
        }

        public AssemblyUdl()
        {
            mAssemblyDescriptor = new AssemblyDescriptor();
            mAssemblyInfo = new StdUfl();
            mAssemblyInfo.m_tSerializeTypeSlot += mAssemblyDescriptor._serializeType;
            mAssemblyInfo.m_tStreamNameSlot += mAssemblyDescriptor._streamName;
            mAssemblyInfo.m_tHeadSerializeSlot += mAssemblyDescriptor._headSerialize;
            mAssembly = null;
        }

        AssemblyDescriptor mAssemblyDescriptor;
        StdUfl mAssemblyInfo;
        Assembly mAssembly;
    }
}
