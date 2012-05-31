using System;
using System.IO;
using System.Collections.Generic;

using platform.include;

namespace platform.optimal
{
    public class BinISerialize : IVirserialize
    {
        public void _virserialize<__t>(ref Dictionary<sbyte, __t> nValue, string nName) where __t : IVirI8
        {
            if (null == nValue)
            {
                nValue = new Dictionary<sbyte, __t>();
            }
            int size_ = mBinaryReader.ReadInt32();
            for (int i = 0; i < size_; i++)
            {
                string virstream_ = mBinaryReader.ReadString();
                if (null == mStreamCreator)
                {
                    throw new NoStreamCreatorException();
                }
                __t t_ = (__t)mStreamCreator._virstream(virstream_);
                if (object.Equals(t_, default(__t)))
                {
                    throw new VirstreamCreateException(virstream_);
                }
                IStreamCreator streamCreator_ = mStreamCreator;
                t_._serialize(this);
                mStreamCreator = streamCreator_;
                sbyte key_ = t_._keyI8();
                nValue[key_] = t_;
            }
        }

        public void _virserialize<__t>(ref Dictionary<byte, __t> nValue, string nName) where __t : IVirU8
        {
            if (null == nValue)
            {
                nValue = new Dictionary<byte, __t>();
            }
            int size_ = mBinaryReader.ReadInt32();
            for (int i = 0; i < size_; i++)
            {
                string virstream_ = mBinaryReader.ReadString();
                if (null == mStreamCreator)
                {
                    throw new NoStreamCreatorException();
                }
                __t t_ = (__t)mStreamCreator._virstream(virstream_);
                if (object.Equals(t_, default(__t)))
                {
                    throw new VirstreamCreateException(virstream_);
                }
                IStreamCreator streamCreator_ = mStreamCreator;
                t_._serialize(this);
                mStreamCreator = streamCreator_;
                byte key_ = t_._keyU8();
                nValue[key_] = t_;
            }
        }

        public void _virserialize<__t>(ref Dictionary<short, __t> nValue, string nName) where __t : IVirI16
        {
            if (null == nValue)
            {
                nValue = new Dictionary<short, __t>();
            }
            int size_ = mBinaryReader.ReadInt32();
            for (int i = 0; i < size_; i++)
            {
                string virstream_ = mBinaryReader.ReadString();
                if (null == mStreamCreator)
                {
                    throw new NoStreamCreatorException();
                }
                __t t_ = (__t)mStreamCreator._virstream(virstream_);
                if (object.Equals(t_, default(__t)))
                {
                    throw new VirstreamCreateException(virstream_);
                }
                IStreamCreator streamCreator_ = mStreamCreator;
                t_._serialize(this);
                mStreamCreator = streamCreator_;
                short key_ = t_._keyI16();
                nValue[key_] = t_;
            }
        }

        public void _virserialize<__t>(ref Dictionary<ushort, __t> nValue, string nName) where __t : IVirU16
        {
            if (null == nValue)
            {
                nValue = new Dictionary<ushort, __t>();
            }
            int size_ = mBinaryReader.ReadInt32();
            for (int i = 0; i < size_; i++)
            {
                string virstream_ = mBinaryReader.ReadString();
                if (null == mStreamCreator)
                {
                    throw new NoStreamCreatorException();
                }
                __t t_ = (__t)mStreamCreator._virstream(virstream_);
                if (object.Equals(t_, default(__t)))
                {
                    throw new VirstreamCreateException(virstream_);
                }
                IStreamCreator streamCreator_ = mStreamCreator;
                t_._serialize(this);
                mStreamCreator = streamCreator_;
                ushort key_ = t_._keyU16();
                nValue[key_] = t_;
            }
        }

        public void _virserialize<__t>(ref Dictionary<int, __t> nValue, string nName) where __t : IVirI32
        {
            if (null == nValue)
            {
                nValue = new Dictionary<int, __t>();
            }
            int size_ = mBinaryReader.ReadInt32();
            for (int i = 0; i < size_; i++)
            {
                string virstream_ = mBinaryReader.ReadString();
                if (null == mStreamCreator)
                {
                    throw new NoStreamCreatorException();
                }
                __t t_ = (__t)mStreamCreator._virstream(virstream_);
                if (object.Equals(t_, default(__t)))
                {
                    throw new VirstreamCreateException(virstream_);
                }
                IStreamCreator streamCreator_ = mStreamCreator;
                t_._serialize(this);
                mStreamCreator = streamCreator_;
                int key_ = t_._keyI32();
                nValue[key_] = t_;
            }
        }

