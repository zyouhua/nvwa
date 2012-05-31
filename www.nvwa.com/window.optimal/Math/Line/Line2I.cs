using System;
using System.Drawing;
using System.Drawing.Drawing2D;

using platform.include;

namespace window.optimal
{
    public class Line2I : Stream
    {
        public void _drawBroken(Graphics nGraphics, Pen nPen, bool nStart = true)
        {
            float length_ = this._length();
            if (length_ < 6)
            {
                GraphicsState graphicsState0_ = nGraphics.Save();
                nGraphics.SmoothingMode = SmoothingMode.HighQuality;
                nGraphics.DrawLine(nPen, mBeg._getX(), mBeg._getY(), mEnd._getX(), mEnd._getY());
                nGraphics.Restore(graphicsState0_);
                return;
            }
            Point2I point_ = this._vector();
            PointF f = new PointF();
            f.X = point_._getX() / length_;
            f.Y = point_._getY() / length_;
            GraphicsState graphicsState1_ = nGraphics.Save();
            nGraphics.SmoothingMode = SmoothingMode.HighQuality;
            if (nStart)
            {
                for (int i = 0; i < (length_ - 1); i += 8)
                {
                    Point beg_ = new Point();
                    beg_.X = (int)(i * f.X + mBeg._getX());
                    beg_.Y = (int)(i * f.Y + mBeg._getY());
                    int k = i + 2;
                    Point end_ = new Point();
                    end_.X = (int)(k * f.X + mBeg._getX());
                    end_.Y = (int)(k * f.Y + mBeg._getY());
                    nGraphics.DrawLine(nPen, beg_, end_);
                }
            }
            else
            {
                for (int i = 0; i < (length_ - 1); i += 8)
                {
                    Point beg_ = new Point();
                    int l = i + 4;
                    beg_.X = (int)(l * f.X + mBeg._getX());
                    beg_.Y = (int)(l * f.Y + mBeg._getY());
                    Point end_ = new Point();
                    int k = i + 6;
                    end_.X = (int)(k * f.X + mBeg._getX());
                    end_.Y = (int)(k * f.Y + mBeg._getY());
                    nGraphics.DrawLine(nPen, beg_, end_);
                }
            }
            nGraphics.Restore(graphicsState1_);
        }

        public void _drawSelect(Graphics nGraphics, Color nColor, Color nSelect, Image nImage = null, LineType_ nLineType = LineType_.mNormal_, int nWidth = 1)
        {
            Point2I beg0_ = _begPoint(3);
            Point2I beg1_ = _begPoint(6);
            Point2I end0_ = _endPoint(3);
            Point2I end1_ = _endPoint(6);
            beg0_._drawEllipse(nGraphics, new Pen(nSelect));
            end0_._drawEllipse(nGraphics, new Pen(nSelect));
            Line2I line_ = new Line2I(beg1_, end1_);
            line_._drawLine(nGraphics, nColor, nImage, nLineType, nWidth);
        }

