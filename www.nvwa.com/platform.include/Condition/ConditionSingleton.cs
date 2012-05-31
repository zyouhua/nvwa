using System.Collections.Generic;

namespace platform.include
{
    public class ConditionSingleton
    {
        public bool _validate(IEnumerable<ConditionStream> nConditionStreams)
        {
            bool result_ = false;
            foreach (ConditionStream i in nConditionStreams)
            {
                if (mValidators.ContainsKey(i._getName()))
                {
                    IValidator validator_ = mValidators[i._getName()];
                    bool temp_ = validator_._validate(i._getValue());
                    if (mConditions.ContainsKey(i._getType()))
                    {
                        IConditon condition_ = mConditions[i._getType()];
                        result_ = condition_._validate(result_, temp_);
                    }
                }
            }
            return result_;
        }

        public void _registerValidator(IValidator nValidator)
        {
            mValidators[nValidator._getName()] = nValidator;
        }

        public void _registerConditon(IConditon nConditon)
        {
            mConditions[nConditon._getName()] = nConditon;
        }

        public void _loadDefaultCondition()
        {
            this._registerConditon(new AndCondition());
            this._registerConditon(new NoCondition());
            this._registerConditon(new OrCondition());
        }

        public ConditionSingleton()
        {
            mConditions = new Dictionary<string, IConditon>();
            mValidators = new Dictionary<string, IValidator>();
        }

        Dictionary<string, IValidator> mValidators;
        Dictionary<string, IConditon> mConditions;
    }
}
