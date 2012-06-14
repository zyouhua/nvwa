using window.include;
using platform.include;

namespace notepad.implement
{
    public class NewProjectCancelCommand : AbstractCommand
    {
        public override void _runCommand()
        {
            IContain contain_ = this._getOwner() as IContain;
            IForm form_ = contain_._contain() as IForm;
            form_._runClose();
        }
    }
}
