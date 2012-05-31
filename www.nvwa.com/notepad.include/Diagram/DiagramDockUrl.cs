using window.include;
using platform.include;

namespace notepad.include
{
    public abstract class DiagramDockUrl : ContentDockUrl
    {
        public override void _initDockWidgets()
        {
            SideBarSingleton sideBarSingleton_ = __singleton<SideBarSingleton>._instance();
            ISideBar sideBar_ = sideBarSingleton_._getSideBar();
            ICanvasDockWidget canvasDockWidget_ = this._getCanvasDockWidget();
            canvasDockWidget_._initControl();
            ICanvas canvas_ = canvasDockWidget_._getCanvas();
            canvas_._setObject(this);
            canvas_._setSideBar(sideBar_);
            base._regDockWidget(canvasDockWidget_);
            base._initDockWidgets();
        }

        public abstract ICanvasDockWidget _getCanvasDockWidget();

        public DiagramDockUrl()
        {
        }
    }
}
