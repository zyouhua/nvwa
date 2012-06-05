using platform.include;

namespace notepad.include
{
    public class Plugin : IPlugin
    {
        public void _startupPlugin()
        {
            ConditionSingleton conditionSingleton_ = __singleton<ConditionSingleton>._instance();
            conditionSingleton_._loadDefaultCondition();
            conditionSingleton_._registerValidator(new ActiveContentValidator());
            conditionSingleton_._registerValidator(new ContentWidgetValidator());
        }
    }
}