        public void _drawLine(Graphics nGraphics, Color nColor, Image nImage = null, LineType_ nLineType = LineType_.mNormal_, int nWidth = 1)
        {
            PenCapProvider penCapProvider_ = __singleton<PenCapProvider>._instance();
            Pen pen_ = new Pen(nColor, nWidth);
            if (LineType_.mMultiEnd_ == nLineType)
            {
                pen_.CustomEndCap = penCapProvider_._getMultiCap();
            }
            else if (LineType_.mMultiBeg_ == nLineType)
            {
                pen_.CustomStartCap = penCapProvider_._getMultiCap();
            }
            else if (LineType_.mMultiMulti_ == nLineType)
            {
                pen_.CustomStartCap = penCapProvider_._getMultiCap();
                pen_.CustomEndCap = penCapProvider_._getMultiCap();
            }
            else if (LineType_.mMultiAggr_ == nLineType)
            {
                pen_.CustomStartCap = penCapProvider_._getMultiCap();
                pen_.CustomEndCap = penCapProvider_._getAggrCap();
            }
            else if (LineType_.mMultiInh_ == nLineType)
            {
                pen_.CustomStartCap = penCapProvider_._getMultiCap();
                pen_.CustomEndCap = penCapProvider_._getInhCap();
            }
            else if (LineType_.mMultiSingle_ == nLineType)
            {
                pen_.CustomStartCap = penCapProvider_._getMultiCap();
                pen_.CustomEndCap = penCapProvider_._getSingleCap();
            }
            else if (LineType_.mAggrEnd_ == nLineType)
            {
                pen_.CustomEndCap = penCapProvider_._getAggrCap();
            }
            else if (LineType_.mAggrBeg_ == nLineType)
            {
                pen_.CustomStartCap = penCapProvider_._getAggrCap();
            }
            else if (LineType_.mAggrMulti_ == nLineType)
            {
                pen_.CustomStartCap = penCapProvider_._getAggrCap();
                pen_.CustomEndCap = penCapProvider_._getMultiCap();
            }
            else if (LineType_.mAggrAggr_ == nLineType)
            {
                pen_.CustomStartCap = penCapProvider_._getAggrCap();
                pen_.CustomEndCap = penCapProvider_._getAggrCap();
            }
            else if (LineType_.mAggrInh_ == nLineType)
            {
                pen_.CustomStartCap = penCapProvider_._getAggrCap();
                pen_.CustomEndCap = penCapProvider_._getInhCap();
            }
            else if (LineType_.mAggrSingle_ == nLineType)
            {
                pen_.CustomStartCap = penCapProvider_._getAggrCap();
                pen_.CustomEndCap = penCapProvider_._getSingleCap();
            }
            else if (LineType_.mInhEnd_ == nLineType)
            {
                pen_.CustomEndCap = penCapProvider_._getInhCap();
            }
            else if (LineType_.mInhBeg_ == nLineType)
            {
                pen_.CustomStartCap = penCapProvider_._getInhCap();
            }
            else if (LineType_.mInhMulti_ == nLineType)
            {
                pen_.CustomStartCap = penCapProvider_._getInhCap();
                pen_.CustomEndCap = penCapProvider_._getMultiCap();
            }
            else if (LineType_.mInhAggr_ == nLineType)
            {
                pen_.CustomStartCap = penCapProvider_._getInhCap();
                pen_.CustomEndCap = penCapProvider_._getAggrCap();
            }
            else if (LineType_.mInhInh_ == nLineType)
            {
                pen_.CustomStartCap = penCapProvider_._getInhCap();
                pen_.CustomEndCap = penCapProvider_._getInhCap();
            }
            else if (LineType_.mInhSingle_ == nLineType)
            {
                pen_.CustomStartCap = penCapProvider_._getInhCap();
                pen_.CustomEndCap = penCapProvider_._getSingleCap();
            }
            else if (LineType_.mSingleEnd_ == nLineType)
            {
                pen_.CustomEndCap = penCapProvider_._getSingleCap();
            }
            else if (LineType_.mSingleBeg_ == nLineType)
            {
                pen_.CustomStartCap = penCapProvider_._getSingleCap();
            }
            else if (LineType_.mSingleMulti_ == nLineType)
            {
                pen_.CustomStartCap = penCapProvider_._getSingleCap();
                pen_.CustomEndCap = penCapProvider_._getMultiCap();
            }
            else if (LineType_.mSingleAggr_ == nLineType)
            {
                pen_.CustomStartCap = penCapProvider_._getSingleCap();
                pen_.CustomEndCap = penCapProvider_._getAggrCap();
            }
            else if (LineType_.mSingleInh_ == nLineType)
            {
                pen_.CustomStartCap = penCapProvider_._getSingleCap();
                pen_.CustomEndCap = penCapProvider_._getInhCap();
            }
            else if (LineType_.mSingleSingle_ == nLineType)
            {
                pen_.CustomStartCap = penCapProvider_._getSingleCap();
                pen_.CustomEndCap = penCapProvider_._getSingleCap();
            }
            else
            {
            }
            GraphicsState graphicsState_ = nGraphics.Save();
            nGraphics.SmoothingMode = SmoothingMode.HighQuality;
            nGraphics.DrawLine(pen_, mBeg._getX(), mBeg._getY(), mEnd._getX(), mEnd._getY());
            nGraphics.Restore(graphicsState_);
            if (null == nImage)
            {
                return;
            }
            Point2I imagePoint_ = this._begPoint(10);
            if (null == imagePoint_)
            {
                return;
            }
            nGraphics.DrawImage(nImage, imagePoint_._getX(), imagePoint_._getY(), 15, 15);
        }

        public void _drawPull(Point2I nPullPoint, Image nImage, Point2I nPoint, Graphics nGraphics, Color nColor, Color nSelect, LineType_ nLineType = LineType_.mNormal_, int nWidth = 1)
        {
            if (mBeg._isSelect(nPullPoint))
            {
                mBeg._setPoint(nPoint);
            }
            if (mEnd._isSelect(nPullPoint))
            {
                mEnd._setPoint(nPoint);
            }
            this._drawSelect(nGraphics, nColor, nSelect, nImage, nLineType, nWidth);
        }

