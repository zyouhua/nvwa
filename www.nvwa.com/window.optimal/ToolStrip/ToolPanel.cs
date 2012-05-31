using System.Windows.Forms;
using System.Collections.Generic;

using window.include;
using platform.include;

namespace window.optimal
{
    public class ToolPanel : Widget, IToolPanel
    {
        public override void _serialize(ISerialize nSerialize)
        {
            nSerialize._serialize(ref mDockStyle, @"dockStyle");
            nSerialize._serialize(ref mToolStrips, @"toolStrips");
            base._serialize(nSerialize);
        }

        public override string _virstream()
        {
            return "toolPanel";
        }

        public override void _runInit()
        {
            foreach (ToolStrip i in mToolStrips)
            {
                i._setContain(mContain);
                i._runInit();
            }
            base._runInit();
        }

        public override void _initControl()
        {
            if (null == mToolStripPanel || mToolStripPanel.IsDisposed)
            {
                mToolStripPanel = new ToolStripPanel();
                if (string.Compare(mDockStyle, @"Top") == 0)
                {
                    mToolStripPanel.Dock = DockStyle.Top;
                }
                else if (string.Compare(mDockStyle, @"Bottom") == 0)
                {
                    mToolStripPanel.Dock = DockStyle.Bottom;
                }
                else if (string.Compare(mDockStyle, @"Fill") == 0)
                {
                    mToolStripPanel.Dock = DockStyle.Fill;
                }
                else if (string.Compare(mDockStyle, @"Left") == 0)
                {
                    mToolStripPanel.Dock = DockStyle.Left;
                }
                else if (string.Compare(mDockStyle, @"Right") == 0)
                {
                    mToolStripPanel.Dock = DockStyle.Right;
                }
                else
                {
                    mToolStripPanel.Dock = DockStyle.None;
                }
            }
            foreach (ToolStrip i in mToolStrips)
            {
                i._initControl();
            }
            foreach (ToolStrip i in mToolStrips)
            {
                System.Windows.Forms.ToolStrip toolStrip_ = i._getToolStrip();
                mToolStripPanel.Controls.Add(toolStrip_);
            }
        }

        public override IWidget _createControl()
        {
            return new ToolPanel();
        }

        public override object _getControl()
        {
            return mToolStripPanel;
        }

        public override void _setContain(IContain nContain)
        {
            mContain = nContain;
        }

        public bool _inHide()
        {
            return !mToolStripPanel.Visible;
        }

        public void _runShow()
        {
            mToolStripPanel.Show();
        }

        public void _runHide()
        {
            mToolStripPanel.Hide();
        }

        public void _setDockStyle(string nDockStyle)
        {
            mDockStyle = nDockStyle;
        }

        public string _getDockStyle()
        {
            return mDockStyle;
        }

        public ToolPanel()
        {
            mToolStrips = new List<ToolStrip>();
            mToolStripPanel = null;
            mDockStyle = @"None";
            mContain = null;
        }

        ToolStripPanel mToolStripPanel;
        List<ToolStrip> mToolStrips;
        string mDockStyle;
        IContain mContain;
    }
}
