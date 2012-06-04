using System.Collections.Generic;

using platform.include;

namespace window.optimal
{
    public class StyleSingleton
    {
        public void _loadDefaultStyle()
        {
            NormalRect normalRect_ = new NormalRect();
            this._regRectStyle(normalRect_);
        }

        public IRectStyle _rectStyle(string nRectStyle)
        {
            if (mRectStyles.ContainsKey(nRectStyle))
            {
                return mRectStyles[nRectStyle];
            }
            return null;
        }

        public LineStyle _lineStyle(string nLineStyle)
        {
            if (mLineStyles.ContainsKey(nLineStyle))
            {
                return mLineStyles[nLineStyle];
            }
            return null;
        }

        public void _regRectStyle(IRectStyle nRectStyle)
        {
            mRectStyles[nRectStyle._styleName()] = nRectStyle;
        }

        public void _regRectStyle(LineStyle nLineStyle)
        {
            mLineStyles[nLineStyle._styleName()] = nLineStyle;
        }

        public StyleSingleton()
        {
            mRectStyles = new Dictionary<string, IRectStyle>();
            mLineStyles = new Dictionary<string, LineStyle>();
        }

        Dictionary<string, IRectStyle> mRectStyles;
        Dictionary<string, LineStyle> mLineStyles;
    }
}
