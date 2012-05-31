namespace platform.include
{
    public interface ICommand
    {
        void _runCommand();

        void _setOwner(object nOwner);

        object _getOwner();
    }
}
