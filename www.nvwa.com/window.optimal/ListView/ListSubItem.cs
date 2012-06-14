using System.Windows.Forms;

using window.include;

namespace window.optimal
{
    public class ListSubItem : ListViewItem.ListViewSubItem
    {
        public void _setListItem(IListItem nListItem)
        {
            this.Text = nListItem._getListItemName();
            nListItem.m_tListItemNameChange += this._setListSubItemName;
        }

        void _setListSubItemName(string nName)
        {
            this.Text = nName;
        }
    }
}
