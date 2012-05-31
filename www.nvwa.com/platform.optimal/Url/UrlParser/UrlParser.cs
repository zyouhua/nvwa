using System.Collections.Generic;

using platform.include;

namespace platform.optimal
{
    public class UrlParser
    {
        public bool _isUdl()
        {
            if (this._isClass())
            {
                return false;
            }
            if (this._isFile())
            {
                return false;
            }
            if (UrlType_.mUrl_ != mUrlType && UrlType_.mUid_ != mUrlType && UrlType_.mRid_ != mUrlType)
            {
                return false;
            }
            return mUrlStruct._isUdl();
        }

        public string _noClassUrl()
        {
            string result_ = null;
            if (UrlType_.mUrl_ == mUrlType || UrlType_.mUid_ == mUrlType || UrlType_.mRid_ == mUrlType)
            {
                result_ = mUrlStruct._noClassUrl(mUrl);
            }
            return result_;
        }

        public string _urlFile(string nFileName)
        {
            string result_ = null;
            if (UrlType_.mUrl_ == mUrlType || UrlType_.mUid_ == mUrlType || UrlType_.mRid_ == mUrlType)
            {
                result_ = mUrlStruct._urlFile(nFileName);
            }
            return result_;
        }
        
        public string _urlDir()
        {
            string result_ = null;
            if (UrlType_.mUrl_ == mUrlType || UrlType_.mUid_ == mUrlType || UrlType_.mRid_ == mUrlType)
            {
                result_ = mUrlStruct._urlDir();
            }
            return result_;
        }

        public string _returnResult()
        {
            string result_;
            if (UrlType_.mUrl_ == mUrlType || UrlType_.mUid_ == mUrlType || UrlType_.mRid_ == mUrlType)
            {
                result_ = mUrlStruct._returnResult();
            }
            else
            {
                result_ = mResult_;
            }
            return result_;
        }

        public string _className()
        {
            string result_ = null;
            if (UrlType_.mUrl_ == mUrlType || UrlType_.mUid_ == mUrlType || UrlType_.mRid_ == mUrlType)
            {
                result_ = mUrlStruct._className();
            }
            return result_;
        }

        public string _fileName()
        {
            string result_ = null;
            if (UrlType_.mUrl_ == mUrlType || UrlType_.mUid_ == mUrlType || UrlType_.mRid_ == mUrlType)
            {
                result_ = mUrlStruct._fileName();
            }
            return result_;
        }

        public bool _isClass()
        {
            bool result_ = false;
            if (UrlType_.mUrl_ == mUrlType || UrlType_.mUid_ == mUrlType)
            {
                result_ = mUrlStruct._isClass();
            }
            return result_;
        }

        public bool _isFile()
        {
            bool result_ = false;
            if (UrlType_.mUrl_ == mUrlType || UrlType_.mUid_ == mUrlType || UrlType_.mRid_ == mUrlType)
            {
                result_ = mUrlStruct._isFile();
            }
            return result_;
        }

        public string _mail()
        {
            return mMail;
        }

        public string _id()
        {
            return mId;
        }
        public string _findUrl(string nUrl)
        {
            string result_ = null;
            mUrl = nUrl.Trim();
            if (mUrl.StartsWith(@"url://"))
            {
                result_ = mUrl;
            }
            else if (mUrl.StartsWith(@"rid://"))
            {
                return this._findRidUrl(mUrl);
            }
            else if (mUrl.StartsWith(@"uid://"))
            {
                return this._findUidUrl(mUrl);
            }
            else if (mUrl.StartsWith(@"cid://"))
            {
                result_ = mUrl;
            }
            else if (mUrl.StartsWith(@"http://"))
            {
                result_ = mUrl;
            }
            else if (mUrl.StartsWith(@"fileId://"))
            {
                result_ = mUrl;
            }
            else if (mUrl.StartsWith(@"local://"))
            {
                result_ = mUrl;
            }
            else
            {
            }
            return result_;
        }

