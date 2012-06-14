using window.include;
using platform.include;

namespace program.optimal
{
    public class ClassCreator : LabelCreater
    {
        public override ILabel _exeCreate()
        {
            ProjectCanvas projectCanvas_ = this._getObject() as ProjectCanvas;
            string ClassCreatorDialogUrl_ = "rid://program.optimal.classShapeDialogUrl";
            WindowSingleton windowSingleton_ = __singleton<WindowSingleton>._instance();
            IForm form_ = windowSingleton_._loadForm(ClassCreatorDialogUrl_);
            form_._setTag(projectCanvas_);
            form_._showDialog();
            ClassShape classShape_ = form_._getTag() as ClassShape;
            if (null == classShape_)
            {
                return null;
            }
            string namespace_ = classShape_._getNameSpace();
            string classname_ = classShape_._getName();
            if (null != namespace_)
            {
                projectCanvas_._addClassShape(classShape_);
                return classShape_;
            }
            //if (projectCanvas_.)
            //{
            //}
            projectCanvas_._addClassShape(classShape_);
            return classShape_;
        }
    }
}
