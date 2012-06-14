using System.Globalization;

using platform.include;

namespace platform.optimal
{
    public class Culture : ICulture
    {
        public string _cultureName()
        {
            return CultureInfo.CurrentCulture.Name;
        }
    }
}
