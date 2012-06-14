using window.include;
using platform.include;

namespace notepad.include
{
    public abstract class CanvasDockWidget : Stream, ICanvasDockWidget
    {
        public void _initControl()
        {
            SideBarSingleton sideBarSingleton_ = __singleton<SideBarSingleton>._instance();
            ISideBar sideBar_ = sideBarSingleton_._getSideBar();
            PlatformSingleton platformSingleton_ = __singleton<PlatformSingleton>._instance();
            string diagramUrl_ = @"uid://notepad.include.window:window.optimal.Canvas";
            mCanvas = platformSingleton_._findInterface<ICanvas>(diagramUrl_);
            mCanvas._setObject(this);
            mCanvas._setSideBar(sideBar_);
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

        protected void _regLabel(ILabel nLabel)
        {
            mCanvas._regLabel(nLabel);
        }

        protected void _regLine(ILine nLine)
        {
            mCanvas._regLine(nLine);
        }

        public CanvasDockWidget()
        {
            mCanvas = null;
        }

        ICanvas mCanvas;
    }
}
