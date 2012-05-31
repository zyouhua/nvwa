using System.Drawing;
using System.Drawing.Drawing2D;

using platform.include;

namespace window.optimal
{
    public class Rect2I : Stream
    {
        public void _drawPull(Graphics nGraphics, Pen nPen, Pen nBroken, Pen nPoint, Image nImage = null, int nSize = 3)
        {
            this._drawRect(nGraphics, nPen, nImage);

            Point2I lefttop_ = new Point2I(mPoint);
            lefttop_._offset(-nSize, -nSize);

            Point2I righttop_ = new Point2I();
            righttop_._setX(this._getRTX() + nSize);
            righttop_._setY(this._getRTY() - nSize);

            Point2I leftbottom_ = new Point2I();
            leftbottom_._setX(this._getLBX() - nSize);
            leftbottom_._setY(this._getLBY() + nSize);

            Point2I rightbottom_ = new Point2I();
            rightbottom_._setX(this._getRBX() + nSize);
            rightbottom_._setY(this._getRBY() + nSize);

            Point2I lt_ = new Point2I();
            lt_._setX(this._getX() - nSize);
            lt_._setY(this._centerY() - 2);
            Point2I lb_ = new Point2I();
            lb_._setX(this._getX() - nSize);
            lb_._setY(this._centerY() + 2);
            Point2I lp_ = new Point2I();
            lp_._setX(this._getX() - 3);
            lp_._setY(this._centerY());

            Point2I rt_ = new Point2I();
            rt_._setX(this._getRTX() + nSize);
            rt_._setY(this._centerY() - 2);
            Point2I rb_ = new Point2I();
            rb_._setX(this._getRTX() + nSize);
            rb_._setY(this._centerY() + 2);
            Point2I rp_ = new Point2I();
            rp_._setX(this._getRTX() + 3);
            rp_._setY(this._centerY());

            Line2I top_ = new Line2I(lefttop_, righttop_);
            top_._drawBroken(nGraphics, nBroken);
            Line2I bottom_ = new Line2I(leftbottom_, rightbottom_);
            bottom_._drawBroken(nGraphics, nBroken);
            Line2I left0_ = new Line2I(lefttop_, lt_);
            left0_._drawBroken(nGraphics, nBroken);
            Line2I left1_ = new Line2I(leftbottom_, lb_);
            left1_._drawBroken(nGraphics, nBroken);
            Line2I right0_ = new Line2I(righttop_, rt_);
            right0_._drawBroken(nGraphics, nBroken);
            Line2I right1_ = new Line2I(rightbottom_, rb_);
            right1_._drawBroken(nGraphics, nBroken);
            lp_._drawEllipse(nGraphics, nPoint);
            rp_._drawEllipse(nGraphics, nPoint);
        }

        public void _drawSelect(Graphics nGraphics, Pen nPen, Pen nSelect, Image nImage = null)
        {
            this._drawRect(nGraphics, nPen, nImage);
            this._drawBroken(nGraphics, nSelect, 4);
        }

        public void _drawBroken(Graphics nGraphics, Pen nPen, int nSize = 0)
        {
            Point2I lefttop_ = new Point2I(mPoint);
            lefttop_._offset(-nSize, -nSize);

            Point2I righttop_ = new Point2I();
            righttop_._setX(this._getRTX() + nSize);
            righttop_._setY(this._getRTY() - nSize);

            Point2I leftbottom_ = new Point2I();
            leftbottom_._setX(this._getLBX() - nSize);
            leftbottom_._setY(this._getLBY() + nSize);

            Point2I rightbottom_ = new Point2I();
            rightbottom_._setX(this._getRBX() + nSize);
            rightbottom_._setY(this._getRBY() + nSize);

            Line2I top_ = new Line2I(lefttop_, righttop_);
            top_._drawBroken(nGraphics, nPen);
            Line2I bottom_ = new Line2I(leftbottom_, rightbottom_);
            bottom_._drawBroken(nGraphics, nPen);
            Line2I left_ = new Line2I(lefttop_, leftbottom_);
            left_._drawBroken(nGraphics, nPen);
            Line2I right_ = new Line2I(righttop_, rightbottom_);
            right_._drawBroken(nGraphics, nPen);
        }

        public void _fileBroken(Graphics nGraphics, Pen nPen)
        {
            int x0_ = this._getX();
            int y0_ = this._getY();
            int x1_ = this._getRBX();
            int y1_ = this._getRBY();
            bool haveY_ = true;
            for (int i = y0_; i < y1_; i += 1)
            {
                bool haveX_ = haveY_;
                for (int j = x0_; j < x1_; j += 2)
                {
                    if (haveX_)
                    {
                        nGraphics.DrawLine(nPen, j, i, j + 1, i);
                    }
                    haveX_ = !haveX_;
                }
                haveY_ = !haveY_;
            }
        }

        public void _drawRect(Graphics nGraphics, Pen nPen, Image nImage = null)
        {
            GraphicsState graphicsState0_ = nGraphics.Save();
            nGraphics.SmoothingMode = SmoothingMode.HighQuality;
            nGraphics.DrawRectangle(nPen, this._getX(), this._getY(), this._getWidth(), this._getHeight());
            nGraphics.Restore(graphicsState0_);
            if (this._getWidth() < 20)
            {
                return;
            }
            if (this._getHeight() < 17)
            {
                return;
            }
            if (null == nImage)
            {
                return;
            }
            Point2I point_ = new Point2I();
            point_._setX(this._getX() + 3);
            point_._setY(this._getY() + ((this._getHeight() - 15) / 2));
            nGraphics.DrawImage(nImage, point_._getX(), point_._getY(), 15, 15);
        }

        public void _fileRect(Graphics nGraphics, Brush nBrush)
        {
            int x_ = this._getX();
            int y_ = this._getY();
            int width_ = this._getWidth();
            int height_ = this._getHeight();
            nGraphics.FillRectangle(nBrush, x_, y_, width_, height_);
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
            return this._intersectWith(nRect._getX(), nRect._getY(), nRect._getWidth(), nRect._getHeight());
        }

        public bool _intersectWith(Point2I nPoint, Size2I nSize)
        {
            return this._intersectWith(nPoint._getX(), nPoint._getY(), nSize._getWidth(), nSize._getHeight());
        }

        public bool _intersectWith(Point2I nPoint, int nWidth, int nHeight)
        {
            return this._intersectWith(nPoint._getX(), nPoint._getY(), nWidth, nHeight);
        }

        public bool _intersectWith(int nX, int nY, Size2I nSize)
        {
            return this._intersectWith(nX, nY, nSize._getWidth(), nSize._getHeight());
        }

        public bool _intersectWith(int nX, int nY, int nWidth, int nHeight)
        {
            Rectangle rectangle1_ = new Rectangle(mPoint._getX(), mPoint._getY(), mSize._getWidth(), mSize._getHeight());
            Rectangle rectangle2_ = new Rectangle(nX, nY, nWidth, nHeight);
            return rectangle1_.IntersectsWith(rectangle2_);
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
            Rectangle rect_ = new Rectangle(mPoint._getX(), mPoint._getY(), mSize._getWidth(), mSize._getHeight());
            return rect_.Contains(new Point(nX, nY));
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
