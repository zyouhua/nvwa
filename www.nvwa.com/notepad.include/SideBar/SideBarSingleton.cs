using window.include;
using platform.include;

namespace notepad.include
{
    public class SideBarSingleton
    {
        public void _setSideBar(ISideBar nSideBar)
        {
            mSideBar = nSideBar;
        }

        public ISideBar _getSideBar()
        {
            return mSideBar;
        }

        public SideBarSingleton()
        {
            mSideBar = null;
        }

        ISideBar mSideBar;
    }
}
