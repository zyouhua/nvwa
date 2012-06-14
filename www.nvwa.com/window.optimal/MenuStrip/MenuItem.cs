using System;
using System.Windows.Forms;
using System.Collections.Generic;

using window.include;
using platform.include;

namespace window.optimal
{
    public class MenuItem : Stream, IUpdate
    {
        public override void _serialize(ISerialize nSerialize)
        {
            nSerialize._serialize(ref mText, @"label");
            nSerialize._serialize(ref mIcon, @"icon");
            nSerialize._serialize(ref mCmdStr, @"command");
            nSerialize._serialize(ref mMenuItems, @"menuItems");
            nSerialize._serialize(ref mMemberStreams, @"memberStreams");
        }

        public void _runInit()
        {
            UpdateSingleton updateSingleton_ = __singleton<UpdateSingleton>._instance();
            updateSingleton_._registerUpdate(this);
            PlatformSingleton platformSingleton_ = __singleton<PlatformSingleton>._instance();
            mCommand = platformSingleton_._findInterface<ICommand>(mCmdStr);
            if (null != mCommand)
            {
                mCommand._setOwner(mContain);
            }
            foreach (MenuItem i in mMenuItems)
            {
                i._setContain(mContain);
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
                foreach (MenuItem i in mMenuItems)
                {
                    i._initControl();
                }
                foreach (MenuItem i in mMenuItems)
                {
                    ToolStripMenuItem toolStripMenuItem_ = i._getToolStripMenuItem();
                    mToolStripMenuItem.DropDownItems.Add(toolStripMenuItem_);
                }
            }
        }

        public void _setContain(IContain nContain)
        {
            mContain = nContain;
        }

        public ToolStripMenuItem _getToolStripMenuItem()
        {
            return mToolStripMenuItem;
        }

        public void _runUpdate()
        {
            if (null == mToolStripMenuItem || mToolStripMenuItem.IsDisposed)
            {
                return;
            }
            ConditionSingleton conditionSingleton_ = __singleton<ConditionSingleton>._instance();
            foreach (MemberStream i in mMemberStreams)
            {
                IEnumerable<ConditionStream> conditionStream_ = i._getConditionStreams();
                bool result_ = conditionSingleton_._validate(conditionStream_);
                string name_ = i._getName();
                string value_ = i._getValue();
                if (@"visible" == name_)
                {
                    if (@"false" == value_)
                    {
                        mToolStripMenuItem.Visible = (!result_);
                    }
                    else
                    {
                        mToolStripMenuItem.Visible = result_;
                    }
                }
                else if (@"enable" == name_)
                {
                    if (@"false" == value_)
                    {
                        mToolStripMenuItem.Enabled = (!result_);
                    }
                    else
                    {
                        mToolStripMenuItem.Enabled = result_;
                    }
                }
                else
                {
                }
            }
        }

        void _onClick(object sender, EventArgs e)
        {
            if (null != mCommand)
            {
                mCommand._runCommand();
            }
        }

        public MenuItem()
        {
            mMemberStreams = new List<MemberStream>();
            mMenuItems = new List<MenuItem>();
            mToolStripMenuItem = null;
            mCommand = null;
            mCmdStr = null;
            mContain = null;
            mText = null;
            mIcon = null;
        }

        List<MemberStream> mMemberStreams;
        ToolStripMenuItem mToolStripMenuItem;
        List<MenuItem> mMenuItems;
        ICommand mCommand;
        IContain mContain;
        string mCmdStr;
        string mText;
        string mIcon;
    }
}
