using window.include;
using platform.include;

namespace program.optimal
{
    public class ClassShapeCancelCommand : AbstractCommand
    {
        public override void _runCommand()
        {
            IForm form_ = this._getOwner() as IForm;
            form_._runClose();
        }
    }
}
