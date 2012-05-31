using System;
using System.Drawing;
using System.Collections.Generic;

using window.include;
using platform.include;

namespace window.optimal
{
    public class ComboBox : Widget, IComboBox
    {
        public override void _serialize(ISerialize nSerialize)
        {
            nSerialize._serialize(ref mComboBoxItems, "comboBoxItems");
            nSerialize._serialize(ref mPoint, @"point");
            base._serialize(nSerialize);
        }

        public override string _virstream()
        {
            return "comboBox";
        }

        public override void _runInit()
        {
            foreach (ComboBoxItem i in mComboBoxItems)
            {
                i._runInit();
            }
            base._runInit();
        }

        public override void _initControl()
        {
            if (null == mComboBox || mComboBox.IsDisposed)
            {
                mComboBox = new System.Windows.Forms.ComboBox();
                int x_ = mPoint._getX();
                int y_ = mPoint._getY();
                mComboBox.Location = new Point(x_, y_);
                if (null != m_tSelectTextSlot)
                {
                    mComboBox.SelectedText = this.m_tSelectTextSlot();
                }
                foreach (ComboBoxItem i in mComboBoxItems)
                {
                    string name_ = i._getName();
                    ICommand command_ = i._getCommand();
                    mCommands[name_] = command_;
                    mComboBox.Items.Add(name_);
                }
                mComboBox.SelectionChangeCommitted += this._selectionChangeCommitted;
            }
        }

        public override IWidget _createControl()
        {
            return new ComboBox();
        }

        public override object _getControl()
        {
            return mComboBox;
        }

        public override void _setContain(IContain nContain)
        {
            mContain = nContain;
        }
        
        private void _selectionChangeCommitted(object sender, EventArgs e)
        {
            string select_ = mComboBox.SelectedItem as string;
            if (mCommands.ContainsKey(select_))
            {
                ICommand command_ = mCommands[select_];
                if (null != command_)
                {
                    command_._setOwner(mContain);
                    command_._runCommand();
                }
            }
        }

        public ComboBox()
        {
            mComboBoxItems = new List<ComboBoxItem>();
            mCommands = new Dictionary<string, ICommand>();
            m_tSelectTextSlot = null;
            mPoint = new Point2I();
            mComboBox = null;
            mContain = null;
        }

        public event _GetStringSlot m_tSelectTextSlot;
        System.Windows.Forms.ComboBox mComboBox;
        Dictionary<string, ICommand> mCommands;
        List<ComboBoxItem> mComboBoxItems;
        IContain mContain;
        Point2I mPoint;
    }
}
