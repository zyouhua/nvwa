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

        public void _setWindow(IWindow nWindow)
        {
            mWindow = nWindow;
        }

        public WindowSingleton()
        {
            mWindow = null;
        }

        IWindow mWindow;
    }
}
