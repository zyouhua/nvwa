using System.Windows.Forms;

using window.include;
using platform.include;

namespace program.optimal
{
    public class ClassShapeOkCommand : AbstractCommand
    {
        public override void _runCommand()
        {
            IForm form_ = this._getOwner() as IForm;
            ITextBox textBox_ = form_._childControl(@"className") as ITextBox;
            string text_ = textBox_._getText();
            string name_ = StringFormat._className(text_);
            if (null == name_)
            {
                MessageBox.Show(@"类名不合法!");
                return;
            }
            string namespace_ = null;
            IComboBox comboBox_ = form_._childControl(@"comboBox1") as IComboBox;
            if (comboBox_._isEnable())
            {
                namespace_ = comboBox_._getSelectText();
            }
            ClassShape classShape_ = null;
            if (null != namespace_)
            {
                classShape_ = new ClassShape();
                classShape_._setNameSpace(namespace_);
                classShape_._setName(name_);
                form_._setTag(classShape_);
                form_._runClose();
                return;
            }
            ProjectCanvas projectCanvas_ = form_._getTag() as ProjectCanvas;
            //projectCanvas_.
            //MessageBox.Show(@"")
            classShape_ = new ClassShape();
            classShape_._setName(name_);
            form_._setTag(classShape_);
            form_._runClose();
        }
    }
}
