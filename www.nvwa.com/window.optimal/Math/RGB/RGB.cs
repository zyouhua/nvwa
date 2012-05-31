using System.Drawing;

using platform.include;

namespace window.optimal
{
    public class RGB : Stream
    {
        public override void _serialize(ISerialize nSerialize)
        {
            nSerialize._serialize(ref mA, @"a");
            nSerialize._serialize(ref mR, @"r");
            nSerialize._serialize(ref mG, @"g");
            nSerialize._serialize(ref mB, @"b");
        }

        public void _fromColor(Color nColor)
        {
            mA = nColor.A;
            mR = nColor.R;
            mG = nColor.G;
            mB = nColor.B;
            base._runDirty();
        }

        public Color _getColor()
        {
            Color result_ = Color.FromArgb(mA, mR, mG, mB);
            return result_;
        }

        public void _setRGB(RGB nRGB)
        {
            mA = nRGB._getA();
            mR = nRGB._getR();
            mG = nRGB._getG();
            mB = nRGB._getB();
            base._runDirty();
        }

        public void _setA(int nA)
        {
            mA = nA;
        }

        public int _getA()
        {
            return mA;
        }

        public void _setR(int nR)
        {
            mR = nR;
        }

        public int _getR()
        {
            return mR;
        }

        public void _setG(int nG)
        {
            mG = nG;
        }

        public int _getG()
        {
            return mG;
        }

        public void _setB(int nB)
        {
            mB = nB;
        }

        public int _getB()
        {
            return mB;
        }

        public RGB()
        {
            mA = 0;
            mR = 0;
            mG = 0;
            mB = 0;
        }

        int mA;
        int mR;
        int mG;
        int mB;
    }
}
