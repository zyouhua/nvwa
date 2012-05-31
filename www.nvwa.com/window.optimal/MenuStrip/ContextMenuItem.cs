using System;
using System.Windows.Forms;
using System.Collections.Generic;

using window.include;
using platform.include;

namespace window.optimal
{
    public class ContextMenuItem : Stream
    {
        public override void _serialize(ISerialize nSerialize)
        {
            nSerialize._serialize(ref mText, @"label");
            nSerialize._serialize(ref mIcon, @"icon");
            nSerialize._serialize(ref mCmdStr, @"command");
            nSerialize._serialize(ref mContextMenuItems, @"contextMenuItems");
        }

        public void _runInit()
        {
            PlatformSingleton platformSingleton_ = __singleton<PlatformSingleton>._instance();
            mCommand = platformSingleton_._findInterface<ICommand>(mCmdStr);
            if (null != mCommand)
            {
                mCommand._setOwner(mTag);
            }
            foreach (ContextMenuItem i in mContextMenuItems)
            {
                i._setTag(mTag);
                i._runInit();
            }
        }

        public void _initControl()
        {
            if (null == mToolStripMenuItem || mToolStripMenuItem.IsDisposed)
            {
                ImageSingleton imageSingleton_ = __singleton<ImageSingleton>._instance();
                mToolStripMenuItem = new ToolStripMenuItem();
                mToolStripMenuItem.Text = mText;
                mToolStripMenuItem.Image = imageSingleton_._getImage(mIcon);
                mToolStripMenuItem.Click += _onClick;
                foreach (ContextMenuItem i in mContextMenuItems)
                {
                    i._initControl();
                }
                foreach (ContextMenuItem i in mContextMenuItems)
                {
                    ToolStripMenuItem toolStripMenuItem_ = i._getToolStripMenuItem();
                    mToolStripMenuItem.DropDownItems.Add(toolStripMenuItem_);
                }
            }
        }

        public ToolStripMenuItem _getToolStripMenuItem()
        {
            return mToolStripMenuItem;
        }

        public void _setTag(object nTag)
        {
            mTag = nTag;
        }

        void _onClick(object sender, EventArgs e)
        {
            if (null != mCommand)
            {
                mCommand._runCommand();
            }
        }

        public ContextMenuItem()
        {
            mContextMenuItems = new List<ContextMenuItem>();
            mToolStripMenuItem = null;
            mCommand = null;
            mCmdStr = null;
            mText = null;
            mIcon = null;
            mTag = null;
        }

        List<ContextMenuItem> mContextMenuItems;
        ToolStripMenuItem mToolStripMenuItem;
        ICommand mCommand;
        string mCmdStr;
        string mText;
        string mIcon;
        object mTag;
    }
}
