using System.Drawing;
using System.Collections.Generic;

using window.include;
using platform.include;

namespace window.optimal
{
    public class LabelShape : RectShape, IShape
    {
        public Rect2I _rectGetRect2I(int nIndex)
        {
            int x_ = mLabel._getX();
            int y_ = mLabel._getY();
            y_ += mLabelHeight;
            y_ += nIndex * mRectHeight;
            int w_ = mLabel._getWidth();
            if (w_ < mRectWidth)
            {
                w_ = mRectWidth;
            }
            int h_ = mRectHeight;
            Rect2I result_ = new Rect2I(x_, y_, w_, h_);
            return result_;
        }

        protected override Point2I _rectJoinPoint(Point2I nPoint)
        {
            Rect2I rect2i_ = this._getRect2I();
            if (mRectShapes.Count <= 0)
            {
                __tuple<Status_, Point2I> tuple_ = rect2i_._borderPoint(nPoint);
                return tuple_._get_1();
            }
            else
            {
                Point2I result_ = rect2i_._connectPoint(rect2i_._centerPoint(), nPoint);
                return result_;
            }
        }

        public override Point2I _rectJoinPoint(Point2I nBeg, Point2I nEnd)
        {
            Rect2I rect_ = this._getRect2I();
            if (mRectShapes.Count < 0)
            {
                __tuple<Status_, Point2I> tuple_ = rect_._borderPoint(nEnd);
                return tuple_._get_1();
            }
            else
            {
                Point2I result_ = rect_._connectPoint(nBeg, nEnd);
                return result_;
            }
        }

        public RectShape _getRectShape(Point2I nPoint, string nId)
        {
            Rect2I rect2i_ = this._getRect2I();
            if (!rect2i_._contain(nPoint))
            {
                return null;
            }
            if (mRectShapes.Count <= 0)
            {
                if (this._rectIdSel(nId))
                {
                    return this;
                }
                return null;
            }
            rect2i_._setHeight(mLabelHeight);
            if (rect2i_._contain(nPoint))
            {
                if (this._rectIdSel(nId))
                {
                    return this;
                }
                return null;
            }
            rect2i_._offset(0, mLabelHeight);
            rect2i_._setHeight(mRectHeight);
            foreach (RectShape i in mRectShapes)
            {
                if (rect2i_._contain(nPoint))
                {
                    if (i._rectIdSel(nId))
                    {
                        return i;
                    }
                    return null;
                }
                rect2i_._offset(0, mRectHeight);
            }
            return null;
        }

        public bool _isPull(Point2I nPoint)
        {
            if (this._isPullLeft(nPoint))
            {
                return true;
            }
            if (this._isPullRight(nPoint))
            {
                return true;
            }
            return false;
        }

        bool _isPullLeft(Point2I nPoint)
        {
            Rect2I rect2i_ = this._getRect2I();
            Point2I left_ = rect2i_._centerPoint();
            left_._setX(rect2i_._getX());
            left_._offset(-4, 0);
            if (left_._isSelect(nPoint))
            {
                return true;
            }
            return false;
        }

        bool _isPullRight(Point2I nPoint)
        {
            Rect2I rect2i_ = this._getRect2I();
            Point2I right_ = rect2i_._centerPoint();
            right_._setX(rect2i_._getRTX());
            right_._offset(4, 0);
            if (right_._isSelect(nPoint))
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
            ShapeDescriptorSingleton shapeDescriptorSingleton_ = __singleton<ShapeDescriptorSingleton>._instance();
            RGB selectrgb_ = shapeDescriptorSingleton_._selectRGB();
            Rect2I labelRect2I_ = this._runPull(nPoint);

            Rect2I rect2i_ = new Rect2I(labelRect2I_);
            rect2i_._setHeight(mLabelHeight);
            this._rectDrawMove(nGraphics, rect2i_);
            rect2i_._offset(0, mLabelHeight);
            rect2i_._setHeight(mRectHeight);
            foreach (RectShape i in mRectShapes)
            {
                this._rectDrawMove(nGraphics, rect2i_);
                rect2i_._offset(0, mRectHeight);
            }

            Graphicsos._drawPull(labelRect2I_, nGraphics, selectrgb_, 4);
        }

