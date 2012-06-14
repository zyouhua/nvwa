using System.Drawing;
using System.Collections.Generic;

using window.include;
using platform.include;

namespace window.optimal
{
    public class CanvasCore
    {
        public void _doubleClick(Point2I nPoint)
        {
        }

        public void _createLabel(Point2I nPoint)
        {
            this._pushDown(nPoint);
            this._resetShape();
            SideItem sideItem_ = mSideBar._getChooseSideItem();
            LabelCreater labelCreater_ = sideItem_._getTag() as LabelCreater;
            labelCreater_._setObject(mObject);
            labelCreater_._setX(nPoint._getX());
            labelCreater_._setY(nPoint._getY());
            ILabel label_ = labelCreater_._runCreate() as ILabel;
            if (null == label_)
            {
                mSideBar._resetActiveTab();
                this._pushUp();
                return;
            }
            LabelShape labelshape_ = new LabelShape();
            labelshape_._initLabel(label_);
            mSelects.Add(labelshape_);
            mSideBar._resetActiveTab();
            this._pushUp();
        }

        public void _mouseMove(Point2I nPoint, Graphics nGraphics)
        {
            SideItem sideItem_ = mSideBar._getChooseSideItem();
            LineCreater lineCreater_ = sideItem_._getTag() as LineCreater;
            string begId_ = lineCreater_._getBegId();
            foreach (IShape i in mNormals)
            {
                if (i._drawCreate(nPoint, begId_, nGraphics))
                {
                    return;
                }
            }
            foreach (IShape i in mSelects)
            {
                if (i._drawCreate(nPoint, begId_, nGraphics))
                {
                    return;
                }
            }
        }

        public void _createBeg(Point2I nPoint)
        {
            this._pushDown(nPoint);
            this._resetShape();

            SideItem sideItem_ = mSideBar._getChooseSideItem();
            LineCreater lineCreater_ = sideItem_._getTag() as LineCreater;
            string begId_ = lineCreater_._getBegId();
            foreach (IShape i in mNormals)
            {
                RectShape rectShape_ = i._getRectShape(nPoint, begId_);
                if (null != rectShape_)
                {
                    mRectShape = rectShape_;
                    break;
                }
            }
        }

        public void _createMid(Point2I nPoint, Graphics nGraphics)
        {
            if (null == mRectShape)
            {
                return;
            }
            Point2I point_ = mRectShape._rectJoinPoint(mMouseDown, nPoint);
            ShapeDescriptorSingleton shapeDescriptorSingleton_ = __singleton<ShapeDescriptorSingleton>._instance();
            RGB selectRGB_ = shapeDescriptorSingleton_._selectRGB();
            Line2I line_ = new Line2I(point_, nPoint);
            Graphicsos._drawBroken(line_, nGraphics, selectRGB_);

            mRectShape._rectDrawCreate(nGraphics);

            SideItem sideItem_ = mSideBar._getChooseSideItem();
            LineCreater lineCreater_ = sideItem_._getTag() as LineCreater;
            string endId_ = lineCreater_._getEndId();
            foreach (IShape i in mNormals)
            {
                if (i._drawCreate(nPoint, endId_, nGraphics))
                {
                    return;
                }
            }
        }

        public void _createEnd(Point2I nPoint)
        {
            if (null == mRectShape)
            {
                mSideBar._resetActiveTab();
                this._pushUp();
                return;
            }
            SideItem sideItem_ = mSideBar._getChooseSideItem();
            LineCreater lineCreater_ = sideItem_._getTag() as LineCreater;
            string endId_ = lineCreater_._getEndId();
            RectShape rectShape_ = null;
            foreach (IShape i in mNormals)
            {
                RectShape temp_ = i._getRectShape(nPoint, endId_);
                if (null != temp_)
                {
                    rectShape_ = temp_;
                    break;
                }
            }
            if (rectShape_ == mRectShape || null == rectShape_)
            {
                mRectShape = null;
                mSideBar._resetActiveTab();
                this._pushUp();
                return;
            }
            lineCreater_._setObject(mObject);
            lineCreater_._setBeg(mRectShape._rectGetIRect());
            lineCreater_._setEnd(rectShape_._rectGetIRect());

            ILine line_ = lineCreater_._runCreate() as ILine;

            LineShape lineshape_ = new LineShape();
            lineshape_._initLine(line_);
            Point2I beg_ = mRectShape._rectJoinPoint(mMouseDown, nPoint);
            Point2I end_ = rectShape_._rectJoinPoint(nPoint, mMouseDown);
            lineshape_._setBegPoint(beg_);
            lineshape_._setEndPoint(end_);
            mSelects.Add(lineshape_);

            mSideBar._resetActiveTab();
            this._pushUp();
        }

