using System.Drawing;
using System.Windows.Forms;

using window.include;

namespace window.optimal
{
    public class SideTabItem : SideItem
    {
        public void _drawItem(Graphics nGraphics, Font nFont, Rectangle nRectangle)
        {
            string name_ = this._getName();
            Image image_ = this._getImage() as Image;
            int width_ = nRectangle.Height - 4;
            switch (mSideTabItemStatus)
            {
                case SideTabItemStatus_.mNormal_:
                    nGraphics.DrawImage(image_, nRectangle.X + 1, nRectangle.Y + 1, width_, width_);
                    nGraphics.DrawString(name_, nFont, SystemBrushes.ControlText, new PointF(nRectangle.X + width_ + 2, nRectangle.Y + 2));
                    break;
                case SideTabItemStatus_.mDrag_:
                    ControlPaint.DrawBorder3D(nGraphics, nRectangle, Border3DStyle.RaisedInner);
                    nRectangle.X += 1;
                    nRectangle.Y += 1;
                    nRectangle.Width -= 2;
                    nRectangle.Height -= 2;
                    nGraphics.FillRectangle(SystemBrushes.ControlDarkDark, nRectangle);
                    nGraphics.DrawImage(image_, nRectangle.X, nRectangle.Y, width_, width_);
                    nGraphics.DrawString(name_, nFont, SystemBrushes.HighlightText, new PointF(nRectangle.X + width_ + 1, nRectangle.Y + 1));
                    break;
                case SideTabItemStatus_.mSelected_:
                    ControlPaint.DrawBorder3D(nGraphics, nRectangle, Border3DStyle.RaisedInner);
                    nGraphics.DrawImage(image_, nRectangle.X + 1, nRectangle.Y + 1, width_, width_);
                    nGraphics.DrawString(name_, nFont, SystemBrushes.ControlText, new PointF(nRectangle.X + width_ + 2, nRectangle.Y + 2));
                    break;
                case SideTabItemStatus_.mChoosed_:
                    ControlPaint.DrawBorder3D(nGraphics, nRectangle, Border3DStyle.Sunken);
                    nRectangle.X += 1;
                    nRectangle.Y += 1;
                    nRectangle.Width -= 2;
                    nRectangle.Height -= 2;
                    using (Brush brush = new SolidBrush(ControlPaint.Light(SystemColors.Control)))
                    {
                        nGraphics.FillRectangle(brush, nRectangle);
                    }
                    nGraphics.DrawImage(image_, nRectangle.X + 1, nRectangle.Y + 1, width_, width_);
                    nGraphics.DrawString(name_, nFont, SystemBrushes.ControlText, new PointF(nRectangle.X + width_ + 2, nRectangle.Y + 2));
                    break;
            }
        }

        public void _setSideTabItemStatus(SideTabItemStatus_ nSideTabItemStatus)
        {
            mSideTabItemStatus = nSideTabItemStatus;
        }

        public SideTabItem()
        {
            mSideTabItemStatus = SideTabItemStatus_.mNormal_;
        }

        SideTabItemStatus_ mSideTabItemStatus;
    }
}
