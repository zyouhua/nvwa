using System.Collections.Generic;

using window.include;
using platform.include;

namespace window.include
{
    public abstract class Label : Stream, ILabel
    {
        public override void _serialize(ISerialize nSerialize)
        {
            nSerialize._serialize(ref mName, @"name");
            nSerialize._serialize(ref mX, @"x");
            nSerialize._serialize(ref mY, @"y");
            nSerialize._serialize(ref mW, @"width");
        }

        public event _Point2ISlot m_tJoinPoint;

        public Point2I _joinPoint(Point2I nPoint)
        {
            if (null != m_tJoinPoint)
            {
                return this.m_tJoinPoint(nPoint);
            }
            return null;
        }

        public event _GetRect2ISlot m_tGetRect;

        public Rect2I _getRect()
        {
            if (null != m_tGetRect)
            {
                return this.m_tGetRect();
            }
            return null;
        }

        public event _SetPoint2ISlot m_tMovePoint2I;

        public void _offset(Point2I nPoint)
        {
            if (null != m_tMovePoint2I)
            {
                this.m_tMovePoint2I(nPoint);
            }
            mX += nPoint._getX();
            mY += nPoint._getY();
        }

        public void _setY(int nY)
        {
            mY = nY;
        }

        public int _getY()
        {
            return mY;
        }

        public void _setX(int nX)
        {
            mX = nX;
        }

        public int _getX()
        {
            return mX;
        }

        public void _setWidth(int nWidth)
        {
            mW = nWidth;
        }

        public int _getWidth()
        {
            return mW;
        }

        public virtual List<IRect> _getRects()
        {
            return null;
        }

        public void _setName(string nName)
        {
            mName = nName;
        }

        public string _getName()
        {
            return mName;
        }

        public abstract string _styleName();

        public Label()
        {
            m_tJoinPoint = null;
            m_tGetRect = null;
            m_tMovePoint2I = null;
            mName = null;
            mX = 0;
            mY = 0;
            mW = 0;
        }

        string mName;
        int mX;
        int mY;
        int mW;
    }
}
