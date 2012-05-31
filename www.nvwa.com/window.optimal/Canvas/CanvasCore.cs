using System.Drawing;
using System.Collections.Generic;

using window.include;
using platform.include;

namespace window.optimal
{
    public class CanvasCore
    {
        public void _paintShape(Graphics nGraphics)
        {
            foreach (Shape i in mNormals)
            {
                i._drawNormal(nGraphics);
            }
            foreach (Shape i in mSelects)
            {
                i._drawSelect(nGraphics);
            }
            if (null != mEdit)
            {
                mEdit._drawChoose(nGraphics);
            }
            if (null != mMove)
            {
                mMove._drawSelect(nGraphics);
            }
        }

        public bool _pullBeg(Point2I nPoint)
        {
            if (mSelects.Count != 1)
            {
                return false;
            }
            Shape shape_ = mSelects[0];
            if (shape_._isPull(nPoint))
            {
                shape_._pullBeg(nPoint);
                mPull = shape_;
                mSelects.Clear();
                return true;
            }
            return false;
        }

        public bool _isEditBeg(Point2I nPoint)
        {
            foreach (Shape i in mSelects)
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
            for (int i = 0; i < mSelects.Count; i++)
            {
                Shape shape_ = mSelects[i];
                if (shape_._isSelect(nPoint))
                {
                    mEdit = shape_;
                    mSelects.RemoveAt(i);
                    return;
                }
            }
        }

        public void _moveBeg(Point2I nPoint)
        {
            this._pushDown(nPoint);
            this._resetShape();
            for (int i = 0; i < mNormals.Count; ++i)
            {
                Shape shape_ = mNormals[i];
                if (shape_._isSelect(nPoint))
                {
                    mMove = shape_;
                    mNormals.RemoveAt(i);
                    break;
                }
            }
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
            Label labelshape_ = new Label();
            labelshape_._initLabel(label_);
            mSelects.Add(labelshape_);
            mSideBar._resetActiveTab();
            this._pushUp();
        }

        public void _createBeg(Point2I nPoint)
        {
            this._pushDown(nPoint);
            this._resetShape();
            SideItem sideItem_ = mSideBar._getChooseSideItem();
            LineCreater lineCreater_ = sideItem_._getTag() as LineCreater;
        }

        public bool _inPull()
        {
            return null != mPull;
        }

        public void _pullMid(Point2I nPoint, Graphics nGraphics)
        {
            mPull._drawPull(nPoint, nGraphics);
        }

        public bool _isSelMid(Point2I nPoint)
        {
            if (null != mEdit)
            {
                return false;
            }
            if (null != mMove)
            {
                return false;
            }
            if (mSelects.Count > 0)
            {
                return false;
            }
            return true;
        }

        public void _selectMid(Point2I nPoint, Graphics nGraphics)
        {
            Rect2I rect_ = new Rect2I(mMouseDown, nPoint);
            rect_._drawBroken(nGraphics, Pens.DarkBlue);
        }

        public void _moveMid(Point2I nPoint, Graphics nGraphics)
        {
            __tuple<Point2I, Size2I> tuple_ = this._moveInfo(nPoint);
            Point2I vector_ = tuple_._get_0();
            if (null != mEdit)
            {
                mEdit._drawMove(vector_, nGraphics);
            }
            if (null != mMove)
            {
                mMove._drawMove(vector_, nGraphics);
            }
            foreach (Shape shape_ in mSelects)
            {
                shape_._drawMove(vector_, nGraphics);
            }
        }

        public void _createMid(Point2I nPoint, Graphics nGraphics)
        {
        }

        public void _pullEnd(Point2I nPoint)
        {
            mPull._pullEnd(nPoint);
            mSelects.Add(mPull);
            mPull = null;
        }

        public bool _isSelEnd(Point2I nPoint)
        {
            if (null != mEdit)
            {
                return false;
            }
            if (null != mMove)
            {
                return false;
            }
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
                Shape shape_ = mNormals[i];
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
            foreach (Shape shape_ in mSelects)
            {
                shape_._moveVector(vector_);
            }
            if (null != mEdit)
            {
                mEdit._moveVector(vector_);
                mSelects.Add(mEdit);
                mEdit = null;
            }
            if (null != mMove)
            {
                mMove._moveVector(vector_);
                mSelects.Add(mMove);
                mMove = null;
            }
            this._pushUp();
        }

        public void _createEnd(Point2I nPoint)
        {
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

        __tuple<Point2I, Point2I> _selectMinMax()
        {
            Point2I min_ = new Point2I(65536, 65536);
            Point2I max_ = new Point2I(0, 0);
            foreach (Shape shape_ in mSelects)
            {
                __tuple<Point2I, Point2I> tuple_ = shape_._minMax(min_, max_);
                if (null == tuple_)
                {
                    continue;
                }
                min_._setPoint(tuple_._get_0());
                max_._setPoint(tuple_._get_1());
            }
            return new __tuple<Point2I, Point2I>(min_, max_);
        }

        __tuple<Point2I, Point2I> _moveMinMax()
        {
            Point2I min_ = new Point2I(65536, 65536);
            Point2I max_ = new Point2I(0, 0);
            __tuple<Point2I, Point2I> tuple_ = this._selectMinMax();
            min_._setPoint(tuple_._get_0());
            max_._setPoint(tuple_._get_1());
            if (null != mEdit)
            {
                tuple_ = mEdit._minMax(min_, max_);
                min_._setPoint(tuple_._get_0());
                max_._setPoint(tuple_._get_1());
            }
            if (null != mMove)
            {
                tuple_ = mMove._minMax(min_, max_);
                min_._setPoint(tuple_._get_0());
                max_._setPoint(tuple_._get_1());
            }
            return tuple_;
        }

        void _pushDown(Point2I nPoint)
        {
            mMouseDown._setPoint(nPoint);
        }

        void _pushUp()
        {
            mMouseDown._setPoint(0, 0);
        }

        void _resetShape()
        {
            foreach (Shape i in mSelects)
            {
                mNormals.Add(i);
            }
            mSelects.Clear();
        }

        public void _setSideBar(ISideBar nSideBar)
        {
            mSideBar = nSideBar;
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

        public void _setObject(object nObject)
        {
            mObject = nObject;
        }

        public CanvasCore()
        {
            mSideBar = null;
            mSelects = new List<Shape>();
            mNormals = new List<Shape>();
            mEdit = null;
            mMove = null;
            mPull = null;
            mMouseDown = new Point2I();
            mObject = null;
        }

        ISideBar mSideBar;
        List<Shape> mSelects;
        List<Shape> mNormals;
        Shape mEdit;
        Shape mMove;
        Shape mPull;
        Point2I mMouseDown;
        object mObject;
    }
}
