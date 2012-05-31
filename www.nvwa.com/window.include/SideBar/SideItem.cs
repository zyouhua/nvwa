using platform.include;

namespace window.include
{
    public class SideItem : Stream
    {
        public override void _serialize(ISerialize nSerialize)
        {
            nSerialize._serialize(ref mId, @"id");
            nSerialize._serialize(ref mMail, @"mail");
            nSerialize._serialize(ref mName, @"name");
            nSerialize._serialize(ref mTagUrl, @"tag");
            nSerialize._serialize(ref mImageUrl, @"imageUrl");
        }

        public virtual void _runInit()
        {
            PlatformSingleton platformSingleton_ = __singleton<PlatformSingleton>._instance();
            mImage = platformSingleton_._findPng(mImageUrl);
            if (null != mTagUrl)
            {
                mTag = platformSingleton_._findInterface<object>(mTagUrl);
            }
        }

        public void _setImageUrl(string nImageUrl)
        {
            mImageUrl = nImageUrl;
        }

        public string _getImageUrl()
        {
            return mImageUrl;
        }

        public void _setImage(object nImage)
        {
            mImage = nImage;
        }

        public object _getImage()
        {
            return mImage;
        }

        public void _setId(string nId)
        {
            mId = nId;
        }

        public string _getId()
        {
            return mId;
        }

        public void _setMail(string nMail)
        {
            mMail = nMail;
        }

        public string _getMail()
        {
            return mMail;
        }

        public void _setName(string nName)
        {
            mName = nName;
        }

        public string _getName()
        {
            return mName;
        }

        public void _setTagUrl(string nTagUrl)
        {
            mTagUrl = nTagUrl;
        }

        public string _getTagUrl()
        {
            return mTagUrl;
        }

        public void _setTag(object nTag)
        {
            mTag = nTag;
        }

        public object _getTag()
        {
            return mTag;
        }

        public SideItem()
        {
            mId = null;
            mMail = null;
            mName = null;
            mTag = null;
            mImage = null;
            mTagUrl = null;
            mImageUrl = null;
        }

        string mId;
        string mMail;
        string mName;
        string mTagUrl;
        string mImageUrl;
        object mTag;
        object mImage;
    }
}
