using window.include;
using notepad.include;
using platform.include;

namespace notepad.implement
{
    public class NotepadApp : Headstream, IApp
    {
        public override void _headSerialize(ISerialize nSerialize)
        {
        }

        public override string _streamName()
        {
            return @"notepadApp";
        }

        public void _runInit()
        {
            string bindingManagerUrl_ = @"rid://notepad.implement.bindingManager";
            PlatformSingleton platformSingleton_ = __singleton<PlatformSingleton>._instance();
            platformSingleton_._loadBindingManager(bindingManagerUrl_);
            WorkbenchSingleton workbenchSingleton_ = __singleton<WorkbenchSingleton>._instance();
            Workbench workbench_ = new Workbench();
            workbenchSingleton_._setWorkbench(workbench_);
            workbenchSingleton_._runInit();
        }

        public void _runApp()
        {
            string windowUrl_ = @"uid://notepad.implement.window:window.optimal.Window";
            string formDescriptorUrl_ = @"rid://notepad.implement.formDescriptorUrl";
            WorkbenchSingleton workbenchSingleton_ = __singleton<WorkbenchSingleton>._instance();
            workbenchSingleton_._showGraceful(windowUrl_, formDescriptorUrl_);
        }
    }
}
