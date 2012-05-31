using window.include;
using platform.include;

namespace notepad.implement
{
    public class DBClickDockTab : AbstractCommand
    {
        public override void _runCommand()
        {
            IDockPanel dockPanel_ = this._getOwner() as IDockPanel;
            IForm form_ = dockPanel_._contain() as IForm;
            IToolPanel toolPanel_ = form_._childControl("toolPanel") as IToolPanel;
            if (dockPanel_._padsInHide() && toolPanel_._inHide())
            {
                toolPanel_._runShow();
            }
            else
            {
                dockPanel_._padsHide();
                toolPanel_._runHide();
            }
        }
    }
}
