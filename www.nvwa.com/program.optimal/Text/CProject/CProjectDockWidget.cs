using window.include;
using program.include;
using platform.include;

namespace program.optimal
{
    public class CProjectDockWidget : Stream, ICProjectDockWidget
    {
        public override void _serialize(ISerialize nSerialize)
        {
            nSerialize._serialize(ref mApplicationType, @"applicationType");
        }

        public void _initControl()
        {
            PlatformSingleton platformSingleton_ = __singleton<PlatformSingleton>._instance();
            string panelUrl_ = @"uid://program.optimal.window:window.optimal.Panel";
            string cprojectUrl_ = @"rid://program.optimal.cprojectPropertyUrl";
            mPanel = platformSingleton_._loadHeadstream<IPanel>(panelUrl_, cprojectUrl_);
            mApplicationTypeComboBox = mPanel._childControl("comboBox1") as IComboBox;
            mApplicationTypeComboBox.m_tSelectTextSlot += this._getApplicationTypeStr;
        }

        public IWidget _getControl()
        {
            return mPanel;
        }

        public string _dockName()
        {
            return @"property";
        }

        public string _getApplicationTypeStr()
        {
            return mApplicationType;
        }

        public void _setApplicationType(ApplicationType_ nApplicationType)
        {
            if (nApplicationType == ApplicationType_.mWindow_)
            {
                mApplicationType = "window";
            }
            else if (nApplicationType == ApplicationType_.mConsole_)
            {
                mApplicationType = "console";
            }
            else
            {
                mApplicationType = "library";
            }
        }

        public CProjectDockWidget()
        {
            mApplicationTypeComboBox = null;
            mApplicationType = "library";
            mPanel = null;
        }

        IComboBox mApplicationTypeComboBox;
        string mApplicationType;
        IPanel mPanel;
    }
}
