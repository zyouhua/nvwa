using System.Drawing;
using System.Drawing.Drawing2D;

using platform.include;

namespace window.optimal
{
    public class Graphicsos
    {
        public static void _fillRectangle(Point2I nPoint, Graphics nGraphics, RGB nRGB, int nSize = 3)
        {
            Point2I result_ = new Point2I(nPoint);
            result_._offset(-nSize, -nSize);
            Color color_ = nRGB._getColor();
            Brush brush_ = new SolidBrush(color_);
            nGraphics.FillRectangle(brush_, result_._getX(), result_._getY(), nSize * 2, nSize * 2);
        }

        public static void _drawRectangle(Point2I nPoint, Graphics nGraphics, RGB nRGB, int nSize = 3)
        {
            Point2I result_ = new Point2I(nPoint);
            result_._offset(-nSize, -nSize);
            Color color_ = nRGB._getColor();
            Pen pen_ = new Pen(color_);
            nGraphics.DrawRectangle(pen_, result_._getX(), result_._getY(), nSize * 2, nSize * 2);
        }

        public static void _fillEllipse(Point2I nPoint, Graphics nGraphics, RGB nRGB, int nSize = 3)
        {
            Point2I result_ = new Point2I(nPoint);
            result_._offset(-nSize, -nSize);
            Color color_ = nRGB._getColor();
            Brush brush_ = new SolidBrush(color_);
            nGraphics.FillEllipse(brush_, result_._getX(), result_._getY(), nSize * 2, nSize * 2);
        }

        public static void _drawEllipse(Point2I nPoint, Graphics nGraphics, RGB nRGB, int nSize = 3)
        {
            Point2I result_ = new Point2I(nPoint);
            result_._offset(-nSize, -nSize);
            Color color_ = nRGB._getColor();
            Pen pen_ = new Pen(color_);
            nGraphics.DrawEllipse(pen_, result_._getX(), result_._getY(), nSize * 2, nSize * 2);
        }

        public static void _drawPull(Rect2I nRect, Graphics nGraphics, RGB nRGB, int nSize = 4)
        {
            Point2I lefttop_ = nRect._getPoint();
            lefttop_._offset(-nSize, -nSize);

            Point2I righttop_ = nRect._getRTPoint();
            righttop_._offset(nSize, -nSize);

            Point2I leftbottom_ = nRect._getLBPoint();
            leftbottom_._offset(-nSize, nSize);

            Point2I rightbottom_ = nRect._getRBPoint();
            rightbottom_._offset(nSize, nSize);

            Point2I lt_ = new Point2I();
            lt_._setX(nRect._getX() - nSize);
            lt_._setY(nRect._centerY() - 3);
            Point2I lb_ = new Point2I();
            lb_._setX(nRect._getX() - nSize);
            lb_._setY(nRect._centerY() + 3);
            Point2I lp_ = new Point2I();
            lp_._setX(nRect._getX() - 4);
            lp_._setY(nRect._centerY());

            Point2I rt_ = new Point2I();
            rt_._setX(nRect._getRTX() + nSize);
            rt_._setY(nRect._centerY() - 3);
            Point2I rb_ = new Point2I();
            rb_._setX(nRect._getRTX() + nSize);
            rb_._setY(nRect._centerY() + 3);
            Point2I rp_ = new Point2I();
            rp_._setX(nRect._getRTX() + 4);
            rp_._setY(nRect._centerY());

            Line2I top_ = new Line2I(lefttop_, righttop_);
            _drawBroken(top_, nGraphics, nRGB);
            Line2I bottom_ = new Line2I(leftbottom_, rightbottom_);
            _drawBroken(bottom_, nGraphics, nRGB);
            Line2I left0_ = new Line2I(lefttop_, lt_);
            _drawBroken(left0_, nGraphics, nRGB);
            Line2I left1_ = new Line2I(leftbottom_, lb_);
            _drawBroken(left1_, nGraphics, nRGB);
            Line2I right0_ = new Line2I(righttop_, rt_);
            _drawBroken(right0_, nGraphics, nRGB);
            Line2I right1_ = new Line2I(rightbottom_, rb_);
            _drawBroken(right1_, nGraphics, nRGB);
            _drawEllipse(lp_, nGraphics, nRGB);
            _drawEllipse(rp_, nGraphics, nRGB);
        }

