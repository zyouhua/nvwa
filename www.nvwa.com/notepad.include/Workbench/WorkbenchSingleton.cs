using System.Collections.Generic;

using window.include;
using platform.include;

namespace notepad.include
{
    public class WorkbenchSingleton
    {
        public void _runInit()
        {
            ConditionSingleton conditionSingleton_ = __singleton<ConditionSingleton>._instance();
            conditionSingleton_._loadDefaultCondition();
            conditionSingleton_._registerValidator(new ActiveContentValidator());
            conditionSingleton_._registerValidator(new ContentWidgetValidator());
        }

        public void _showGraceful(string nWindowUrl, string nFormDescriptorUrl)
        {
            mWorkbench._showGraceful(nWindowUrl, nFormDescriptorUrl);
        }

        public void _openUrl(string nUrl)
        {
            IContent content_ = null;
            if (mContents.ContainsKey(nUrl))
            {
                content_ = mContents[nUrl];
            }
            else
            {
                PlatformSingleton platformSingleton_ = __singleton<PlatformSingleton>._instance();
                content_ = platformSingleton_._findContent<IContent>(nUrl);
                if (null == content_)
                {
                    return;
                }
                content_._openUrl(nUrl);
                content_._runInit();
                mContents[nUrl] = content_;
            }
            IDockUrl dockUrl_ = content_._getDockUrl();
            if (null != dockUrl_)
            {
                this._showDockUrl(dockUrl_);
            }
        }

        public IDockUrl _getActiveDockUrl()
        {
            return mWorkbench._getActiveDockUrl();
        }

        public void _createContent(string nContentUrl, string nUrl, string nName)
        {
            PlatformSingleton platformSingleton_ = __singleton<PlatformSingleton>._instance();
            IContent content_ = platformSingleton_._findInterface<IContent>(nContentUrl);
            if (null == content_)
            {
                return;
            }
            content_._firstInit();
            content_._createUrl(nUrl, nName);
            content_._runInit();
            string url_ = content_._getUrl();
            mContents[url_] = content_;
            IDockUrl dockUrl_ = content_._getDockUrl();
            if (null != dockUrl_)
            {
                this._showDockUrl(dockUrl_);
            }
        }

        public void _showDockUrl(IDockUrl nDockUrl)
        {
            mWorkbench._showDockUrl(nDockUrl);
        }

        public void _showTreeNode(ITreeNode nTreeNode)
        {
            mWorkbench._showTreeNode(nTreeNode);
        }

        public void _setWorkbench(IWorkbench nWorkbench)
        {
            mWorkbench = nWorkbench;
        }

        public WorkbenchSingleton()
        {
            mContents = new Dictionary<string, IContent>();
            mWorkbench = null;
        }

        Dictionary<string, IContent> mContents;
        IWorkbench mWorkbench;
    }
}
