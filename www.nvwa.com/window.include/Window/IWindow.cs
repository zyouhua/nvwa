namespace window.include
{
    public interface IWindow
    {
        IForm _loadForm(string nFormDescriptorUrl);

        IWidget _getControl(string nControl);
    }
}
