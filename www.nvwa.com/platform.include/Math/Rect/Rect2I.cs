using platform.include;

namespace platform.include
{
    public class Rect2I : Stream
    {
        public Point2I _connectPoint(Point2I nBeg, Point2I nEnd)
        {
            if (this._contain(nEnd))
            {
                return nEnd;
            }
            if (!this._contain(nBeg))
            {
                return nEnd;
            }
            Point2I result_ = new Point2I();
            int x0_ = mPoint._getX();
            int x1_ = x0_ + mSize._getWidth();
            int y0_ = mPoint._getY();
            int y1_ = y0_ + mSize._getHeight();
            if (nEnd._getY() < this._centerY())
            {
                if (nBeg._getY() == y0_)
                {
                    result_._setPoint(nBeg);
                    return result_;
                }
                float temp_ = this._connectPointY(nBeg, nEnd, y0_);
                if (temp_ > x0_ && temp_ < x1_)
                {
                    int int_ = (int)temp_;
                    result_._setX(int_);
                    result_._setY(y0_);
                    return result_;
                }
            }
            else
            {
                if (nBeg._getY() == y1_)
                {
                    result_._setPoint(nBeg);
                    return result_;
                }
                float temp_ = this._connectPointY(nBeg, nEnd, y1_);
                if (temp_ > x0_ && temp_ < x1_)
                {
                    int int_ = (int)temp_;
                    result_._setX(int_);
                    result_._setY(y1_);
                    return result_;
                }
            }
            if (nEnd._getX() > nBeg._getX())
            {
                result_._setX(x1_);
            }
            else
            {
                result_._setX(x0_);
            }
            if (nEnd._getY() > nBeg._getY())
            {
                result_._setY(y1_);
            }
            else
            {
                result_._setY(y0_);
            }
            return result_;
        }

        float _connectPointY(Point2I nBeg, Point2I nEnd, int nY)
        {
            if (nY > nBeg._getY() && nY > nEnd._getY())
            {
                return default(float);
            }
            if (nY < nBeg._getY() && nY < nEnd._getY())
            {
                return default(float);
            }
            int y1_ = nEnd._getY() - nY;
            int y0_ = nEnd._getY() - nBeg._getY();
            int x_ = nEnd._getX() - nBeg._getX();
            float result_ = (x_ * y1_) / y0_;
            result_ = nEnd._getX() - result_;
            if (result_ > nBeg._getX() && result_ > nEnd._getX())
            {
                return default(float);
            }
            if (result_ < nBeg._getX() && result_ < nEnd._getX())
            {
                return default(float);
            }
            return result_;
        }

        public Point2I _connectPoint(Point2I nPoint)
        {
            Point2I result_ = new Point2I();
            Point2I center_ = this._centerPoint();
            if (center_._getX() > nPoint._getX())
            {
                result_._setX(mPoint._getX());
            }
            else
            {
                result_._setX(mPoint._getX() + mSize._getWidth());
            }

            result_._setY(center_._getY());
            return result_;
        }

        public bool _intersectWith(Line2I nLine)
        {
            if (this._contain(nLine._getBeg()))
            {
                return true;
            }
            if (this._contain(nLine._getEnd()))
            {
                return true;
            }
            bool statusX_ = this._intersectWithX(nLine);
            if (statusX_ == true)
            {
                return true;
            }
            bool statusY_ = this._intersectWithY(nLine);
            if (statusY_ == true)
            {
                return true;
            }
            return false;
        }

