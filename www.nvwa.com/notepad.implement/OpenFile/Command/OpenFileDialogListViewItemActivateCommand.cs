using System.Collections.Generic;

using window.include;
using platform.include;

namespace notepad.implement
{
    public class OpenFileDialogListViewItemActivateCommand : AbstractCommand
    {
        public override void _runCommand()
        {
            IContain contain_ = this._getOwner() as IContain;
            IListView listView_ = contain_._childControl("listView1") as IListView;
            IList<IListItem> listItems_ = listView_._selectedItems();
            if (listItems_.Count < 1)
            {
                return;
            }
            IListItem listItem_ = listItems_[0];
            listItem_._listItemDoubleClick(contain_);
        }
    }
}
