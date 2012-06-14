using window.include;
using platform.include;

namespace notepad.implement
{
    public class CloseWorkbench : AbstractCommand
    {
        public override void _runCommand()
        {
            IForm form_ = this._getOwner() as IForm;
            form_._runClose();
        }
    }
}
