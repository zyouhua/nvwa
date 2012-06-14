using System.Collections.Generic;

namespace platform.include
{
    public class SaveSingleton
    {
        public void _runSave()
        {
            foreach (ISave save_ in mSaves)
            {
                save_._runSave();
            }
        }

        public void _addSave(ISave nSave)
        {
            mSaves.Add(nSave);
        }

        public SaveSingleton()
        {
            mSaves = new List<ISave>();
        }

        List<ISave> mSaves;
    }
}
