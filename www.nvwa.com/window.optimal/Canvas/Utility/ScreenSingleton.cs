using platform.include;

namespace window.optimal
{
    public class ScreenSingleton
    {
        public Point2I _normalPoint(Point2I nPoint)
        {
            int width_ = mWidth * 2 - 3;
            int height_ = mHeight * 3 - 3;
            Point2I point_ = new Point2I(nPoint);
            int x_ = point_._getX();
            if (x_ < 3)
            {
                point_._setX(3);
            }
            if (x_ > width_)
            {
                point_._setX(width_);
            }
            int y_ = point_._getY();
            if (y_ < 3)
            {
                point_._setY(3);
            }
            if (y_ > height_)
            {
                point_._setY(height_);
            }
            return point_;
        }

        public ScreenSingleton()
        {
             mWidth = 1024;
             mHeight = 768;
        }

        int mWidth;
        int mHeight;
    }
}
