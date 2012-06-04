using System.Collections.Generic;

using notepad.include;
using platform.include;

namespace program.optimal
{
    public class ProjectCanvas : CanvasDockWidget
    {
        public override void _serialize(ISerialize nSerialize)
        {
            nSerialize._serialize(ref mClassShapes, @"classShapes");
        }

        public void _addClassShape(ClassShape nClassShape)
        {
            mClassShapes.Add(nClassShape);
            base._regLabel(nClassShape);
            base._runDirty();
        }

        public ProjectCanvas()
        {
            mClassShapes = new List<ClassShape>();
        }

        List<ClassShape> mClassShapes;
    }
}