        public bool _pullBeg(Point2I nPoint)
        {
            if (mSelects.Count != 1)
            {
                return false;
            }
            IShape shape_ = mSelects[0];
            if (shape_._isPull(nPoint))
            {
                shape_._pullBeg(nPoint);
                mPull = shape_;
                mSelects.Clear();
                return true;
            }
            return false;
        }

        public bool _inPull()
        {
            return null != mPull;
        }

        public void _pullMid(Point2I nPoint, Graphics nGraphics)
        {
            mPull._pullMid(nPoint, nGraphics);
        }

        public void _pullEnd(Point2I nPoint)
        {
            mPull._pullEnd(nPoint);
            mSelects.Add(mPull);
            mPull = null;
            foreach (IShape i in mSelects)
            {
                i._updatePoint();
            }
            foreach (IShape i in mNormals)
            {
                i._updatePoint();
            }
        }

        public bool _isEditBeg(Point2I nPoint)
        {
            foreach (IShape i in mSelects)
            {
                if (i._isSelect(nPoint))
                {
                    return true;
                }
            }
            return false;
        }

        public void _editBeg(Point2I nPoint)
        {
            this._pushDown(nPoint);
        }

        public void _moveBeg(Point2I nPoint)
        {
            this._pushDown(nPoint);
            this._resetShape();
            for (int i = 0; i < mNormals.Count; ++i)
            {
                IShape shape_ = mNormals[i];
                if (shape_._isSelect(nPoint))
                {
                    mSelects.Add(shape_);
                    mNormals.RemoveAt(i);
                    break;
                }
            }
        }

        public bool _isSelMid(Point2I nPoint)
        {
            if (mSelects.Count > 0)
            {
                return false;
            }
            return true;
        }

        public void _selectMid(Point2I nPoint, Graphics nGraphics)
        {
            Rect2I rect_ = new Rect2I(mMouseDown, nPoint);
            ShapeDescriptorSingleton shapeDescriptorSingleton_ = __singleton<ShapeDescriptorSingleton>._instance();
            RGB rgb_ = shapeDescriptorSingleton_._selectRGB();
            Graphicsos._drawBroken(rect_, nGraphics, rgb_);
        }

        public void _moveMid(Point2I nPoint, Graphics nGraphics)
        {
            __tuple<Point2I, Size2I> tuple_ = this._moveInfo(nPoint);
            Point2I vector_ = tuple_._get_0();
            foreach (IShape i in mSelects)
            {
                i._drawMove(vector_, nGraphics);
            }
        }

        public bool _isSelEnd(Point2I nPoint)
        {
            if (mSelects.Count > 0)
            {
                return false;
            }
            return true;
        }

        public void _selectEnd(Point2I nPoint)
        {
            for (int i = 0; i < mNormals.Count; )
            {
                IShape shape_ = mNormals[i];
                if (shape_._isSelect(mMouseDown, nPoint))
                {
                    mSelects.Add(shape_);
                    mNormals.RemoveAt(i);
                }
                else
                {
                    i++;
                }
            }
            this._pushUp();
        }

        public void _moveEnd(Point2I nPoint)
        {
            __tuple<Point2I, Size2I> tuple_ = this._moveInfo(nPoint);
            Point2I vector_ = tuple_._get_0();
            foreach (IShape i in mSelects)
            {
                i._moveVector(vector_);
            }
            foreach (IShape i in mSelects)
            {
                i._updatePoint();
            }
            foreach (IShape i in mNormals)
            {
                i._updatePoint();
            }
            this._pushUp();
        }

