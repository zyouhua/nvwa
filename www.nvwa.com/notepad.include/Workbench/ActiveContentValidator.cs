using System;

using window.include;
using platform.include;

namespace notepad.include
{
    public class ActiveContentValidator : IValidator
    {
        public bool _validate(string nValue)
        {
            WorkbenchSingleton workbenchSingleton_ = __singleton<WorkbenchSingleton>._instance();
            IDockUrl dockUrl_ = workbenchSingleton_._getActiveDockUrl();
            if (null == dockUrl_)
            {
                return false;
            }
            Type type_ = dockUrl_.GetType();
            if (type_.FullName == nValue)
            {
                return true;
            }
            foreach (Type i in type_.GetInterfaces())
            {
                if (i.FullName == nValue)
                {
                    return true;
                }
            }
            while ((type_ = type_.BaseType) != null)
            {
                if (type_.FullName == nValue)
                    return true;
            }
            return false;
        }

        public string _getName()
        {
            return @"ActiveDockUrl";
        }
    }
}
