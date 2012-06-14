using platform.include;

namespace platform.optimal
{
    public class Launch
    {
        public void _runLaunch()
        {
            SettingSingleton settingSingleton_ = __singleton<SettingSingleton>._instance();
            settingSingleton_._runInit();
            Platform platform_ = new Platform();
            PlatformSingleton platformSingleton_ = __singleton<PlatformSingleton>._instance();
            platformSingleton_._setPlatform(platform_);
        }
    }
}
