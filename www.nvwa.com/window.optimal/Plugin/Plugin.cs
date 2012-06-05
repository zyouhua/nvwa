using System.Windows.Forms;

using window.include;
using platform.include;

namespace window.optimal
{
    public class Plugin : IPlugin
    {
        public void _startupPlugin()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            WindowSingleton windowSingleton_ = __singleton<WindowSingleton>._instance();
            windowSingleton_._setWindow(new Window());
            StyleSingleton styleSingleton_ = __singleton<StyleSingleton>._instance();
            styleSingleton_._loadDefaultStyle();
        }
    }
}
