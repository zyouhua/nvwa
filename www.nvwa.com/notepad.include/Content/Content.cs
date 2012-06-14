using System.Collections.Generic;

using window.include;
using platform.include;

namespace notepad.include
{
    public abstract class Content : Headstream, IContent
    {
        public abstract void _openUrl(string nUrl);

        public abstract void _createUrl(string nUrl, string nName);

        public abstract string _getUrl();

        public virtual IDockUrl _getDockUrl()
        {
            return null;
        }

        public virtual ITreeNode _getTreeNode()
        {
            return null;
        }

        public virtual void _firstInit()
        {
        }

        public virtual void _runInit()
        {
        }

        public Content()
        {
        }
    }
}
