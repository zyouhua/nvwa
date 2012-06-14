using window.include;
using platform.include;

namespace notepad.implement
{
    public class OpenFileCommand : AbstractCommand
    {
        public override void _runCommand()
        {
            PlatformSingleton platformSingleton_ = __singleton<PlatformSingleton>._instance();
            string formUrl_ = @"uid://notepad.implement.window:window.optimal.Form";
            string openFileDialogUrl_ = @"rid://notepad.implement.openFileDialogUrl";
            IForm openFileDialog_ = platformSingleton_._loadHeadstream<IForm>(formUrl_, openFileDialogUrl_);
            openFileDialog_._runInit();
            openFileDialog_._showDialog();
        }
    }
}
