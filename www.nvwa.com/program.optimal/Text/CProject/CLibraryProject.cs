using program.include;

namespace program.optimal
{
    public class CLibraryProject : CProject
    {
        public override void _runInit()
        {
            base._setApplicationType(ApplicationType_.mLibrary_);
            base._runInit();
        }
    }
}
