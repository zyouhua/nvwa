using platform.include;

namespace window.optimal
{
    public class ComboBoxItem : Stream
    {
        public override void _serialize(ISerialize nSerialize)
        {
            nSerialize._serialize(ref mCmdStr, @"command");
            nSerialize._serialize(ref mName, @"name");
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

        public void _setName(string nName)
        {
            mName = nName;
        }

        public string _getName()
        {
            return mName;
        }

        public ComboBoxItem()
        {
            mCommand = null;
            mCmdStr = null;
            mName = null;
        }

        ICommand mCommand;
        string mCmdStr;
        string mName;
    }
}
