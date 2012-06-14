using System.Windows.Forms;
using System.Collections.Generic;

using window.include;
using platform.include;

namespace window.optimal
{
    public class ToolStrip : Stream, IUpdate
    {
        public override void _serialize(ISerialize nSerialize)
        {
            nSerialize._serialize(ref mVisible, @"visible");
            nSerialize._serialize(ref mDockStyle, @"dockStyle");
            nSerialize._serialize(ref mToolStripItemAdapts, @"toolStripItems");
            nSerialize._serialize(ref mMemberStreams, @"memberStreams");
        }

        public void _runInit()
        {
            UpdateSingleton updateSingleton_ = __singleton<UpdateSingleton>._instance();
            updateSingleton_._registerUpdate(this);
            foreach (ToolStripItemAdapt i in mToolStripItemAdapts)
            {
                i._setContain(mContain);
                i._runInit();
            }
        }

        public void _initControl()
        {
            if (null == mToolStrip || mToolStrip.IsDisposed)
            {
                ImageSingleton imageSingleton_ = __singleton<ImageSingleton>._instance();
                mToolStrip = new System.Windows.Forms.ToolStrip();
                if (string.Compare(mDockStyle, @"Top") == 0)
                {
                    mToolStrip.Dock = DockStyle.Top;
                }
                else if (string.Compare(mDockStyle, @"Bottom") == 0)
                {
                    mToolStrip.Dock = DockStyle.Bottom;
                }
                else if (string.Compare(mDockStyle, @"Fill") == 0)
                {
                    mToolStrip.Dock = DockStyle.Fill;
                }
                else if (string.Compare(mDockStyle, @"Left") == 0)
                {
                    mToolStrip.Dock = DockStyle.Left;
                }
                else if (string.Compare(mDockStyle, @"Right") == 0)
                {
                    mToolStrip.Dock = DockStyle.Right;
                }
                else
                {
                    mToolStrip.Dock = DockStyle.None;
                }
                mToolStrip.Visible = mVisible;
                foreach (ToolStripItemAdapt i in mToolStripItemAdapts)
                {
                    i._initControl();
                }
                foreach (ToolStripItemAdapt i in mToolStripItemAdapts)
                {
                    System.Windows.Forms.ToolStripItem toolStripItem_ = i._getControl();
                    mToolStrip.Items.Add(toolStripItem_);
                }
            }
        }

        public System.Windows.Forms.ToolStrip _getToolStrip()
        {
            return mToolStrip;
        }

        public void _setContain(IContain nContain)
        {
            mContain = nContain;
        }

        public void _runUpdate()
        {
            if (null == mToolStrip || mToolStrip.IsDisposed)
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
                        mToolStrip.Visible = (!result_);
                    }
                    else
                    {
                        mToolStrip.Visible = result_;
                    }
                }
                else
                {

                }
            }
        }

        public void _setVisible(bool nVisible)
        {
            mVisible = nVisible;
        }

        public bool _getVisible()
        {
            return mVisible;
        }

        public void _setDockStyle(string nDockStyle)
        {
            mDockStyle = nDockStyle;
        }

        public string _getDockStyle()
        {
            return mDockStyle;
        }

        public ToolStrip()
        {
            mMemberStreams = new List<MemberStream>();
            mToolStripItemAdapts = new List<ToolStripItemAdapt>();
            mDockStyle = @"None";
            mToolStrip = null;
            mVisible = false;
            mContain = null;
        }

        System.Windows.Forms.ToolStrip mToolStrip;
        List<MemberStream> mMemberStreams;
        List<ToolStripItemAdapt> mToolStripItemAdapts;
        string mDockStyle;
        IContain mContain;
        bool mVisible;
    }
}
