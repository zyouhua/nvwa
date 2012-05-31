using System.Drawing;

namespace window.optimal
{
    public interface IRectStyle
    {
        void _drawLabel(Graphics nGraphics, string nName, Rect2I nLabel, Rect2I nRect, RectStream nRectDescriptor);

        void _drawRect(Graphics nGraphics, string nName, Rect2I nRect, RectStream nRectDescriptor);

        string _styleName();
    }
}
