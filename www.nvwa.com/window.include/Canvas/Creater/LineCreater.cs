namespace window.include
{
    public abstract class LineCreater : Creater
    {
        public override Action_ _getAction()
        {
            return Action_.mLine_;
        }

        public override object _runCreate()
        {
            ILine result_ = this._exeCreate();
            result_._setBeg(mBeg);
            result_._setEnd(mEnd);
            return result_;
        }

        public abstract ILine _exeCreate();

        public void _setBeg(IRect nRect)
        {
            mBeg = nRect;
        }

        public void _setEnd(IRect nRect)
        {
            mEnd = nRect;
        }

        public abstract string _getBegId();

        public abstract string _getEndId();

        public LineCreater()
        {
            mBeg = null;
            mEnd = null;
        }

        IRect mBeg;
        IRect mEnd;
    }
}
