using System;
using System.Collections.Generic;

using window.include;
using platform.include;

namespace window.optimal
{
    public class ToolStripComboBox : ToolStripItem
    {
        public override void _serialize(ISerialize nSerialize)
        {
            nSerialize._serialize(ref mToolStripComboBoxItems, "toolStripComboBoxItems");
            nSerialize._serialize(ref mMemberStreams, "memberStreams");
        }

        public override void _runInit()
        {
            foreach (ToolStripComboBoxItem i in mToolStripComboBoxItems)
            {
                i._runInit();
            }
            base._runInit();
        }

        public override void _initControl()
        {
            if (null == mToolStripComboBox || mToolStripComboBox.IsDisposed)
            {
                mToolStripComboBox = new System.Windows.Forms.ToolStripComboBox();
                foreach (ToolStripComboBoxItem i in mToolStripComboBoxItems)
                {
                    string text_ = i._getText();
                    ICommand command_ = i._getCommand();
                    mCommands[text_] = command_;
                    mToolStripComboBox.Items.Add(text_);
                }
                mToolStripComboBox.SelectedIndexChanged += this._selectedIndexChanged;
            }
        }

        public override System.Windows.Forms.ToolStripItem _getToolStripItem()
        {
            return mToolStripComboBox;
        }

        public override void _runUpdate()
        {
            if (null == mToolStripComboBox || mToolStripComboBox.IsDisposed)
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
                        mToolStripComboBox.Visible = (!result_);
                    }
                    else
                    {
                        mToolStripComboBox.Visible = result_;
                    }
                }
                else if (@"enable" == name_)
                {
                    if (@"false" == value_)
                    {
                        mToolStripComboBox.Enabled = (!result_);
                    }
                    else
                    {
                        mToolStripComboBox.Enabled = result_;
                    }
                }
                else
                {
                }
            }
        }

        void _selectedIndexChanged(object obj, EventArgs e)
        {
            string select_ = mToolStripComboBox.SelectedItem as string;
            if (mCommands.ContainsKey(select_))
            {
                ICommand command_ = mCommands[select_];
                if (null != command_)
                {
                    IContain contain_ = this._getContain();
                    command_._setOwner(contain_);
                    command_._runCommand();
                }
            }
        }

        public ToolStripComboBox()
        {
            mToolStripComboBoxItems = new List<ToolStripComboBoxItem>();
            mMemberStreams = new List<MemberStream>();
            mCommands = new Dictionary<string, ICommand>();
            mToolStripComboBox = null;
        }

        System.Windows.Forms.ToolStripComboBox mToolStripComboBox;
        List<ToolStripComboBoxItem> mToolStripComboBoxItems;
        List<MemberStream> mMemberStreams;
        Dictionary<string, ICommand> mCommands;
    }
}