        public void _parserUrl(string nUrl)
        {
            mUrl = nUrl.Trim();
            if (mUrl.StartsWith(@"url://"))
            {
                this._urlUrl(mUrl);
            }
            else if (mUrl.StartsWith(@"rid://"))
            {
                this._ridUrl(mUrl);
            }
            else if (mUrl.StartsWith(@"uid://"))
            {
                this._uidUrl(mUrl);
            }
            else if (mUrl.StartsWith(@"cid://"))
            {
                this._cidUrl(mUrl);
            }
            else if (mUrl.StartsWith(@"http://"))
            {
                this._httpUrl(mUrl);
            }
            else if (mUrl.StartsWith(@"fileId://"))
            {
                this._fileIdUrl(mUrl);
            }
            else if (mUrl.StartsWith(@"local://"))
            {
                this._localUrl(mUrl);
            }
            else
            {
            }
        }

        void _urlUrl(string nUrl)
        {
            mUrlStruct = new UrlStruct();
            mUrlStruct._parserUrl(nUrl);
            mUrlType = UrlType_.mUrl_;
        }

        string _findRidUrl(string nUrl)
        {
            string url_ = nUrl.Substring(6);
            if (null == url_ || @"" == url_)
            {
                mUrlType = UrlType_.mError_;
                return null;
            }
            int pos0_ = url_.IndexOf(@"/");
            int pos1_ = url_.IndexOf(@"\");
            int pos2_ = url_.IndexOf(@"*");
            int pos3_ = url_.IndexOf(@":");
            SortedSet<int> sortedSet_ = new SortedSet<int>();
            sortedSet_.Add(pos0_);
            sortedSet_.Add(pos1_);
            sortedSet_.Add(pos2_);
            sortedSet_.Add(pos3_);
            int beg_ = -1;
            foreach (int i in sortedSet_)
            {
                if (i > 0)
                {
                    beg_ = i;
                    break;
                }
            }
            string name_ = null;
            string left_ = null;
            if (beg_ < 0)
            {
                name_ = url_;
            }
            else
            {
                name_ = url_.Substring(0, beg_);
                left_ = url_.Substring(beg_);
            }
            UidSingleton uidSingleton_ = __singleton<UidSingleton>._instance();
            Rid rid_ = uidSingleton_._getRid(name_);
            string ridUrl_ = rid_._getUrl();
            if (null != left_)
            {
                ridUrl_ += left_;
            }
            return ridUrl_;
        }

        void _ridUrl(string nUrl)
        {
            string url_ = nUrl.Substring(6);
            if (null == url_ || @"" == url_)
            {
                mUrlType = UrlType_.mError_;
                return;
            }
            int pos0_ = url_.IndexOf(@"/");
            int pos1_ = url_.IndexOf(@"\");
            int pos2_ = url_.IndexOf(@"*");
            int pos3_ = url_.IndexOf(@":");
            SortedSet<int> sortedSet_ = new SortedSet<int>();
            sortedSet_.Add(pos0_);
            sortedSet_.Add(pos1_);
            sortedSet_.Add(pos2_);
            sortedSet_.Add(pos3_);
            int beg_ = -1;
            foreach (int i in sortedSet_)
            {
                if (i > 0)
                {
                    beg_ = i;
                    break;
                }
            }
            string name_ = null;
            string left_ = null;
            if (beg_ < 0)
            {
                name_ = url_;
            }
            else
            {
                name_ = url_.Substring(0, beg_);
                left_ = url_.Substring(beg_);
            }
            UidSingleton uidSingleton_ = __singleton<UidSingleton>._instance();
            Rid rid_ = uidSingleton_._getRid(name_);
            string ridUrl_ = rid_._getUrl();
            if (null != left_)
            {
                ridUrl_ += left_;
            }
            mUrlStruct = new UrlStruct();
            mUrlStruct._parserUrl(ridUrl_);
            mUrlType = UrlType_.mRid_;
        }

        string _findUidUrl(string nUrl)
        {
            string url_ = nUrl.Substring(6);
            if (null == url_ || @"" == url_)
            {
                mUrlType = UrlType_.mError_;
                return null;
            }
            int pos0_ = url_.IndexOf(@"/");
            int pos1_ = url_.IndexOf(@"\");
            int pos2_ = url_.IndexOf(@"*");
            int pos3_ = url_.IndexOf(@":");
            SortedSet<int> sortedSet_ = new SortedSet<int>();
            sortedSet_.Add(pos0_);
            sortedSet_.Add(pos1_);
            sortedSet_.Add(pos2_);
            sortedSet_.Add(pos3_);
            int beg_ = -1;
            foreach (int i in sortedSet_)
            {
                if (i > 0)
                {
                    beg_ = i;
                    break;
                }
            }
            string name_ = null;
            string left_ = null;
            if (beg_ < 0)
            {
                name_ = url_;
            }
            else
            {
                name_ = url_.Substring(0, beg_);
                left_ = url_.Substring(beg_);
            }
            UidSingleton uidSingleton_ = __singleton<UidSingleton>._instance();
            Uid uid_ = uidSingleton_._getUid(name_);
            Uid optimalUid_ = uid_._getUid();
            string uidUrl_ = optimalUid_._getOptimal();
            if (null != left_)
            {
                uidUrl_ += left_;
            }
            return uidUrl_;
        }
        
        void _uidUrl(string nUrl)
        {
            string url_ = nUrl.Substring(6);
            if (null == url_ || @"" == url_)
            {
                mUrlType = UrlType_.mError_;
                return;
            }
            int pos0_ = url_.IndexOf(@"/");
            int pos1_ = url_.IndexOf(@"\");
            int pos2_ = url_.IndexOf(@"*");
            int pos3_ = url_.IndexOf(@":");
            SortedSet<int> sortedSet_ = new SortedSet<int>();
            sortedSet_.Add(pos0_);
            sortedSet_.Add(pos1_);
            sortedSet_.Add(pos2_);
            sortedSet_.Add(pos3_);
            int beg_ = -1;
            foreach (int i in sortedSet_)
            {
                if (i > 0)
                {
                    beg_ = i;
                    break;
                }
            }
            string name_ = null;
            string left_ = null;
            if (beg_ < 0)
            {
                name_ = url_;
            }
            else
            {
                name_ = url_.Substring(0, beg_);
                left_ = url_.Substring(beg_);
            }
            UidSingleton uidSingleton_ = __singleton<UidSingleton>._instance();
            Uid uid_ = uidSingleton_._getUid(name_);
            Uid optimalUid_ = uid_._getUid();
            string uidUrl_ = optimalUid_._getOptimal();
            if (null != left_)
            {
                uidUrl_ += left_;
            }
            mUrlStruct = new UrlStruct();
            mUrlStruct._parserUrl(uidUrl_);
            mUrlType = UrlType_.mUid_;
        }

        void _cidUrl(string nUrl)
        {
            string temp_ = nUrl.Substring(6);
            if (null == temp_ || @"" == temp_)
            {
                return;
            }
            PlatformSingleton platformSingleton_ = __singleton<PlatformSingleton>._instance();
            ICulture culture_ = platformSingleton_._currentCulture();
            mResult_ = culture_._cultureName();
            mResult_ += @".";
            mResult_ += temp_;
            mUrlType = UrlType_.mCid_;
        }

        void _httpUrl(string nUrl)
        {
            mResult_ = nUrl.Substring(7);
            if (null == mResult_ || @"" == mResult_)
            {
                return;
            }
            mUrlType = UrlType_.mHttp_;
        }

        void _fileIdUrl(string nUrl)
        {
            string temp_ = nUrl.Substring(9);
            if (null == temp_ || @"" == temp_)
            {
                return;
            }
            int pos_ = temp_.IndexOf(":");
            mMail = temp_.Substring(0, pos_);
            mId = temp_.Substring(pos_ + 1);
            mUrlType = UrlType_.mfileId_;
        }

        void _localUrl(string nUrl)
        {
            mResult_ = nUrl.Substring(8);
            if (null == mResult_ || @"" == mResult_)
            {
                return;
            }
            mUrlType = UrlType_.mLocal_;
        }

        public UrlParser(string nUrl)
        {
            mUrlType = UrlType_.mError_;
            mUrlStruct = null;
            mResult_ = null;
            mMail = null;
            mId = null;
            mUrl = null;
            this._parserUrl(nUrl);
        }

        public UrlParser()
        {
            mUrlType = UrlType_.mError_;
            mUrlStruct = null;
            mResult_ = null;
            mMail = null;
            mId = null;
            mUrl = null;
        }

        UrlStruct mUrlStruct;
        UrlType_ mUrlType;
        string mResult_;
        string mMail;
        string mId;
        string mUrl;
    }
}
