using notepad.include;
using program.include;
using platform.include;

namespace program.optimal
{
    public class TextClass : TextContentAll, IStream
    {
        public void _serialize(ISerialize nSerialize)
        {
            nSerialize._serialize(ref mFileName, "fileName");
            nSerialize._serialize(ref mBuildAction, "buildAction");
        }

        public override string _getTreeNodeName()
        {
            return mFileName;
        }

        public override string _getTreeNodeImage()
        {
            string suffix_ = "txt";
            int pos_ = mFileName.LastIndexOf(".");
            if (pos_ > 0)
            {
                suffix_ = mFileName.Substring(pos_ + 1);
            }
            PlatformSingleton platformSingleton_ = __singleton<PlatformSingleton>._instance();
            return platformSingleton_._getContentImage(suffix_);
        }

        protected override void _setUrl(string nUrl, string nName)
        {
            mFileName = nName;
            mUrl = nUrl;
        }

        protected override void _setUrl(string nUrl)
        {
            int pos_ = nUrl.LastIndexOf("*");
            if (pos_ > 0)
            {
                mFileName = nUrl.Substring(pos_ + 1);
                mUrl = nUrl.Substring(0, pos_);
            }
        }

        public  void _setDirUrl(string nUrl)
        {
            mUrl = nUrl;
        }

        public override string _getDockUrlName()
        {
            return mFileName;
        }

        public override string _getUrl()
        {
            string result_ = mUrl.TrimEnd(new char[] { '/', '\\' });
            result_ += "*";
            result_ += mFileName;
            return result_;
        }

        public void _setBuildAction(BuildAction_ nBuildAction)
        {
            if (nBuildAction == BuildAction_.mCompile_)
            {
                mBuildAction = "Compile";
            }
            else
            {
                mBuildAction = "None";
            }
        }

        public BuildAction_ _getBuildAction()
        {
            if ("Compile" == mBuildAction)
            {
                return BuildAction_.mCompile_;
            }
            else
            {
                return BuildAction_.mNone_;
            }
        }

        public TextClass()
        {
            mBuildAction = @"None";
            mFileName = null;
            mUrl = null;
        }

        string mBuildAction;
        string mFileName;
        string mUrl;
    }
}
