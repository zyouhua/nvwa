using platform.include;

namespace window.optimal
{
    public class Size2I : Stream
    {
        public static Size2I operator -(Size2I nLeft, Size2I nRight)
        {
            Size2I result_ = new Size2I();
            result_._setWidth(nLeft._getWidth() - nRight._getWidth());
            result_._setHeight(nLeft._getHeight() - nRight._getHeight());
            return result_;
        }

        public static Size2I operator +(Size2I nLeft, Size2I nRight)
        {
            Size2I result_ = new Size2I();
            result_._setWidth(nLeft._getWidth() + nRight._getWidth());
            result_._setHeight(nLeft._getHeight() + nRight._getHeight());
            return result_;
        }

        public static Size2I operator -(Size2I nLeft, Point2I nRight)
        {
            Size2I result_ = new Size2I();
            result_._setWidth(nLeft._getWidth() - nRight._getX());
            result_._setHeight(nLeft._getHeight() - nRight._getY());
            return result_;
        }

        public static Size2I operator +(Size2I nLeft, Point2I nRight)
        {
            Size2I result_ = new Size2I();
            result_._setWidth(nLeft._getWidth() + nRight._getX());
            result_._setHeight(nLeft._getHeight() + nRight._getY());
            return result_;
        }

        public override void _serialize(ISerialize nSerialize)
        {
            nSerialize._serialize(ref mWidth, @"width");
            nSerialize._serialize(ref mHeight, @"height");
        }

        public void _setSize(int nWidth, int nHeight)
        {
            mWidth = nWidth;
            mHeight = nHeight;
        }

        public void _setSize(Size2I nSize)
        {
            mWidth = nSize._getWidth();
            mHeight = nSize._getHeight();
        }

        public Size2I _getSize()
        {
            Size2I result_ = new Size2I();
            result_._setSize(this);
            return result_;
        }

        public void _setWidth(int nWidth)
        {
            mWidth = nWidth;
        }

        public int _getWidth()
        {
            return mWidth;
        }

        public void _setHeight(int nHeight)
        {
            mHeight = nHeight;
        }

        public int _getHeight()
        {
            return mHeight;
        }

        public Size2I(int nWidth, int nHeight)
        {
            mWidth = nWidth;
            mHeight = nHeight;
        }

        public Size2I(Size2I nSize)
        {
            mWidth = nSize._getWidth();
            mHeight = nSize._getHeight();
        }

        public Size2I()
        {
            mWidth = 0;
            mHeight = 0;
        }

        int mWidth;
        int mHeight;
    }
}
