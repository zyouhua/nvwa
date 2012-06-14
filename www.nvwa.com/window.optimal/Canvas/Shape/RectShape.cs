using System.Drawing;

using window.include;
using platform.include;

namespace window.optimal
{
    public class RectShape
    {
        public void _rectDrawNormal(Graphics nGraphics, Rect2I nRect)
        {
            RGB brushRGB_ = mRectStream._getFill();
            Graphicsos._runFill(nRect, nGraphics, brushRGB_);
            RGB penRGB_ = mRectStream._getDraw();
            Graphicsos._runDraw(nRect, nGraphics, penRGB_);
            this._rectDraw(nGraphics, nRect);
        }

        public void _rectDrawMove(Graphics nGraphics, Rect2I nRect)
        {
            RGB brushRGB_ = mRectStream._getMoveFill();
            Graphicsos._runFill(nRect, nGraphics, brushRGB_);
            RGB penRGB_ = mRectStream._getMoveDraw();
            Graphicsos._runDraw(nRect, nGraphics, penRGB_);
            this._rectDraw(nGraphics, nRect);
        }

        public void _rectDrawCreate(Graphics nGraphics, Rect2I nRect)
        {
            RGB brushRGB_ = mRectStream._getCreateFill();
            Graphicsos._runFill(nRect, nGraphics, brushRGB_);
            RGB penRGB_ = mRectStream._getCreateDraw();
            Graphicsos._runDraw(nRect, nGraphics, penRGB_);
        }

        public void _rectDrawCreate(Graphics nGraphics)
        {
            Rect2I rect_ = this._getRect2I();
            this._rectDrawCreate(nGraphics, rect_);
        }

        public void _rectDraw(Graphics nGraphics, Rect2I nRect)
        {
            ImagePos_ imagePos_ = mRectStream._getImagePos();
            Image image_ = mRectStream._getImage();
            int width_ = 12;
            int x_ = nRect._getX();
            int x1_ = x_ + width_ + 1;
            int y_ = nRect._getHeight() - width_;
            y_ /= 2;
            y_ = nRect._getY() + y_;
            int y1_ = nRect._getY();
            int w1_ = nRect._getWidth() - x1_;
            int h1_ = nRect._getHeight();
            if (imagePos_ == ImagePos_.mRectLeftTop_)
            {
                x1_ = nRect._getX();
                w1_ = nRect._getWidth();
                y_ = nRect._getY() - 11;
            }
            nGraphics.DrawImage(image_, x_ + 1, y_, width_, width_);
            string name_ = mRect._getName();
            FONT font_ = mRectStream._getFont();
            Rect2I rect_ = new Rect2I(x1_, y1_, w1_, h1_);
            Graphicsos._drawString(name_, rect_, nGraphics, font_);
        }

        public bool _rectIdSel(string nId)
        {
            string id_ = mRectStream._getStreamName();
            if (id_ != nId)
            {
                return false;
            }
            return true;
        }

        public void _setLabelShape(LabelShape nLabelShape)
        {
            mLabelShape = nLabelShape;
        }

        protected virtual Rect2I _getRect2I()
        {
            return mLabelShape._rectGetRect2I(mIndex);
        }

        public IRect _rectGetIRect()
        {
            return mRect;
        }

        protected virtual Point2I _rectJoinPoint(Point2I nPoint)
        {
            Rect2I rect_ = this._getRect2I();
            Point2I result_ = rect_._connectPoint(nPoint);
            return result_;
        }

        public virtual Point2I _rectJoinPoint(Point2I nBeg, Point2I nEnd)
        {
            Rect2I rect_ = mLabelShape._rectGetRect2I(mIndex);
            Point2I result_ = rect_._connectPoint(nEnd);
            return result_;
        }

        public void _setIndex(int nIndex)
        {
            mIndex = nIndex;
        }

        public void _initRect(IRect nRect)
        {
            ShapeDescriptorSingleton shapeDescriptorSingleton_ = __singleton<ShapeDescriptorSingleton>._instance();
            mRectStream = shapeDescriptorSingleton_._rectDescriptor(nRect._styleName());
            mRect = nRect;
            mRect.m_tGetRect += this._getRect2I;
            mRect.m_tJoinPoint += this._rectJoinPoint;
        }

        public RectShape()
        {
            mIndex = default(int);
            mLabelShape = null;
            mRectStream = null;
            mRect = null;
        }

        LabelShape mLabelShape;
        RectStream mRectStream;
        IRect mRect;
        int mIndex;
    }
}
