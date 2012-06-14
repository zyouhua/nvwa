using System.Windows.Forms;
using System.ComponentModel;
using WeifenLuo.WinFormsUI.Docking;

using window.include;

namespace window.optimal
{
    public class DockFrame : WeifenLuo.WinFormsUI.Docking.DockContent
    {
        public IDockUrl _getDockUrl()
        {
            return mDockUrl;
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            if (null == mDockUrl)
            {
                e.Cancel = false;
            }
            else if (mDockUrl._isDirty())
            {
                string dockUrlName_ = mDockUrl._getDockUrlName();
                if (null == dockUrlName_ || "" == dockUrlName_)
                {
                    dockUrlName_ = "untitle";
                }
                DialogResult dialogResult_ = MessageBox.Show("是否保存?", dockUrlName_, MessageBoxButtons.OKCancel);
                if (dialogResult_ == DialogResult.OK)
                {
                    mDockUrl._runSave();
                    e.Cancel = false;
                }
                else
                {
                    e.Cancel = true;
                }
            }
            else
            {
                e.Cancel = false;
            }
            base.OnClosing(e);
        }

        void _setName(string nName)
        {
            this.Text = nName;
        }

        public DockFrame(IDockUrl nDockUrl)
        {
            if (null == nDockUrl)
            {
                return;
            }
            mDockUrl = nDockUrl;
            this.Text = nDockUrl._getDockUrlName();
            mDockUrl.m_tDockUrlNameChange += this._setName;
        }

        IDockUrl mDockUrl;
    }
}
