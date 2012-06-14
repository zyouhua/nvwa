using window.include;

namespace program.optimal
{
    public class DeriveCreator : LineCreater
    {
        public override ILine _exeCreate()
        {
            ProjectCanvas projectCanvas_ = this._getObject() as ProjectCanvas;
            DeriveShape deriveShape_ = new DeriveShape();
            projectCanvas_._addDeriveShape(deriveShape_);
            return deriveShape_;
        }

        public override string _getBegId()
        {
            return @"zyouhua@gmail.com:classShape";
        }

        public override string _getEndId()
        {
            return @"zyouhua@gmail.com:classShape";
        }
    }
}
