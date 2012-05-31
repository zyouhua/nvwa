using System.Collections.Generic;

namespace platform.include
{
    public class UpdateSingleton
    {
        public void _registerUpdate(IUpdate nUpdate)
        {
            mUpdates.Add(nUpdate);
        }

        public void _runUpdate()
        {
            foreach (IUpdate update_ in mUpdates)
            {
                update_._runUpdate();
            }
        }

        public UpdateSingleton()
        {
            mUpdates = new List<IUpdate>();
        }

        List<IUpdate> mUpdates;
    }
}