        public void _pullEnd(Point2I nPoint)
        {
            Rect2I rect2i_ = this._runPull(nPoint);
            mLabel._setX(rect2i_._getX());
            mLabel._setY(rect2i_._getY());
            mLabel._setWidth(rect2i_._getWidth());
            mPullPoint._setPoint(default(int), default(int));
        }

        Rect2I _runPull(Point2I nPoint)
        {
            Rect2I rect2i_ = this._getRect2I();
            if (this._isPullRight(mPullPoint))
            {
                int v_ = nPoint._getX() - mPullPoint._getX();
                int w_ = rect2i_._getWidth();
                w_ += v_;
                if (w_ < mRectWidth)
                {
                    w_ = mRectWidth;
                }
                rect2i_._setWidth(w_);
            }
            if (this._isPullLeft(mPullPoint))
            {
                int v_ = nPoint._getX() - mPullPoint._getX();
                int w_ = rect2i_._getWidth();
                w_ -= v_;
                if (w_ < mRectWidth)
                {
                    v_ -= mRectWidth;
                    v_ += w_;
                }
                int x_ = rect2i_._getX();
                x_ += v_;
                if (x_ < 3)
                {
                    w_ -= 3;
                    w_ += x_;
                    x_ = 3;
                }
                rect2i_._setX(x_);
                rect2i_._sizeOffset(-v_, 0);
            }
            return rect2i_;
        }

        public bool _isSelect(Point2I nPoint)
        {
            Rect2I rect2i_ = this._getRect2I();
            return rect2i_._contain(nPoint);
        }

        public bool _isSelect(Point2I nBeg, Point2I nEnd)
        {
            Rect2I rect2i0_ = this._getRect2I();
            Rect2I rect2i1_ = new Rect2I(nBeg, nEnd);
            return rect2i0_._intersectWith(rect2i1_);
        }

        public void _moveVector(Point2I nPoint)
        {
            mLabel._offset(nPoint);
        }

        public void _updatePoint()
        {
        }

        public __tuple<Point2I, Point2I> _minMax(Point2I nMin, Point2I nMax)
        {
            Rect2I rect2i_ = this._getRect2I();
            return rect2i_._minMax(nMin, nMax);
        }

        static int mLabelHeight = 20;
        static int mRectHeight = 16;
        static int mRectWidth = 100;

        public bool _drawCreate(Point2I nPoint, string nId, Graphics nGraphics)
        {
            Rect2I labelRect2I_ = this._getRect2I();
            if (!labelRect2I_._contain(nPoint))
            {
                return false;
            }
            if (mRectShapes.Count <= 0)
            {
                if (this._rectIdSel(nId))
                {
                    base._rectDrawCreate(nGraphics, labelRect2I_);
                    return true;
                }
                return false;
            }
            Rect2I rect2i_ = new Rect2I(labelRect2I_);
            rect2i_._setHeight(mLabelHeight);
            if (rect2i_._contain(nPoint))
            {
                if (this._rectIdSel(nId))
                {
                    base._rectDrawCreate(nGraphics, labelRect2I_);
                    return true;
                }
                return false;
            }
            rect2i_._offset(0, mLabelHeight);
            rect2i_._setHeight(mRectHeight);
            foreach (RectShape i in mRectShapes)
            {
                if (rect2i_._contain(nPoint))
                {
                    if (i._rectIdSel(nId))
                    {
                        i._rectDrawCreate(nGraphics, rect2i_);
                        return true;
                    }
                    return false;
                }
                rect2i_._offset(0, mRectHeight);
            }
            return false;
        }

        public void _drawMove(Point2I nPoint, Graphics nGraphics)
        {
            Rect2I rect_ = this._getRect2I();
            rect_._offset(nPoint);
            rect_._setHeight(mLabelHeight);
            this._rectDrawMove(nGraphics, rect_);
            rect_._offset(0, mLabelHeight);
            rect_._setHeight(mRectHeight);
            foreach (RectShape i in mRectShapes)
            {
                this._rectDrawMove(nGraphics, rect_);
                rect_._offset(0, mRectHeight);
            }
        }