        bool _intersectWithX(Line2I nLine)
        {
            int x_ = default(int);
            int x0_ = default(int);
            int x1_ = mPoint._getX();
            int x2_ = mPoint._getX() + mSize._getWidth();
            if (((nLine._begX() < x1_) && (nLine._endX() > x1_)) || ((nLine._begX() > x1_) && (nLine._endX() < x1_)))
            {
                x_ = x1_;
            }

            if (((nLine._begX() < x2_) && (nLine._endX() > x2_)) || ((nLine._begX() > x2_) && (nLine._endX() < x2_)))
            {
                x0_ = x2_;
            }
            if ((x_ == default(int)) && (x0_ == default(int)))
            {
                return false;
            }
            int y1_ = mPoint._getY();
            int y2_ = mPoint._getY() + mSize._getHeight();

            int y_ = default(int);
            if (x_ != default(int))
            {
                y_ = nLine._yPoint(x_);
            }

            int y0_ = default(int);
            if (x0_ != default(int))
            {
                y0_ = nLine._yPoint(x0_);
            }

            if ((y_ > y1_) && (y_ < y2_))
            {
                return true;
            }

            if ((y0_ > y1_) && (y0_ < y2_))
            {
                return true;
            }
            return false;
        }

        bool _intersectWithY(Line2I nLine)
        {
            int x_ = default(int);
            int x0_ = default(int);
            int x1_ = mPoint._getY();
            int x2_ = mPoint._getY() + mSize._getHeight();
            if (((nLine._begY() < x1_) && (nLine._endY() > x1_)) || ((nLine._begY() > x1_) && (nLine._endY() < x1_)))
            {
                x_ = x1_;
            }

            if (((nLine._begY() < x2_) && (nLine._endY() > x2_)) || ((nLine._begY() > x2_) && (nLine._endY() < x2_)))
            {
                x0_ = x2_;
            }
            if ((x_ == default(int)) && (x0_ == default(int)))
            {
                return false;
            }
            int y1_ = mPoint._getX();
            int y2_ = mPoint._getX() + mSize._getWidth();

            int y_ = default(int);
            if (x_ != default(int))
            {
                y_ = nLine._xPoint(x_);
            }

            int y0_ = default(int);
            if (x0_ != default(int))
            {
                y0_ = nLine._xPoint(x0_);
            }

            if ((y_ > y1_) && (y_ < y2_))
            {
                return true;
            }

            if ((y0_ > y1_) && (y0_ < y2_))
            {
                return true;
            }
            return false;
        }

        public bool _intersectWith(Rect2I nRect)
        {
            Point2I lt0_ = this._getPoint();
            Point2I lb0_ = this._getLBPoint();
            Point2I rt0_ = this._getRTPoint();
            Point2I rb0_ = this._getRBPoint();
            if (nRect._contain(lt0_))
            {
                return true;
            }
            if (nRect._contain(lb0_))
            {
                return true;
            }
            if (nRect._contain(rt0_))
            {
                return true;
            }
            if (nRect._contain(rb0_))
            {
                return true;
            }
            Point2I lt1_ = nRect._getPoint();
            Point2I lb1_ = nRect._getLBPoint();
            Point2I rt1_ = nRect._getRTPoint();
            Point2I rb1_ = nRect._getRBPoint();
            if (this._contain(lt1_))
            {
                return true;
            }
            if (this._contain(lb1_))
            {
                return true;
            }
            if (this._contain(rt1_))
            {
                return true;
            }
            if (this._contain(rb1_))
            {
                return true;
            }
            int x00_ = this._getX();
            int y00_ = this._getY();
            int x01_ = this._getRTX();
            int y01_ = this._getLBY();
            int x10_ = nRect._getX();
            int y10_ = nRect._getY();
            int x11_ = nRect._getRTX();
            int y11_ = nRect._getLBY();
            if (x00_ < x10_ && x01_ > x11_ && y00_ > y10_ && y01_ < y11_)
            {
                return true;
            }
            if (x00_ > x10_ && x01_ < x11_ && y00_ < y10_ && y01_ > y11_)
            {
                return true;
            }
            return false;
        }

        public bool _intersectWith(int nX, int nY, int nWidth, int nHeight)
        {
            int x_ = nX + nWidth;
            int y_ = nY + nHeight;
            if (this._contain(nX, nY))
            {
                return true;
            }
            if (this._contain(nX, y_))
            {
                return true;
            }
            if (this._contain(x_, nY))
            {
                return true;
            }
            if (this._contain(x_, y_))
            {
                return true;
            }
            return false;
        }

