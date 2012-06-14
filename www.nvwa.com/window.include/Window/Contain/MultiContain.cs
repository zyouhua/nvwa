using System.Collections.Generic;

using platform.include;

namespace window.include
{
    public abstract class MultiContain : Stream, IContain
    {
        public override void _serialize(ISerialize nSerialize)
        {
            nSerialize._serialize(ref mWidgets, "widgets");
        }

        public virtual void _runInit()
        {
            foreach (KeyValuePair<string, Widgets> i in mWidgets)
            {
                Widgets widgets_ = i.Value;
                widgets_._setContain(this);
                widgets_._runInit();
            }
        }

        public virtual void _initControl()
        {
            foreach (KeyValuePair<string, Widgets> i in mWidgets)
            {
                Widgets widgets_ = i.Value;
                widgets_._initControl();
            }
        }

        public IWidget _childControl(string nPath)
        {
            string name_ = null;
            string childPath_ = null;
            int pos_ = nPath.IndexOf("/");
            if (pos_ < 0)
            {
                name_ = nPath;
            }
            else
            {
                name_ = nPath.Substring(0, pos_);
                childPath_ = nPath.Substring(pos_ + 1);
            }
            if (null == childPath_)
            {
                return null;
            }
            if (mWidgets.ContainsKey(name_))
            {
                Widgets widgets_ = mWidgets[name_];
                return widgets_._childControl(childPath_);
            }
            return null;
        }

        public abstract void _addControl(object nControl);

        public abstract IContain _contain(int nLevel = 0);

        public MultiContain()
        {
            mWidgets = new Dictionary<string, Widgets>();
        }

        Dictionary<string, Widgets> mWidgets;
    }
}
