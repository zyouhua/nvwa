using System.Collections.Generic;

using window.include;
using platform.include;

namespace notepad.implement
{
    public class OpenFileOkCommand : AbstractCommand
    {
        public override void _runCommand()
        {
            IContain contain_ = this._getOwner() as IContain;
            IForm form_ = contain_._contain() as IForm;
            IPanel panel_ = form_._childControl(@"panel2") as IPanel;
            IListView listView_ = form_._childControl(@"panel2/listView1") as IListView;
            IList<IListItem> listItems_ = listView_._selectedItems();
            if (listItems_.Count < 1)
            {
                return;
            }
            IListItem listItem_ = listItems_[0];
            listItem_._listItemDoubleClick(panel_);
        }
    }
}
