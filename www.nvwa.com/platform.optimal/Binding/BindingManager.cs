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

        public BindingManager()
        {
            mBindings = new Dictionary<string, Binding>();
        }

        Dictionary<string, Binding> mBindings;
    }
}
