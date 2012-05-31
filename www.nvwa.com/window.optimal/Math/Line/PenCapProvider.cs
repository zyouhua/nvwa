using System.Drawing;
using System.Drawing.Drawing2D;

namespace window.optimal
{
    public class PenCapProvider
    {
        public CustomLineCap _getSingleCap()
        {
            if (null == mSingleCap)
            {
                int width_ = 6;
                int height_ = 10;
                int span_ = 10;
                GraphicsPath path_ = new GraphicsPath();
                path_.StartFigure();
                path_.AddPolygon(new PointF[]{
                    new PointF(0, 0),
                    new PointF(width_/2, height_),
                    new PointF(width_,0)
                });
                Matrix matrix_ = new Matrix();
                matrix_.Translate(-width_ / 2, -span_);
                path_.Transform(matrix_);
                mSingleCap = new CustomLineCap(null, path_);
                mSingleCap.BaseInset = span_;
            }
            return mSingleCap;
        }

        public CustomLineCap _getMultiCap()
        {
            if (null == mMultiCap)
            {
                int width_ = 6;
                int height_ = 10;
                int span_ = height_ + width_ / 2;
                GraphicsPath path_ = new GraphicsPath();
                path_.StartFigure();
                path_.AddPolygon(new PointF[]{
                    new PointF(0, 0),
                    new PointF(width_/2, height_),
                    new PointF(width_, 0)
                });
                GraphicsPath capPath_ = path_.Clone() as GraphicsPath;
                capPath_.AddEllipse(new Rectangle(width_ / 4, height_, width_ / 2, width_ / 2));
                Matrix matrix_ = new Matrix();
                matrix_.Translate(-width_ / 2, -span_);
                capPath_.Transform(matrix_);
                mMultiCap = new CustomLineCap(null, capPath_);
                mMultiCap.BaseInset = span_;
            }
            return mMultiCap;
        }

        public CustomLineCap _getAggrCap()
        {
            if (null == mAggrCap)
            {
                int span_ = 10;
                int width_ = 10;
                int height_ = 10;
                GraphicsPath path_ = new GraphicsPath();
                path_.StartFigure();
                path_.AddPolygon(new PointF[] {
                    new PointF(0, height_/2),
                    new PointF(width_/2, height_),
                    new PointF(width_,height_/2),
                    new PointF(width_/2,0)
                });
                path_.CloseFigure();
                Matrix matrix_ = new Matrix();
                matrix_.Translate(-height_ / 2, -span_);
                path_.Transform(matrix_);
                mAggrCap = new CustomLineCap(null, path_);
                mAggrCap.BaseInset = span_;
            }
            return mAggrCap;
        }

        public CustomLineCap _getInhCap()
        {
            if (null == mInhCap)
            {
                int x_ = 5;
                int y_ = 10;
                int span_ = 2 * y_;
                GraphicsPath path_ = new GraphicsPath();
                path_.StartFigure();
                path_.AddPolygon(new Point[]{
                    new Point(0, y_),
                    new Point(x_, 0),
                    new Point(y_, y_)
                });
                path_.AddLine(x_, y_, x_, span_);
                path_.CloseFigure();
                Matrix matrix_ = new Matrix();
                matrix_.Translate(-x_, -span_);
                path_.Transform(matrix_);
                mInhCap = new CustomLineCap(null, path_);
                mInhCap.BaseInset = span_;
            }
            return mInhCap;
        }

        public PenCapProvider()
        {
            mMultiCap = null;
            mAggrCap = null;
            mInhCap = null;
            mSingleCap = null;
        }

        CustomLineCap mMultiCap;
        CustomLineCap mAggrCap;
        CustomLineCap mInhCap;
        CustomLineCap mSingleCap;
    }
}
