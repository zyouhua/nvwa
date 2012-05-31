namespace window.include
{
    public interface IDockWidget
    {
        void _initControl();

        IWidget _getControl();

        string _dockName();
    }
}
