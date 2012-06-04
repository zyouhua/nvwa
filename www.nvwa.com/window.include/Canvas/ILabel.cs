using System.Collections.Generic;

namespace window.include
{
    public interface ILabel : IRect
    {
        void _setY(int nY);

        int _getY();

        void _setX(int nX);

        int _getX();

        void _setWidth(int nWidth);

        int _getWidth();

        List<IRect> _getRects();
    }
}