        public __tuple<Status_, Point2I> _borderPoint(Point2I nPoint)
        {
            Point2I center_ = _centerPoint();

            Point2I point_ = new Point2I();
            point_._setX(nPoint._getX() - center_._getX());
            point_._setY(nPoint._getY() - center_._getY());

            long x_ = point_._getX() * mSize._getHeight();
            long y_ = point_._getY() * mSize._getWidth();


            Point2I result_ = new Point2I();
            Quadrant_ quadrant_ = _getQuadrant(nPoint);
            //                    |
            //                    |
            //             _______0_______
            //                    |
            //                    |
            //                    |
            if (Quadrant_.mCenter_ == quadrant_)
            {
                return new __tuple<Status_, Point2I>(Status_.mSucess_, center_);
            }
            //                    |
            //                    |
            //             _______|_______1
            //                    |
            //                    |
            //                    |
            else if (Quadrant_.mUdx_ == quadrant_)
            {
                result_._setX(mPoint._getX() + mSize._getWidth());
                result_._setY(center_._getY());
                return new __tuple<Status_, Point2I>(Status_.mSucess_, result_);
            }
            //                    |
            //                    |  2
            //             _______|_______
            //                    |
            //                    |
            //                    |
            else if (Quadrant_.mFirst_ == quadrant_)
            {
                y_ = -y_;
                if (x_ > y_)
                {
                    result_._setX(mPoint._getX() + mSize._getWidth());
                    long temp_ = y_ / 2;
                    y_ = (int)(temp_ / point_._getX());
                    result_._setY((int)(center_._getY() - y_));
                }
                else if (x_ == y_)
                {
                    result_._setX(mPoint._getX() + mSize._getWidth());
                    result_._setY(mPoint._getY());
                }
                else
                {
                    result_._setY(mPoint._getY());
                    long temp_ = x_ / 2;
                    x_ = (int)(temp_ / point_._getY());
                    result_._setX((int)(center_._getX() - x_));
                }
                return new __tuple<Status_, Point2I>(Status_.mSucess_, result_);
            }
            //                    3
            //                    |
            //                    |
            //             _______|_______
            //                    |
            //                    |
            //                    |
            else if (Quadrant_.mUdy_ == quadrant_)
            {
                result_._setX(center_._getX());
                result_._setY(mPoint._getY());
                return new __tuple<Status_, Point2I>(Status_.mSucess_, result_);
            }
            //                    |
            //                 4  |
            //             _______|_______
            //                    |
            //                    |
            //                    |
            else if (Quadrant_.mSecond_ == quadrant_)
            {
                x_ = -x_;
                y_ = -y_;
                if (x_ > y_)
                {
                    result_._setX(mPoint._getX());
                    long temp_ = y_ / 2;
                    y_ = (int)(temp_ / point_._getX());
                    result_._setY((int)(center_._getY() + y_));
                }
                else if (x_ == y_)
                {
                    result_._setX(mPoint._getX());
                    result_._setY(mPoint._getY());
                }
                else
                {
                    result_._setY(mPoint._getY());
                    long temp_ = x_ / 2;
                    x_ = (int)(temp_ / point_._getY());
                    result_._setX((int)(center_._getX() + x_));
                }
                return new __tuple<Status_, Point2I>(Status_.mSucess_, result_);
            }
            //                    |
            //                    |
            //            5_______|_______
            //                    |
            //                    |
            //                    |
            else if (Quadrant_.mSdx_ == quadrant_)
            {
                result_._setX(mPoint._getX());
                result_._setY(center_._getY());

                return new __tuple<Status_, Point2I>(Status_.mSucess_, result_);
            }
            //                    |
            //                    |
            //             _______|_______
            //                    |
            //                 6  |
            //                    |
            if (Quadrant_.mThree_ == quadrant_)
            {
                x_ = -x_;
                if (x_ > y_)
                {
                    result_._setX(mPoint._getX());
                    long temp_ = y_ / 2;
                    y_ = (int)(temp_ / point_._getX());
                    result_._setY((int)(center_._getY() - y_));
                }
                else if (x_ == y_)
                {
                    result_._setX(mPoint._getX());
                    result_._setY(mPoint._getY() + mSize._getHeight());
                }
                else
                {
                    result_._setY(mPoint._getY() + mSize._getHeight());
                    long temp_ = x_ / 2;
                    x_ = (int)(temp_ / point_._getY());
                    result_._setX((int)(center_._getX() - x_));
                }
                return new __tuple<Status_, Point2I>(Status_.mSucess_, result_);
            }
            //                    |
            //                    |
            //             _______|_______
            //                    |
            //                    |
            //                    |
            //                    7
            if (Quadrant_.mSdy_ == quadrant_)
            {
                result_._setX(center_._getX());
                result_._setY(mPoint._getY() + mSize._getHeight());
                return new __tuple<Status_, Point2I>(Status_.mSucess_, result_);
            }
            //                    |     
            //                    |
            //             _______|_______
            //                    |
            //                    |   8
            //                    |
            else if (Quadrant_.mFour_ == quadrant_)
            {
                if (x_ > y_)
                {
                    result_._setX(mPoint._getX() + mSize._getWidth());
                    long temp_ = y_ / 2;
                    y_ = (int)(temp_ / point_._getX());
                    result_._setY((int)(center_._getY() + y_));
                }
                else if (x_ == y_)
                {
                    result_._setX(mPoint._getX() + mSize._getWidth());
                    result_._setY(mPoint._getY() + mSize._getHeight());
                }
                else
                {
                    result_._setY(mPoint._getY() + mSize._getHeight());
                    long temp = x_ / 2;
                    x_ = (int)(temp / point_._getY());
                    result_._setX((int)(center_._getX() + x_));
                }
                return new __tuple<Status_, Point2I>(Status_.mSucess_, result_);
            }
            else
            {
                return new __tuple<Status_, Point2I>(Status_.mError_, result_);
            }
        }

