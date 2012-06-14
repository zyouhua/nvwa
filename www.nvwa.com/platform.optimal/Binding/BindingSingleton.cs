using System.Collections.Generic;

using platform.include;

namespace platform.optimal
{
    public class BindingSingleton
    {
        public string _findImage(string nName)
        {
            PlatformSingleton platformSingleton_ = __singleton<PlatformSingleton>._instance();
            foreach (BindingManager i in mBindingManagers)
            {
                Binding binding_ = i._getBinding(nName);
                if (null != binding_)
                {
                    return binding_._getImage();
                }
            }
            return null;
        }

        public __t _createContent<__t>(string nName)
        {
            PlatformSingleton platformSingleton_ = __singleton<PlatformSingleton>._instance();
            foreach (BindingManager i in mBindingManagers)
            {
                Binding binding_ = i._getBinding(nName);
                if (null != binding_)
                {
                    Uid uid_ = binding_._getUid();
                    Uid optimalUid_ = uid_._getUid();
                    string url_ = @"uid://" + optimalUid_._getName();
                    url_ += ":";
                    url_ += binding_._getClass();
                    __t result_ = platformSingleton_._findInterface<__t>(url_);
                    return result_;
                }
            }
            return default(__t);
        }

        public void _pushBindingManager(BindingManager nBindingManager)
        {
            mBindingManagers.Add(nBindingManager);
            UidSingleton uidSingleton_ = __singleton<UidSingleton>._instance();
            IEnumerable<KeyValuePair<string, Binding>> bindings_ = nBindingManager._getBindings();
            foreach (KeyValuePair<string, Binding> i in bindings_)
            {
                Binding binding_ = i.Value;
                Uid uid_ = binding_._getUid();
                uidSingleton_._addUid(uid_);
                Uid optimalUid_ = uid_._getUid();
                string uidUrl_ = optimalUid_._getOptimal();
                UrlParser urlParser_ = new UrlParser(uidUrl_);
                if (urlParser_._isFile())
                {
                    AssemblyUfl assemblyUfl_ = new AssemblyUfl();
                    assemblyUfl_._runLoad(uidUrl_);
                }
                else
                {
                    AssemblyUdl assemblyUdl_ = new AssemblyUdl();
                    assemblyUdl_._runLoad(uidUrl_);
                }
            }
        }

        public BindingSingleton()
        {
            mBindingManagers = new List<BindingManager>();
        }

        List<BindingManager> mBindingManagers;
    }
}
