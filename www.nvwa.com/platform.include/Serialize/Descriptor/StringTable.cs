using System.Collections.Generic;

namespace platform.include
{
    public class StringTable : Headstream
    {
        public override void _headSerialize(ISerialize nSerialize)
        {
            nSerialize._serialize(ref mStringElements, "stringElements");
            base._headSerialize(nSerialize);
        }

        public override string _streamName()
        {
            return @"stringTable";
        }

        public string _getString(string nName)
        {
            if (mStringElements.ContainsKey(nName))
            {
                StringElement stringElement_ = mStringElements[nName];
                string value_ = stringElement_._getValue();
                return value_;
            }
            return null;
        }

        public StringTable()
        {
            mStringElements = new Dictionary<string, StringElement>();
        }

        Dictionary<string, StringElement> mStringElements;
    }
}
