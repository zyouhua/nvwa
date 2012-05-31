using platform.include;

namespace window.include
{
    public abstract class ListItem : IListItem
    {
        public virtual void _addListItem(IListContain nListContain)
        {
        }

        public virtual void _listItemDoubleClick(object nObject)
        {
        }

        public virtual void _listItemClick(object nObject)
        {
        }

        public event _SetStringSlot m_tListItemNameChange;

        public void _setListItemName(string nListItemName)
        {
            if (null != m_tListItemNameChange)
            {
                m_tListItemNameChange(nListItemName);
            }
        }

        public abstract string _getListItemName();

        public abstract string _getListItemImage();

        protected void _newListSubItem(IListItem nListItem)
        {
            if (null != m_tNewListSubItem)
            {
                this.m_tNewListSubItem(nListItem);
            }
        }

        public event _SetListItemSlot m_tNewListSubItem;
    }
}
