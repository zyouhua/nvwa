using System.Collections.Generic;

using window.include;
using notepad.include;
using platform.include;


namespace notepad.implement
{
    public class OpenFileOkCommand : AbstractCommand
    {
        public override void _runCommand()
        {
            IContain contain_ = this._getOwner() as IContain;
            ITextBox fileUrl_ = contain_._childControl("fileName") as ITextBox;
            IForm form_ = contain_._contain() as IForm;
            IPanel panel_ = form_._childControl(@"panel2") as IPanel;
            IListView listView_ = form_._childControl(@"panel2/listView1") as IListView;
            string text_ = fileUrl_._getText();
            if (null != text_)
            {
                text_.Trim();
            }
            if (null == text_ || "" == text_)
            {
                IList<IListItem> listItems_ = listView_._selectedItems();
                if (listItems_.Count < 1)
                {
                    return;
                }
                IListItem listItem_ = listItems_[0];
                listItem_._listItemDoubleClick(panel_);
            }
            else
            {
                form_._runClose();
                WorkbenchSingleton workbenchSingleton_ = __singleton<WorkbenchSingleton>._instance();
                workbenchSingleton_._openUrl(text_);
            }
        }
    }
}
