using window.include;
using platform.include;

namespace program.optimal
{
    public class ClassShapeRadioCheckCommand : AbstractCommand
    {
        public override void _runCommand()
        {
            RadioButtonCheckedChangedArg radioButtonCheckedChangedArg_ = this._getOwner() as RadioButtonCheckedChangedArg;
            IForm form_ = radioButtonCheckedChangedArg_._getContain() as IForm;
            bool checked_ = radioButtonCheckedChangedArg_._getChecked();
            IComboBox comboBox_ = form_._childControl("comboBox1") as IComboBox;
            if (checked_)
            {
                comboBox_._setEnable(true);
            }
            else
            {
                comboBox_._setEnable(false);
            }
        }
    }
}
