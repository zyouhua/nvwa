using window.include;
using notepad.include;
using platform.include;

namespace notepad.implement
{
    public class SideBarInitCommand : AbstractCommand
    {
        public override void _runCommand()
        {
            IContain contain_ = this._getOwner() as IContain;
            ISideBar sideBar_ = contain_._childControl("sideBar") as ISideBar;
            SideBarSingleton sideBarSingleton_ = __singleton<SideBarSingleton>._instance();
            sideBarSingleton_._setSideBar(sideBar_);
        }
    }
}
