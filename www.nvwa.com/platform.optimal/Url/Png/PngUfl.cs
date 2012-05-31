using System.Drawing;

using platform.include;

namespace platform.optimal
{
    public class PngUfl : Ufl
    {
        public override void _runLoad(string nUrl)
        {
            UrlParser urlParser_ = new UrlParser(nUrl);
            string pngPath_ = urlParser_._returnResult();
            mImage = Image.FromFile(pngPath_);
            base._runLoad(nUrl);
        }

        public object _getImage()
        {
            return mImage;
        }

        public PngUfl()
        {
            mImage = null;
        }

        Image mImage;
    }
}
