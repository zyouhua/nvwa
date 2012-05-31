using System.Windows.Forms;

using window.include;
using platform.include;

namespace window.optimal
{
    public class ListItemWidget : ListViewItem, IListContain
    {
        public void _addListItem(IListItem nListItem)
        {
            ListSubItem listViewSubItem_ = new ListSubItem();
            listViewSubItem_._setListItem(nListItem);
            this.SubItems.Add(listViewSubItem_);
            nListItem._addListItem(this);
        }

        public void _setListItem(IListItem nListItem)
        {
            mListItem = nListItem;
            this.Text = nListItem._getListItemName();
            ImageSingleton imageSingleton_ = __singleton<ImageSingleton>._instance();
            string listItemImage_ = nListItem._getListItemImage();
            this.ImageIndex = imageSingleton_._getImageId(listItemImage_);
            nListItem.m_tListItemNameChange += this._setListItemName;
            nListItem.m_tNewListSubItem += this._newListSubItem;
        }

        public IListItem _getListItem()
        {
            return mListItem;
        }

        void _setListItemName(string nName)
        {
            this.Text = nName;
        }

        void _newListSubItem(IListItem nListItem)
        {
            ListSubItem listViewSubItem_ = new ListSubItem();
            listViewSubItem_._setListItem(nListItem);
            this.SubItems.Add(listViewSubItem_);
            nListItem._addListItem(this);
        }

        public ListItemWidget()
        {
            mListItem = null;
        }

        IListItem mListItem;
    }
}
