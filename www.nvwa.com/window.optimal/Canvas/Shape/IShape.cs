using System.Drawing;

using window.include;
using platform.include;

namespace window.optimal
{
    public interface IShape
    {
        RectShape _getRectShape(Point2I nPoint, string nId);

        bool _isPull(Point2I nPoint);

        void _pullBeg(Point2I nPoint);

        void _pullMid(Point2I nPoint, Graphics nGraphics);

        void _pullEnd(Point2I nPoint);

        bool _isSelect(Point2I nPoint);

        bool _isSelect(Point2I nBeg, Point2I nEnd);

        void _moveVector(Point2I nPoint);

        void _updatePoint();

        __tuple<Point2I, Point2I> _minMax(Point2I nMin, Point2I nMax);

        bool _drawCreate(Point2I nPoint, string nId, Graphics nGraphics);

        void _drawMove(Point2I nPoint, Graphics nGraphics);

        void _drawNormal(Graphics nGraphics);

        void _drawSelect(Graphics nGraphics);

        void _drawPull(Graphics nGraphics);
    }
}