        public static void _drawString(string nName, Rect2I nRect, Graphics nGraphics, FONT nFont)
        {
            Font font_ = nFont._getFont();
            Color color_ = nFont._getColor();
            Brush brush_ = new SolidBrush(color_);
            string text_ = _widthString(nGraphics, font_, nName, nRect._getWidth() + 1);
            int x_ = _stringWidth(nGraphics, font_, text_);
            x_ = nRect._getWidth() - x_;
            x_ /= 2;
            x_ = nRect._getX() + x_;
            int y_ = nRect._getHeight() - font_.Height;
            y_ /= 2;
            y_ = nRect._getY() + y_ - 1;
            nGraphics.DrawString(text_, font_, brush_, x_, y_);
        }

        static string _widthString(Graphics nGraphics, Font nFont, string nText, int nWidth)
        {
            int end_ = 0;
            bool left_ = false;
            for (int i = nText.Length; i > 0; i--)
            {
                string temp_ = nText.Substring(0, i);
                if (left_)
                {
                    temp_ += "...";
                }
                int width_ = _stringWidth(nGraphics, nFont, temp_);
                if (width_ < nWidth)
                {
                    end_ = i;
                    break;
                }
                if (!left_)
                {
                    left_ = true;
                }
            }
            string result_ = nText.Substring(0, end_);
            if (left_)
            {
                result_ += "...";
            }
            return result_;
        }

        static int _stringWidth(Graphics nGraphics, Font nFont, string nText)
        {
            if (nText.Length <= 0)
            {
                return 1;
            }
            StringFormat format_ = new StringFormat();
            RectangleF rect_ = new RectangleF(0, 0, 1000, 1000);
            CharacterRange[] ranges_ = { new CharacterRange(0, nText.Length) };
            Region[] regions_ = new Region[1];
            format_.SetMeasurableCharacterRanges(ranges_);
            regions_ = nGraphics.MeasureCharacterRanges(nText, nFont, rect_, format_);
            rect_ = regions_[0].GetBounds(nGraphics);
            return (int)(rect_.Right);
        }

        public static void _runFill(Rect2I nRect, Graphics nGraphics, RGB nRGB)
        {
            Color color_ = nRGB._getColor();
            Brush brush_ = new SolidBrush(color_);
            nGraphics.FillRectangle(brush_, nRect._getX(), nRect._getY(), nRect._getWidth(), nRect._getHeight());
        }

