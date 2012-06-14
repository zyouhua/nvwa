using System.Collections.Generic;

using platform.include;

namespace window.include
{
    public interface ILabel : IRect
    {
        void _offset(Point2I nPoint);

        void _setY(int nY);

        int _getY();

        void _setX(int nX);

        int _getX();

        void _setWidth(int nWidth);

        int _getWidth();

        List<IRect> _getRects();
    }
}
