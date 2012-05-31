namespace platform.include
{
    public class Descriptor : StdUdl, IDescriptor
    {
        public string _getString(string nName)
        {
            return mStringTable._getString(nName);
        }

        public StringTable _getStringTable()
        {
            return mStringTable;
        }

        public Descriptor()
        {
            mStringTable = new StringTable();
        }

        StringTable mStringTable;
    }
}
