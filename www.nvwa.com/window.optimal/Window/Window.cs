using System.Windows.Forms;
using System.Collections.Generic;

using window.include;
using platform.include;

namespace window.optimal
{
    public class Window : IWindow
    {
        public void _regShapeDescriptor(string nShapeDescriptorUrl)
        {
            ShapeDescriptorSingleton shapeDescriptorSingleton_ = __singleton<ShapeDescriptorSingleton>._instance();
            shapeDescriptorSingleton_._regDescriptor(nShapeDescriptorUrl);
        }

        public IForm _loadForm(string nFormDescriptorUrl)
        {
            PlatformSingleton platformSingleton_ = __singleton<PlatformSingleton>._instance();
            Form result_ = platformSingleton_._findHeadstream<Form>(nFormDescriptorUrl);
            result_._runInit();
            return result_;
        }

        public IWidget _getControl(string nControl)
        {
            this._runInit();
            IWidget result_ = null;
            if (mControls.ContainsKey(nControl))
            {
                result_ = mControls[nControl];
            }
            result_ = result_._createControl();
            return result_;
        }

        public void _runInit()
        {
            if (true == mInited)
            {
                return;
            }

            Button button_ = new Button();
            this._regControl(button_);
            MenuStrip menuStrip_ = new MenuStrip();
            this._regControl(menuStrip_);
            ToolPanel toolPanel_ = new ToolPanel();
            this._regControl(toolPanel_);
            SideBar sideBar_ = new SideBar();
            this._regControl(sideBar_);
            DockPanel dockPanel_ = new DockPanel();
            this._regControl(dockPanel_);
            StatusBar statusBar_ = new StatusBar();
            this._regControl(statusBar_);
            Panel panel_ = new Panel();
            this._regControl(panel_);
            TextLabel textLabel_ = new TextLabel();
            this._regControl(textLabel_);
            TextBox textBox_ = new TextBox();
            this._regControl(textBox_);
            ListView listView_ = new ListView();
            this._regControl(listView_);
            TreeView treeView_ = new TreeView();
            this._regControl(treeView_);
            TextEdit textEdit_ = new TextEdit();
            this._regControl(textEdit_);
            ComboBox combox_ = new ComboBox();
            this._regControl(combox_);

            mInited = true;
        }
        
        void _regControl(IWidget nControl)
        {
            string control_ = nControl._virstream();
            if (mControls.ContainsKey(control_))
            {
                throw new VirstreamRepeatException(control_);
            }
            mControls[control_] = nControl;
        }

        public Window()
        {
            mControls = new Dictionary<string, IWidget>();
            mInited = false;
        }

        Dictionary<string, IWidget> mControls;
        bool mInited;
    }
}