        public Quadrant_ _getQuadrant(Point2I nPoint)
        {
            Point2I center_ = _centerPoint();
            int x_ = nPoint._getX() - center_._getX();
            int y_ = nPoint._getY() - center_._getY();
            if (0 == x_ && 0 == y_)
            {
                return Quadrant_.mCenter_;
            }
            else if (0 < x_ && 0 == y_)
            {
                return Quadrant_.mUdx_;
            }
            else if (0 < x_ && 0 > y_)
            {
                return Quadrant_.mFirst_;
            }
            else if (0 == x_ && 0 > y_)
            {
                return Quadrant_.mUdy_;
            }
            else if (0 > x_ && 0 > y_)
            {
                return Quadrant_.mSecond_;
            }
            else if (0 > x_ && 0 == y_)
            {
                return Quadrant_.mSdx_;
            }
            else if (0 > x_ && 0 < y_)
            {
                return Quadrant_.mThree_;
            }
            else if (0 == x_ && 0 < y_)
            {
                return Quadrant_.mSdy_;
            }
            else if (0 < x_ && 0 < y_)
            {
                return Quadrant_.mFour_;
            }
            else
            {
                return Quadrant_.mError_;
            }
        }

        public bool _contain(Point2I nPoint)
        {
            return this._contain(nPoint._getX(), nPoint._getY());
        }

        public bool _contain(int nX, int nY)
        {
            int x0_ = mPoint._getX();
            int y0_ = mPoint._getY();
            int x1_ = x0_ + mSize._getWidth();
            int y1_ = y0_ + mSize._getHeight();
            if (nX < x0_)
            {
                return false;
            }
            if (nX > x1_)
            {
                return false;
            }
            if (nY < y0_)
            {
                return false;
            }
            if (nY > y1_)
            {
                return false;
            }
            return true;
        }

