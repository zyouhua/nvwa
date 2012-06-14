using System;

namespace platform.include
{
    public class Line2I : Stream
    {
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
            float x_ = point_._getX() / length_;
            float y_ = point_._getY() / length_;
            Point2I result_ = new Point2I();
            result_._setX((int)(nLength * x_ + mBeg._getX()));
            result_._setY((int)(nLength * y_ + mBeg._getY()));
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
            float x_ = point_._getX() / length_;
            float y_ = point_._getY() / length_;
            Point2I result_ = new Point2I();
            result_._setX((int)(nLength * x_ + mEnd._getX()));
            result_._setY((int)(nLength * y_ + mEnd._getY()));
            return result_;
        }

        public bool _isSelect(Point2I nPoint, int nDistance = 3)
        {
            return _isSelect(nPoint._getX(), nPoint._getY(), nDistance);
        }

        public bool _isSelect(int nX, int nY, int nDistance = 3)
        {
            Rect2I rect_ = new Rect2I(mBeg, mEnd);
            rect_._offset(-nDistance, -nDistance);
            rect_._sizeOffset(nDistance * 2, nDistance * 2);
            if (!rect_._contain(nX, nY))
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
            double b_ = (nY - endY_) * (endX_ - begX_);
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