        public void _virserialize<__t>(ref Dictionary<uint, __t> nValue, string nName) where __t : IVirU32
        {
            if (null == nValue)
            {
                nValue = new Dictionary<uint, __t>();
            }
            int size_ = mBinaryReader.ReadInt32();
            for (int i = 0; i < size_; i++)
            {
                string virstream_ = mBinaryReader.ReadString();
                if (null == mStreamCreator)
                {
                    throw new NoStreamCreatorException();
                }
                __t t_ = (__t)mStreamCreator._virstream(virstream_);
                if (object.Equals(t_, default(__t)))
                {
                    throw new VirstreamCreateException(virstream_);
                }
                IStreamCreator streamCreator_ = mStreamCreator;
                t_._serialize(this);
                mStreamCreator = streamCreator_;
                uint key_ = t_._keyU32();
                nValue[key_] = t_;
            }
        }

        public void _virserialize<__t>(ref Dictionary<long, __t> nValue, string nName) where __t : IVirI64
        {
            if (null == nValue)
            {
                nValue = new Dictionary<long, __t>();
            }
            int size_ = mBinaryReader.ReadInt32();
            for (int i = 0; i < size_; i++)
            {
                string virstream_ = mBinaryReader.ReadString();
                if (null == mStreamCreator)
                {
                    throw new NoStreamCreatorException();
                }
                __t t_ = (__t)mStreamCreator._virstream(virstream_);
                if (object.Equals(t_, default(__t)))
                {
                    throw new VirstreamCreateException(virstream_);
                }
                IStreamCreator streamCreator_ = mStreamCreator;
                t_._serialize(this);
                mStreamCreator = streamCreator_;
                long key_ = t_._keyI64();
                nValue[key_] = t_;
            }
        }

        public void _virserialize<__t>(ref Dictionary<ulong, __t> nValue, string nName) where __t : IVirU64
        {
            if (null == nValue)
            {
                nValue = new Dictionary<ulong, __t>();
            }
            int size_ = mBinaryReader.ReadInt32();
            for (int i = 0; i < size_; i++)
            {
                string virstream_ = mBinaryReader.ReadString();
                if (null == mStreamCreator)
                {
                    throw new NoStreamCreatorException();
                }
                __t t_ = (__t)mStreamCreator._virstream(virstream_);
                if (object.Equals(t_, default(__t)))
                {
                    throw new VirstreamCreateException(virstream_);
                }
                IStreamCreator streamCreator_ = mStreamCreator;
                t_._serialize(this);
                mStreamCreator = streamCreator_;
                ulong key_ = t_._keyU64();
                nValue[key_] = t_;
            }
        }

        public void _virserialize<__t>(ref Dictionary<string, __t> nValue, string nName) where __t : IVirStr
        {
            if (null == nValue)
            {
                nValue = new Dictionary<string, __t>();
            }
            int size_ = mBinaryReader.ReadInt32();
            for (int i = 0; i < size_; i++)
            {
                string virstream_ = mBinaryReader.ReadString();
                if (null == mStreamCreator)
                {
                    throw new NoStreamCreatorException();
                }
                __t t_ = (__t)mStreamCreator._virstream(virstream_);
                if (object.Equals(t_, default(__t)))
                {
                    throw new VirstreamCreateException(virstream_);
                }
                IStreamCreator streamCreator_ = mStreamCreator;
                t_._serialize(this);
                mStreamCreator = streamCreator_;
                string key_ = t_._keyStr();
                nValue[key_] = t_;
            }
        }

        public void _virserialize<__t>(ref Dictionary<float, __t> nValue, string nName) where __t : IVirFloat
        {
            if (null == nValue)
            {
                nValue = new Dictionary<float, __t>();
            }
            int size_ = mBinaryReader.ReadInt32();
            for (int i = 0; i < size_; i++)
            {
                string virstream_ = mBinaryReader.ReadString();
                if (null == mStreamCreator)
                {
                    throw new NoStreamCreatorException();
                }
                __t t_ = (__t)mStreamCreator._virstream(virstream_);
                if (object.Equals(t_, default(__t)))
                {
                    throw new VirstreamCreateException(virstream_);
                }
                IStreamCreator streamCreator_ = mStreamCreator;
                t_._serialize(this);
                mStreamCreator = streamCreator_;
                float key_ = t_._keyFloat();
                nValue[key_] = t_;
            }
        }

