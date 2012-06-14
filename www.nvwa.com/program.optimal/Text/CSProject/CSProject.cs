using window.include;
using notepad.include;
using program.include;
using platform.include;

namespace program.optimal
{
    public class CSProject : TextProject
    {
        public override void _headSerialize(ISerialize nSerialize)
        {
            nSerialize._serialize(ref mProjectDockWidget, "projectProperty");
            base._headSerialize(nSerialize);
        }

        public override void _firstInit()
        {
            base._setId(@"zyouhua@gmail.com:csproject");
            base._firstInit();
        }

        public void _setApplicationType(ApplicationType_ nApplicationType)
        {
            mProjectDockWidget._setApplicationType(nApplicationType);
        }

        public void _showPropertyDockWidget()
        {
            WorkbenchSingleton workbenchSingleton_ = __singleton<WorkbenchSingleton>._instance();
            workbenchSingleton_._showDockUrl(this);
        }

        public override void _initDockWidgets()
        {
            mProjectDockWidget._initControl();
            base._regDockWidget(mProjectDockWidget);
            base._initDockWidgets();
        }

        public override void _createUrl(string nUrl, string nName)
        {
            string projectName_ = null;
            string fileName_ = null;
            int pos_ = nName.LastIndexOf(".");
            if (pos_ < 0)
            {
                projectName_ = nName;
                fileName_ = nName + ".csproject";
            }
            else
            {
                string suffix_ = nName.Substring(pos_ + 1);
                if (suffix_ != "csproject")
                {
                    projectName_ = nName;
                    fileName_ = nName + ".csproject";
                }
                else
                {
                    projectName_ = nName.Substring(0, pos_);
                    fileName_ = nName;
                }
            }
            base._setProjectName(projectName_);
            base._createUrl(nUrl, fileName_);
        }

        public override void _treeNodeRightClick(TreeNodeMouseClickEventParams nTreeNodeMouseClickEventParams)
        {
            string contextMenuStripHeadstreamUrl_  = @"uid://program.optimal.window:window.optimal.ContextMenuStrip";
            string contextMenuStripUrl_ = @"rid://program.optimal.csprojectNodeContextMenuStripUrl";
            PlatformSingleton platformSingleton_ = __singleton<PlatformSingleton>._instance();
            IContextMenuStrip contextMenuStrip_ = platformSingleton_._loadHeadstream<IContextMenuStrip>(contextMenuStripHeadstreamUrl_, contextMenuStripUrl_);
            contextMenuStrip_._setTag(this);
            contextMenuStrip_._runInit();
            contextMenuStrip_._initControl();
            ITreeView treeView_ = nTreeNodeMouseClickEventParams._getTreeView();
            treeView_._showContextMenuStrip(contextMenuStrip_, nTreeNodeMouseClickEventParams._getX(), nTreeNodeMouseClickEventParams._getY());
            base._treeNodeRightClick(nTreeNodeMouseClickEventParams);
        }

        static readonly string mCSProjectImageUrl = "rid://program.optimal.csprojectImageUrl";
        public override string _getTreeNodeImage()
        {
            return mCSProjectImageUrl;
        }

        public CSProject()
        {
            mProjectDockWidget = new CProjectDockWidget();
        }

        CProjectDockWidget mProjectDockWidget;
    }
}
