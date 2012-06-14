using System.Collections.Generic;

using window.include;
using platform.include;

namespace program.optimal
{
    public class DeriveShape : Line
    {
        public override void _setBeg(IRect nRect)
        {
            mBegClassShape = nRect as ClassShape;
            base._setBeg(mBegClassShape);
        }

        public override IRect _getBeg()
        {
            return mBegClassShape;
        }

        public override void _setEnd(IRect nRect)
        {
            mEndClassShape = nRect as ClassShape;
            base._setEnd(mEndClassShape);
        }

        public override IRect _getEnd()
        {
            return mEndClassShape;
        }

        public override string _styleName()
        {
            return @"zyouhua@gmail.com:deriveShape";
        }

        public DeriveShape()
        {
            mBegClassShape = null;
            mEndClassShape = null;
        }

        ClassShape mBegClassShape;
        ClassShape mEndClassShape;
    }
}
