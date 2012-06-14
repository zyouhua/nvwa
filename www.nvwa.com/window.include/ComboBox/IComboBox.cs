using platform.include;

namespace window.include
{
    public interface IComboBox
    {
        event _GetStringSlot m_tSelectTextSlot;

        void _setEnable(bool nEnable);

        bool _isEnable();

        string _getSelectText();
    }
}
