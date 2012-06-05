using window.include;
using notepad.include;
using platform.include;

namespace notepad.implement
{
    public class OpenFileArcListItem : ListItem
    {
        public override void _listItemDoubleClick(object nObject)
        {
            IContain contain_ = nObject as IContain;
            IForm form_ = contain_._contain() as IForm;
            form_._runClose();
            WorkbenchSingleton workbenchSingleton_ = __singleton<WorkbenchSingleton>._instance();
            workbenchSingleton_._openUrl(mListItemName);
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

        static string mListItemImageUrl = @"rid://notepad.implement.iconArchiveImageUrl";
        public override string _getListItemImage()
        {
            return mListItemImageUrl;
        }

        public OpenFileArcListItem()
        {
            mListItemName = null;
        }

        string mListItemName;
    }
}
