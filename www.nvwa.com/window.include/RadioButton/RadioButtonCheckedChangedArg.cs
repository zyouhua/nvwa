namespace window.include
{
    public class RadioButtonCheckedChangedArg
    {
        public void _setContain(IContain nContain)
        {
            mContain = nContain;
        }

        public IContain _getContain()
        {
            return mContain;
        }

        public void _setChecked(bool nChecked)
        {
            mChecked = nChecked;
        }

        public bool _getChecked()
        {
            return mChecked;
        }

        public RadioButtonCheckedChangedArg()
        {
            mContain = null;
            mChecked = false;
        }

        IContain mContain;
        bool mChecked;
    }
}
