using System.Drawing;
using System.Windows.Forms;
using System.Collections.Generic;
using WeifenLuo.WinFormsUI.Docking;

using window.include;
using platform.include;

namespace window.optimal
{
    public class Form : Contain, IForm
    {
        public event _SerializeSlot m_tHeadSerializeSlot;

        public void _headSerialize(ISerialize nSerialize)
        {
            if (null != m_tHeadSerializeSlot)
            {
                m_tHeadSerializeSlot(nSerialize);
            }
            nSerialize._serialize(ref mInitCmd, @"initCommand");
            nSerialize._serialize(ref mLoadCmd, @"loadCommand");
            nSerialize._serialize(ref mSize, @"size");
            nSerialize._serialize(ref mIconUrl, @"icon");
            nSerialize._serialize(ref mCaption, @"caption");
            nSerialize._serialize(ref mStartPosition, @"startPosition");
            nSerialize._serialize(ref mBorderStyle, @"borderStyle");
            base._serialize(nSerialize);
        }

        public string _streamName()
        {
            if (null != m_tStreamNameSlot)
            {
                return m_tStreamNameSlot();
            }
            return @"form";
        }

        public event _SerializeTypeSlot m_tSerializeTypeSlot;

        public SerializeType_ _serializeType()
        {
            if (null != m_tSerializeTypeSlot)
            {
                return m_tSerializeTypeSlot();
            }
            return SerializeType_.mXml_;
        }

        public event _GetStringSlot m_tStreamNameSlot;

        public override void _runInit()
        {
            PlatformSingleton platformSingleton_ = __singleton<PlatformSingleton>._instance();
            mInitCommand = platformSingleton_._findInterface<ICommand>(mInitCmd);
            if (null != mInitCommand)
            {
                mInitCommand._setOwner(this);
                mInitCommand._runCommand();
            }
            mLoadCommand = platformSingleton_._findInterface<ICommand>(mLoadCmd);
            if (null != mLoadCommand)
            {
                mLoadCommand._setOwner(this);
            }
            base._runInit();
        }

        public override void _initControl()
        {
            if (null == mForm || mForm.IsDisposed)
            {
                mForm = new System.Windows.Forms.Form();
                mForm.Text = mCaption;
                mForm.Width = mSize._getWidth();
                mForm.Height = mSize._getHeight();
                mForm.KeyDown += _keyDown;
                if (mStartPosition == @"CenterParent")
                {
                    mForm.StartPosition = FormStartPosition.CenterParent;
                }
                else if (mStartPosition == @"CenterScreen")
                {
                    mForm.StartPosition = FormStartPosition.CenterScreen;
                }
                else if (mStartPosition == @"WindowsDefaultLocation")
                {
                    mForm.StartPosition = FormStartPosition.WindowsDefaultLocation;
                }
                else if (mStartPosition == @"WindowsDefaultBounds")
                {
                    mForm.StartPosition = FormStartPosition.WindowsDefaultBounds;
                }
                else
                {
                    mForm.StartPosition = FormStartPosition.Manual;
                }
                if (mBorderStyle == @"Fixed3D")
                {
                    mForm.FormBorderStyle = FormBorderStyle.Fixed3D;
                }
                else if (mBorderStyle == @"FixedDialog")
                {
                    mForm.FormBorderStyle = FormBorderStyle.FixedDialog;
                }
                else if (mBorderStyle == @"FixedSingle")
                {
                    mForm.FormBorderStyle = FormBorderStyle.FixedSingle;
                }
                else if (mBorderStyle == @"FixedToolWindow")
                {
                    mForm.FormBorderStyle = FormBorderStyle.FixedToolWindow;
                }
                else if (mBorderStyle == @"None")
                {
                    mForm.FormBorderStyle = FormBorderStyle.None;
                }
                else if (mBorderStyle == @"SizableToolWindow")
                {
                    mForm.FormBorderStyle = FormBorderStyle.SizableToolWindow;
                }
                else
                {
                    mForm.FormBorderStyle = FormBorderStyle.Sizable;
                }
                PlatformSingleton platformSingleton_ = __singleton<PlatformSingleton>._instance();
                mForm.Icon = (Icon)platformSingleton_._findIcon(mIconUrl);
                if (null != mLoadCommand)
                {
                    mLoadCommand._runCommand();
                }
            }
            base._initControl();
        }

        public override void _addControl(object nControl)
        {
            System.Windows.Forms.Control control_ = nControl as System.Windows.Forms.Control;
            mForm.Controls.Add(control_);
        }

        public override IContain _contain(int nLevel = 0)
        {
            return null;
        }

        public void _setTag(object nTag)
        {
            mTag = nTag;
        }

        public object _getTag()
        {
            return mTag;
        }

        public void _appShow()
        {
            this._initControl();
            Application.Run(mForm);
        }

        public void _runShow()
        {
            this._initControl();
            mForm.Show();
        }

        public void _showDialog()
        {
            this._initControl();
            mForm.ShowDialog();
        }

        public void _runClose()
        {
            if (null == mForm || mForm.IsDisposed)
            {
                return;
            }
            mForm.Close();
        }

        public void _setSize(Size2I nSize)
        {
            mSize._setWidth(nSize._getWidth());
            mSize._setHeight(nSize._getHeight());
        }

        public Size2I _getSize()
        {
            return mSize;
        }

        public void _setCaption(string nCaption)
        {
            mCaption = nCaption;
        }

        public string _getCaption()
        {
            return mCaption;
        }

        public void _setStartPosition(string nStartPosition)
        {
            mStartPosition = nStartPosition;
        }

        public string _getStartPosition()
        {
            return mStartPosition;
        }

        public void _setBorderStyle(string nBorderStyle)
        {
            mBorderStyle = nBorderStyle;
        }

        public string _getBorderStyle()
        {
            return mBorderStyle;
        }

        public void _setIconUrl(string nIconUrl)
        {
            mIconUrl = nIconUrl;
        }

        public string _getIconUrl()
        {
            return mIconUrl;
        }

        void _keyDown(object sender, KeyEventArgs e)
        {
        }

        public Form()
        {
            m_tSerializeTypeSlot = null;
            m_tHeadSerializeSlot = null;
            mForm = null;
            mSize = null;
            mCaption = null;
            mStartPosition = null;
            mBorderStyle = null;
            mIconUrl = null;
            mTag = null;
            mInitCommand = null;
            mInitCmd = null;
            mLoadCommand = null;
            mLoadCmd = null;
        }

        System.Windows.Forms.Form mForm;
        ICommand mInitCommand;
        string mInitCmd;
        ICommand mLoadCommand;
        string mLoadCmd;
        Size2I mSize;
        string mCaption;
        string mStartPosition;
        string mBorderStyle;
        string mIconUrl;
        object mTag;
    }
}
