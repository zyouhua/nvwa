using window.include;
using platform.include;

namespace notepad.implement
{
    public class NewFileCommand : AbstractCommand
    {
        public override void _runCommand()
        {
            PlatformSingleton platformSingleton_ = __singleton<PlatformSingleton>._instance();
            string formUrl_ = @"uid://notepad.implement.window:window.optimal.Form";
            string newProjectUrl_ = @"rid://notepad.implement.newProjectFormUrl";
            IForm projectForm_ = platformSingleton_._loadHeadstream<IForm>(formUrl_, newProjectUrl_);
            projectForm_._runInit();
            projectForm_._showDialog();
        }
    }
}