        public void _drawNormal(Graphics nGraphics)
        {
            Rect2I rect2i_ = this._getRect2I();
            rect2i_._setHeight(mLabelHeight);
            this._rectDrawNormal(nGraphics, rect2i_);
            rect2i_._offset(0, mLabelHeight);
            rect2i_._setHeight(mRectHeight);
            foreach (RectShape i in mRectShapes)
            {
                this._rectDrawNormal(nGraphics, rect2i_);
                rect2i_._offset(0, mRectHeight);
            }
        }

        public void _drawSelect(Graphics nGraphics)
        {
            ShapeDescriptorSingleton shapeDescriptorSingleton_ = __singleton<ShapeDescriptorSingleton>._instance();
            RGB selectrgb_ = shapeDescriptorSingleton_._selectRGB();
            Rect2I labelRect2I_ = this._getRect2I();

            Rect2I rect2i_ = new Rect2I(labelRect2I_);
            rect2i_._setHeight(mLabelHeight);
            this._rectDrawNormal(nGraphics, rect2i_);
            rect2i_._offset(0, mLabelHeight);
            rect2i_._setHeight(mRectHeight);
            foreach (RectShape i in mRectShapes)
            {
                this._rectDrawNormal(nGraphics, rect2i_);
                rect2i_._offset(0, mRectHeight);
            }

            Graphicsos._drawBroken(labelRect2I_, nGraphics, selectrgb_, 4);
        }

        public void _drawPull(Graphics nGraphics)
        {
            if (default(int) != mPullPoint._getX() || default(int) != mPullPoint._getY())
            {
                return;
            }
            ShapeDescriptorSingleton shapeDescriptorSingleton_ = __singleton<ShapeDescriptorSingleton>._instance();
            RGB selectrgb_ = shapeDescriptorSingleton_._selectRGB();
            Rect2I labelRect2I_ = this._getRect2I();

            Rect2I rect2i_ = new Rect2I(labelRect2I_);
            rect2i_._setHeight(mLabelHeight);
            this._rectDrawMove(nGraphics, rect2i_);
            rect2i_._offset(0, mLabelHeight);
            rect2i_._setHeight(mRectHeight);
            foreach (RectShape i in mRectShapes)
            {
                this._rectDrawMove(nGraphics, rect2i_);
                rect2i_._offset(0, mRectHeight);
            }

            Graphicsos._drawPull(labelRect2I_, nGraphics, selectrgb_, 4);
        }

        protected override Rect2I _getRect2I()
        {
            int x_ = mLabel._getX();
            int y_ = mLabel._getY();
            int w_ = mLabel._getWidth();
            if (w_ < mRectWidth)
            {
                w_ = mRectWidth;
            }
            int h_ = mLabelHeight;
            if (null != mRectShapes)
            {
                h_ += mRectShapes.Count * mRectHeight;
            }
            Rect2I result_ = new Rect2I(x_, y_, w_, h_);
            return result_;
        }

        public void _initLabel(ILabel nlabel)
        {
            base._initRect(nlabel);
            base._setLabelShape(this);
            mLabel = nlabel;
            ShapeDescriptorSingleton shapeDescriptorSingleton_ = __singleton<ShapeDescriptorSingleton>._instance();
            mLabelStream = shapeDescriptorSingleton_._labelDescriptor(nlabel._styleName());
            List<IRect> rects_ = nlabel._getRects();
            if (null == rects_)
            {
                return;
            }
            int index_ = 0;
            foreach (IRect i in rects_)
            {
                RectShape rect_ = new RectShape();
                rect_._initRect(i);
                rect_._setLabelShape(this);
                rect_._setIndex(index_);
                mRectShapes.Add(rect_);
                index_++;
            }
        }

        public LabelShape()
        {
            mRectShapes = new List<RectShape>();
            mPullPoint = new Point2I(default(int), default(int));
            mLabelStream = null;
            mLabel = null;
        }

        List<RectShape> mRectShapes;
        LabelStream mLabelStream;
        Point2I mPullPoint;
        ILabel mLabel;
    }
}
