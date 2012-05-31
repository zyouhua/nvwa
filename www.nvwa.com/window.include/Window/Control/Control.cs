using platform.include;

namespace window.include
{
    public abstract class Control : Contain, IControl
    {
        public override void _serialize(ISerialize nSerialize)
        {
            nSerialize._serialize(ref mControlName, @"controlName");
            base._serialize(nSerialize);
        }

        public override IContain _contain(int nLevel = 0)
        {
            if (null == mContain)
            {
                return null;
            }
            if (nLevel <= 0)
            {
                return mContain;
            }
            return mContain._contain(nLevel - 1);
        }

        public string _controlName()
        {
            return mControlName;
        }

        public abstract IWidget _createControl();

        public abstract object _getControl();

        public bool _isContain()
        {
            return true;
        }

        public void _setContain(IContain nContain)
        {
            mContain = nContain;
        }

        public abstract string _virstream();

        public Control()
        {
            mControlName = null;
            mContain = null;
        }

        string mControlName;
        IContain mContain;
    }
}
