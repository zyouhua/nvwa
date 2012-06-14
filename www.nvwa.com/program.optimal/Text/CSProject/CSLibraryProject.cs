using program.include;

namespace program.optimal
{
    public class CSLibraryProject : CSProject
    {
        public override void _runInit()
        {
            base._setApplicationType(ApplicationType_.mLibrary_);
            base._runInit();
        }
    }
}
