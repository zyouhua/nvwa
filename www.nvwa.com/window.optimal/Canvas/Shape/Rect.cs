using window.include;
using platform.include;

namespace window.optimal
{
    public class Rect
    {
        public void _initRect(IRect nRect)
        {
            ShapeDescriptorSingleton shapeDescriptorSingleton_ = __singleton<ShapeDescriptorSingleton>._instance();
            mRectDescriptor = shapeDescriptorSingleton_._rectDescriptor(nRect._styleName());
            StyleSingleton styleSingleton_ = __singleton<StyleSingleton>._instance();
            mRectStyle = styleSingleton_._rectStyle(mRectDescriptor._getStyleName());
            mRect = nRect;
        }

        public Rect()
        {
            mRect = null;
            mRectStyle = null;
            mRectDescriptor = null;
        }

        IRect mRect;
        IRectStyle mRectStyle;
        RectStream mRectDescriptor;
    }
}
