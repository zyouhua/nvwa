namespace window.include
{
    public abstract class LabelCreater : Creater
    {
        public override Action_ _getAction()
        {
            return Action_.mLabel_;
        }

        public override object _runCreate()
        {
            ILabel result_ = this._exeCreate();
            result_._setX(mX);
            result_._setY(mY);
            return result_;
        }

        public abstract ILabel _exeCreate();

        public void _setX(int nX)
        {
            mX = nX;
        }

        public void _setY(int nY)
        {
            mY = nY;
        }

        public LabelCreater()
        {
            mX = 0;
            mY = 0;
        }

        int mX;
        int mY;
    }
}
