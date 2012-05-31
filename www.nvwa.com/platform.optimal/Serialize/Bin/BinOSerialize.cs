using System.IO;
using System.Collections.Generic;

using platform.include;

namespace platform.optimal
{
    public class BinOSerialize : ISerialize
    {
        public void _serialize(ref bool nValue, string nName, bool nOptimal = default(bool))
        {
            mBinaryWriter.Write(nValue);
        }

        public void _serialize(ref sbyte nValue, string nName, sbyte nOptimal = default(sbyte))
        {
            mBinaryWriter.Write(nValue);
        }

        public void _serialize<__t>(ref Dictionary<sbyte, __t> nValue, string nName) where __t : IKeyI8
        {
            if (null == nValue)
            {
                nValue = new Dictionary<sbyte, __t>();
            }
            foreach (KeyValuePair<sbyte, __t> i in nValue)
            {
                __t t_ = i.Value;
                this._serialize(ref t_, @"__t");
            }
        }

        public void _serialize(ref List<sbyte> nValue, string nName)
        {
            if (null == nValue)
            {
                nValue = new List<sbyte>();
            }
            int size_ = nValue.Count;
            this._serialize(ref size_, null);
            for (int i = 0; i < size_; i++)
            {
                sbyte temp_ = nValue[i];
                this._serialize(ref temp_, null);
            }
        }

        public void _serialize(ref byte nValue, string nName, byte nOptimal = default(byte))
        {
            mBinaryWriter.Write(nValue);
        }

        public void _serialize<__t>(ref Dictionary<byte, __t> nValue, string nName) where __t : IKeyU8
        {
            if (null == nValue)
            {
                nValue = new Dictionary<byte, __t>();
            }
            foreach (KeyValuePair<byte, __t> i in nValue)
            {
                __t t_ = i.Value;
                this._serialize(ref t_, @"__t");
            }
        }

        public void _serialize(ref List<byte> nValue, string nName)
        {
            if (null == nValue)
            {
                nValue = new List<byte>();
            }
            int size_ = nValue.Count;
            this._serialize(ref size_, null);
            for (int i = 0; i < size_; i++)
            {
                byte temp_ = nValue[i];
                this._serialize(ref temp_, null);
            }
        }

        public void _serialize(ref short nValue, string nName, short nOptimal = default(short))
        {
            mBinaryWriter.Write(nValue);
        }

        public void _serialize<__t>(ref Dictionary<short, __t> nValue, string nName) where __t : IKeyI16
        {
            if (null == nValue)
            {
                nValue = new Dictionary<short, __t>();
            }
            foreach (KeyValuePair<short, __t> i in nValue)
            {
                __t t_ = i.Value;
                this._serialize(ref t_, @"__t");
            }
        }

        public void _serialize(ref List<short> nValue, string nName)
        {
            if (null == nValue)
            {
                nValue = new List<short>();
            }
            int size_ = nValue.Count;
            this._serialize(ref size_, null);
            for (int i = 0; i < size_; i++)
            {
                short temp_ = nValue[i];
                this._serialize(ref temp_, null);
            }
        }

        public void _serialize(ref ushort nValue, string nName, ushort nOptimal = default(ushort))
        {
            mBinaryWriter.Write(nValue);
        }

        public void _serialize<__t>(ref Dictionary<ushort, __t> nValue, string nName) where __t : IKeyU16
        {
            if (null == nValue)
            {
                nValue = new Dictionary<ushort, __t>();
            }
            foreach (KeyValuePair<ushort, __t> i in nValue)
            {
                __t t_ = i.Value;
                this._serialize(ref t_, @"__t");
            }
        }

        public void _serialize(ref List<ushort> nValue, string nName)
        {
            if (null == nValue)
            {
                nValue = new List<ushort>();
            }
            int size_ = nValue.Count;
            this._serialize(ref size_, null);
            for (int i = 0; i < size_; i++)
            {
                ushort temp_ = nValue[i];
                this._serialize(ref temp_, null);
            }
        }

        public void _serialize(ref int nValue, string nName, int nOptimal = default(int))
        {
            mBinaryWriter.Write(nValue);
        }

        public void _serialize<__t>(ref Dictionary<int, __t> nValue, string nName) where __t : IKeyI32
        {
            if (null == nValue)
            {
                nValue = new Dictionary<int, __t>();
            }
            foreach (KeyValuePair<int, __t> i in nValue)
            {
                __t t_ = i.Value;
                this._serialize(ref t_, @"__t");
            }
        }

        public void _serialize(ref List<int> nValue, string nName)
        {
            if (null == nValue)
            {
                nValue = new List<int>();
            }
            int size_ = nValue.Count;
            this._serialize(ref size_, null);
            for (int i = 0; i < size_; i++)
            {
                int temp_ = nValue[i];
                this._serialize(ref temp_, null);
            }
        }

        public void _serialize(ref uint nValue, string nName, uint nOptimal = default(uint))
        {
            mBinaryWriter.Write(nValue);
        }

        public void _serialize<__t>(ref Dictionary<uint, __t> nValue, string nName) where __t : IKeyU32
        {
            if (null == nValue)
            {
                nValue = new Dictionary<uint, __t>();
            }
            foreach (KeyValuePair<uint, __t> i in nValue)
            {
                __t t_ = i.Value;
                this._serialize(ref t_, @"__t");
            }
        }

        public void _serialize(ref List<uint> nValue, string nName)
        {
            if (null == nValue)
            {
                nValue = new List<uint>();
            }
            int size_ = nValue.Count;
            this._serialize(ref size_, null);
            for (int i = 0; i < size_; i++)
            {
                uint temp_ = nValue[i];
                this._serialize(ref temp_, null);
            }
        }

