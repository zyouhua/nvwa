using System.IO;

namespace platform.optimal
{
    public class DirUrl
    {
        public string _dirUrlPath()
        {
            string result_ = null;
            if (null != mFileUrl)
            {
                result_ = @"^file^" + mFileUrl;
            }
            if (null != mDirUrl)
            {
                if (null != result_)
                {
                    result_ = Path.Combine(result_, mDirUrl);
                }
                else
                {
                    result_ = mDirUrl;
                }
            }
            return result_;
        }

        public void _parserUrl(string nUrl)
        {
            int pos_ = nUrl.IndexOf(@"/");
            if (pos_ < 0)
            {
                mFileUrl = nUrl;
                return;
            }
            if (pos_ > 0)
            {
                mFileUrl = nUrl.Substring(0, pos_);
            }
            mDirUrl = nUrl.Substring(pos_ + 1);
        }

        public DirUrl()
        {
            mDirUrl = null;
            mFileUrl = null;
        }

        string mDirUrl;
        string mFileUrl;
    }
}
