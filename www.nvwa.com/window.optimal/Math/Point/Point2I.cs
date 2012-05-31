using System;
using System.Drawing;

using platform.include;

namespace window.optimal
{
    public class Point2I : Stream
    {
        public void _drawPoint(Graphics nGraphics, Pen nPen, int nSize = 3)
        {
            Point2I result_ = new Point2I();
            result_._setX(mX - nSize);
            result_._setY(mY - nSize);
            nGraphics.DrawRectangle(nPen, result_._getX(), result_._getY(), nSize * 2, nSize * 2);
        }

        public void _drawEllipse(Graphics nGraphics, Pen nPen, int nSize = 3)
        {
            Point2I result_ = new Point2I();
            result_._setX(mX - nSize);
            result_._setY(mY - nSize);
            nGraphics.DrawEllipse(nPen, result_._getX(), result_._getY(), nSize * 2, nSize * 2);
        }

        public void _fillPoint(Graphics nGraphics, Brush nBrush, int nSize = 2)
        {
            Point2I result_ = new Point2I();
            result_._setX(mX - nSize);
            result_._setY(mY - nSize);
            nGraphics.FillRectangle(nBrush, result_._getX(), result_._getY(), nSize * 2, nSize * 2);
        }

        public void _fillEllipse(Graphics nGraphics, Brush nBrush, int nSize = 3)
        {
            Point2I result_ = new Point2I();
            result_._setX(mX - nSize);
            result_._setY(mY - nSize);
            nGraphics.FillEllipse(nBrush, result_._getX(), result_._getY(), nSize * 2, nSize * 2);
        }

        public bool _isSelect(Point2I nPoint, int nSize = 3)
        {
            return this._isSelect(nPoint._getX(), nPoint._getY(), nSize);
        }

        public bool _isSelect(int nX, int nY, int nSize = 3)
        {
            int x_, y_;
            if (mX > nX)
            {
                x_ = mX - nX;
            }
            else
            {
                x_ = nX - mX;
            }
            if (mY > nY)
            {
                y_ = mY - nY;
            }
            else
            {
                y_ = nY - mY;
            }
            if ((x_ < nSize) && (y_ < nSize))
            {
                return true;
            }
            return false;
        }

        public __tuple<Point2I, Point2I> _minMax(Point2I nPoint)
        {
            return this._minMax(nPoint._getX(), nPoint._getY());
        }

        public __tuple<Point2I, Point2I> _minMax(int nX, int nY)
        {
            Point2I min_ = new Point2I();
            Point2I max_ = new Point2I();
            if (nX > mX)
            {
                min_._setX(mX);
                max_._setX(nX);
            }
            else
            {
                min_._setX(nX);
                max_._setX(mX);
            }

            if (nY > mY)
            {
                min_._setY(mY);
                max_._setY(nY);
            }
            else
            {
                min_._setY(nY);
                max_._setY(mY);
            }
            return new __tuple<Point2I, Point2I>(min_, max_);
        }

        public Point2I _vectorFrom(Point2I nPoint)
        {
            return this._vectorFrom(nPoint._getX(), nPoint._getY());
        }

        public Point2I _vectorFrom(int nX, int nY)
        {
            Point2I result_ = new Point2I();
            result_._setX(mX - nX);
            result_._setY(mY - nY);
            return result_;
        }

        public Point2I _vectorTo(Point2I nPoint)
        {
            return this._vectorTo(nPoint._getX(), nPoint._getY());
        }

        public Point2I _vectorTo(int nX, int nY)
        {
            Point2I result_ = new Point2I();
            result_._setX(nX - mX);
            result_._setY(nY - mY);
            return result_;
        }

        public void _offset(Point2I nPoint)
        {
            this._offset(nPoint._getX(), nPoint._getY());
        }

        public void _offset(int nX, int nY)
        {
            mX += nX;
            mY += nY;
        }

        public decimal _length(Point2I nPoint)
        {
            return this._length(nPoint._getX(), nPoint._getY());
        }

        public decimal _length(int nX, int nY)
        {
            long x_ = nX - mX;
            long y_ = nY - mY;
            x_ *= x_;
            y_ *= y_;
            double l_ = x_ + y_;
            decimal d_ = (decimal)(Math.Sqrt(l_));
            return d_;
        }

        public decimal _length()
        {
            long x_ = mX;
            long y_ = mY;
            x_ *= x_;
            y_ *= y_;
            long l_ = x_ + y_;
            decimal d_ = (decimal)(Math.Sqrt((double)l_));
            return d_;
        }

        public static Point2I operator -(Point2I nLeft, Size2I nRight)
        {
            Point2I result_ = new Point2I();
            result_._setX(nLeft._getX() - nRight._getWidth());
            result_._setY(nLeft._getY() - nRight._getHeight());
            return result_;
        }

        public static Point2I operator +(Point2I nLeft, Size2I nRight)
        {
            Point2I result_ = new Point2I();
            result_._setX(nLeft._getX() + nRight._getWidth());
            result_._setY(nLeft._getY() + nRight._getHeight());
            return result_;
        }

        public static Point2I operator -(Point2I nLeft, Point2I nRight)
        {
            Point2I result_ = new Point2I();
            result_._setX(nLeft._getX() - nRight._getX());
            result_._setY(nLeft._getY() - nRight._getY());
            return result_;
        }

        public static Point2I operator +(Point2I nLeft, Point2I nRight)
        {
            Point2I result_ = new Point2I();
            result_._setX(nLeft._getX() + nRight._getX());
            result_._setY(nLeft._getY() + nRight._getY());
            return result_;
        }

        public override void _serialize(ISerialize nSerialize)
        {
            nSerialize._serialize(ref mX, @"x");
            nSerialize._serialize(ref mY, @"y");
        }

        public void _setPoint(int nX, int nY)
        {
            mX = nX;
            mY = nY;
        }

        public void _setPoint(Point2I nPoint)
        {
            mX = nPoint._getX();
            mY = nPoint._getY();
        }

        public void _setX(int nX)
        {
            mX = nX;
        }

        public int _getX()
        {
            return mX;
        }

        public void _setY(int nY)
        {
            mY = nY;
        }

        public int _getY()
        {
            return mY;
        }

        public Point2I(int nX, int nY)
        {
            mX = nX;
            mY = nY;
        }

        public Point2I(Point2I nPoint)
        {
            mX = nPoint._getX();
            mY = nPoint._getY();
        }

        public Point2I()
        {
            mX = 0;
            mY = 0;
        }

        int mX;
        int mY;
    }
}
