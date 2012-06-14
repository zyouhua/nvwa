namespace program.optimal
{
    public class StringFormat
    {
        public static string _className(string nName)
        {
            if (null == nName)
            {
                return null;
            }
            string name_ = nName.Trim();
            if ("" == name_)
            {
                return null;
            }
            bool result_ = true;
            foreach (char i in nName)
            {
                if ('_' == i)
                {
                    continue;
                }
                if ('a' <= i && 'z'>= i)
                {
                    continue;
                }
                if ('A' <= i && 'Z'>= i)
                {
                    continue;
                }
                if ('0' <= i && '9'>= i)
                {
                    continue;
                }
                result_ = false;
            }
            if (!result_)
            {
                return null;
            }
            char c_ = name_[0];
            if ('I' == c_)
            {
                return null;
            }
            if ('A' <= c_ && 'Z' >= c_)
            {
                return name_;
            }
            return null;
        }
    }
}
