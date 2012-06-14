namespace platform.include
{
    public class OrCondition : IConditon
    {
        public bool _validate(bool nA, bool nB)
        {
            return (nA || nB);
        }

        public string _getName()
        {
            return @"or";
        }
    }
}
