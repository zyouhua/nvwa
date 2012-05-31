using window.include;
using platform.include;

namespace notepad.implement
{
    public class TreeViewInitCommand : AbstractCommand
    {
        public override void _runCommand()
        {
            IContain contain_ = this._getOwner() as IContain;
            ITreeView treeView_ = contain_._childControl("treeView1") as ITreeView;
            NewProjectUrl newProjectUrl_ = new NewProjectUrl();
            string newUrl_ = @"rid://notepad.implement.newProjectUrl";
            newProjectUrl_._runLoad(newUrl_);
            newProjectUrl_._runInit();
            newProjectUrl_._addTreeNode(treeView_);
        }
    }
}
