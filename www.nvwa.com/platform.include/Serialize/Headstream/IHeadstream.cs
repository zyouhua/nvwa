namespace platform.include
{
    public interface IHeadstream : IDirty
    {
        event _SerializeSlot m_tHeadSerializeSlot;

        void _headSerialize(ISerialize nSerialize);

        event _SerializeTypeSlot m_tSerializeTypeSlot;

        SerializeType_ _serializeType();

        event _GetStringSlot m_tStreamNameSlot;

        string _streamName();
    }
}
