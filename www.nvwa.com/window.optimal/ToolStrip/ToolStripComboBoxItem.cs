using platform.include;

namespace window.optimal
{
    public class ToolStripComboBoxItem : Stream
    {
        public override void _serialize(ISerialize nSerialize)
        {
            nSerialize._serialize(ref mCmdStr, @"command");
            nSerialize._serialize(ref mText, @"tooltip");
        }

        public  void _runInit()
        {
            PlatformSingleton platformSingleton_ = __singleton<PlatformSingleton>._instance();
            mCommand = platformSingleton_._findInterface<ICommand>(mCmdStr);
        }

        public ICommand _getCommand()
        {
            return mCommand;
        }

        public void _setText(string nText)
        {
            mText = nText;
        }

        public string _getText()
        {
            return mText;
        }

        public ToolStripComboBoxItem()
        {
            mCommand = null;
            mCmdStr = null;
            mText = null;
        }

        ICommand mCommand;
        string mCmdStr;
        string mText;
    }
}
