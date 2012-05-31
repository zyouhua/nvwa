using window.include;
using platform.include;

namespace window.optimal
{
    public abstract class ToolStripItem : Stream, IToolStripItem
    {
        public virtual void _runInit()
        {
            UpdateSingleton updateSingleton_ = __singleton<UpdateSingleton>._instance();
            updateSingleton_._registerUpdate(this);
        }

        public abstract void _initControl();

        public void _setContain(IContain nContain)
        {
            mContain = nContain;
        }

        protected IContain _getContain()
        {
            return mContain;
        }

        public abstract System.Windows.Forms.ToolStripItem _getToolStripItem();

        public abstract void _runUpdate();

        public ToolStripItem()
        {
            mContain = null;
        }
        IContain mContain;
    }
}
