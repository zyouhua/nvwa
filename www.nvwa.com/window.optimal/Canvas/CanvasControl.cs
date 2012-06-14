﻿using System.Drawing;
using System.Windows.Forms;

using window.include;
using platform.include;

namespace window.optimal
{
    public class CanvasControl : PictureBox
    {
        void _mouseMove(Point2I nPoint, Graphics nGraphics)
        {
            Action_ action_ = mCanvasCore._whichAction();
            if (Action_.mSelect_ == action_)
            {
            }
            else if (Action_.mLine_ == action_)
            {
                mCanvasCore._mouseMove(nPoint, nGraphics);
            }
            else
            {
            }
        }

        void _leftDown(Point2I nPoint)
        {
            this._pushDown();
            Action_ action_ = mCanvasCore._whichAction();
            if (Action_.mLabel_ == action_)
            {
                mCanvasCore._createLabel(nPoint);
                this._pushUp();
            }
            else if (Action_.mLine_ == action_)
            {
                mCanvasCore._createBeg(nPoint);
            }
            else
            {
                if (mCanvasCore._pullBeg(nPoint))
                {
                    return;
                }
                if (mCanvasCore._isEditBeg(nPoint))
                {
                    mCanvasCore._editBeg(nPoint);
                }
                else
                {
                    mCanvasCore._moveBeg(nPoint);
                }
            }
        }

        void _leftMove(Point2I nPoint, Graphics nGraphics)
        {
            if (!this._isPush())
            {
                return;
            }
            Action_ action_ = mCanvasCore._whichAction();
            if (Action_.mSelect_ == action_)
            {
                if (mCanvasCore._inPull())
                {
                    mCanvasCore._pullMid(nPoint, nGraphics);
                    return;
                }
                if (mCanvasCore._isSelMid(nPoint))
                {
                    mCanvasCore._selectMid(nPoint, nGraphics);
                }
                else
                {
                    mCanvasCore._moveMid(nPoint, nGraphics);
                }
            }
            else if (Action_.mLine_ == action_)
            {
                mCanvasCore._createMid(nPoint, nGraphics);
            }
            else
            {
            }
        }

        void _leftUp(Point2I nPoint)
        {
            if (!this._isPush())
            {
                return;
            }
            Action_ action_ = mCanvasCore._whichAction();
            if (Action_.mSelect_ == action_)
            {
                if (mCanvasCore._inPull())
                {
                    mCanvasCore._pullEnd(nPoint);
                    this._pushUp();
                    return;
                }
                if (mCanvasCore._isSelEnd(nPoint))
                {
                    mCanvasCore._selectEnd(nPoint);
                }
                else
                {
                    mCanvasCore._moveEnd(nPoint);
                }
            }
            else if (Action_.mLine_ == action_)
            {
                mCanvasCore._createEnd(nPoint);
            }
            else
            {
            }
            this._pushUp();
        }

        void _leftClick(Point2I nPoint)
        {
        }

        void _doubleClick(Point2I nPoint)
        {
            if (!this._isPush())
            {
                return;
            }
            mCanvasCore._doubleClick(nPoint);
        }

        bool _isPush()
        {
            return mMouseDown;
        }

        void _pushDown()
        {
            mMouseDown = true;
        }

        void _pushUp()
        {
            mMouseDown = false;
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Point2I point_ = new Point2I(e.X, e.Y);
                ScreenSingleton screenSingleton_ = __singleton<ScreenSingleton>._instance();
                point_ = screenSingleton_._normalPoint(point_);
                this._leftDown(point_);
            }
            this.Refresh();

            base.OnMouseDown(e);
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            Graphics graphics_ = Graphics.FromHwnd(Handle);
            Point2I point_ = new Point2I(e.X, e.Y);
            ScreenSingleton screenSingleton_ = __singleton<ScreenSingleton>._instance();
            point_ = screenSingleton_._normalPoint(point_);
            this.Refresh();
            this._mouseMove(point_, graphics_);
            if (e.Button == MouseButtons.Left)
            {
                this._leftMove(point_, graphics_);
            }
            graphics_.Dispose();
            base.OnMouseMove(e);
        }

        protected override void OnMouseUp(MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Point2I point_ = new Point2I(e.X, e.Y);
                ScreenSingleton screenSingleton_ = __singleton<ScreenSingleton>._instance();
                point_ = screenSingleton_._normalPoint(point_);
                this._leftUp(point_);
            }
            this.Refresh();

            base.OnMouseUp(e);
        }

        protected override void OnMouseClick(MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Point2I point_ = new Point2I(e.X, e.Y);
                ScreenSingleton screenSingleton_ = __singleton<ScreenSingleton>._instance();
                point_ = screenSingleton_._normalPoint(point_);
                this._leftClick(point_);
            }
            this.Refresh();

            base.OnMouseClick(e);
        }

        protected override void OnMouseDoubleClick(MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Point2I point_ = new Point2I(e.X, e.Y);
                ScreenSingleton screenSingleton_ = __singleton<ScreenSingleton>._instance();
                point_ = screenSingleton_._normalPoint(point_);
                this._doubleClick(point_);
            }
            this.Refresh();

            base.OnMouseDoubleClick(e);
        }

        protected override bool ProcessDialogKey(Keys keyData)
        {
            return base.ProcessDialogKey(keyData);
        }

        protected override void OnPaint(PaintEventArgs pe)
        {
            mCanvasCore._paintShape(pe.Graphics);
            base.OnPaint(pe);
        }

        public CanvasControl(CanvasCore nCanvasCore)
        {
            SetStyle(ControlStyles.UserPaint, true);
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            SetStyle(ControlStyles.CacheText, true);
            this.BackColor = Color.White;
            ResizeRedraw = true;
            AllowDrop = true;
            mCanvasCore = nCanvasCore;
        }

        CanvasCore mCanvasCore;
        bool mMouseDown;
    }
}
