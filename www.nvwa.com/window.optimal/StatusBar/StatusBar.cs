using window.include;
namespace window.optimal
{
    public class StatusBar : Widget
    {
        public override string _virstream()
        {
            return @"statusBar";
        }

        public override void _initControl()
        {
            if (null == mStatusStrip || mStatusStrip.IsDisposed)
            {
                mStatusStrip = new System.Windows.Forms.StatusStrip();
            }
        }

        public override IWidget _createControl()
        {
            return new StatusBar();
        }

        public override object _getControl()
        {
            return mStatusStrip;
        }

        public StatusBar()
        {
            mStatusStrip = null;
        }

        System.Windows.Forms.StatusStrip mStatusStrip;
    }
}
