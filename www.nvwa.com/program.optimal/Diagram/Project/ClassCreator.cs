using window.include;

namespace program.optimal
{
    public class ClassCreator : LabelCreater
    {
        public override ILabel _exeCreate()
        {
            ProjectCanvas projectCanvas_ = this._getObject() as ProjectCanvas;
            ClassShape classShape_ = new ClassShape();
            projectCanvas_._addClassShape(classShape_);
            return classShape_;
        }
    }
}
