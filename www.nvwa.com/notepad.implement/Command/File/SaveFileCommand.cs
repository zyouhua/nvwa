using window.include;
using notepad.include;
using platform.include;

namespace notepad.implement
{
    public class SaveFileCommand : AbstractCommand
    {
        public override void _runCommand()
        {
            WorkbenchSingleton workbenchSingleton_ = __singleton<WorkbenchSingleton>._instance();
            IDockUrl dockUrl_ = workbenchSingleton_._getActiveDockUrl();
            if (null == dockUrl_)
            {
                return;
            }
            if (dockUrl_._isDirty())
            {
                dockUrl_._runSave();
            }
        }
    }
}
