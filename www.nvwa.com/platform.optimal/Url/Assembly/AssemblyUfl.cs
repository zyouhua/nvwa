using System;
using System.Reflection;

using platform.include;

namespace platform.optimal
{
    public class AssemblyUfl : Ufl
    {
        public override void _runLoad(string nUrl)
        {
            UrlParser urlParser_ = new UrlParser(nUrl);
            string assemblyPath_ = urlParser_._returnResult();
            AssemblyName assemblyName_ = AssemblyName.GetAssemblyName(assemblyPath_);
            AppDomain appDomain_ = AppDomain.CurrentDomain;
            Assembly[] assemblies_ = appDomain_.GetAssemblies();
            foreach (Assembly i in assemblies_)
            {
                if (string.Compare(i.FullName, assemblyName_.FullName) == 0)
                {
                    mAssembly = i;
                }
            }
            if (null == mAssembly)
            {
                mAssembly = Assembly.LoadFrom(assemblyPath_);
                string namespace_ = assemblyName_.Name;
                string pluginClass_ = namespace_ + ".Plugin";
                IPlugin plugin_ = mAssembly.CreateInstance(pluginClass_) as IPlugin;
                if (null != plugin_)
                {
                    plugin_._startupPlugin();
                }
            }
            base._runLoad(nUrl);
        }

        public object _findClass(string nId)
        {
            object result_ = mAssembly.CreateInstance(nId);
            return result_;
        }

        public AssemblyUfl()
        {
            mAssembly = null;
        }

        Assembly mAssembly;
    }
}