        public bool _isSelect(Point2I nBeg, Point2I nEnd)
        {
            Rect2I rect_ = new Rect2I(nBeg, nEnd);
            return rect_._intersectWith(this);
        }

        public int _yPoint(int nX)
        {
            int result_ = default(int);
            int y2_ = mEnd._getY();
            int x2_ = mEnd._getX();
            int y0_ = mBeg._getY();
            int x0_ = mBeg._getX();
            long y_ = (nX - x0_) * (y2_ - y0_);
            int x_ = x2_ - x0_;
            result_ = (int)(y_ / x_);
            result_ += y0_;
            return result_;
        }

        public int _xPoint(int nY)
        {
            int result_ = default(int);
            int y2_ = mEnd._getY();
            int x2_ = mEnd._getX();
            int y0_ = mBeg._getY();
            int x0_ = mBeg._getX();
            long y_ = (nY - y0_) * (x2_ - x0_);
            int x_ = y2_ - y0_;
            result_ = (int)(y_ / x_);
            result_ += x0_;
            return result_;
        }

        public Point2I _begPoint(int nLength = 16)
        {
            Point2I point_ = this._vector();
            float length_ = this._length();
            if (length_ < nLength)
            {
                return null;
            }
            PointF f = new PointF();
            f.X = point_._getX() / length_;
            f.Y = point_._getY() / length_;
            Point2I result_ = new Point2I();
            result_._setX((int)(nLength * f.X + mBeg._getX()));
            result_._setY((int)(nLength * f.Y + mBeg._getY()));
            return result_;
        }

        public Point2I _endPoint(int nLength = 16)
        {
            Point2I point_ = this._deVector();
            float length_ = this._length();
            if (length_ < nLength)
            {
                return null;
            }
            PointF f = new PointF();
            f.X = point_._getX() / length_;
            f.Y = point_._getY() / length_;
            Point2I result_ = new Point2I();
            result_._setX((int)(nLength * f.X + mEnd._getX()));
            result_._setY((int)(nLength * f.Y + mEnd._getY()));
            return result_;
        }

        public bool _isSelect(Point2I nPoint, int nDistance = 3)
        {
            return _isSelect(nPoint._getX(), nPoint._getY(), nDistance);
        }

        public bool _isSelect(int nX, int nY, int nDistance = 3)
        {
            int begX_ = mBeg._getX();
            int begY_ = mBeg._getY();
            int endX_ = mEnd._getX();
            int endY_ = mEnd._getY();
            int x0_ = default(int);
            int y0_ = default(int);
            int x1_ = default(int);
            int y1_ = default(int);
            if (begX_ < endX_)
            {
                x0_ = begX_;
                x1_ = endX_;
            }
            else
            {
                x0_ = endX_;
                x1_ = begX_;
            }
            if (begY_ < endY_)
            {
                y0_ = begY_;
                y1_ = endY_;
            }
            else
            {
                y0_ = endY_;
                y1_ = begY_;
            }
            if ((nX < x0_) && (nY < y0_))
            {
                return false;
            }
            if ((nX > x1_) && (nY > y1_))
            {
                return false;
            }
            double distance_ = this._distance(nX, nY);
            if (distance_ < nDistance)
            {
                return true;
            }
            return false;
        }

        public double _distance(Point2I nPoint)
        {
            return this._distance(nPoint._getX(), nPoint._getY());
        }

        public double _distance(int nX, int nY)
        {
            int begX_ = mBeg._getX();
            int begY_ = mBeg._getY();
            int endX_ = mEnd._getX();
            int endY_ = mEnd._getY();
            double result_ = 0;
            if (begX_ == endX_)
            {
                result_ = Math.Abs(nX - begX_);
                return result_;
            }
            if (begY_ == endY_)
            {
                result_ = Math.Abs(nY - begY_);
                return result_;
            }
            double a_ = (endY_ - begY_) * (endX_ - nX);
            double b_ = (nY - endY_) * (endX_ - endX_);
            double y_ = Math.Abs(a_ + b_);
            double c_ = (endX_ - begX_) * (endX_ - begX_);
            double d_ = (endY_ - begY_) * (endY_ - begY_);
            double x_ = Math.Sqrt(c_ + d_);
            result_ = y_ / x_;
            return result_;
        }