        public void _virserialize<__t>(ref Dictionary<double, __t> nValue, string nName) where __t : IVirDouble
        {
            if (null == nValue)
            {
                nValue = new Dictionary<double, __t>();
            }
            int size_ = mBinaryReader.ReadInt32();
            for (int i = 0; i < size_; i++)
            {
                string virstream_ = mBinaryReader.ReadString();
                if (null == mStreamCreator)
                {
                    throw new NoStreamCreatorException();
                }
                __t t_ = (__t)mStreamCreator._virstream(virstream_);
                if (object.Equals(t_, default(__t)))
                {
                    throw new VirstreamCreateException(virstream_);
                }
                IStreamCreator streamCreator_ = mStreamCreator;
                t_._serialize(this);
                mStreamCreator = streamCreator_;
                double key_ = t_._keyDouble();
                nValue[key_] = t_;
            }
        }

        public void _virserialize<__t>(ref List<__t> nValue, string nName) where __t : IVirstream
        {
            if (null == nValue)
            {
                nValue = new List<__t>();
            }
            int size_ = mBinaryReader.ReadInt32();
            for (int i = 0; i < size_; i++)
            {
                string virstream_ = mBinaryReader.ReadString();
                if (null == mStreamCreator)
                {
                    throw new NoStreamCreatorException();
                }
                __t t_ = (__t)mStreamCreator._virstream(virstream_);
                if (object.Equals(t_, default(__t)))
                {
                    throw new VirstreamCreateException(virstream_);
                }
                IStreamCreator streamCreator_ = mStreamCreator;
                t_._serialize(this);
                mStreamCreator = streamCreator_;
                nValue.Add(t_);
            }
        }

        public void _virserialize<__t>(ref __t nValue, string nName) where __t : IVirstream
        {
            string virstream_ = mBinaryReader.ReadString();
            if (object.Equals(nValue, default(__t)))
            {
                if (null == mStreamCreator)
                {
                    throw new NoStreamCreatorException();
                }
                nValue = (__t)mStreamCreator._virstream(virstream_);
                if (null == nValue)
                {
                    throw new VirstreamCreateException(virstream_);
                }
            }
            nValue._serialize(this);
        }

        public void _setCreator(IStreamCreator nStreamCreator)
        {
            mStreamCreator = nStreamCreator;
        }

        public void _clearCreator()
        {
            mStreamCreator = null;
        }

        public void _serialize(ref bool nValue, string nName, bool nOptimal = default(bool))
        {
            nValue = mBinaryReader.ReadBoolean();
        }

        public void _serialize(ref sbyte nValue, string nName, sbyte nOptimal = default(sbyte))
        {
            nValue = mBinaryReader.ReadSByte();
        }

        public void _serialize<__t>(ref Dictionary<sbyte, __t> nValue, string nName) where __t : IKeyI8
        {
            if (null == nValue)
            {
                nValue = new Dictionary<sbyte, __t>();
            }
            int size_ = mBinaryReader.ReadInt32();
            for (int i = 0; i < size_; i++)
            {
                __t t_ = Activator.CreateInstance<__t>();
                t_._serialize(this);
                sbyte key_ = t_._keyI8();
                nValue[key_] = t_;
            }
        }

        public void _serialize(ref List<sbyte> nValue, string nName)
        {
            int size_ = mBinaryReader.ReadInt32();
            for (int i = 0; i < size_; i++)
            {
                sbyte temp_ = mBinaryReader.ReadSByte();
                nValue.Add(temp_);
            }
        }

        public void _serialize(ref byte nValue, string nName, byte nOptimal = default(byte))
        {
            nValue = mBinaryReader.ReadByte();
        }

        public void _serialize<__t>(ref Dictionary<byte, __t> nValue, string nName) where __t : IKeyU8
        {
            if (null == nValue)
            {
                nValue = new Dictionary<byte, __t>();
            }
            int size_ = mBinaryReader.ReadInt32();
            for (int i = 0; i < size_; i++)
            {
                __t t_ = Activator.CreateInstance<__t>();
                t_._serialize(this);
                byte key_ = t_._keyU8();
                nValue[key_] = t_;
            }
        }

        public void _serialize(ref List<byte> nValue, string nName)
        {
            int size_ = mBinaryReader.ReadInt32();
            for (int i = 0; i < size_; i++)
            {
                byte temp_ = mBinaryReader.ReadByte();
                nValue.Add(temp_);
            }
        }

        public void _serialize(ref short nValue, string nName, short nOptimal = default(short))
        {
            nValue = mBinaryReader.ReadInt16();
        }

        public void _serialize<__t>(ref Dictionary<short, __t> nValue, string nName) where __t : IKeyI16
        {
            if (null == nValue)
            {
                nValue = new Dictionary<short, __t>();
            }
            int size_ = mBinaryReader.ReadInt32();
            for (int i = 0; i < size_; i++)
            {
                __t t_ = Activator.CreateInstance<__t>();
                t_._serialize(this);
                short key_ = t_._keyI16();
                nValue[key_] = t_;
            }
        }

