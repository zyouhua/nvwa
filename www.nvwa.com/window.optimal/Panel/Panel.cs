using window.include;
using platform.include;

namespace window.optimal
{
    public class Panel : Control, IPanel
    {
        public event _SerializeSlot m_tHeadSerializeSlot;

        public void _headSerialize(ISerialize nSerialize)
        {
            if (null != m_tHeadSerializeSlot)
            {
                this.m_tHeadSerializeSlot(nSerialize);
            }
            this._serialize(nSerialize);
        }

        public event _SerializeTypeSlot m_tSerializeTypeSlot;

        public SerializeType_ _serializeType()
        {
            if (null != m_tSerializeTypeSlot)
            {
                return this.m_tSerializeTypeSlot();
            }
            return SerializeType_.mXml_;
        }

        public event _GetStringSlot m_tStreamNameSlot;

        public string _streamName()
        {
            if (null != m_tStreamNameSlot)
            {
                return this.m_tStreamNameSlot();
            }
            return _virstream();
        }

        public override void _serialize(ISerialize nSerialize)
        {
            nSerialize._serialize(ref mBackColor, "backColor");
            nSerialize._serialize(ref mAutoScroll, "autoScroll");
            nSerialize._serialize(ref mDockStyle, @"dockStyle");
            nSerialize._serialize(ref mSize, @"size");
            base._serialize(nSerialize);
        }

        public override string _virstream()
        {
            return @"panel";
        }

        public override void _initControl()
        {
            if (null == mPanel || mPanel.IsDisposed)
            {
                mPanel = new System.Windows.Forms.Panel();
                if (string.Compare(mDockStyle, @"Top") == 0)
                {
                    mPanel.Dock = System.Windows.Forms.DockStyle.Top;
                }
                else if (string.Compare(mDockStyle, @"Bottom") == 0)
                {
                    mPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
                }
                else if (string.Compare(mDockStyle, @"Fill") == 0)
                {
                    mPanel.Dock = System.Windows.Forms.DockStyle.Fill;
                }
                else if (string.Compare(mDockStyle, @"Left") == 0)
                {
                    mPanel.Dock = System.Windows.Forms.DockStyle.Left;
                }
                else if (string.Compare(mDockStyle, @"Right") == 0)
                {
                    mPanel.Dock = System.Windows.Forms.DockStyle.Right;
                }
                else
                {
                    mPanel.Dock = System.Windows.Forms.DockStyle.None;
                }
                mPanel.AutoScroll = mAutoScroll;
                if (null != mBackColor)
                {
                    mPanel.BackColor = mBackColor._getColor();
                }
                if (null != mSize)
                {
                    mPanel.Width = mSize._getWidth();
                    mPanel.Height = mSize._getHeight();
                }
            }
            base._initControl();
        }

        public override IWidget _createControl()
        {
            return new Panel();
        }

        public override object _getControl()
        {
            return mPanel;
        }

        public override void _addControl(object nControl)
        {
            System.Windows.Forms.Control control_ = nControl as System.Windows.Forms.Control;
            mPanel.Controls.Add(control_);
        }

        public void _setAutoScroll(bool nAutoScroll)
        {
            mAutoScroll = nAutoScroll;
            base._runDirty();
        }

        public bool _getAutoScroll()
        {
            return mAutoScroll;
        }

        public void _setDockStyle(string nDockStyle)
        {
            mDockStyle = nDockStyle;
        }

        public string _getDockStyle()
        {
            return mDockStyle;
        }

        public void _setBackColor(RGB nRGB)
        {
            mBackColor._setRGB(nRGB);
        }

        public RGB _getBackColor()
        {
            return mBackColor;
        }

        public Panel()
        {
            mBackColor = null;
            mDockStyle = @"None";
            mAutoScroll = false;
            mPanel = null;
            mSize = null;
        }

        System.Windows.Forms.Panel mPanel;
        string mDockStyle;
        RGB mBackColor;
        bool mAutoScroll;
        Size2I mSize;
    }
}
