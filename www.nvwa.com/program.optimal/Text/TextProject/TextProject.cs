using System.Collections.Generic;

using window.include;
using notepad.include;
using platform.include;

namespace program.optimal
{
    public abstract class TextProject : UrlContentAll
    {
        public override void _headSerialize(ISerialize nSerialize)
        {
            nSerialize._serialize(ref mTextClass, @"files");
            nSerialize._serialize(ref mTextDirs, "dirs");
            nSerialize._serialize(ref mProjectName, "projectName");
            nSerialize._serialize(ref mReference, "reference", mReference);
            base._headSerialize(nSerialize);
        }

        public override string _streamName()
        {
            return "project";
        }

        public override void _runInit()
        {
            WorkbenchSingleton workbenchSingleton_ = __singleton<WorkbenchSingleton>._instance();
            workbenchSingleton_._showTreeNode(this);
            base._runInit();
        }

        public override void _addTreeNode(ITreeContain nTreeContain)
        {
            nTreeContain._addTreeNode(mReference);
            foreach (TextClass i in mTextClass)
            {
                nTreeContain._addTreeNode(i);
            }
            base._addTreeNode(nTreeContain);
        }

        public override void _treeNodeDoubleClick(TreeNodeMouseClickEventParams nTreeNodeMouseClickEventParams)
        {
        }

        public override string _getTreeNodeName()
        {
            return mProjectName;
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

        public void _setId(string nId)
        {
            UdlHeadstream udlHeadstream_ = mProjectUrl._getUdlHeadstream();
            udlHeadstream_._setId(nId);
        }

        public override IUrl _getIUrl()
        {
            return mProjectUrl;
        }

        public TextProject()
        {
            mReference = new Reference();
            mTextClass = new List<TextClass>();
            mTextDirs = new List<TextDir>();
            mProjectName = null;
            mProjectUrl = new StdUdl();
            mProjectUrl.m_tHeadSerializeSlot += this._headSerialize;
            mProjectUrl.m_tSerializeTypeSlot += this._serializeType;
            mProjectUrl.m_tStreamNameSlot += this._streamName;
            SaveSingleton saveSingleton_ = __singleton<SaveSingleton>._instance();
            saveSingleton_._addSave(mProjectUrl);
        }

        List<TextClass> mTextClass;
        List<TextDir> mTextDirs;
        string mProjectName;
        StdUdl mProjectUrl;
        Reference mReference;
    }
}
