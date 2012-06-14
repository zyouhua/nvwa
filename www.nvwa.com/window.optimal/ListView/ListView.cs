using System;
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
            nSerialize._serialize(ref mInitCmd, @"initCommand");
            nSerialize._serialize(ref mLoadCmd, @"loadCommand");
            nSerialize._serialize(ref mItemActivateCmd, @"itemActivateCommand");
            nSerialize._serialize(ref mSelectedIndexChangedCmd, @"selectedIndexChangedCommand");
            nSerialize._serialize(ref mSize, @"size");
            base._serialize(nSerialize);
        }

        public override string _virstream()
        {
            return @"listView";
        }

        public override void _runInit()
        {
            PlatformSingleton platformSingleton_ = __singleton<PlatformSingleton>._instance();
            mInitCommand = platformSingleton_._findInterface<ICommand>(mInitCmd);
            if (null != mInitCommand)
            {
                mInitCommand._setOwner(mContain);
                mInitCommand._runCommand();
            }
            mLoadCommand = platformSingleton_._findInterface<ICommand>(mLoadCmd);
            if (null != mLoadCommand)
            {
                mLoadCommand._setOwner(mContain);
            }
            mItemActivateCommand = platformSingleton_._findInterface<ICommand>(mItemActivateCmd);
            if (null != mItemActivateCommand)
            {
                mItemActivateCommand._setOwner(mContain);
            }
            mSelectedIndexChangedCommand = platformSingleton_._findInterface<ICommand>(mSelectedIndexChangedCmd);
            if (null != mSelectedIndexChangedCommand)
            {
                mSelectedIndexChangedCommand._setOwner(mContain);
            }
            base._runInit();
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
                mListView.ItemActivate += _onItemActivate;
                mListView.SelectedIndexChanged += _selectedIndexChanged;
                if (null != mLoadCommand)
                {
                    mLoadCommand._runCommand();
                }
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

        void _onItemActivate(object sender, EventArgs e)
        {
            if (null != mItemActivateCommand)
            {
                mItemActivateCommand._runCommand();
            }
        }

        void _selectedIndexChanged(object sender, EventArgs e)
        {
            if (null != mSelectedIndexChangedCommand)
            {
                mSelectedIndexChangedCommand._runCommand();
            }
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
            mInitCommand = null;
            mInitCmd = null;
            mLoadCommand = null;
            mLoadCmd = null;
            mItemActivateCommand = null;
            mItemActivateCmd = null;
            mSelectedIndexChangedCommand = null;
            mSelectedIndexChangedCmd = null;
            mSize = null;
        }

        System.Windows.Forms.ListView mListView;
        string mDockStyle;
        string mViewStyle;
        IContain mContain;
        ICommand mInitCommand;
        string mInitCmd;
        ICommand mLoadCommand;
        string mLoadCmd;
        ICommand mItemActivateCommand;
        string mItemActivateCmd;
        ICommand mSelectedIndexChangedCommand;
        string mSelectedIndexChangedCmd;
        Size2I mSize;
    }
}