        public __tuple<Point2I, Point2I> _minMax(Point2I nMin, Point2I nMax)
        {
            __tuple<Point2I, Point2I> tuple0_ = mPoint._minMax(nMin);
            Point2I min_ = tuple0_._get_0();
            Point2I point_ = mPoint + mSize;
            __tuple<Point2I, Point2I> tuple1_ = point_._minMax(nMax);
            Point2I max_ = tuple1_._get_1();
            return new __tuple<Point2I, Point2I>(min_, max_);
        }

        public void _sizeOffset(int nX, int nY)
        {
            mSize._offset(nX, nY);
        }

        public void _offset(Point2I nPoint)
        {
            mPoint._offset(nPoint);
        }

        public void _offset(int nX, int nY)
        {
            mPoint._offset(nX, nY);
        }

        public Point2I _centerPoint()
        {
            Point2I result_ = new Point2I();
            int x_ = mSize._getWidth();
            int y_ = mSize._getHeight();
            x_ /= 2;
            y_ /= 2;
            result_._setX(mPoint._getX() + x_);
            result_._setY(mPoint._getY() + y_);
            return result_;
        }

        public int _centerX()
        {
            int x_ = mSize._getWidth();
            x_ /= 2;
            int result_ = this._getX() + x_;
            return result_;
        }

        public int _centerY()
        {
            int y_ = mSize._getHeight();
            y_ /= 2;
            int result_ = this._getY() + y_;
            return result_;
        }

        public override void _serialize(ISerialize nSerialize)
        {
            nSerialize._serialize(ref mPoint, "point");
            nSerialize._serialize(ref mSize, "size");
        }

        public void _setRect(int nX, int nY, int nWidth, int nHeight)
        {
            mPoint._setPoint(nX, nY);
            mSize._setSize(nWidth, nHeight);
        }

        public void _setRect(Rect2I nRect)
        {
            mPoint._setPoint(nRect._getPoint());
            mSize._setSize(nRect._getSize());
        }

        public Rect2I _getRect()
        {
            Rect2I result_ = new Rect2I(this);
            return result_;
        }

        public void _setX(int nX)
        {
            mPoint._setX(nX);
        }

        public int _getX()
        {
            return mPoint._getX();
        }

        public void _setY(int nY)
        {
            mPoint._setY(nY);
        }

        public int _getY()
        {
            return mPoint._getY();
        }

        public void _setWidth(int nWidth)
        {
            mSize._setWidth(nWidth);
        }

        public int _getWidth()
        {
            return mSize._getWidth();
        }

        public void _setHeight(int nHeight)
        {
            mSize._setHeight(nHeight);
        }

        public int _getHeight()
        {
            return mSize._getHeight();
        }

        public void _setPoint(Point2I nPoint)
        {
            mPoint._setX(nPoint._getX());
            mPoint._setY(nPoint._getY());
        }

        public void _setPoint(int nX, int nY)
        {
            mPoint._setX(nX);
            mPoint._setY(nY);
        }

        public Point2I _getPoint()
        {
            Point2I result_ = new Point2I(mPoint);
            return result_;
        }

        public Point2I _getRTPoint()
        {
            Point2I result_ = new Point2I();
            result_._setX(this._getX() + this._getWidth());
            result_._setY(this._getY());
            return result_;
        }

        public Point2I _getLBPoint()
        {
            Point2I result_ = new Point2I();
            result_._setX(this._getX());
            result_._setY(this._getY() + this._getHeight());
            return result_;
        }

        public Point2I _getRBPoint()
        {
            Point2I result_ = new Point2I();
            result_._setX(this._getX() + this._getWidth());
            result_._setY(this._getY() + this._getHeight());
            return result_;
        }

        public int _getRTX()
        {
            int result_ = this._getX() + this._getWidth();
            return result_;
        }

        public int _getRTY()
        {
            int result_ = this._getY();
            return result_;
        }

        public int _getLBX()
        {
            int result_ = this._getX();
            return result_;
        }

        public int _getLBY()
        {
            int result_ = this._getY() + this._getHeight();
            return result_;
        }

        public int _getRBX()
        {
            int result_ = this._getX() + this._getWidth();
            return result_;
        }

        public int _getRBY()
        {
            int result_ = this._getY() + this._getHeight();
            return result_;
        }

