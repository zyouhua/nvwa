namespace platform.include
{
    public abstract class AbstractCommand : ICommand
    {
        public abstract void _runCommand();

        public void _setOwner(object nOwner)
        {
            mOwner = nOwner;
        }

        public object _getOwner()
        {
            return mOwner;
        }

        public AbstractCommand()
        {
            mOwner = null;
        }

        object mOwner;
    }
}
