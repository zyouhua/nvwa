using window.include;
using platform.include;

namespace program.optimal
{
    public class ClassShapeTextChangedCommand : AbstractCommand
    {
        public override void _runCommand()
        {
            IForm form_ = this._getOwner() as IForm;
            ITextBox textBox_ = form_._childControl(@"className") as ITextBox;
            IButton button_ = form_._childControl(@"ok") as IButton;
            string text_ = textBox_._getText();
            if (null == text_ || "" == text_)
            {
                button_._setEnable(false);
            }
            else
            {
                button_._setEnable(true);
            }
        }
    }
}
