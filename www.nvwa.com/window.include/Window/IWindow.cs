namespace window.include
{
    public interface IWindow
    {
        void _regShapeDescriptor(string nShapeDescriptorUrl);

        IForm _loadForm(string nFormDescriptorUrl);

        IWidget _getControl(string nControl);
    }
}
