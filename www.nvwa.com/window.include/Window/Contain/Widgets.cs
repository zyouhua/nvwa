using System.Collections.Generic;

using platform.include;

namespace window.include
{
    public class Widgets : Stream, IStreamCreator, IKeyStr
    {
        public override void _serialize(ISerialize nSerialize)
        {
            SerializeIO_ serializeIO_ = nSerialize._serializeIO();
            if (SerializeIO_.mInput_ == serializeIO_)
            {
                nSerialize._serialize(ref mName, @"name");
                IVirserialize serialize_ = nSerialize as IVirserialize;
                serialize_._setCreator(this);
                serialize_._virserialize(ref mWidgets, "controls");
                serialize_._clearCreator();
            }
            else if (SerializeIO_.mOutput_ == serializeIO_)
            {
                nSerialize._serialize(ref mWidgets, @"controls");
                nSerialize._serialize(ref mName, @"name");
            }
            else
            {
            }
        }

        public string _keyStr()
        {
            return mName;
        }

        public IVirstream _virstream(string nVirstream)
        {
            WindowSingleton windowSingleton_ = __singleton<WindowSingleton>._instance();
            IWidget result_ = windowSingleton_._getControl(nVirstream);
            return result_;
        }

        public void _runInit()
        {
            foreach (IWidget i in mWidgets)
            {
                i._setContain(mContain);
                i._runInit();
            }
        }

        public void _initControl()
        {
            foreach (IWidget i in mWidgets)
            {
                i._initControl();
                object control_ = i._getControl();
                mContain._addControl(control_);
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
            foreach (IWidget i in mWidgets)
            {
                string controlName_ = i._controlName();
                if (name_ == controlName_)
                {
                    if (null == childPath_)
                    {
                        return i;
                    }
                    else if (i._isContain())
                    {
                        IControl control_ = i as IControl;
                        IWidget result_ = control_._childControl(childPath_);
                        return result_;
                    }
                    else
                    {
                        throw new ControlPathException(nPath);
                    }
                }
            }
            return null;
        }

        public void _setContain(IContain nContain)
        {
            mContain = nContain;
        }

        public Widgets()
        {
            mWidgets = new List<IWidget>();
            mContain = null;
            mName = null;
        }

        List<IWidget> mWidgets;
        IContain mContain;
        string mName;
    }
}
