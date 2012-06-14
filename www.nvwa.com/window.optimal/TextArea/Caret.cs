using System;
using System.Drawing;
using System.Runtime.InteropServices;

namespace window.optimal
{
    public class Caret
    {
        public bool _create(int nWidth, int nHeight)
        {
            return CreateCaret(mHandle, 0, nWidth, nHeight);
        }

        public bool _setPos(int nX, int nY)
        {
            return SetCaretPos(nX, nY);
        }

        public void _hide()
        {
            HideCaret(mHandle);
        }

        public void _show()
        {
            ShowCaret(mHandle);
        }

        public void _paint(Graphics nGraphics)
        {
        }

        public void _destroy()
        {
            DestroyCaret();
        }

        public Caret(IntPtr nHandle)
        {
            mHandle = nHandle;
        }

        IntPtr mHandle;

        [DllImport("User32.dll")]
        static extern bool CreateCaret(IntPtr nWnd, int nBitmap, int nWidth, int nHeight);

        [DllImport("User32.dll")]
        static extern bool SetCaretPos(int nX, int nY);

        [DllImport("User32.dll")]
        static extern bool DestroyCaret();

        [DllImport("User32.dll")]
        static extern bool ShowCaret(IntPtr nWnd);

        [DllImport("User32.dll")]
        static extern bool HideCaret(IntPtr nWnd);
    }
}
