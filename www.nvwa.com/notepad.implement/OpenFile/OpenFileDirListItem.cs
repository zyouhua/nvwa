using window.include;
using platform.include;

namespace notepad.implement
{
    public class OpenFileDirListItem : ListItem
    {
        public override void _listItemDoubleClick(object nObject)
        {
            IContain contain_ = nObject as IContain;
            IListView listView_ = contain_._childControl("listView1") as IListView;
            listView_._clearListItem();
            PlatformSingleton platformSingleton_ = __singleton<PlatformSingleton>._instance();
            string[] dirUrls_ = platformSingleton_._dirUrls(mListItemName);
            foreach (string i in dirUrls_)
            {
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

        public OpenFileDirListItem()
        {
            mListItemName = null;
        }

        string mListItemName;
    }
}
