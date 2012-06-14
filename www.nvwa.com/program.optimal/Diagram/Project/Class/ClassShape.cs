using System.Collections.Generic;

using window.include;
using platform.include;

namespace program.optimal
{
    public class ClassShape : Label
    {
        public override void _serialize(ISerialize nSerialize)
        {
            nSerialize._serialize(ref mNameSpace, @"namespace");
            base._serialize(nSerialize);
        }

        public override string _styleName()
        {
            return @"zyouhua@gmail.com:classShape";
        }

        public void _setNameSpace(string nNameSpace)
        {
            mNameSpace = nNameSpace;
        }

        public string _getNameSpace()
        {
            return mNameSpace;
        }

        public ClassShape()
        {
            mNameSpace = null;
        }

        string mNameSpace;
    }
}
