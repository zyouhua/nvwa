using System.Collections.Generic;

using window.include;
using platform.include;

namespace program.optimal
{
    public class ClassShape : Stream, ILabel
    {
        public override void _serialize(ISerialize nSerialize)
        {
            nSerialize._serialize(ref mNameSpace, "namespace");
            nSerialize._serialize(ref mClassName, "className");
            nSerialize._serialize(ref mX, "x");
            nSerialize._serialize(ref mY, "y");
            nSerialize._serialize(ref mW, "width");
        }

        public void _setY(int nY)
        {
            mY = nY;
        }

        public int _getY()
        {
            return mY;
        }

        public void _setX(int nX)
        {
            mX = nX;
        }

        public int _getX()
        {
            return mX;
        }

        public void _setWidth(int nWidth)
        {
            mW = nWidth;
        }

        public int _getWidth()
        {
            return mW;
        }

        public List<IRect> _getRects()
        {
            return null;
        }

        public void _setName(string nName)
        {
            mClassName = nName;
        }

        public string _getName()
        {
            return mClassName;
        }

        public void  _setNameSpace(string nNameSpace)
        {
            mNameSpace = nNameSpace;
        }

        public string _getNameSpace()
        {
            return mNameSpace;
        }

        public string _styleName()
        {
            return @"zyouhua@gmail.com:classShape";
        }

        public ClassShape()
        {
            mNameSpace = null;
            mClassName = null;
            mX = 0;
            mY = 0;
            mW = 0;
        }

        string mNameSpace;
        string mClassName;
        int mX;
        int mY;
        int mW;
    }
}