        public void _serialize(ref long nValue, string nName, long nOptimal = default(long))
        {
            mBinaryWriter.Write(nValue);
        }

        public void _serialize<__t>(ref Dictionary<long, __t> nValue, string nName) where __t : IKeyI64
        {
            if (null == nValue)
            {
                nValue = new Dictionary<long, __t>();
            }
            foreach (KeyValuePair<long, __t> i in nValue)
            {
                __t t_ = i.Value;
                this._serialize(ref t_, @"__t");
            }
        }

        public void _serialize(ref List<long> nValue, string nName)
        {
            if (null == nValue)
            {
                nValue = new List<long>();
            }
            int size_ = nValue.Count;
            this._serialize(ref size_, null);
            for (int i = 0; i < size_; i++)
            {
                long temp_ = nValue[i];
                this._serialize(ref temp_, null);
            }
        }

        public void _serialize(ref ulong nValue, string nName, ulong nOptimal = default(ulong))
        {
            mBinaryWriter.Write(nValue);
        }

        public void _serialize<__t>(ref Dictionary<ulong, __t> nValue, string nName) where __t : IKeyU64
        {
            if (null == nValue)
            {
                nValue = new Dictionary<ulong, __t>();
            }
            foreach (KeyValuePair<ulong, __t> i in nValue)
            {
                __t t_ = i.Value;
                this._serialize(ref t_, @"__t");
            }
        }

        public void _serialize(ref List<ulong> nValue, string nName)
        {
            if (null == nValue)
            {
                nValue = new List<ulong>();
            }
            int size_ = nValue.Count;
            this._serialize(ref size_, null);
            for (int i = 0; i < size_; i++)
            {
                ulong temp_ = nValue[i];
                this._serialize(ref temp_, null);
            }
        }

        public void _serialize(ref string nValue, string nName, string nOptimal = default(string))
        {
            mBinaryWriter.Write(nValue);
        }

        public void _serialize<__t>(ref Dictionary<string, __t> nValue, string nName) where __t : IKeyStr
        {
            if (null == nValue)
            {
                nValue = new Dictionary<string, __t>();
            }
            foreach (KeyValuePair<string, __t> i in nValue)
            {
                __t t_ = i.Value;
                this._serialize(ref t_, @"__t");
            }
        }

        public void _serialize(ref List<string> nValue, string nName)
        {
            if (null == nValue)
            {
                nValue = new List<string>();
            }
            int size_ = nValue.Count;
            this._serialize(ref size_, null);
            for (int i = 0; i < size_; i++)
            {
                string temp_ = nValue[i];
                this._serialize(ref temp_, null);
            }
        }

        public void _serialize(ref float nValue, string nName, float nOptimal = default(float))
        {
            mBinaryWriter.Write(nValue);
        }

        public void _serialize<__t>(ref Dictionary<float, __t> nValue, string nName) where __t : IKeyFloat
        {
            if (null == nValue)
            {
                nValue = new Dictionary<float, __t>();
            }
            foreach (KeyValuePair<float, __t> i in nValue)
            {
                __t t_ = i.Value;
                this._serialize(ref t_, @"__t");
            }
        }

        public void _serialize(ref List<float> nValue, string nName)
        {
            if (null == nValue)
            {
                nValue = new List<float>();
            }
            int size_ = nValue.Count;
            this._serialize(ref size_, null);
            for (int i = 0; i < size_; i++)
            {
                float temp_ = nValue[i];
                this._serialize(ref temp_, null);
            }
        }

        public void _serialize(ref double nValue, string nName, double nOptimal = default(double))
        {
            mBinaryWriter.Write(nValue);
        }

        public void _serialize<__t>(ref Dictionary<double, __t> nValue, string nName) where __t : IKeyDouble
        {
            if (null == nValue)
            {
                nValue = new Dictionary<double, __t>();
            }
            foreach (KeyValuePair<double, __t> i in nValue)
            {
                __t t_ = i.Value;
                this._serialize(ref t_, @"__t");
            }
        }

        public void _serialize(ref List<double> nValue, string nName)
        {
            if (null == nValue)
            {
                nValue = new List<double>();
            }
            int size_ = nValue.Count;
            this._serialize(ref size_, null);
            for (int i = 0; i < size_; i++)
            {
                double temp_ = nValue[i];
                this._serialize(ref temp_, null);
            }
        }

        public void _serialize<__t>(ref __t nValue, string nName, __t nOptimal = default(__t)) where __t : IStream
        {
            if (null == nValue)
            {
                return;
            }
            nValue._serialize(this);
        }

        public void _serialize<__t>(ref List<__t> nValue, string nName) where __t : IStream
        {
            if (null == nValue)
            {
                nValue = new List<__t>();
            }
            int size_ = nValue.Count;
            this._serialize(ref size_, null);
            for (int i = 0; i < size_; i++)
            {
                __t value_ = nValue[i];
                this._serialize(ref value_, null);
            }
        }

        public void _openUrl(string nUrl)
        {
            UrlParser urlParser_ = new UrlParser(nUrl);
            string path_ = urlParser_._returnResult();
            mBinaryWriter = new BinaryWriter(File.Open(path_, FileMode.OpenOrCreate));
        }

        public void _selectStream(string nStreamName)
        {
        }

        public SerializeIO_ _serializeIO()
        {
            return SerializeIO_.mOutput_;
        }

        public void _runClose()
        {
            mBinaryWriter.Close();
        }

        public BinOSerialize()
        {
            mBinaryWriter = null;
        }

        BinaryWriter mBinaryWriter;
    }
}
