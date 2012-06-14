using window.include;
using platform.include;

namespace program.optimal
{
    public class OpenCProjectPropertyCommand : AbstractCommand
    {
        public override void _runCommand()
        {
            CProject cproject_ = this._getOwner() as CProject;
            cproject_._showPropertyDockWidget();
        }
    }
}
