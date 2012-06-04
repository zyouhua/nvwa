using window.include;
using platform.include;

namespace program.optimal
{
    public class OpenCSProjectPropertyCommand : AbstractCommand
    {
        public override void _runCommand()
        {
            CSProject csproject_ = this._getOwner() as CSProject;
            csproject_._showPropertyDockWidget();
        }
    }
}
