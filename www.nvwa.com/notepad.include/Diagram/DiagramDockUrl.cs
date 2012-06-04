using window.include;
using platform.include;

namespace notepad.include
{
    public abstract class DiagramDockUrl : ContentDockUrl
    {
        public override void _initDockWidgets()
        {
            ICanvasDockWidget canvasDockWidget_ = this._getCanvasDockWidget();
            canvasDockWidget_._initControl();
            base._regDockWidget(canvasDockWidget_);
            base._initDockWidgets();
        }

        public abstract ICanvasDockWidget _getCanvasDockWidget();

        public DiagramDockUrl()
        {
        }
    }
}
