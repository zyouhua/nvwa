﻿using window.include;

namespace notepad.include
{
    public interface ICanvasDockWidget : IDockWidget
    {
        ICanvas _getCanvas();
    }
}