        public __tuple<Point2I, Point2I> _minMax(Point2I nMin, Point2I nMax)
        {
            __tuple<Point2I, Point2I> tuple0_ = mBeg._minMax(mEnd);
            Point2I min0_ = tuple0_._get_0();
            Point2I max0_ = tuple0_._get_1();
            __tuple<Point2I, Point2I> tuple1_ = min0_._minMax(nMin);
            __tuple<Point2I, Point2I> tuple2_ = max0_._minMax(nMax);
            Point2I min_ = tuple1_._get_0();
            Point2I max_ = tuple2_._get_1();
            return new __tuple<Point2I, Point2I>(min_, max_);
        }

        public void _begOffset(Point2I nPoint)
        {
            this._begOffset(nPoint._getX(), nPoint._getY());
        }

        public void _begOffset(int nX, int nY)
        {
            mBeg._offset(nX, nY);
        }

        public void _endOffset(Point2I nPoint)
        {
            this._endOffset(nPoint._getX(), nPoint._getY());
        }

        public void _endOffset(int nX, int nY)
        {
            mEnd._offset(nX, nY);
        }

        public void _offset(Point2I nPoint)
        {
            this._offset(nPoint._getX(), nPoint._getY());
        }

        public void _offset(int nX, int nY)
        {
            mBeg._offset(nX, nY);
            mEnd._offset(nX, nY);
        }

        public Point2I _vector()
        {
            int x_ = mEnd._getX() - mBeg._getX();
            int y_ = mEnd._getY() - mBeg._getY();
            Point2I result_ = new Point2I(x_, y_);
            return result_;
        }

        public Point2I _deVector()
        {
            int x_ = mBeg._getX() - mEnd._getX();
            int y_ = mBeg._getY() - mEnd._getY();
            Point2I result_ = new Point2I(x_, y_);
            return result_;
        }

        public float _length()
        {
            float result_ = (float)mBeg._length(mEnd);
            return result_;
        }

        public override void _serialize(ISerialize nSerialize)
        {
            nSerialize._serialize(ref mBeg, "beg");
            nSerialize._serialize(ref mEnd, "end");
        }

        public void _setLine(Line2I nLine)
        {
            mBeg._setPoint(nLine._getBeg());
            mEnd._setPoint(nLine._getEnd());
        }

        public void _setBeg(Point2I nBeg)
        {
            mBeg._setX(nBeg._getX());
            mBeg._setY(nBeg._getY());
        }

        public Point2I _getBeg()
        {
            Point2I result_ = new Point2I(mBeg);
            return result_;
        }

        public void _setEnd(Point2I nEnd)
        {
            mEnd._setX(nEnd._getX());
            mEnd._setY(nEnd._getY());
        }

        public Point2I _getEnd()
        {
            Point2I result_ = new Point2I(mEnd);
            return result_;
        }

        public void _setBegX(int nX)
        {
            mBeg._setX(nX);
        }

        public int _begX()
        {
            return mBeg._getX();
        }

        public void _setBegY(int nY)
        {
            mBeg._setY(nY);
        }

        public int _begY()
        {
            return mBeg._getY();
        }

        public void _setEndX(int nX)
        {
            mEnd._setX(nX);
        }

        public int _endX()
        {
            return mEnd._getX();
        }

        public void _setEndY(int nX)
        {
            mEnd._setY(nX);
        }

        public int _endY()
        {
            return mEnd._getY();
        }

        public Line2I(int nAx, int nAy, int nBx, int nBy)
        {
            mBeg = new Point2I(nAx, nAy);
            mEnd = new Point2I(nBx, nBy);
        }

        public Line2I(int nAx, int nAy, Point2I nEnd)
        {
            mBeg = new Point2I(nAx, nAy);
            mEnd = new Point2I(nEnd);
        }

        public Line2I(Point2I nBeg, int nBx, int nBy)
        {
            mBeg = new Point2I(nBeg);
            mEnd = new Point2I(nBx, nBy);
        }

        public Line2I(Point2I nBeg, Point2I nEnd)
        {
            mBeg = new Point2I(nBeg);
            mEnd = new Point2I(nEnd);
        }

        public Line2I(Line2I nLine)
        {
            mBeg = new Point2I(nLine._getBeg());
            mEnd = new Point2I(nLine._getEnd());
        }

        public Line2I()
        {
            mBeg = new Point2I();
            mEnd = new Point2I();
        }

        Point2I mBeg;
        Point2I mEnd;
    }
}
