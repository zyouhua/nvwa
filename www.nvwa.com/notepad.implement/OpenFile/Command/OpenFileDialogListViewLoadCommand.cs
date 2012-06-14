using window.include;
using platform.include;

namespace notepad.implement
{
    public class OpenFileDialogListViewLoadCommand : AbstractCommand
    {
        public override void _runCommand()
        {
            IContain contain_ = this._getOwner() as IContain;
            IListView listView_ = contain_._childControl("listView1") as IListView;
            PlatformSingleton platformSingleton_ = __singleton<PlatformSingleton>._instance();
            string[] rootUrls_ = platformSingleton_._rootUrls();
            foreach (string i in rootUrls_)
            {
                OpenFileUrlListItem openFileUrlListItem_ = new OpenFileUrlListItem();
                openFileUrlListItem_._setListItemName(i);
                listView_._addListItem(openFileUrlListItem_);
            }
        }
    }
}