        public static void _runDraw(Line2I nLine, Graphics nGraphics, RGB nRGB, string nStyle, int nWidth = 1, Image nImage = null, string nName = null, FONT nFont = null)
        {
            PenCapProvider penCapProvider_ = __singleton<PenCapProvider>._instance();
            Color color_ = nRGB._getColor();
            Pen pen_ = new Pen(color_, nWidth);
            if ("multiEnd" == nStyle)
            {
                pen_.CustomEndCap = penCapProvider_._getMultiCap();
            }
            else if ("multiBeg" == nStyle)
            {
                pen_.CustomStartCap = penCapProvider_._getMultiCap();
            }
            else if ("multiMulti" == nStyle)
            {
                pen_.CustomStartCap = penCapProvider_._getMultiCap();
                pen_.CustomEndCap = penCapProvider_._getMultiCap();
            }
            else if ("multiAggr" == nStyle)
            {
                pen_.CustomStartCap = penCapProvider_._getMultiCap();
                pen_.CustomEndCap = penCapProvider_._getAggrCap();
            }
            else if ("multiInh" == nStyle)
            {
                pen_.CustomStartCap = penCapProvider_._getMultiCap();
                pen_.CustomEndCap = penCapProvider_._getInhCap();
            }
            else if ("multiSingle" == nStyle)
            {
                pen_.CustomStartCap = penCapProvider_._getMultiCap();
                pen_.CustomEndCap = penCapProvider_._getSingleCap();
            }
            else if ("aggrEnd" == nStyle)
            {
                pen_.CustomEndCap = penCapProvider_._getAggrCap();
            }
            else if ("aggrBeg" == nStyle)
            {
                pen_.CustomStartCap = penCapProvider_._getAggrCap();
            }
            else if ("aggrMulti" == nStyle)
            {
                pen_.CustomStartCap = penCapProvider_._getAggrCap();
                pen_.CustomEndCap = penCapProvider_._getMultiCap();
            }
            else if ("aggrAggr" == nStyle)
            {
                pen_.CustomStartCap = penCapProvider_._getAggrCap();
                pen_.CustomEndCap = penCapProvider_._getAggrCap();
            }
            else if ("aggrInh" == nStyle)
            {
                pen_.CustomStartCap = penCapProvider_._getAggrCap();
                pen_.CustomEndCap = penCapProvider_._getInhCap();
            }
            else if ("aggrSingle" == nStyle)
            {
                pen_.CustomStartCap = penCapProvider_._getAggrCap();
                pen_.CustomEndCap = penCapProvider_._getSingleCap();
            }
            else if ("inhEnd" == nStyle)
            {
                pen_.CustomEndCap = penCapProvider_._getInhCap();
            }
            else if ("inhBeg" == nStyle)
            {
                pen_.CustomStartCap = penCapProvider_._getInhCap();
            }
            else if ("inhMulti" == nStyle)
            {
                pen_.CustomStartCap = penCapProvider_._getInhCap();
                pen_.CustomEndCap = penCapProvider_._getMultiCap();
            }
            else if ("inhAggr" == nStyle)
            {
                pen_.CustomStartCap = penCapProvider_._getInhCap();
                pen_.CustomEndCap = penCapProvider_._getAggrCap();
            }
            else if ("inhInh" == nStyle)
            {
                pen_.CustomStartCap = penCapProvider_._getInhCap();
                pen_.CustomEndCap = penCapProvider_._getInhCap();
            }
            else if ("inhSingle" == nStyle)
            {
                pen_.CustomStartCap = penCapProvider_._getInhCap();
                pen_.CustomEndCap = penCapProvider_._getSingleCap();
            }
            else if ("singleEnd" == nStyle)
            {
                pen_.CustomEndCap = penCapProvider_._getSingleCap();
            }
            else if ("singleBeg" == nStyle)
            {
                pen_.CustomStartCap = penCapProvider_._getSingleCap();
            }
            else if ("singleMulti" == nStyle)
            {
                pen_.CustomStartCap = penCapProvider_._getSingleCap();
                pen_.CustomEndCap = penCapProvider_._getMultiCap();
            }
            else if ("singleAggr" == nStyle)
            {
                pen_.CustomStartCap = penCapProvider_._getSingleCap();
                pen_.CustomEndCap = penCapProvider_._getAggrCap();
            }
            else if ("singleInh" == nStyle)
            {
                pen_.CustomStartCap = penCapProvider_._getSingleCap();
                pen_.CustomEndCap = penCapProvider_._getInhCap();
            }
            else if ("singleSingle" == nStyle)
            {
                pen_.CustomStartCap = penCapProvider_._getSingleCap();
                pen_.CustomEndCap = penCapProvider_._getSingleCap();
            }
            else
            {
            }
            GraphicsState graphicsState_ = nGraphics.Save();
            nGraphics.SmoothingMode = SmoothingMode.HighQuality;
            nGraphics.DrawLine(pen_, nLine._begX(), nLine._begY(), nLine._endX(), nLine._endY());
            nGraphics.Restore(graphicsState_);
            Rect2I rect_ = new Rect2I(nLine._getBeg(), nLine._getEnd());
            Point2I imagePoint_ = nLine._begPoint();
            if (null == imagePoint_)
            {
                return;
            }
            if (nLine._begX() < nLine._endX())
            {
                imagePoint_._offset(3, 0);
            }
            else
            {
                imagePoint_._offset(-3, 0);
            }
            if (nLine._begY() < nLine._endY())
            {
                imagePoint_._offset(0, 3);
            }
            else
            {
                imagePoint_._offset(0, -3);
            }
            nGraphics.DrawImage(nImage, imagePoint_._getX(), imagePoint_._getY(), 12, 12);
            if (null == nName || "" == nName)
            {
                return;
            }
            int h_ = rect_._getHeight();
            if (h_ < 18)
            {
                return;
            }
            Point2I center_ = rect_._centerPoint();
            int x_ = center_._getX() - 50;
            int y_ = center_._getY() - 9;
            int w_ = 100;
            int hx_ = 18;
            Rect2I rect0_ = new Rect2I(x_, y_, w_, hx_);
            Graphicsos._drawString(nName, rect0_, nGraphics, nFont);
        }

