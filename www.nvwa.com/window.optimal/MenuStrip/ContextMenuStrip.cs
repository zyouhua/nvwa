using System.Windows.Forms;

using window.include;
using System.Collections.Generic;

using platform.include;

namespace window.optimal
{
    public class ContextMenuStrip : Headstream, IContextMenuStrip
    {
        public override void _headSerialize(ISerialize nSerialize)
        {
            nSerialize._serialize(ref mContextMenuItems, @"contextMenuItems");
            base._headSerialize(nSerialize);
        }

        public override string _streamName()
        {
            return "contextMenuStrip";
        }

        public void _runInit()
        {
            foreach (ContextMenuItem i in mContextMenuItems)
            {
                i._setTag(mTag);
                i._runInit();
            }
        }

        public void _initControl()
        {
            if (null == mContextMenuStrip || mContextMenuStrip.IsDisposed)
            {
                mContextMenuStrip = new System.Windows.Forms.ContextMenuStrip();
                foreach (ContextMenuItem i in mContextMenuItems)
                {
                    i._initControl();
                }
                foreach (ContextMenuItem i in mContextMenuItems)
                {
                    ToolStripMenuItem toolStripMenuItem_ = i._getToolStripMenuItem();
                    mContextMenuStrip.Items.Add(toolStripMenuItem_);
                }
            }
        }

        public void _setTag(object nTag)
        {
            mTag = nTag;
        }

        public void _runShow(int nX, int nY)
        {
            mContextMenuStrip.Show(nX, nY);
        }

        public ContextMenuStrip()
        {
            mContextMenuItems = new List<ContextMenuItem>();
            mContextMenuStrip = null;
            mTag = null;
        }

        System.Windows.Forms.ContextMenuStrip mContextMenuStrip;
        List<ContextMenuItem> mContextMenuItems;
        object mTag;
    }
}
