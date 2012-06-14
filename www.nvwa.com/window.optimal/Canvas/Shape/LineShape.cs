using System.Drawing;
using System.Collections.Generic;

using window.include;
using platform.include;

namespace window.optimal
{
    public class LineShape : IShape
    {
        public RectShape _getRectShape(Point2I nPoint, string nId)
        {
            return null;
        }

        public bool _isPull(Point2I nPoint)
        {
            Point2I beg_ = mLine._getBegPoint();
            Point2I end_ = mLine._getEndPoint();
            Line2I line_ = new Line2I(beg_, end_);
            Point2I beg0_ = line_._begPoint(3);
            if (beg0_._isSelect(nPoint))
            {
                return true;
            }
            Point2I end0_ = line_._endPoint(3);
            if (end0_._isSelect(nPoint))
            {
                return true;
            }
            return false;
        }

        public void _pullBeg(Point2I nPoint)
        {
            mPullPoint._setPoint(nPoint);
        }

        public void _pullMid(Point2I nPoint, Graphics nGraphics)
        {
            if (default(int) == mPullPoint._getX() && default(int) == mPullPoint._getY())
            {
                return;
            }
            Line2I line_ = _runPulling(nPoint);
            Point2I beg0_ = line_._begPoint(3);
            Point2I beg1_ = line_._begPoint(6);
            Point2I end0_ = line_._endPoint(3);
            Point2I end1_ = line_._endPoint(6);
            ShapeDescriptorSingleton shapeDescriptorSingleton_ = __singleton<ShapeDescriptorSingleton>._instance();
            Graphicsos._drawEllipse(beg0_, nGraphics, shapeDescriptorSingleton_._selectRGB());
            Graphicsos._drawEllipse(end0_, nGraphics, shapeDescriptorSingleton_._selectRGB());
            Line2I line0_ = new Line2I(beg1_, end1_);
            string name_ = mLine._getName();
            Graphicsos._runDraw(line0_, nGraphics, mLineStream._getMoveDraw(), mLineStream._getStyleName(), 1, mLineStream._getImage(), name_, mLineStream._getFont());
        }

        public void _pullEnd(Point2I nPoint)
        {
            //IRect beg_ = mLine._getBeg();
            //IRect end_ = mLine._getEnd();
            //end_._joinPoint(nPoint)
            //Point2I beg_ = mRectShape._rectJoinPoint(mMouseDown, nPoint);
            //Point2I end_ = rectShape_._rectJoinPoint(nPoint, mMouseDown);
        }

        Line2I _runPulling(Point2I nPoint)
        {
            Point2I beg_ = mLine._getBegPoint();
            Point2I end_ = mLine._getEndPoint();
            if (beg_._isSelect(mPullPoint))
            {
                beg_._setPoint(nPoint);
            }
            if (end_._isSelect(mPullPoint))
            {
                end_._setPoint(nPoint);
            }
            return new Line2I(beg_, end_);
        }

        public bool _isSelect(Point2I nPoint)
        {
            Point2I beg_ = mLine._getBegPoint();
            Point2I end_ = mLine._getEndPoint();
            Line2I line_ = new Line2I(beg_, end_);
            return line_._isSelect(nPoint);
        }

        public bool _isSelect(Point2I nBeg, Point2I nEnd)
        {
            Point2I beg_ = mLine._getBegPoint();
            Point2I end_ = mLine._getEndPoint();
            Line2I line_ = new Line2I(beg_, end_);
            return line_._isSelect(nBeg, nEnd);
        }

        public void _moveVector(Point2I nPoint)
        {
        }

        public void _updatePoint()
        {
            mLine._updateMove();
        }

        public __tuple<Point2I, Point2I> _minMax(Point2I nMin, Point2I nMax)
        {
            Point2I beg_ = mLine._getBegPoint();
            Point2I end_ = mLine._getEndPoint();
            Line2I line_ = new Line2I(beg_, end_);
            return line_._minMax(nMin, nMax);
        }

        public bool _drawCreate(Point2I nPoint, string nId, Graphics nGraphics)
        {
            return false;
        }

