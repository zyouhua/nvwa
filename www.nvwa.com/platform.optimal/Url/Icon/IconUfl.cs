using System.Drawing;

using platform.include;

namespace platform.optimal
{
    public class IconUfl : Ufl
    {
        public override void _runLoad(string nUrl)
        {
            UrlParser urlParser_ = new UrlParser(nUrl);
            string iconPath_ = urlParser_._returnResult();
            mImage = new Icon(iconPath_);
            base._runLoad(nUrl);
        }

        public object _getImage()
        {
            return mImage;
        }

        public IconUfl()
        {
            mImage = null;
        }

        Icon mImage;
    }
}
