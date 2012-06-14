namespace window.include
{
    public abstract class Creater
    {
        public abstract Action_ _getAction();

        public abstract object _runCreate();

        public void _setObject(object nObject)
        {
            mObject = nObject;
        }

        protected object _getObject()
        {
            return mObject;
        }

        public Creater()
        {
            mObject = null;
        }

        object mObject;
    }
}
