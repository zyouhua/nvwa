using platform.include;

namespace window.include
{
    public class WindowSingleton : IWindow
    {
        public void _regShapeDescriptor(string nShapeDescriptorUrl)
        {
            mWindow._regShapeDescriptor(nShapeDescriptorUrl);
        }

        public IForm _loadForm(string nFormDescriptorUrl)
        {
            return mWindow._loadForm(nFormDescriptorUrl);
        }

        public IWidget _getControl(string nControl)
        {
            return mWindow._getControl(nControl);
        }

        public void _loadWindow(string nWindowUrl)
        {
            PlatformSingleton platformSingleton_ = __singleton<PlatformSingleton>._instance();
            mWindow = platformSingleton_._findInterface<IWindow>(nWindowUrl);
        }

        public WindowSingleton()
        {
            mWindow = null;
        }

        IWindow mWindow;
    }
}
