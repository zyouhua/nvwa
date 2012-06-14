using window.include;
using notepad.include;
using platform.include;

namespace notepad.implement
{
    public class NewFileNodeContent : ListItem, IStream
    {
        public void _serialize(ISerialize nSerialize)
        {
            nSerialize._serialize(ref mImageUrl, @"imageUrl");
            nSerialize._serialize(ref mContentUrl, @"contentUrl");
            nSerialize._serialize(ref mContentName, @"contentName");
        }

        public void _runInit()
        {
        }

        public void _runDirty()
        {
            mDirty = true;
        }

        public event _GetBoolSlot m_tIsDirty;

        public virtual bool _isDirty()
        {
            if (mDirty)
            {
                return true;
            }
            if (null == m_tIsDirty)
            {
                return false;
            }
            return this.m_tIsDirty();
        }

        public event _RunSlot m_tRunSave;

        public virtual void _runSave()
        {
            if (null == m_tRunSave)
            {
                this.m_tRunSave();
            }
            mDirty = false;
        }

        public override void _listItemDoubleClick(object nObject)
        {
            IContain contain_ = nObject as IContain;
            IForm form_ = contain_._contain() as IForm;
            ITextBox fileUrlTextBox_ = form_._childControl("panel1/fileUrl") as ITextBox;
            ITextBox fileNameTextBox_ = form_._childControl("panel1/fileName") as ITextBox;
            string fileUrl_ = fileUrlTextBox_._getText();
            string fileName_ = fileNameTextBox_._getText();
            WorkbenchSingleton workbenchSingleton_ = __singleton<WorkbenchSingleton>._instance();
            workbenchSingleton_._createContent(mContentUrl, fileUrl_, fileName_);
            base._listItemDoubleClick(nObject);
        }

        public override string _getListItemName()
        {
            return mContentName;
        }

        public override string _getListItemImage()
        {
            return mImageUrl;
        }

        public NewFileNodeContent()
        {
            mContentName = null;
            mContentUrl = null;
            mImageUrl = null;
            mDirty = false;
        }

        string mContentName;
        string mContentUrl;
        string mImageUrl;
        bool mDirty;
    }
}
