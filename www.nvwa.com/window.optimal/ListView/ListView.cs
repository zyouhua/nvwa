using System.Windows.Forms;
using System.Collections.Generic;

using window.include;
using platform.include;

namespace window.optimal
{
    public class ListView : Widget, IListView
    {
        public override void _serialize(ISerialize nSerialize)
        {
            nSerialize._serialize(ref mDockStyle, @"dockStyle");
            nSerialize._serialize(ref mViewStyle, @"viewStyle");
            nSerialize._serialize(ref mSize, @"size");
            base._serialize(nSerialize);
        }

        public override string _virstream()
        {
            return @"listView";
        }

        public override void _initControl()
        {
            if (null == mListView || mListView.IsDisposed)
            {
                mListView = new System.Windows.Forms.ListView();
                if (string.Compare(mDockStyle, @"Top") == 0)
                {
                    mListView.Dock = DockStyle.Top;
                }
                else if (string.Compare(mDockStyle, @"Bottom") == 0)
                {
                    mListView.Dock = DockStyle.Bottom;
                }
                else if (string.Compare(mDockStyle, @"Fill") == 0)
                {
                    mListView.Dock = DockStyle.Fill;
                }
                else if (string.Compare(mDockStyle, @"Left") == 0)
                {
                    mListView.Dock = DockStyle.Left;
                }
                else if (string.Compare(mDockStyle, @"Right") == 0)
                {
                    mListView.Dock = DockStyle.Right;
                }
                else
                {
                    mListView.Dock = DockStyle.None;
                }
                if (string.Compare(mViewStyle, @"Details") == 0)
                {
                    mListView.View = View.Details;
                }
                else if (string.Compare(mViewStyle, @"LargeIcon") == 0)
                {
                    mListView.View = View.LargeIcon;
                }
                else if (string.Compare(mViewStyle, @"SmallIcon") == 0)
                {
                    mListView.View = View.SmallIcon;
                }
                else if (string.Compare(mViewStyle, @"Tile") == 0)
                {
                    mListView.View = View.Tile;
                }
                else
                {
                    mListView.View = View.List;
                }
                if (null != mSize)
                {
                    mListView.Width = mSize._getWidth();
                    mListView.Height = mSize._getHeight();
                }
                ImageSingleton imageSingleton_ = __singleton<ImageSingleton>._instance();
                mListView.SmallImageList = imageSingleton_._getImageList();
            }
        }

        public override IWidget _createControl()
        {
            return new ListView();
        }

        public override object _getControl()
        {
            return mListView;
        }

        public override void _setContain(IContain nContain)
        {
            mContain = nContain;
        }

        public void _addListItem(IListItem nListItem)
        {
            ListItemWidget listItemWidget_ = new ListItemWidget();
            listItemWidget_._setListItem(nListItem);
            mListView.Items.Add(listItemWidget_);
            nListItem._addListItem(listItemWidget_);
        }

        public IList<IListItem> _selectedItems()
        {
            List<IListItem> result_ = new List<IListItem>();
            foreach (ListViewItem i in mListView.SelectedItems)
            {
                ListItemWidget listItemWidget_ = i as ListItemWidget;
                IListItem listItem_ = listItemWidget_._getListItem();
                result_.Add(listItem_);
            }
            return result_;
        }

        public void _clearListItem()
        {
            mListView.Clear();
        }

        public void _setDockStyle(string nDockStyle)
        {
            mDockStyle = nDockStyle;
        }

        public string _getDockStyle()
        {
            return mDockStyle;
        }

        public void _setViewStyle(string nViewStyle)
        {
            mViewStyle = nViewStyle;
        }

        public string _getViewStyle()
        {
            return mViewStyle;
        }

        public ListView()
        {
            mDockStyle = @"None";
            mViewStyle = "List";
            mContain = null;
            mSize = null;
        }

        System.Windows.Forms.ListView mListView;
        string mDockStyle;
        string mViewStyle;
        IContain mContain;
        Size2I mSize;
    }
}
