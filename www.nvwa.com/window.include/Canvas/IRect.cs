using platform.include;

namespace window.include
{
    public interface IRect : IStyle
    {
        event _Point2ISlot m_tJoinPoint;

        Point2I _joinPoint(Point2I nPoint);

        event _GetRect2ISlot m_tGetRect;

        Rect2I _getRect();

        event _SetPoint2ISlot m_tMovePoint2I;

        void _setName(string nName);

        string _getName();
    }
}
