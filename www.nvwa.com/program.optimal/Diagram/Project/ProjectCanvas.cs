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
            nSerialize._serialize(ref mDeriveShapes, @"deriveShapes");
        }

        public void _runInit()
        {
            foreach (ClassShape i in mClassShapes)
            {
                base._regLabel(i);
            }
            foreach (DeriveShape i in mDeriveShapes)
            {
                base._regLine(i);
            }
        }

        public bool _haveClass(string nName)
        {
            return false;
            //return mProject._haveClass(nName);
        }

        public void _addDeriveShape(DeriveShape nDeriveShape)
        {
            mDeriveShapes.Add(nDeriveShape);
            base._runDirty();
        }

        public void _addClassShape(ClassShape nClassShape)
        {
            mClassShapes.Add(nClassShape);
            base._runDirty();
        }

        public ProjectCanvas(Project nProject)
        {
            mDeriveShapes = new List<DeriveShape>();
            mClassShapes = new List<ClassShape>();
            mProject = nProject;
        }

        List<DeriveShape> mDeriveShapes;
        List<ClassShape> mClassShapes;
        Project mProject;
    }
}
