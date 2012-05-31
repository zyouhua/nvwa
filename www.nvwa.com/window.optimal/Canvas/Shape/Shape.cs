using System.Drawing;

using platform.include;

namespace window.optimal
{
    public abstract class Shape
    {
        public abstract void _drawNormal(Graphics nGraphics);

        public abstract void _drawSelect(Graphics nGraphics);

        public abstract void _drawChoose(Graphics nGraphics);

        public abstract bool _isPull(Point2I nPoint);

        public abstract void _pullBeg(Point2I nPoint);

        public abstract bool _isSelect(Point2I nPoint);

        public abstract void _drawPull(Point2I nPoint, Graphics nGraphics);

        public abstract void _drawMove(Point2I nPoint, Graphics nGraphics);

        public abstract __tuple<Point2I, Point2I> _minMax(Point2I nMin, Point2I nMax);

        public abstract void _pullEnd(Point2I nPoint);

        public abstract bool _isSelect(Point2I nBeg, Point2I nEnd);

        public abstract void _moveVector(Point2I nPoint);
    }
}
