using System.IO;
using System.Collections.Generic;

using platform.include;

namespace platform.optimal
{
    public class UrlStruct
    {
        public bool _isUdl()
        {
            if (null != mFileName && @"" != mFileName)
            {
                return false;
            }
            if (null == mArchiveUrl || @"" == mArchiveUrl)
            {
                return false;
            }
            if (null != mFileUrl && @"" != mFileUrl)
            {
                return true;
            }
            if (mDirUrls.Count > 0)
            {
                return false;
            }
            return true;
        }

        public string _noClassUrl(string nUrl)
        {
            string result_ = null;
            int beg_ = nUrl.LastIndexOf(@":");
            if (beg_ < 6)
            {
                result_ = nUrl;
            }
            else
            {
                result_ = nUrl.Substring(0, beg_);
            }
            return result_;
        }

        public string _urlFile(string nFileName)
        {
            string result_ = this._urlDir();
            result_ = Path.Combine(result_, nFileName);
            return result_;
        }

        public string _urlDir()
        {
            SettingSingleton settingSingleton_ = __singleton<SettingSingleton>._instance();
            string result_ = Path.Combine(settingSingleton_._urlDirectory(), mSrcUrl);
            if (null != mDirName && @"" != mDirName)
            {
                result_ = Path.Combine(result_, mDirName);
            }
            if (null != mArchiveUrl && @"" != mArchiveUrl)
            {
                string temp_ = @"^arc^" + mArchiveUrl;
                result_ = Path.Combine(result_, temp_);
            }
            foreach (DirUrl i in mDirUrls)
            {
                string dirUrlPath_ = i._dirUrlPath();
                result_ = Path.Combine(result_, dirUrlPath_);
            }
            if (null != mFileUrl && @"" != mFileUrl)
            {
                string temp_ = @"^file^" + mFileUrl;
                result_ = Path.Combine(result_, temp_);
            }
            return result_;
        }

        public string _returnResult()
        {
            string result_ = this._urlDir();
            if (null != mFileName && @"" != mFileName)
            {
                result_ = Path.Combine(result_, mFileName);
            }
            return result_;
        }

        public string _className()
        {
            return mClassName;
        }

        public string _fileName()
        {
            return mFileName;
        }

        public bool _isClass()
        {
            return null != mClassName;
        }

        public bool _isFile()
        {
            return null != mFileName;
        }

        public void _parserUrl(string nUrl)
        {
            this._srcUrl(nUrl);
            this._dirName(nUrl);
            this._archiveUrl(nUrl);
            this._dirUrl(nUrl);
            this._fileUrl(nUrl);
            this._fileName(nUrl);
            this._className(nUrl);
        }

        void _srcUrl(string nUrl)
        {
            __tuple<int, int> index_ = this._srcUrlIndex(nUrl);
            if (null == index_)
            {
                return;
            }
            int beg_ = index_._get_0();
            int end_ = index_._get_1();
            if (beg_ < 0)
            {
                return;
            }
            if (end_ < 0)
            {
                mSrcUrl = nUrl.Substring(beg_);
            }
            else
            {
                mSrcUrl = nUrl.Substring(beg_, (end_ - beg_));
            }
        }

