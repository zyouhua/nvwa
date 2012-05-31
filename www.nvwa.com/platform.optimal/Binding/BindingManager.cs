using System.Collections.Generic;

using platform.include;

namespace platform.optimal
{
    public class BindingManager : Headstream
    {
        public override void _headSerialize(ISerialize nSerialize)
        {
            nSerialize._serialize(ref mBindings, @"bindings");
        }

        public override string _streamName()
        {
            return @"bindingManager";
        }

        public void _addBinding(Binding nBinding)
        {
            string key_ = nBinding._keyStr();
            if (mBindings.ContainsKey(key_))
            {
                return;
            }
            mBindings[key_] = nBinding;
            base._runDirty();
        }

        public Binding _getBinding(string nBinding)
        {
            Binding result_ = null;
            if (mBindings.ContainsKey(nBinding))
            {
                result_ = mBindings[nBinding];
            }
            return result_;
        }

        public IEnumerable<KeyValuePair<string, Binding>> _getBindings()
        {
            return mBindings;
        }

        public override bool _isDirty()
        {
            foreach (KeyValuePair<string, Binding> i in mBindings)
            {
                Binding binding_ = i.Value;
                if (binding_._isDirty())
                {
                    return true;
                }
            }
            return base._isDirty();
        }

        public BindingManager()
        {
            mBindings = new Dictionary<string, Binding>();
        }

        Dictionary<string, Binding> mBindings;
    }
}
