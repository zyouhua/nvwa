namespace window.include
{
    public class TreeNodeMouseClickEventParams
    {
        public void _setTreeView(ITreeView nTreeView)
        {
            mTreeView = nTreeView;
        }

        public ITreeView _getTreeView()
        {
            return mTreeView;
        }

        public void _setContain(IContain nContain)
        {
            mContain = nContain;
        }

        public IContain _getcontain()
        {
            return mContain;
        }

        public void _setX(int nX)
        {
            mX = nX;
        }

        public int _getX()
        {
            return mX;
        }

        public void _setY(int nY)
        {
            mY = nY;
        }

        public int _getY()
        {
            return mY;
        }

        public TreeNodeMouseClickEventParams()
        {
            mTreeView = null;
            mContain = null;
            mX = -1;
            mY = -1;
        }

        ITreeView mTreeView;
        IContain mContain;
        int mX;
        int mY;
    }
}