        __tuple<int, int> _srcUrlIndex(string nUrl)
        {
            string url_ = nUrl.Substring(6);
            int pos0_ = url_.IndexOf(@"/");
            int pos1_ = url_.IndexOf(@"\");
            int pos2_ = url_.IndexOf(@":");
            int pos3_ = url_.IndexOf(@"*");
            SortedSet<int> sortedSet_ = new SortedSet<int>();
            sortedSet_.Add(pos0_);
            sortedSet_.Add(pos1_);
            sortedSet_.Add(pos2_);
            sortedSet_.Add(pos3_);
            int result_ = -1;
            foreach (int i in sortedSet_)
            {
                if (i > 0)
                {
                    result_ = i;
                    break;
                }
            }
            if (result_ > 0)
            {
                result_ += 6;
            }
            return new __tuple<int, int>(6, result_);
        }

        void _dirName(string nUrl)
        {
            __tuple<int, int> index_ = this._dirNameIndex(nUrl);
            if (null == index_)
            {
                return;
            }
            int beg_ = index_._get_0();
            int end_ = index_._get_1();
            if (beg_ < 0)
            {
                return;
            }
            if (end_ < 0)
            {
                mDirName = nUrl.Substring(beg_);
            }
            else
            {
                mDirName = nUrl.Substring(beg_, (end_ - beg_));
            }
        }

        __tuple<int, int> _dirNameIndex(string nUrl)
        {
            string url_ = nUrl.Substring(6);
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
            if ((pos0_ < 0) || (pos0_ != beg_))
            {
                return null;
            }
            sortedSet_.Remove(pos0_);
            int end_ = -1;
            foreach (int i in sortedSet_)
            {
                if (i > 0)
                {
                    end_ = i;
                    break;
                }
            }
            if (end_ < 0)
            {
                return new __tuple<int, int>(beg_ + 7, end_);
            }
            else
            {
                return new __tuple<int, int>(beg_ + 7, end_ + 6);
            }
        }

        void _archiveUrl(string nUrl)
        {
            __tuple<int, int> index_ = this._archiveUrlIndex(nUrl);
            if (null == index_)
            {
                return;
            }
            int beg_ = index_._get_0();
            int end_ = index_._get_1();
            if (beg_ < 0)
            {
                return;
            }
            if (end_ < 0)
            {
                mArchiveUrl = nUrl.Substring(beg_);
            }
            else
            {
                mArchiveUrl = nUrl.Substring(beg_, (end_ - beg_));
            }
        }

        __tuple<int, int> _archiveUrlIndex(string nUrl)
        {
            int beg_ = nUrl.IndexOf(@"\");
            if (beg_ < 0)
            {
                return null;
            }
            string url_ = nUrl.Substring(beg_ + 1);
            int pos0_ = url_.IndexOf(@"/");
            int pos1_ = url_.IndexOf(@"\");
            int pos2_ = url_.IndexOf(@"*");
            int pos3_ = url_.IndexOf(@":");
            SortedSet<int> sortedSet_ = new SortedSet<int>();
            sortedSet_.Add(pos0_);
            sortedSet_.Add(pos1_);
            sortedSet_.Add(pos2_);
            sortedSet_.Add(pos3_);
            int end_ = -1;
            foreach (int i in sortedSet_)
            {
                if (i > 0)
                {
                    end_ = i;
                    break;
                }
            }
            if (end_ < 0)
            {
                return new __tuple<int, int>((beg_ + 1), end_);
            }
            else
            {
                return new __tuple<int, int>((beg_ + 1), (end_ + beg_ + 1));
            }
        }

        void _dirUrl(string nUrl)
        {
            __tuple<int, int> index_ = this._dirUrlIndex(nUrl);
            if (null == index_)
            {
                return;
            }
            int beg_ = index_._get_0();
            int end_ = index_._get_1();
            if (beg_ < 0)
            {
                return;
            }
            string dirUrlStr_ = null;
            if (end_ < 0)
            {
                dirUrlStr_ = nUrl.Substring(beg_);
            }
            else
            {
                dirUrlStr_ = nUrl.Substring(beg_, (end_ - beg_));
            }
            string[] str_ = dirUrlStr_.Split(new char[] { '\\' });
            foreach (string i in str_)
            {
                if (null == i || "" == i)
                {
                    continue;
                }
                DirUrl dirUrl_ = new DirUrl();
                dirUrl_._parserUrl(i);
                mDirUrls.Add(dirUrl_);
            }
        }

        __tuple<int, int> _dirUrlIndex(string nUrl)
        {
            int pos_ = nUrl.IndexOf(@"\");
            if (pos_ < 0)
            {
                return null;
            }
            string url_ = nUrl.Substring(pos_ + 1);
            int pos0_ = url_.IndexOf(@"/");
            int pos1_ = url_.IndexOf(@"\");
            int pos2_ = url_.IndexOf(@"*");
            int pos3_ = url_.IndexOf(@":");
            SortedSet<int> sortedSet_ = new SortedSet<int>();
            sortedSet_.Add(pos0_);
            sortedSet_.Add(pos1_);
            sortedSet_.Add(pos2_);
            sortedSet_.Add(pos3_);
            int start_ = -1;
            foreach (int i in sortedSet_)
            {
                if (i > 0)
                {
                    start_ = i;
                    break;
                }
            }
            if (start_ < 0)
            {
                return null;
            }
            url_ = url_.Substring(start_);
            pos2_ = url_.LastIndexOf(@"*");
            pos3_ = url_.LastIndexOf(@":");
            sortedSet_.Clear();
            sortedSet_.Add(pos2_);
            sortedSet_.Add(pos3_);
            int pos4_ = -1;
            foreach (int i in sortedSet_)
            {
                if (i > 0)
                {
                    pos4_ = i;
                    break;
                }
            }
            int pos5_ = -1;
            pos0_ = url_.LastIndexOf(@"/");
            pos1_ = url_.LastIndexOf(@"\");
            if (pos0_ < 0 && pos1_ < 0)
            {
                return null;
            }
            if (pos1_ < pos0_)
            {
                pos5_ = pos4_;
            }
            else
            {
                pos5_ = pos1_;
            }
            if (pos5_ < 0)
            {
                return new __tuple<int, int>(start_ + pos_ + 1, pos5_);
            }
            else
            {
                return new __tuple<int, int>(start_ + pos_ + 1, pos5_ + start_ + pos_ + 1);
            }
        }

        void _fileUrl(string nUrl)
        {
            __tuple<int, int> index_ = this._fileUrlIndex(nUrl);
            if (null == index_)
            {
                return;
            }
            int beg_ = index_._get_0();
            int end_ = index_._get_1();
            if (beg_ < 0)
            {
                return;
            }
            if (end_ < 0)
            {
                mFileUrl = nUrl.Substring(beg_);
            }
            else
            {
                mFileUrl = nUrl.Substring(beg_, (end_ - beg_));
            }
        }

        __tuple<int, int> _fileUrlIndex(string nUrl)
        {
            int pos_ = nUrl.IndexOf(@"\");
            if (pos_ < 0)
            {
                return null;
            }
            string url_ = nUrl.Substring(pos_ + 1);
            int beg_ = url_.LastIndexOf(@"\");
            if (beg_ < 0)
            {
                return null;
            }
            int pos0_ = url_.LastIndexOf(@"/");
            if (pos0_ > beg_)
            {
                return null;
            }
            int pos1_ = url_.LastIndexOf(@"*");
            int pos2_ = url_.LastIndexOf(@":");
            SortedSet<int> sortedSet_ = new SortedSet<int>();
            sortedSet_.Add(pos1_);
            sortedSet_.Add(pos2_);
            int end_ = -1;
            foreach (int i in sortedSet_)
            {
                if (i > 0)
                {
                    end_ = i;
                    break;
                }
            }
            if (end_ < 0)
            {
                return new __tuple<int, int>((beg_ + pos_ + 2), end_);
            }
            else
            {
                return new __tuple<int, int>((beg_ + pos_ + 2), (end_ + pos_ + 1));
            }
        }

        void _fileName(string nUrl)
        {
            int filePos_ = nUrl.LastIndexOf(@"*");
            if (filePos_ < 6)
            {
                return;
            }
            string url_ = nUrl.Substring(filePos_ + 1);
            int classPos_ = url_.LastIndexOf(@":");
            if (classPos_ > 6)
            {
                mFileName = url_.Substring(0, classPos_);
            }
            else
            {
                mFileName = url_;
            }
        }

        void _className(string nUrl)
        {
            int beg_ = nUrl.LastIndexOf(@":");
            if (beg_ < 6)
            {
                return;
            }
            mClassName = nUrl.Substring(beg_ + 1);
        }

        public UrlStruct()
        {
            mSrcUrl = null;
            mDirName = null;
            mArchiveUrl = null;
            mDirUrls = new List<DirUrl>();
            mFileUrl = null;
            mFileName = null;
            mClassName = null;
        }

        string mSrcUrl;
        string mDirName;
        string mArchiveUrl;
        List<DirUrl> mDirUrls;
        string mFileUrl;
        string mFileName;
        string mClassName;
    }
}
