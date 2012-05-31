using System;
using System.Windows.Forms;
using System.Collections.Generic;

using window.include;
using platform.include;

namespace window.optimal
{
    public class ToolItem : ToolStripItem
    {
        public override void _serialize(ISerialize nSerialize)
        {
            nSerialize._serialize(ref mMemberStreams, @"memberStreams");
            nSerialize._serialize(ref mIcon, @"icon");
            nSerialize._serialize(ref mText, @"tooltip");
            nSerialize._serialize(ref mCmdStr, @"command");
            nSerialize._serialize(ref mPressed, @"pressed");
        }

        public override void _runInit()
        {
            PlatformSingleton platformSingleton_ = __singleton<PlatformSingleton>._instance();
            mCommand = platformSingleton_._findInterface<ICommand>(mCmdStr);
            if (null != mCommand)
            {
                IContain contain_ = this._getContain();
                mCommand._setOwner(contain_);
            }
            base._runInit();
        }

        public override void _initControl()
        {
            if (null == mToolStripButton || mToolStripButton.IsDisposed)
            {
                ImageSingleton imageSingleton_ = __singleton<ImageSingleton>._instance();
                mToolStripButton = new ToolStripButton();
                mToolStripButton.Checked = mPressed;
                mToolStripButton.ToolTipText = mText;
                mToolStripButton.Image = imageSingleton_._getImage(mIcon);
                mToolStripButton.Click += _onClick;
            }
        }

        public override System.Windows.Forms.ToolStripItem _getToolStripItem()
        {
            return mToolStripButton;
        }

        void _onClick(object sender, EventArgs e)
        {
            if (null != mCommand)
            {
                mCommand._runCommand();
            }
        }

        public override void _runUpdate()
        {
            if (null == mToolStripButton || mToolStripButton.IsDisposed)
            {
                return;
            }
            ConditionSingleton conditionSingleton_ = __singleton<ConditionSingleton>._instance();
            foreach (MemberStream i in mMemberStreams)
            {
                bool result_ = conditionSingleton_._validate(i._getConditionStreams());
                string name_ = i._getName();
                string value_ = i._getValue();
                if (@"visible" == name_)
                {
                    if (@"false" == value_)
                    {
                        mToolStripButton.Visible = (!result_);
                    }
                    else
                    {
                        mToolStripButton.Visible = result_;
                    }
                }
                else if (@"enable" == name_)
                {
                    if (@"false" == value_)
                    {
                        mToolStripButton.Enabled = (!result_);
                    }
                    else
                    {
                        mToolStripButton.Enabled = result_;
                    }
                }
                else
                {
                }
            }
        }

        public void _setPress(bool nPressed)
        {
            mPressed = nPressed;
        }

        public bool _getPressed()
        {
            return mPressed;
        }

        public void _setText(string nText)
        {
            mText = nText;
        }

        public string _getText()
        {
            return mText;
        }

        public void _setIcon(string nIcon)
        {
            mIcon = nIcon;
        }

        public string _getIcon()
        {
            return mIcon;
        }

        public ToolItem()
        {
            mMemberStreams = new List<MemberStream>();
            mToolStripButton = null;
            mPressed = false;
            mCommand = null;
            mCmdStr = null;
            mText = null;
            mIcon = null;
        }

        List<MemberStream> mMemberStreams;
        ToolStripButton mToolStripButton;
        ICommand mCommand;
        string mCmdStr;
        bool mPressed;
        string mText;
        string mIcon;
    }
}
