using System.Drawing;
using platform.include;

namespace window.optimal
{
    public class FONT : Stream
    {
        public override void _serialize(ISerialize nSerialize)
        {
            nSerialize._serialize(ref mFamilyName, "familyName");
            nSerialize._serialize(ref mRGB, "rgb");
            nSerialize._serialize(ref mSize, "size");
            nSerialize._serialize(ref mBold, "bold");
        }

        public Font _getFont()
        {
            Font result_ = null;
            if (mBold)
            {
                result_ = new Font(mFamilyName, mSize, FontStyle.Bold);
            }
            else
            {
                result_ = new Font(mFamilyName, mSize);
            }
            return result_;
        }

        public Color _getColor()
        {
            return mRGB._getColor();
        }

        public FONT()
        {
            mFamilyName = null;
            mRGB = null;
            mSize = 0;
        }

        string mFamilyName;
        RGB mRGB;
        int mSize;
        bool mBold;
    }
}
