using System;
using System.Drawing;

using window.include;
using platform.include;

namespace window.optimal
{
    public class RadioButton : Widget
    {
        public override void _serialize(ISerialize nSerialize)
        {
            nSerialize._serialize(ref mCheckCmd, @"checkCommand");
            nSerialize._serialize(ref mPoint, "point");
            nSerialize._serialize(ref mSize, "size");
            nSerialize._serialize(ref mText, "text");
            base._serialize(nSerialize);
        }

        public override string _virstream()
        {
            return @"radioButton";
        }

        public override void _runInit()
        {
            PlatformSingleton platformSingleton_ = __singleton<PlatformSingleton>._instance();
            mCheckCommand = platformSingleton_._findInterface<ICommand>(mCheckCmd);
            base._runInit();
        }

        public override void _initControl()
        {
            if (null == mRadioButton || mRadioButton.IsDisposed)
            {
                mRadioButton = new System.Windows.Forms.RadioButton();
                mRadioButton.Location = new Point(mPoint._getX(), mPoint._getY());
                mRadioButton.Size = new Size(mSize._getWidth(), mSize._getHeight());
                mRadioButton.Text = mText;
                mRadioButton.AutoCheck = false;
                mRadioButton.Click += this._radioButtonClick;
                mRadioButton.CheckedChanged += this._radioButtonCheckedChanged;
            }
        }

        public override IWidget _createControl()
        {
            return new RadioButton();
        }

        public override object _getControl()
        {
            return mRadioButton;
        }

        public override void _setContain(IContain nContain)
        {
            mContain = nContain;
        }

        void _radioButtonClick(object sender, EventArgs e)
        {
            if (mRadioButton.Checked)
            {
                mRadioButton.Checked = false;
            }
            else
            {
                mRadioButton.Checked = true;
            }
        }

        void _radioButtonCheckedChanged(object sender, EventArgs e)
        {
            if (null != mCheckCommand)
            {
                RadioButtonCheckedChangedArg radioButtonCheckedChangedArg_ = new RadioButtonCheckedChangedArg();
                radioButtonCheckedChangedArg_._setChecked(mRadioButton.Checked);
                radioButtonCheckedChangedArg_._setContain(mContain);
                mCheckCommand._setOwner(radioButtonCheckedChangedArg_);
                mCheckCommand._runCommand();
            }
        }

        public RadioButton()
        {
            mCheckCommand = null;
            mCheckCmd = null;
            mRadioButton = null;
            mPoint = new Point2I();
            mSize = new Size2I();
            mContain = null;
            mText = null;
        }

        System.Windows.Forms.RadioButton mRadioButton;
        ICommand mCheckCommand;
        string mCheckCmd;
        IContain mContain;
        Point2I mPoint;
        Size2I mSize;
        string mText;
    }
}
