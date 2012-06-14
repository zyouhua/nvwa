using System.Drawing;
using System.Windows.Forms;
using System.Collections.Generic;

using platform.include;

namespace window.optimal
{
    public class ImageSingleton
    {
        public void _register(string nKey, Image nImage)
        {
            if (null == nKey || null == nImage)
            {
                return;
            }
            string key_ = nKey.Trim();
            if (@"" == key_)
            {
                return;
            }
            PlatformSingleton platformSingleton_ = __singleton<PlatformSingleton>._instance();
            string url_ = platformSingleton_._findUrl(key_);
            if (mImages.ContainsKey(url_))
            {
                return;
            }
            int index_ = this._getIndex();
            mImages[url_] = index_;
            mImageList.Images.Add(nImage);
        }

        public Image _getImage(string nKey)
        {
            if (null == nKey)
            {
                return null;
            }
            string key_ = nKey.Trim();
            if (@"" == key_)
            {
                return null;
            }
            PlatformSingleton platformSingleton_ = __singleton<PlatformSingleton>._instance();
            string url_ = platformSingleton_._findUrl(key_);
            if (mImages.ContainsKey(url_))
            {
                int imageIndex_ = mImages[url_];
                Image result_ = mImageList.Images[imageIndex_];
                return result_;
            }
            Image image_ = (Image)platformSingleton_._findPng(url_);
            if (null == image_)
            {
                return null;
            }
            int index = this._getIndex();
            mImages[url_] = index;
            mImageList.Images.Add(image_);
            return image_;
        }

        public int _getImageId(string nKey)
        {
            if (null == nKey)
            {
                return 0;
            }

            string key_ = nKey.Trim();
            if (@"" == key_)
            {
                return 0;
            }
            PlatformSingleton platformSingleton_ = __singleton<PlatformSingleton>._instance();
            string url_ = platformSingleton_._findUrl(key_);
            if (mImages.ContainsKey(url_))
            {
                return mImages[url_];
            }
            Image image_ = (Image)platformSingleton_._findPng(url_);
            if (null == image_)
            {
                return 0;
            }
            int index = this._getIndex();
            mImages[url_] = index;
            mImageList.Images.Add(image_);
            return index;
        }

        public ImageList _getImageList()
        {
            return mImageList;
        }

        int _getIndex()
        {
            mIndex++;
            return mIndex;
        }

        public ImageSingleton()
        {
            mImages = new Dictionary<string, int>();
            mImageList = new ImageList();
            mIndex = -1;
        }

        Dictionary<string, int> mImages;
        ImageList mImageList;
        int mIndex;
    }
}
