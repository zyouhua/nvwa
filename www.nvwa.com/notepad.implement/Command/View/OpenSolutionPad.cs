using window.include;
using platform.include;

namespace notepad.implement
{
    public class OpenSolutionPad : AbstractCommand
    {
        public override void _runCommand()
        {
            IForm form_ = this._getOwner() as IForm;
            IDockPanel dockPanel_ = form_._childControl("dockPanel1") as IDockPanel;
            dockPanel_._showPad("solutionPad");
        }
    }
}
