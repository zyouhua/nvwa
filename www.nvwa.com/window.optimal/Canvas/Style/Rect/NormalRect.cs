using System.Drawing;

using platform.include;

namespace window.optimal
{
    public class NormalRect : IRectStyle
    {
        public void _drawLabel(Graphics nGraphics, string nName, Rect2I nLabel, Rect2I nRect, RectStream nRectDescriptor)
        {
            RGB brushRGB_ = nRectDescriptor._getFill();
            Color brushColor_ = brushRGB_._getColor();
            Brush brush_ = new SolidBrush(brushColor_);
            RGB penRGB_ = nRectDescriptor._getDraw();
            Color penColor_ = penRGB_._getColor();
            Pen pen_ = new Pen(penColor_);
            nGraphics.FillRectangle(brush_, nLabel._getX(), nLabel._getY(), nLabel._getWidth(), nLabel._getHeight());
            nGraphics.DrawRectangle(pen_, nLabel._getX(), nLabel._getY(), nLabel._getWidth(), nLabel._getHeight());

            ShapeDescriptorSingleton shapeDescriptorSingleton_ = __singleton<ShapeDescriptorSingleton>._instance();
            Image image_ = nRectDescriptor._getImage();
            FONT font_ = shapeDescriptorSingleton_._labelFont();
            Font font0_ = font_._getFont();
            Color color_ = font_._getColor();
            int width_ = nRect._getHeight() - 4;
            nGraphics.DrawImage(image_, nRect._getX() + 1, nRect._getY() + 2, width_, width_);
            int width0_ = nRect._getWidth() - width_ - 3;
            string text_ = this._widthString(nGraphics, font0_, nName, width0_);
            nGraphics.DrawString(text_, font0_, new SolidBrush(color_), nRect._getX() + width_ + 2, nRect._getY() + 2);

        }

        public void _drawRect(Graphics nGraphics, string nName, Rect2I nRect, RectStream nRectDescriptor)
        {
            RGB penRGB_ = nRectDescriptor._getDraw();
            Color penColor_ = penRGB_._getColor();
            Line2I line_ = new Line2I(nRect._getPoint(), nRect._getRTPoint());
            line_._drawLine(nGraphics, penColor_);

            ShapeDescriptorSingleton shapeDescriptorSingleton_ = __singleton<ShapeDescriptorSingleton>._instance();
            Image image_ = nRectDescriptor._getImage();
            FONT font_ = shapeDescriptorSingleton_._rectFont();
            Font font0_ = font_._getFont();
            Color color_ = font_._getColor();
            int width_ = nRect._getHeight() - 4;
            nGraphics.DrawImage(image_, nRect._getX() + 1, nRect._getY() + 2, width_, width_);
            int width0_ = nRect._getWidth() - width_ - 3;
            string text_ = this._widthString(nGraphics, font0_, nName, width0_);
            nGraphics.DrawString(text_, font0_, new SolidBrush(color_), nRect._getX() + width_ + 2, nRect._getY() + 2);
        }

        string _widthString(Graphics nGraphics, Font nFont, string nText, int nWidth)
        {
            int end_ = 0;
            for (int i = nText.Length; i > 0; i--)
            {
                string temp_ = nText.Substring(0, i);
                int width_ = this._stringWidth(nGraphics, nFont, temp_);
                if (width_ < nWidth)
                {
                    end_ = i;
                    break;
                }
            }
            string result_ = nText.Substring(0, end_);
            return result_;
        }

        int _stringWidth(Graphics nGraphics, Font nFont, string nText)
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

        public string _styleName()
        {
            return @"normalRect";
        }
    }
}
