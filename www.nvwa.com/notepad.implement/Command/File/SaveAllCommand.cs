using platform.include;

namespace notepad.implement
{
    class SaveAllCommand : AbstractCommand
    {
        public override void _runCommand()
        {
            SaveSingleton saveSingleton_ = __singleton<SaveSingleton>._instance();
            saveSingleton_._runSave();
        }
    }
}
