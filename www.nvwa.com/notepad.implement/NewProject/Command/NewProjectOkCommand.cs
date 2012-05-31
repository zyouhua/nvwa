using System.Collections.Generic;

using window.include;
using platform.include;

namespace notepad.implement
{
    public class NewProjectOkCommand : AbstractCommand
    {
        public override void _runCommand()
        {
            IContain contain_ = this._getOwner() as IContain;
            IForm form_ = contain_._contain() as IForm;
            IListView listView_ = form_._childControl("panel2/listView1") as IListView;
            ITextBox fileUrl_ = form_._childControl("panel1/fileUrl") as ITextBox;
            ITextBox fileName_ = form_._childControl("panel1/fileName") as ITextBox;
            string text_ = fileUrl_._getText();
            if (null == text_ || "" == text_)
            {
                return;
            }
            text_ = fileName_._getText();
            if (null == text_ || "" == text_)
            {
                return;
            }
            IList<IListItem> listItems_ = listView_._selectedItems();
            foreach (IListItem i in listItems_)
            {
                i._listItemDoubleClick(contain_);
            }
            form_._runClose();
        }
    }
}