        public void _serialize(ref List<short> nValue, string nName)
        {
            int size_ = mBinaryReader.ReadInt32();
            for (int i = 0; i < size_; i++)
            {
                short temp_ = mBinaryReader.ReadInt16();
                nValue.Add(temp_);
            }
        }

        public void _serialize(ref ushort nValue, string nName, ushort nOptimal = default(ushort))
        {
            nValue = mBinaryReader.ReadUInt16();
        }

        public void _serialize<__t>(ref Dictionary<ushort, __t> nValue, string nName) where __t : IKeyU16
        {
            if (null == nValue)
            {
                nValue = new Dictionary<ushort, __t>();
            }
            int size_ = mBinaryReader.ReadInt32();
            for (int i = 0; i < size_; i++)
            {
                __t t_ = Activator.CreateInstance<__t>();
                t_._serialize(this);
                ushort key_ = t_._keyU16();
                nValue[key_] = t_;
            }
        }

        public void _serialize(ref List<ushort> nValue, string nName)
        {
            int size_ = mBinaryReader.ReadInt32();
            for (int i = 0; i < size_; i++)
            {
                ushort temp_ = mBinaryReader.ReadUInt16();
                nValue.Add(temp_);
            }
        }

        public void _serialize(ref int nValue, string nName, int nOptimal = default(int))
        {
            nValue = mBinaryReader.ReadInt32();
        }

        public void _serialize<__t>(ref Dictionary<int, __t> nValue, string nName) where __t : IKeyI32
        {
            if (null == nValue)
            {
                nValue = new Dictionary<int, __t>();
            }
            int size_ = mBinaryReader.ReadInt32();
            for (int i = 0; i < size_; i++)
            {
                __t t_ = Activator.CreateInstance<__t>();
                t_._serialize(this);
                int key_ = t_._keyI32();
                nValue[key_] = t_;
            }
        }

        public void _serialize(ref List<int> nValue, string nName)
        {
            int size_ = mBinaryReader.ReadInt32();
            for (int i = 0; i < size_; i++)
            {
                int temp_ = mBinaryReader.ReadInt32();
                nValue.Add(temp_);
            }
        }

        public void _serialize(ref uint nValue, string nName, uint nOptimal = default(uint))
        {
            nValue = mBinaryReader.ReadUInt32();
        }

        public void _serialize<__t>(ref Dictionary<uint, __t> nValue, string nName) where __t : IKeyU32
        {
            if (null == nValue)
            {
                nValue = new Dictionary<uint, __t>();
            }
            int size_ = mBinaryReader.ReadInt32();
            for (int i = 0; i < size_; i++)
            {
                __t t_ = Activator.CreateInstance<__t>();
                t_._serialize(this);
                uint key_ = t_._keyU32();
                nValue[key_] = t_;
            }
        }

        public void _serialize(ref List<uint> nValue, string nName)
        {
            int size_ = mBinaryReader.ReadInt32();
            for (int i = 0; i < size_; i++)
            {
                uint temp_ = mBinaryReader.ReadUInt32();
                nValue.Add(temp_);
            }
        }

        public void _serialize(ref long nValue, string nName, long nOptimal = default(long))
        {
            nValue = mBinaryReader.ReadInt64();
        }

        public void _serialize<__t>(ref Dictionary<long, __t> nValue, string nName) where __t : IKeyI64
        {
            if (null == nValue)
            {
                nValue = new Dictionary<long, __t>();
            }
            int size_ = mBinaryReader.ReadInt32();
            for (int i = 0; i < size_; i++)
            {
                __t t_ = Activator.CreateInstance<__t>();
                t_._serialize(this);
                long key_ = t_._keyI64();
                nValue[key_] = t_;
            }
        }

        public void _serialize(ref List<long> nValue, string nName)
        {
            int size_ = mBinaryReader.ReadInt32();
            for (int i = 0; i < size_; i++)
            {
                long temp_ = mBinaryReader.ReadInt64();
                nValue.Add(temp_);
            }
        }

        public void _serialize(ref ulong nValue, string nName, ulong nOptimal = default(ulong))
        {
            nValue = mBinaryReader.ReadUInt64();
        }

        public void _serialize<__t>(ref Dictionary<ulong, __t> nValue, string nName) where __t : IKeyU64
        {
            if (null == nValue)
            {
                nValue = new Dictionary<ulong, __t>();
            }
            int size_ = mBinaryReader.ReadInt32();
            for (int i = 0; i < size_; i++)
            {
                __t t_ = Activator.CreateInstance<__t>();
                t_._serialize(this);
                ulong key_ = t_._keyU64();
                nValue[key_] = t_;
            }
        }

