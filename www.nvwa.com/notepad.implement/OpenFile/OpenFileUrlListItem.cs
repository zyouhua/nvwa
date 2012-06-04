using window.include;
using platform.include;

namespace notepad.implement
{
    public class OpenFileUrlListItem : ListItem
    {
        public override void _listItemDoubleClick(object nObject)
        {
            IContain contain_ = nObject as IContain;
            IListView listView_ = contain_._childControl("listView1") as IListView;
            listView_._clearListItem();
            PlatformSingleton platformSingleton_ = __singleton<PlatformSingleton>._instance();
            string[] arcUrls_ = platformSingleton_._arcs(mListItemName);
            foreach (string i in arcUrls_)
            {
                OpenFileArcListItem openFileArcListItem_ = new OpenFileArcListItem();
                openFileArcListItem_._setListItemName(i);
                listView_._addListItem(openFileArcListItem_);
            }
            string[] dirUrls_ = platformSingleton_._dirUrls(mListItemName);
            foreach (string i in dirUrls_)
            {
                OpenFileDirListItem openFileDirListItem_ = new OpenFileDirListItem();
                openFileDirListItem_._setListItemName(i);
                listView_._addListItem(openFileDirListItem_);
            }
            string[] files_ = platformSingleton_._files(mListItemName);
            foreach (string i in files_)
            {
                OpenFileFileListItem openFileFileListItem_ = new OpenFileFileListItem();
                openFileFileListItem_._setListItemName(i);
                listView_._addListItem(openFileFileListItem_);
            }
            base._listItemDoubleClick(nObject);
        }

        public override void _setListItemName(string nListItemName)
        {
            mListItemName = nListItemName;
            base._setListItemName(nListItemName);
        }

        public override string _getListItemName()
        {
            return mListItemName;
        }

        static string mListItemImageUrl = @"rid://notepad.implement.closeFolderImageUrl";
        public override string _getListItemImage()
        {
            return mListItemImageUrl;
        }

        public OpenFileUrlListItem()
        {
            mListItemName = null;
        }

        string mListItemName;
    }
}
