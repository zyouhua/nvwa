using window.include;
using program.include;
using notepad.include;
using platform.include;

namespace program.optimal
{
    public class Project : UrlDiagramAll, IProject
    {
        public override void _headSerialize(ISerialize nSerialize)
        {
            nSerialize._serialize(ref mProjectName, "projectName");
            nSerialize._serialize(ref mProjectDockWidget, "projectProperty");
            nSerialize._serialize(ref mProjectCanvas, "projectCanvas");
            base._headSerialize(nSerialize);
        }

        public override string _streamName()
        {
            return "nvwaProject";
        }

        public override void _firstInit()
        {
            UdlHeadstream udlHeadstream_ = mProjectUrl._getUdlHeadstream();
            udlHeadstream_._setId(@"zyouhua@gmail.com:nvwaproject");
            base._firstInit();
        }

        public override void _runInit()
        {
            base._runInit();
            WorkbenchSingleton workbenchSingleton_ = __singleton<WorkbenchSingleton>._instance();
            workbenchSingleton_._showTreeNode(this);
            mProjectCanvas._runInit();
        }

        private void _loadInit()
        {

        }

        public override bool _isDirty()
        {
            if (mProjectCanvas._isDirty())
            {
                return true;
            }
            return base._isDirty();
        }

        public override void _runSave()
        {
            mProjectCanvas._runSave();
            base._runSave();
        }

        public override void _initDockWidgets()
        {
            base._initDockWidgets();
            mProjectDockWidget._initControl();
            base._regDockWidget(mProjectDockWidget);
        }

        public override void _createUrl(string nUrl, string nName)
        {
            string projectName_ = null;
            string fileName_ = null;
            int pos_ = nName.LastIndexOf(".");
            if (pos_ < 0)
            {
                projectName_ = nName;
                fileName_ = nName + ".nvwaproject";
            }
            else
            {
                string suffix_ = nName.Substring(pos_ + 1);
                if (suffix_ != "nvwaproject")
                {
                    projectName_ = nName;
                    fileName_ = nName + ".nvwaproject";
                }
                else
                {
                    projectName_ = nName.Substring(0, pos_);
                    fileName_ = nName;
                }
            }
            UdlHeadstream udlHeadstream_ = mProjectUrl._getUdlHeadstream();
            udlHeadstream_._setFileName(fileName_);
            this._setProjectName(projectName_);
            base._createUrl(nUrl, fileName_);
        }

        public override IUrl _getIUrl()
        {
            return mProjectUrl;
        }

        public override void _addTreeNode(ITreeContain nTreeContain)
        {
            nTreeContain._addTreeNode(mReference);
            base._addTreeNode(nTreeContain);
        }

        public override string _getTreeNodeName()
        {
            return mProjectName;
        }

        static readonly string mNvwaProjectImage = @"rid://program.optimal.nvwaprojectImageUrl";
        public override string _getTreeNodeImage()
        {
            return mNvwaProjectImage;
        }

        public override ICanvasDockWidget _getCanvasDockWidget()
        {
            return mProjectCanvas;
        }

        public override string _getDockUrlName()
        {
            return mProjectName;
        }

        public void _setProjectName(string nProjectName)
        {
            mProjectName = nProjectName;
            base._setTreeNodeName(nProjectName);
        }

        public string _getProjectName()
        {
            return mProjectName;
        }

        public Project()
        {
            mProjectDockWidget = new ProjectDockWidget();
            mProjectCanvas = new ProjectCanvas(this);
            mReference = new Reference();
            mProjectName = null;
            mProjectUrl = new StdUdl();
            mProjectUrl.m_tHeadSerializeSlot += this._headSerialize;
            mProjectUrl.m_tSerializeTypeSlot += this._serializeType;
            mProjectUrl.m_tStreamNameSlot += this._streamName;
            mProjectUrl.m_tLoadInit += this._loadInit;
            mProjectUrl.m_tIsDirty += this._isDirty;
            mProjectUrl.m_tRunSave += this._runSave;
            SaveSingleton saveSingleton_ = __singleton<SaveSingleton>._instance();
            saveSingleton_._addSave(mProjectUrl);
        }

        ProjectDockWidget mProjectDockWidget;
        ProjectCanvas mProjectCanvas;
        string mProjectName;
        StdUdl mProjectUrl;
        Reference mReference;
    }
}
