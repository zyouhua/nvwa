using System.Windows.Forms;
using ICSharpCode.TextEditor;

using window.include;
using platform.include;
using platform.optimal;

namespace window.optimal
{
    public class TextEdit : Widget, ITextEdit
    {
        public override void _serialize(ISerialize nSerialize)
        {
            nSerialize._serialize(ref mHighlighting, @"highlighting");
            nSerialize._serialize(ref mDockStyle, @"dockStyle");
            base._serialize(nSerialize);
        }

        public override string _virstream()
        {
            return @"textEdit";
        }

        public override void _initControl()
        {
            if (null == mTextEditorControl || mTextEditorControl.IsDisposed)
            {
                mTextEditorControl = new TextEditorControl();
                if (string.Compare(mDockStyle, @"Top") == 0)
                {
                    mTextEditorControl.Dock = DockStyle.Top;
                }
                else if (string.Compare(mDockStyle, @"Bottom") == 0)
                {
                    mTextEditorControl.Dock = DockStyle.Bottom;
                }
                else if (string.Compare(mDockStyle, @"Fill") == 0)
                {
                    mTextEditorControl.Dock = DockStyle.Fill;
                }
                else if (string.Compare(mDockStyle, @"Left") == 0)
                {
                    mTextEditorControl.Dock = DockStyle.Left;
                }
                else if (string.Compare(mDockStyle, @"Right") == 0)
                {
                    mTextEditorControl.Dock = DockStyle.Right;
                }
                else
                {
                    mTextEditorControl.Dock = DockStyle.None;
                }
                mTextEditorControl.SetHighlighting(mHighlighting);
                if (null != mUrl)
                {
                    this._openUrl(mUrl);
                }
            }
        }

        public override IWidget _createControl()
        {
            return new TextEdit();
        }

        public override object _getControl()
        {
            return mTextEditorControl;
        }

        public void _openUrl(string nUrl)
        {
            mUrl = nUrl;
            if (null == mTextEditorControl || mTextEditorControl.IsDisposed)
            {
                return;
            }
            UrlParser urlParser_ = new UrlParser(nUrl);
            string path_ = urlParser_._returnResult();
            mTextEditorControl.LoadFile(path_);
        }

        public void _createUrl(string nUrl)
        {
            this._initControl();
            UrlParser urlParser_ = new UrlParser(nUrl);
            string path_ = urlParser_._returnResult();
            mTextEditorControl.SaveFile(path_);
            mUrl = nUrl;
        }

        public void _runSave()
        {
            UrlParser urlParser_ = new UrlParser(mUrl);
            string path_ = urlParser_._returnResult();
            mTextEditorControl.SaveFile(path_);
        }

        public void _setHighlighting(string nHighlighting)
        {
            mHighlighting = nHighlighting;
        }

        public string _getHighlighting()
        {
            return mHighlighting;
        }

        public void _setDockStyle(string nDockStyle)
        {
            mDockStyle = nDockStyle;
        }

        public string _getDockStyle()
        {
            return mDockStyle;
        }

        public TextEdit()
        {
            mTextEditorControl = null;
            mDockStyle = @"None";
            mHighlighting = null;
        }

        TextEditorControl mTextEditorControl;
        string mHighlighting;
        string mDockStyle;
        string mUrl;
    }
}
