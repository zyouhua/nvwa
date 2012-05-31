using System.Collections.Generic;

using platform.include;

namespace window.optimal
{
    public class SideBarUrl : Headstream
    {
        public override void _headSerialize(ISerialize nSerialize)
        {
            nSerialize._serialize(ref mSideTabUrls, @"sideTabUrls");
        }

        public override string _streamName()
        {
            return @"sideBarUrl";
        }

        public List<string> _sideTabUrls()
        {
            return mSideTabUrls;
        }

        public SideBarUrl()
        {
            mSideTabUrls = new List<string>();
        }

        List<string> mSideTabUrls;
    }
}
