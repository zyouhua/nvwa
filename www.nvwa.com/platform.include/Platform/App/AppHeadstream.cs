namespace platform.include
{
    public class AppHeadstream : Headstream
    {
        public override void _headSerialize(ISerialize nSerialize)
        {
            nSerialize._serialize(ref mAppUrl, @"appUrl");
            base._headSerialize(nSerialize);
        }
		
		public override string _streamName()
		{
			return @"appHeadstream";
		}
		
		public string _getAppUrl()
        {
            return mAppUrl;
        }

        public AppHeadstream()
        {
            mAppUrl = null;
        }

        string mAppUrl;
    }
}
