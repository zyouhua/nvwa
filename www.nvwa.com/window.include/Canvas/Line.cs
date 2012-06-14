using System.Collections.Generic;

using window.include;
using platform.include;

namespace window.include
{
    public abstract class Line : Stream, ILine
    {
        public override void _serialize(ISerialize nSerialize)
        {
            nSerialize._serialize(ref mName, @"name");
            nSerialize._serialize(ref mBegPoint, "begPoint");
            nSerialize._serialize(ref mEndPoint, "endPoint");
        }

        public void _updateMove()
        {
            IRect beg_ = this._getBeg();
            IRect end_ = this._getEnd();
            Rect2I begRect_ = beg_._getRect();
            Rect2I endRect_ = end_._getRect();
            Point2I point_ = beg_._joinPoint(endRect_._centerPoint());
            mBegPoint._setPoint(point_);
            point_ = end_._joinPoint(begRect_._centerPoint());
            mEndPoint._setPoint(point_);
        }
        
        public void _setName(string nName)
        {
            mName = nName;
        }

        public string _getName()
        {
            return mName;
        }

        public virtual void _setBeg(IRect nRect)
        {
            nRect.m_tMovePoint2I += _begPointOffset;
        }

        public abstract IRect _getBeg();

        public virtual void _setEnd(IRect nRect)
        {
            nRect.m_tMovePoint2I += _endPointOffset;
        }

        public abstract IRect _getEnd();

        void _begPointOffset(Point2I nPoint)
        {
            mBegPoint._offset(nPoint);
        }

        void _endPointOffset(Point2I nPoint)
        {
            mEndPoint._offset(nPoint);
        }

        public void _setBegPoint(Point2I nPoint)
        {
            mBegPoint._setPoint(nPoint);
        }

        public Point2I _getBegPoint()
        {
            return new Point2I(mBegPoint);
        }

        public void _setEndPoint(Point2I nPoint)
        {
            mEndPoint._setPoint(nPoint);
        }

        public Point2I _getEndPoint()
        {
            return new Point2I(mEndPoint);
        }

        public abstract string _styleName();

        public Line()
        {
            mBegPoint = new Point2I();
            mEndPoint = new Point2I();
            mName = null;
        }

        Point2I mBegPoint;
        Point2I mEndPoint;
        string mName;
    }
}
