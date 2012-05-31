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
            throw new System.NotImplementedException();
        }

        public LineCreater()
        {
        }
    }
}
