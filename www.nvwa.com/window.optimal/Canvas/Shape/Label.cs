using System.Drawing;
using System.Collections.Generic;

using window.include;
using platform.include;

namespace window.optimal
{
    public class Label : Shape
    {
        public override void _drawNormal(Graphics nGraphics)
        {
        }

        public override void _drawSelect(Graphics nGraphics)
        {
            throw new System.NotImplementedException();
        }

        public override void _drawChoose(Graphics nGraphics)
        {
            throw new System.NotImplementedException();
        }

        public override bool _isPull(Point2I nPoint)
        {
            throw new System.NotImplementedException();
        }

        public override void _pullBeg(Point2I nPoint)
        {
            throw new System.NotImplementedException();
        }

        public override bool _isSelect(Point2I nPoint)
        {
            throw new System.NotImplementedException();
        }

        public override void _drawPull(Point2I nPoint, Graphics nGraphics)
        {
            throw new System.NotImplementedException();
        }

        public override void _drawMove(Point2I nPoint, Graphics nGraphics)
        {
            throw new System.NotImplementedException();
        }

        public override __tuple<Point2I, Point2I> _minMax(Point2I nMin, Point2I nMax)
        {
            throw new System.NotImplementedException();
        }

        public override void _pullEnd(Point2I nPoint)
        {
            throw new System.NotImplementedException();
        }

        public override bool _isSelect(Point2I nBeg, Point2I nEnd)
        {
            throw new System.NotImplementedException();
        }

        public override void _moveVector(Point2I nPoint)
        {
            throw new System.NotImplementedException();
        }

        public void _initLabel(ILabel nlabel)
        {
            ShapeDescriptorSingleton shapeDescriptorSingleton_ = __singleton<ShapeDescriptorSingleton>._instance();
            mRectDescriptor = shapeDescriptorSingleton_._rectDescriptor(nlabel._styleName());
            StyleSingleton styleSingleton_ = __singleton<StyleSingleton>._instance();
            mRectStyle = styleSingleton_._rectStyle(mRectDescriptor._getStyleName());
            mLabel = nlabel;
            List<IRect> rects_ = nlabel._getRects();
            foreach (IRect i in rects_)
            {
                Rect rect_ = new Rect();
                rect_._initRect(i);
                mRects.Add(rect_);
            }
        }

        public Label()
        {
            mRects = new List<Rect>();
            mLabel = null;
            mRectStyle = null;
            mRectDescriptor = null;
        }

        List<Rect> mRects;
        ILabel mLabel;
        IRectStyle mRectStyle;
        RectStream mRectDescriptor;
    }
}
