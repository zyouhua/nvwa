using window.include;
using platform.include;

namespace notepad.include
{
    public class CanvasDockWidget : ICanvasDockWidget
    {
        public ICanvas _getCanvas()
        {
            return mCanvas;
        }

        public void _initControl()
        {
            PlatformSingleton platformSingleton_ = __singleton<PlatformSingleton>._instance();
            string diagramUrl_ = @"uid://notepad.include.window:window.optimal.Canvas";
            mCanvas = platformSingleton_._findInterface<ICanvas>(diagramUrl_);
            mCanvas._setDockStyle("Fill");
        }

        public IWidget _getControl()
        {
            return mCanvas;
        }

        public string _dockName()
        {
            return @"canvas";
        }

        public CanvasDockWidget()
        {
            mCanvas = null;
        }
        ICanvas mCanvas;
    }
}
