using platform.include;

namespace window.include
{
    public interface IListItem
    {
        void _addListItem(IListContain nListContain);

        void _listItemDoubleClick(object nObject);

        void _listItemClick(object nObject);

        event _SetStringSlot m_tListItemNameChange;
        
        void _setListItemName(string nListItemName);

        string _getListItemName();

        string _getListItemImage();

        event _SetListItemSlot m_tNewListSubItem;
    }
}
