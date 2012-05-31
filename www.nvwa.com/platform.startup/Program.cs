using System;

using platform.include;
using platform.optimal;

namespace platform.startup
{
    class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            _startLaunch();
            _startNotepad();
        }

        static void _startLaunch()
        {
            Launch launch_ = new Launch();
            launch_._runLaunch();
        }

        static string _loadNotepadUrl()
        {
            PlatformSingleton platformSingleton_ = __singleton<PlatformSingleton>._instance();
            string url_ = @"local://platform/notepadUrl.xml";
            NotepadUrl notepadUrl_ = platformSingleton_._findHeadstream<NotepadUrl>(url_);
            string result_ = notepadUrl_._getNotepadUrl();
            return result_;
        }

        static void _startNotepad()
        {
            PlatformSingleton platformSingleton_ = __singleton<PlatformSingleton>._instance();
            string notepadUrl_ = _loadNotepadUrl();
            IApp app_ = platformSingleton_._findInterface<IApp>(notepadUrl_);
            app_._runInit();
            app_._runApp();
        }
    }
}
