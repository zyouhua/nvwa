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

            string shapeDescriptorSingletonUrl_ = "rid://window.optimal.shapeDescriptorSingletonUrl";
            PlatformSingleton platformSingleton_ = __singleton<PlatformSingleton>._instance();
            ShapeDescriptorSingleton shapeDescriptorSingleton_ = __singleton<ShapeDescriptorSingleton>._instance();
            platformSingleton_._loadHeadstream<ShapeDescriptorSingleton>(shapeDescriptorSingleton_, shapeDescriptorSingletonUrl_);
        }
    }
}