        public void _drawMove(Point2I nPoint, Graphics nGraphics)
        {
            Point2I beg_ = mLine._getBegPoint();
            Point2I end_ = mLine._getEndPoint();
            beg_._offset(nPoint);
            end_._offset(nPoint);
            Line2I line_ = new Line2I(beg_, end_);
            string name_ = mLine._getName();
            Graphicsos._runDraw(line_, nGraphics, mLineStream._getMoveDraw(), mLineStream._getStyleName(), 1, mLineStream._getImage(), name_, mLineStream._getFont());
        }

        public void _drawNormal(Graphics nGraphics)
        {
            Point2I beg_ = mLine._getBegPoint();
            Point2I end_ = mLine._getEndPoint();
            Line2I line_ = new Line2I(beg_, end_);
            string name_ = mLine._getName();
            Graphicsos._runDraw(line_, nGraphics, mLineStream._getDraw(), mLineStream._getStyleName(), 1, mLineStream._getImage(), name_, mLineStream._getFont());
        }

        public void _drawSelect(Graphics nGraphics)
        {
            Point2I beg_ = mLine._getBegPoint();
            Point2I end_ = mLine._getEndPoint();
            Line2I line_ = new Line2I(beg_, end_);
            Point2I beg0_ = line_._begPoint(3);
            Point2I beg1_ = line_._begPoint(6);
            Point2I end0_ = line_._endPoint(3);
            Point2I end1_ = line_._endPoint(6);
            ShapeDescriptorSingleton shapeDescriptorSingleton_ = __singleton<ShapeDescriptorSingleton>._instance();
            Graphicsos._fillRectangle(beg0_, nGraphics, shapeDescriptorSingleton_._selectRGB());
            Graphicsos._fillRectangle(end0_, nGraphics, shapeDescriptorSingleton_._selectRGB());
            Line2I line0_ = new Line2I(beg1_, end1_);
            string name_ = mLine._getName();
            Graphicsos._runDraw(line0_, nGraphics, mLineStream._getDraw(), mLineStream._getStyleName(), 1, mLineStream._getImage(), name_, mLineStream._getFont());
        }

        public void _drawPull(Graphics nGraphics)
        {
            if (default(int) != mPullPoint._getX() || default(int) != mPullPoint._getY())
            {
                return;
            }
            Point2I beg_ = mLine._getBegPoint();
            Point2I end_ = mLine._getEndPoint();
            Line2I line_ = new Line2I(beg_, end_);
            Point2I beg0_ = line_._begPoint(3);
            Point2I beg1_ = line_._begPoint(6);
            Point2I end0_ = line_._endPoint(3);
            Point2I end1_ = line_._endPoint(6);
            ShapeDescriptorSingleton shapeDescriptorSingleton_ = __singleton<ShapeDescriptorSingleton>._instance();
            Graphicsos._drawEllipse(beg0_, nGraphics, shapeDescriptorSingleton_._selectRGB());
            Graphicsos._drawEllipse(end0_, nGraphics, shapeDescriptorSingleton_._selectRGB());
            Line2I line0_ = new Line2I(beg1_, end1_);
            string name_ = mLine._getName();
            Graphicsos._runDraw(line0_, nGraphics, mLineStream._getMoveDraw(), mLineStream._getStyleName(), 1, mLineStream._getImage(), name_, mLineStream._getFont());
        }

        public void _setBegPoint(Point2I nPoint)
        {
            mLine._setBegPoint(nPoint);
        }

        public void _setEndPoint(Point2I nPoint)
        {
            mLine._setEndPoint(nPoint);
        }

        public void _initLine(ILine nLine)
        {
            ShapeDescriptorSingleton shapeDescriptorSingleton_ = __singleton<ShapeDescriptorSingleton>._instance();
            mLineStream = shapeDescriptorSingleton_._lineDescriptor(nLine._styleName());
            mLine = nLine;
        }

        public LineShape()
        {
            mPullPoint = new Point2I(default(int), default(int));
            mLineStream = null;
            mLine = null;
        }

        LineStream mLineStream;
        Point2I mPullPoint;
        ILine mLine;
    }
}
