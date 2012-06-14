using System.Collections.Generic;

namespace window.include
{
    public interface IListView : IListContain
    {
        IList<IListItem> _selectedItems();

        void _clearListItem();
    }
}
