using platform.include;

namespace platform.startup
{
    class NotepadUrl : Headstream
    {
        public override void _headSerialize(ISerialize nSerialize)
        {
            nSerialize._serialize(ref mNotepadUrl, @"url");
        }

        public override string _streamName()
        {
            return @"notepadUrl";
        }

        public string _getNotepadUrl()
        {
            return mNotepadUrl;
        }

        public NotepadUrl()
        {
            mNotepadUrl = null;
        }

        string mNotepadUrl;
    }
}
