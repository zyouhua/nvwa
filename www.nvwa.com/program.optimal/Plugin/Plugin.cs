using window.include;
using platform.include;

namespace program.optimal
{
    public class Plugin : IPlugin
    {
        public void _startupPlugin()
        {
            string shapeDescriptorUrl_ = @"rid://program.optimal.shapeDescriptorManagerUrl";
            WindowSingleton windowSingleton_ = __singleton<WindowSingleton>._instance();
            windowSingleton_._regShapeDescriptor(shapeDescriptorUrl_);
        }
    }
}
