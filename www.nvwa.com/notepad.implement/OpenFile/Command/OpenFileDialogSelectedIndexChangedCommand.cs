using System.Collections.Generic;

using window.include;
using platform.include;

namespace notepad.implement
{
    public class OpenFileDialogSelectedIndexChangedCommand : AbstractCommand
    {
        public override void _runCommand()
        {
            IContain contain_ = this._getOwner() as IContain;
            IForm form_ = contain_._contain() as IForm;
            IListView listView_ = contain_._childControl("listView1") as IListView;
            ITextBox fileName_ = form_._childControl("panel1/fileName") as ITextBox;
            IList<IListItem> listItems_ = listView_._selectedItems();
            if (listItems_.Count < 1)
            {
                return;
            }
            IListItem listItem_ = listItems_[0];
            string listItemName_ = listItem_._getListItemName();
            fileName_._setText(listItemName_);
        }
    }
}