        public static void _runDraw(Rect2I nRect, Graphics nGraphics, RGB nRGB)
        {
            Color color_ = nRGB._getColor();
            Pen pen_ = new Pen(color_);
            nGraphics.DrawRectangle(pen_, nRect._getX(), nRect._getY(), nRect._getWidth(), nRect._getHeight());
        }

        public static void _drawBroken(Rect2I nRect, Graphics nGraphics, RGB nRGB, int nSize = 0)
        {
            Point2I lefttop_ = nRect._getPoint();
            lefttop_._offset(-nSize, -nSize);

            Point2I righttop_ = nRect._getRTPoint();
            righttop_._offset(nSize, -nSize);

            Point2I leftbottom_ = nRect._getLBPoint();
            leftbottom_._offset(-nSize, nSize);

            Point2I rightbottom_ = nRect._getRBPoint();
            rightbottom_._offset(nSize, nSize);

            Line2I top_ = new Line2I(lefttop_, righttop_);
            Graphicsos._drawBroken(top_, nGraphics, nRGB);
            Line2I bottom_ = new Line2I(rightbottom_, leftbottom_);
            Graphicsos._drawBroken(bottom_, nGraphics, nRGB);
            Line2I left_ = new Line2I(leftbottom_, lefttop_);
            Graphicsos._drawBroken(left_, nGraphics, nRGB);
            Line2I right_ = new Line2I(righttop_, rightbottom_);
            Graphicsos._drawBroken(right_, nGraphics, nRGB);
        }

        public static void _drawBroken(Line2I nLine, Graphics nGraphics, RGB nRGB, bool nStart = true)
        {
            Color color_ = nRGB._getColor();
            Pen pen_ = new Pen(color_);
            float length_ = nLine._length();
            if (length_ < 6)
            {
                nGraphics.DrawLine(pen_, nLine._begX(), nLine._begY(), nLine._endX(), nLine._endY());
                return;
            }
            Point2I point_ = nLine._vector();
            PointF f = new PointF();
            f.X = point_._getX() / length_;
            f.Y = point_._getY() / length_;
            if (nStart)
            {
                for (int i = 0; i < (length_ - 1); i += 8)
                {
                    Point beg_ = new Point();
                    beg_.X = (int)(i * f.X + nLine._begX());
                    beg_.Y = (int)(i * f.Y + nLine._begY());
                    int k = i + 3;
                    Point end_ = new Point();
                    end_.X = (int)(k * f.X + nLine._begX());
                    end_.Y = (int)(k * f.Y + nLine._begY());
                    nGraphics.DrawLine(pen_, beg_, end_);
                }
            }
            else
            {
                for (int i = 0; i < (length_ - 1); i += 8)
                {
                    Point beg_ = new Point();
                    int l = i + 5;
                    beg_.X = (int)(l * f.X + nLine._begX());
                    beg_.Y = (int)(l * f.Y + nLine._begY());
                    Point end_ = new Point();
                    int k = i;
                    end_.X = (int)(k * f.X + nLine._begX());
                    end_.Y = (int)(k * f.Y + nLine._begY());
                    nGraphics.DrawLine(pen_, beg_, end_);
                }
            }
        }
    }
}
