using notepad.include;
using platform.include;

namespace notepad.implement
{
    public class Plugin : IPlugin
    {
        public void _startupPlugin()
        {
            string bindingManagerUrl_ = @"rid://notepad.implement.bindingManager";
            PlatformSingleton platformSingleton_ = __singleton<PlatformSingleton>._instance();
            platformSingleton_._loadBindingManager(bindingManagerUrl_);
            WorkbenchSingleton workbenchSingleton_ = __singleton<WorkbenchSingleton>._instance();
            workbenchSingleton_._setWorkbench(new Workbench());
        }
    }
}
