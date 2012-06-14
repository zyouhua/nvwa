using platform.include;

namespace window.include
{
    public interface ILine : IStyle
    {
        void _updateMove();
        
        void _setName(string nName);

        string _getName();

        void _setBeg(IRect nRect);

        IRect _getBeg();

        void _setEnd(IRect nRect);

        IRect _getEnd();

        void _setBegPoint(Point2I nPoint);

        Point2I _getBegPoint();

        void _setEndPoint(Point2I nPoint);

        Point2I _getEndPoint();
    }
}
