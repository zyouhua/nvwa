using window.include;
using platform.include;

namespace window.optimal
{
    public class ToolStripItemAdapt : Stream
    {
        public override void _serialize(ISerialize nSerialize)
        {
            nSerialize._serialize(ref mType, @"type");
            if (mType == @"toolItem")
            {
                ToolItem toolItem_ = new ToolItem();
                toolItem_._serialize(nSerialize);
                this._setToolStripItem(toolItem_);
            }
            else if (mType == @"toolStripComboBox")
            {
                ToolStripComboBox toolStripComboBox_ = new ToolStripComboBox();
                toolStripComboBox_._serialize(nSerialize);
                this._setToolStripItem(toolStripComboBox_);
            }
            else
            {
            }
        }

        public void _runInit()
        {
            mToolStripItem._setContain(mContain);
            mToolStripItem._runInit();
        }

        public void _initControl()
        {
            mToolStripItem._initControl();
        }

        public System.Windows.Forms.ToolStripItem _getControl()
        {
            return mToolStripItem._getToolStripItem();
        }

        public void _setContain(IContain nContain)
        {
            mContain = nContain;
        }

        public void _setToolStripItem(IToolStripItem nToolStripItem)
        {
            mToolStripItem = nToolStripItem;
        }

        public IToolStripItem _getToolStripItem()
        {
            return mToolStripItem;
        }

        public void _setType(string nType)
        {
            mType = nType;
        }

        public string _getType()
        {
            return mType;
        }

        public ToolStripItemAdapt()
        {
            mToolStripItem = null;
            mContain = null;
            mType = null;
        }

        IToolStripItem mToolStripItem;
        IContain mContain;
        string mType;
    }
}