        __tuple<Point2I, Size2I> _moveInfo(Point2I nPoint)
        {
            Point2I vector_ = nPoint._vectorFrom(mMouseDown);
            __tuple<Point2I, Point2I> tuple_ = this._moveMinMax();
            Point2I min_ = tuple_._get_0();
            Point2I max_ = tuple_._get_1();
            Size2I size_ = new Size2I();
            int width_ = max_._getX() - min_._getX();
            int height_ = max_._getY() - min_._getY();
            size_._setWidth(width_);
            size_._setHeight(height_);
            Point2I begin_ = new Point2I();
            if (vector_._getX() > 0)
            {
                begin_._setX(max_._getX());
            }
            else
            {
                begin_._setX(min_._getX());
            }
            if (vector_._getY() > 0)
            {
                begin_._setY(max_._getY());
            }
            else
            {
                begin_._setY(min_._getY());
            }
            Point2I end_ = begin_ + vector_;
            ScreenSingleton screenSingleton_ = __singleton<ScreenSingleton>._instance();
            end_ = screenSingleton_._normalPoint(end_);
            vector_ = end_ - begin_;
            return new __tuple<Point2I, Size2I>(vector_, size_);
        }

        __tuple<Point2I, Point2I> _moveMinMax()
        {
            Point2I min_ = new Point2I(65536, 65536);
            Point2I max_ = new Point2I(0, 0);
            foreach (IShape i in mSelects)
            {
                __tuple<Point2I, Point2I> tuple_ = i._minMax(min_, max_);
                if (null == tuple_)
                {
                    continue;
                }
                min_._setPoint(tuple_._get_0());
                max_._setPoint(tuple_._get_1());
            }
            return new __tuple<Point2I, Point2I>(min_, max_);
        }

        void _pushDown(Point2I nPoint)
        {
            mMouseDown._setPoint(nPoint);
        }

        void _pushUp()
        {
            mMouseDown._setPoint(0, 0);
        }

        public Action_ _whichAction()
        {
            if (null == mSideBar)
            {
                return Action_.mSelect_;
            }
            SideItem sideItem_ = mSideBar._getChooseSideItem();
            if (null == sideItem_)
            {
                return Action_.mSelect_;
            }
            string id_ = sideItem_._getId();
            string mail_ = sideItem_._getMail();
            if ("selectPointor" == id_ && @"zyouhua@gmail.com" == mail_)
            {
                return Action_.mSelect_;
            }
            Creater creater_ = sideItem_._getTag() as Creater;
            if (null == creater_)
            {
                return Action_.mSelect_;
            }
            return creater_._getAction();
        }

        public void _paintShape(Graphics nGraphics)
        {
            foreach (IShape i in mNormals)
            {
                i._drawNormal(nGraphics);
            }
            if (mSelects.Count == 1)
            {
                IShape shape_ = mSelects[0];
                shape_._drawPull(nGraphics);
            }
            else
            {
                foreach (IShape i in mSelects)
                {
                    i._drawSelect(nGraphics);
                }
            }
            if (null != mPull)
            {
                mPull._drawPull(nGraphics);
            }
        }

        public void _regLabel(ILabel nLabel)
        {
            LabelShape labelshape_ = new LabelShape();
            labelshape_._initLabel(nLabel);
            mSelects.Add(labelshape_);
        }

        public void _regLine(ILine nLine)
        {
            LineShape lineshape_ = new LineShape();
            lineshape_._initLine(nLine);
            mNormals.Add(lineshape_);
        }

        void _resetShape()
        {
            foreach (IShape i in mSelects)
            {
                mNormals.Add(i);
            }
            mSelects.Clear();
        }

        public void _setSideBar(ISideBar nSideBar)
        {
            mSideBar = nSideBar;
        }

        public void _setObject(object nObject)
        {
            mObject = nObject;
        }

        public CanvasCore()
        {
            mSelects = new List<IShape>();
            mNormals = new List<IShape>();
            mPull = null;
            mMouseDown = new Point2I();
            mRectShape = null;
            mSideBar = null;
            mObject = null;
        }

        List<IShape> mSelects;
        List<IShape> mNormals;
        IShape mPull;
        Point2I mMouseDown;
        RectShape mRectShape;
        ISideBar mSideBar;
        object mObject;
    }
}