        public void _setSize(Size2I nSize)
        {
            mSize._setWidth(nSize._getWidth());
            mSize._setHeight(nSize._getHeight());
        }

        public void _setSize(int nWidth, int nHeight)
        {
            mSize._setWidth(nWidth);
            mSize._setHeight(nHeight);
        }

        public Size2I _getSize()
        {
            Size2I result_ = new Size2I(mSize);
            return result_;
        }

        public Rect2I(int nX, int nY, int nWidth, int nHeight)
        {
            Point2I point0_ = new Point2I(nX, nY);
            Point2I point_ = new Point2I();
            point_._setX(nX + nWidth);
            point_._setY(nY + nHeight);

            __tuple<Point2I, Point2I> tuple_ = point0_._minMax(point_);
            Point2I min_ = tuple_._get_0();
            Point2I max_ = tuple_._get_1();

            Size2I size_ = new Size2I();
            size_._setWidth(max_._getX() - min_._getX());
            size_._setHeight(max_._getY() - min_._getY());

            mPoint = new Point2I(min_);
            mSize = new Size2I(size_);
        }

        public Rect2I(Point2I nPoint, int nWidth, int nHeight)
        {
            Point2I point_ = new Point2I();
            point_._setX(nPoint._getX() + nWidth);
            point_._setY(nPoint._getY() + nHeight);

            __tuple<Point2I, Point2I> tuple_ = nPoint._minMax(point_);
            Point2I min_ = tuple_._get_0();
            Point2I max_ = tuple_._get_1();

            Size2I size_ = new Size2I();
            size_._setWidth(max_._getX() - min_._getX());
            size_._setHeight(max_._getY() - min_._getY());

            mPoint = new Point2I(min_);
            mSize = new Size2I(size_);
        }

        public Rect2I(int nX, int nY, Size2I nSize)
        {
            Point2I point0_ = new Point2I(nX, nY);
            Point2I point_ = new Point2I();
            point_._setX(nX + nSize._getWidth());
            point_._setY(nY + nSize._getHeight());

            __tuple<Point2I, Point2I> tuple_ = point0_._minMax(point_);
            Point2I min_ = tuple_._get_0();
            Point2I max_ = tuple_._get_1();

            Size2I size_ = new Size2I();
            size_._setWidth(max_._getX() - min_._getX());
            size_._setHeight(max_._getY() - min_._getY());

            mPoint = new Point2I(min_);
            mSize = new Size2I(size_);
        }

        public Rect2I(Point2I nPoint, Size2I nSize)
        {
            Point2I point_ = new Point2I();
            point_._setX(nPoint._getX() + nSize._getWidth());
            point_._setY(nPoint._getY() + nSize._getHeight());

            __tuple<Point2I, Point2I> tuple_ = nPoint._minMax(point_);
            Point2I min_ = tuple_._get_0();
            Point2I max_ = tuple_._get_1();

            Size2I size_ = new Size2I();
            size_._setWidth(max_._getX() - min_._getX());
            size_._setHeight(max_._getY() - min_._getY());

            mPoint = new Point2I(min_);
            mSize = new Size2I(size_);
        }

        public Rect2I(Point2I nBeg, Point2I nEnd)
        {
            __tuple<Point2I, Point2I> tuple_ = nBeg._minMax(nEnd);
            Point2I min_ = tuple_._get_0();
            Point2I max_ = tuple_._get_1();

            Size2I size_ = new Size2I();
            size_._setWidth(max_._getX() - min_._getX());
            size_._setHeight(max_._getY() - min_._getY());

            mPoint = new Point2I(min_);
            mSize = new Size2I(size_);
        }

        public Rect2I(Rect2I nRect)
        {
            mPoint = new Point2I(nRect._getPoint());
            mSize = new Size2I(nRect._getSize());
        }

        public Rect2I()
        {
            mPoint = new Point2I();
            mSize = new Size2I();
        }

        Point2I mPoint;
        Size2I mSize;
    }
}
