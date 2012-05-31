using System.Collections.Generic;

using window.include;
using platform.include;

namespace notepad.implement
{
    public class NewProjectUrl : Headstream
    {
        public override void _headSerialize(ISerialize nSerialize)
        {
            nSerialize._serialize(ref mNewFileNodes, "newFileNodes");

            base._headSerialize(nSerialize);
        }

        public override string _streamName()
        {
            return @"newProjectUrl";
        }

        public void _runInit()
        {
            foreach (NewFileNode i in mNewFileNodes)
            {
                i._runInit();
            }
        }

        public void _runLoad(string nUrl)
        {
            mStdUfl = new StdUfl();
            mStdUfl.m_tHeadSerializeSlot += this._headSerialize;
            mStdUfl.m_tStreamNameSlot += this._streamName;
            mStdUfl._runLoad(nUrl);
        }

        public void _addTreeNode(ITreeContain nTreeContain)
        {
            foreach (NewFileNode i in mNewFileNodes)
            {
                nTreeContain._addTreeNode(i);
            }
        }

        public NewProjectUrl()
        {
            mNewFileNodes = new List<NewFileNode>();
            mStdUfl = null;
        }

        List<NewFileNode> mNewFileNodes;
        StdUfl mStdUfl;
    }
}