        public void _serialize(ref List<ulong> nValue, string nName)
        {
            int size_ = mBinaryReader.ReadInt32();
            for (int i = 0; i < size_; i++)
            {
                ulong temp_ = mBinaryReader.ReadUInt64();
                nValue.Add(temp_);
            }
        }

        public void _serialize(ref string nValue, string nName, string nOptimal = default(string))
        {
            nValue = mBinaryReader.ReadString();
        }

        public void _serialize<__t>(ref Dictionary<string, __t> nValue, string nName) where __t : IKeyStr
        {
            if (null == nValue)
            {
                nValue = new Dictionary<string, __t>();
            }
            int size_ = mBinaryReader.ReadInt32();
            for (int i = 0; i < size_; i++)
            {
                __t t_ = Activator.CreateInstance<__t>();
                t_._serialize(this);
                string key_ = t_._keyStr();
                nValue[key_] = t_;
            }
        }

        public void _serialize(ref List<string> nValue, string nName)
        {
            int size_ = mBinaryReader.ReadInt32();
            for (int i = 0; i < size_; i++)
            {
                string temp_ = mBinaryReader.ReadString();
                nValue.Add(temp_);
            }
        }

        public void _serialize(ref float nValue, string nName, float nOptimal = default(float))
        {
            nValue = mBinaryReader.ReadSingle();
        }

        public void _serialize<__t>(ref Dictionary<float, __t> nValue, string nName) where __t : IKeyFloat
        {
            if (null == nValue)
            {
                nValue = new Dictionary<float, __t>();
            }
            int size_ = mBinaryReader.ReadInt32();
            for (int i = 0; i < size_; i++)
            {
                __t t_ = Activator.CreateInstance<__t>();
                t_._serialize(this);
                float key_ = t_._keyFloat();
                nValue[key_] = t_;
            }
        }

        public void _serialize(ref List<float> nValue, string nName)
        {
            int size_ = mBinaryReader.ReadInt32();
            for (int i = 0; i < size_; i++)
            {
                float temp_ = mBinaryReader.ReadSingle();
                nValue.Add(temp_);
            }
        }

        public void _serialize(ref double nValue, string nName, double nOptimal = default(double))
        {
            nValue = mBinaryReader.ReadDouble();
        }

        public void _serialize<__t>(ref Dictionary<double, __t> nValue, string nName) where __t : IKeyDouble
        {
            if (null == nValue)
            {
                nValue = new Dictionary<double, __t>();
            }
            int size_ = mBinaryReader.ReadInt32();
            for (int i = 0; i < size_; i++)
            {
                __t t_ = Activator.CreateInstance<__t>();
                t_._serialize(this);
                double key_ = t_._keyDouble();
                nValue[key_] = t_;
            }
        }

        public void _serialize(ref List<double> nValue, string nName)
        {
            int size_ = mBinaryReader.ReadInt32();
            for (int i = 0; i < size_; i++)
            {
                double temp_ = mBinaryReader.ReadDouble();
                nValue.Add(temp_);
            }
        }

        public void _serialize<__t>(ref __t nValue, string nName, __t nOptimal = default(__t)) where __t : IStream
        {
            if (object.Equals(nValue, default(__t)))
            {
                nValue = Activator.CreateInstance<__t>();
            }
            nValue._serialize(this);
        }

        public void _serialize<__t>(ref List<__t> nValue, string nName) where __t : IStream
        {
            if (null == nValue)
            {
                nValue = new List<__t>();
            }
            int size_ = mBinaryReader.ReadInt32();
            for (int i = 0; i < size_; i++)
            {
                __t t_ = Activator.CreateInstance<__t>();
                t_._serialize(this);
                nValue.Add(t_);
            }
        }

        public void _openUrl(string nUrl)
        {
            UrlParser urlParser_ = new UrlParser(nUrl);
            string path_ = urlParser_._returnResult();
            mBinaryReader = new BinaryReader(File.Open(path_, FileMode.Open));
        }

        public void _selectStream(string nStreamName)
        {
        }

        public SerializeIO_ _serializeIO()
        {
            return SerializeIO_.mInput_;
        }

        public void _runClose()
        {
            mBinaryReader.Close();
            mStreamCreator = null;
            mBinaryReader = null;
        }

        public BinISerialize()
        {
            mStreamCreator = null;
            mBinaryReader = null;
        }

        IStreamCreator mStreamCreator;
        BinaryReader mBinaryReader;
    }
}
