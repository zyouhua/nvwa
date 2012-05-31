namespace window.include
{
    public interface ICanvas : IWidget
    {
        void _setObject(object nObject);

        void _setSideBar(ISideBar nSideBar);
        
        void _setDockStyle(string nDockStyle);
    }
}
