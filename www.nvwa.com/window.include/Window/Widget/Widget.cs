using platform.include;

namespace window.include
{
    public abstract class Widget : Stream, IWidget
    {
        public override void _serialize(ISerialize nSerialize)
        {
            nSerialize._serialize(ref mControlName, @"controlName");
        }

        public abstract string _virstream();

        public string _controlName()
        {
            return mControlName;
        }

        public virtual void _runInit()
        {
        }

        public abstract void _initControl();

        public abstract IWidget _createControl();

        public abstract object _getControl();

        public bool _isContain()
        {
            return false;
        }

        public virtual void _setContain(IContain nContain)
        {
        }

        public Widget()
        {
            mControlName = null;
        }

        string mControlName;
    }
}
