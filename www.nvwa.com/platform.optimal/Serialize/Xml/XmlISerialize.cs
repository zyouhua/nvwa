using System;
using System.Xml;
using System.Collections.Generic;

using platform.include;

namespace platform.optimal
{
    public class XmlISerialize : IVirserialize
    {
        public void _virserialize<__t>(ref Dictionary<sbyte, __t> nValue, string nName) where __t : IVirI8
        {
            if (null == nValue)
            {
                nValue = new Dictionary<sbyte, __t>();
            }
            mXmlNodes.Push(mXmlNode);
            XmlNode xmlNode_ = mXmlNode.SelectSingleNode(nName);
            if (null != xmlNode_)
            {
                foreach (XmlNode i in xmlNode_.ChildNodes)
                {
                    mXmlNode = i;
                    XmlAttribute xmlAttribute_ = mXmlNode.Attributes["virstream"];
                    if (null == xmlAttribute_)
                    {
                        throw new NoAssignVirstreamException(nName);
                    }
                    if (null == mStreamCreator)
                    {
                        throw new NoStreamCreatorException();
                    }
                    string virstream_ = xmlAttribute_.InnerText;
                    __t t_ = (__t)mStreamCreator._virstream(virstream_);
                    if (object.Equals(t_, default(__t)))
                    {
                        throw new VirstreamCreateException(virstream_);
                    }
                    t_._serialize(this);
                    sbyte key_ = t_._keyI8();
                    nValue[key_] = t_;
                }
            }
            mXmlNode = mXmlNodes.Pop();
        }

        public void _virserialize<__t>(ref Dictionary<byte, __t> nValue, string nName) where __t : IVirU8
        {
            if (null == nValue)
            {
                nValue = new Dictionary<byte, __t>();
            }
            mXmlNodes.Push(mXmlNode);
            XmlNode xmlNode_ = mXmlNode.SelectSingleNode(nName);
            if (null != xmlNode_)
            {
                foreach (XmlNode i in xmlNode_.ChildNodes)
                {
                    mXmlNode = i;
                    XmlAttribute xmlAttribute_ = mXmlNode.Attributes["virstream"];
                    if (null == xmlAttribute_)
                    {
                        throw new NoAssignVirstreamException(nName);
                    }
                    if (null == mStreamCreator)
                    {
                        throw new NoStreamCreatorException();
                    }
                    string virstream_ = xmlAttribute_.InnerText;
                    __t t_ = (__t)mStreamCreator._virstream(virstream_);
                    if (object.Equals(t_, default(__t)))
                    {
                        throw new VirstreamCreateException(virstream_);
                    }
                    t_._serialize(this);
                    byte key_ = t_._keyU8();
                    nValue[key_] = t_;
                }
            }
            mXmlNode = mXmlNodes.Pop();
        }

        public void _virserialize<__t>(ref Dictionary<short, __t> nValue, string nName) where __t : IVirI16
        {
            if (null == nValue)
            {
                nValue = new Dictionary<short, __t>();
            }
            mXmlNodes.Push(mXmlNode);
            XmlNode xmlNode_ = mXmlNode.SelectSingleNode(nName);
            if (null != xmlNode_)
            {
                foreach (XmlNode i in xmlNode_.ChildNodes)
                {
                    mXmlNode = i;
                    XmlAttribute xmlAttribute_ = mXmlNode.Attributes["virstream"];
                    if (null == xmlAttribute_)
                    {
                        throw new NoAssignVirstreamException(nName);
                    }
                    if (null == mStreamCreator)
                    {
                        throw new NoStreamCreatorException();
                    }
                    string virstream_ = xmlAttribute_.InnerText;
                    __t t_ = (__t)mStreamCreator._virstream(virstream_);
                    if (object.Equals(t_, default(__t)))
                    {
                        throw new VirstreamCreateException(virstream_);
                    }
                    t_._serialize(this);
                    short key_ = t_._keyI16();
                    nValue[key_] = t_;
                }
            }
            mXmlNode = mXmlNodes.Pop();
        }

        public void _virserialize<__t>(ref Dictionary<ushort, __t> nValue, string nName) where __t : IVirU16
        {
            if (null == nValue)
            {
                nValue = new Dictionary<ushort, __t>();
            }
            mXmlNodes.Push(mXmlNode);
            XmlNode xmlNode_ = mXmlNode.SelectSingleNode(nName);
            if (null != xmlNode_)
            {
                foreach (XmlNode i in xmlNode_.ChildNodes)
                {
                    mXmlNode = i;
                    XmlAttribute xmlAttribute_ = mXmlNode.Attributes["virstream"];
                    if (null == xmlAttribute_)
                    {
                        throw new NoAssignVirstreamException(nName);
                    }
                    if (null == mStreamCreator)
                    {
                        throw new NoStreamCreatorException();
                    }
                    string virsteam_ = xmlAttribute_.InnerText;
                    __t t_ = (__t)mStreamCreator._virstream(virsteam_);
                    if (object.Equals(t_, default(__t)))
                    {
                        throw new VirstreamCreateException(virsteam_);
                    }
                    t_._serialize(this);
                    ushort key_ = t_._keyU16();
                    nValue[key_] = t_;
                }
            }
            mXmlNode = mXmlNodes.Pop();
        }

        public void _virserialize<__t>(ref Dictionary<int, __t> nValue, string nName) where __t : IVirI32
        {
            if (null == nValue)
            {
                nValue = new Dictionary<int, __t>();
            }
            mXmlNodes.Push(mXmlNode);
            XmlNode xmlNode_ = mXmlNode.SelectSingleNode(nName);
            if (null != xmlNode_)
            {
                foreach (XmlNode i in xmlNode_.ChildNodes)
                {
                    mXmlNode = i;
                    XmlAttribute xmlAttribute_ = mXmlNode.Attributes["virsteam"];
                    if (null == xmlAttribute_)
                    {
                        throw new NoAssignVirstreamException(nName);
                    }
                    if (null == mStreamCreator)
                    {
                        throw new NoStreamCreatorException();
                    }
                    string virstream_ = xmlAttribute_.InnerText;
                    __t t_ = (__t)mStreamCreator._virstream(virstream_);
                    if (object.Equals(t_, default(__t)))
                    {
                        throw new VirstreamCreateException(virstream_);
                    }
                    t_._serialize(this);
                    int key_ = t_._keyI32();
                    nValue[key_] = t_;
                }
            }
            mXmlNode = mXmlNodes.Pop();
        }

        public void _virserialize<__t>(ref Dictionary<uint, __t> nValue, string nName) where __t : IVirU32
        {
            if (null == nValue)
            {
                nValue = new Dictionary<uint, __t>();
            }
            mXmlNodes.Push(mXmlNode);
            XmlNode xmlNode_ = mXmlNode.SelectSingleNode(nName);
            if (null != xmlNode_)
            {
                foreach (XmlNode i in xmlNode_.ChildNodes)
                {
                    mXmlNode = i;
                    XmlAttribute xmlAttribute_ = mXmlNode.Attributes["virstream"];
                    if (null == xmlAttribute_)
                    {
                        throw new NoAssignVirstreamException(nName);
                    }
                    if (null == mStreamCreator)
                    {
                        throw new NoStreamCreatorException();
                    }
                    string virstream_ = xmlAttribute_.InnerText;
                    __t t_ = (__t)mStreamCreator._virstream(virstream_);
                    if (object.Equals(t_, default(__t)))
                    {
                        throw new VirstreamCreateException(virstream_);
                    }
                    t_._serialize(this);
                    uint key_ = t_._keyU32();
                    nValue[key_] = t_;
                }
            }
            mXmlNode = mXmlNodes.Pop();
        }

        public void _virserialize<__t>(ref Dictionary<long, __t> nValue, string nName) where __t : IVirI64
        {
            if (null == nValue)
            {
                nValue = new Dictionary<long, __t>();
            }
            mXmlNodes.Push(mXmlNode);
            XmlNode xmlNode_ = mXmlNode.SelectSingleNode(nName);
            if (null != xmlNode_)
            {
                foreach (XmlNode i in xmlNode_.ChildNodes)
                {
                    mXmlNode = i;
                    XmlAttribute xmlAttribute_ = mXmlNode.Attributes["virstream"];
                    if (null == xmlAttribute_)
                    {
                        throw new NoAssignVirstreamException(nName);
                    }
                    if (null == mStreamCreator)
                    {
                        throw new NoStreamCreatorException();
                    }
                    string virstream_ = xmlAttribute_.InnerText;
                    __t t_ = (__t)mStreamCreator._virstream(virstream_);
                    if (object.Equals(t_, default(__t)))
                    {
                        throw new VirstreamCreateException(virstream_);
                    }
                    t_._serialize(this);
                    long key_ = t_._keyI64();
                    nValue[key_] = t_;
                }
            }
            mXmlNode = mXmlNodes.Pop();
        }

        public void _virserialize<__t>(ref Dictionary<ulong, __t> nValue, string nName) where __t : IVirU64
        {
            if (null == nValue)
            {
                nValue = new Dictionary<ulong, __t>();
            }
            mXmlNodes.Push(mXmlNode);
            XmlNode xmlNode_ = mXmlNode.SelectSingleNode(nName);
            if (null != xmlNode_)
            {
                foreach (XmlNode i in xmlNode_.ChildNodes)
                {
                    mXmlNode = i;
                    XmlAttribute xmlAttribute_ = mXmlNode.Attributes["virstream"];
                    if (null == xmlAttribute_)
                    {
                        throw new NoAssignVirstreamException(nName);
                    }
                    if (null == mStreamCreator)
                    {
                        throw new NoStreamCreatorException();
                    }
                    string virstream_ = xmlAttribute_.InnerText;
                    __t t_ = (__t)mStreamCreator._virstream(virstream_);
                    if (object.Equals(t_, default(__t)))
                    {
                        throw new VirstreamCreateException(virstream_);
                    }
                    t_._serialize(this);
                    ulong key_ = t_._keyU64();
                    nValue[key_] = t_;
                }
            }
            mXmlNode = mXmlNodes.Pop();
        }

        public void _virserialize<__t>(ref Dictionary<string, __t> nValue, string nName) where __t : IVirStr
        {
            if (null == nValue)
            {
                nValue = new Dictionary<string, __t>();
            }
            mXmlNodes.Push(mXmlNode);
            XmlNode xmlNode_ = mXmlNode.SelectSingleNode(nName);
            if (null != xmlNode_)
            {
                foreach (XmlNode i in xmlNode_.ChildNodes)
                {
                    mXmlNode = i;
                    XmlAttribute xmlAttribute_ = mXmlNode.Attributes["virstream"];
                    if (null == xmlAttribute_)
                    {
                        throw new NoAssignVirstreamException(nName);
                    }
                    if (null == mStreamCreator)
                    {
                        throw new NoStreamCreatorException();
                    }
                    string virstream_ = xmlAttribute_.InnerText;
                    __t t_ = (__t)mStreamCreator._virstream(virstream_);
                    if (object.Equals(t_, default(__t)))
                    {
                        throw new VirstreamCreateException(virstream_);
                    }
                    t_._serialize(this);
                    string key_ = t_._keyStr();
                    nValue[key_] = t_;
                }
            }
            mXmlNode = mXmlNodes.Pop();
        }

        public void _virserialize<__t>(ref Dictionary<float, __t> nValue, string nName) where __t : IVirFloat
        {
            if (null == nValue)
            {
                nValue = new Dictionary<float, __t>();
            }
            mXmlNodes.Push(mXmlNode);
            XmlNode xmlNode_ = mXmlNode.SelectSingleNode(nName);
            if (null != xmlNode_)
            {
                foreach (XmlNode i in xmlNode_.ChildNodes)
                {
                    mXmlNode = i;
                    XmlAttribute xmlAttribute_ = mXmlNode.Attributes["virstream"];
                    if (null == xmlAttribute_)
                    {
                        throw new NoAssignVirstreamException(nName);
                    }
                    if (null == mStreamCreator)
                    {
                        throw new NoStreamCreatorException();
                    }
                    string virstream_ = xmlAttribute_.InnerText;
                    __t t_ = (__t)mStreamCreator._virstream(virstream_);
                    if (object.Equals(t_, default(__t)))
                    {
                        throw new VirstreamCreateException(virstream_);
                    }
                    t_._serialize(this);
                    float key_ = t_._keyFloat();
                    nValue[key_] = t_;
                }
            }
            mXmlNode = mXmlNodes.Pop();
        }

        public void _virserialize<__t>(ref Dictionary<double, __t> nValue, string nName) where __t : IVirDouble
        {
            if (null == nValue)
            {
                nValue = new Dictionary<double, __t>();
            }
            mXmlNodes.Push(mXmlNode);
            XmlNode xmlNode_ = mXmlNode.SelectSingleNode(nName);
            if (null != xmlNode_)
            {
                foreach (XmlNode i in xmlNode_.ChildNodes)
                {
                    mXmlNode = i;
                    XmlAttribute xmlAttribute_ = mXmlNode.Attributes["virstream"];
                    if (null == xmlAttribute_)
                    {
                        throw new NoAssignVirstreamException(nName);
                    }
                    if (null == mStreamCreator)
                    {
                        throw new NoStreamCreatorException();
                    }
                    string virstream_ = xmlAttribute_.InnerText;
                    __t t_ = (__t)mStreamCreator._virstream(virstream_);
                    if (object.Equals(t_, default(__t)))
                    {
                        throw new VirstreamCreateException(virstream_);
                    }
                    t_._serialize(this);
                    double key_ = t_._keyDouble();
                    nValue[key_] = t_;
                }
            }
            mXmlNode = mXmlNodes.Pop();
        }

        public void _virserialize<__t>(ref List<__t> nValue, string nName) where __t : IVirstream
        {
            if (null == nValue)
            {
                nValue = new List<__t>();
            }
            mXmlNodes.Push(mXmlNode);
            XmlNode xmlNode_ = mXmlNode.SelectSingleNode(nName);
            if (null != xmlNode_)
            {
                foreach (XmlNode i in xmlNode_.ChildNodes)
                {
                    mXmlNode = i;
                    XmlAttribute xmlAttribute_ = mXmlNode.Attributes["virstream"];
                    if (null == xmlAttribute_)
                    {
                        throw new NoAssignVirstreamException(nName);
                    }
                    if (null == mStreamCreator)
                    {
                        throw new NoStreamCreatorException();
                    }
                    string virstream_ = xmlAttribute_.InnerText;
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
            mXmlNode = mXmlNodes.Pop();
        }

        public void _virserialize<__t>(ref __t nValue, string nName) where __t : IVirstream
        {
            mXmlNodes.Push(mXmlNode);
            mXmlNode = mXmlNode.SelectSingleNode(nName);
            if (null == mXmlNode)
            {
                nValue = default(__t);
            }
            else
            {
                if (object.Equals(nValue, default(__t)))
                {
                    XmlAttribute xmlAttribute_ = mXmlNode.Attributes["virstream"];
                    if (null == xmlAttribute_)
                    {
                        throw new NoAssignVirstreamException(nName);
                    }
                    if (null == mStreamCreator)
                    {
                        throw new NoStreamCreatorException();
                    }
                    string virstream_ = xmlAttribute_.InnerText;
                    nValue = (__t)mStreamCreator._virstream(virstream_);
                    if (null == nValue)
                    {
                        throw new VirstreamCreateException(virstream_);
                    }
                }
                nValue._serialize(this);
            }
            mXmlNode = mXmlNodes.Pop();
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
            nValue = nOptimal;
            XmlAttribute xmlAttribute_ = mXmlNode.Attributes[nName];
            if (null == xmlAttribute_)
            {
                return;
            }
            string text_ = xmlAttribute_.InnerText;
            if (@"true" == text_)
            {
                nValue = true;
            }
            else if (@"false" == text_)
            {
                nValue = false;
            }
            else
            {
                nValue = nOptimal;
            }
        }

        public void _serialize(ref sbyte nValue, string nName, sbyte nOptimal = default(sbyte))
        {
            nValue = nOptimal;
            XmlAttribute xmlAttribute_ = mXmlNode.Attributes[nName];
            if (null != xmlAttribute_)
            {
                string text_ = xmlAttribute_.InnerText;
                nValue = Convert.ToSByte(text_);
            }
        }

        public void _serialize<__t>(ref Dictionary<sbyte, __t> nValue, string nName) where __t : IKeyI8
        {
            if (null == nValue)
            {
                nValue = new Dictionary<sbyte, __t>();
            }
            mXmlNodes.Push(mXmlNode);
            XmlNode xmlNode_ = mXmlNode.SelectSingleNode(nName);
            if (null != xmlNode_)
            {
                foreach (XmlNode i in xmlNode_.ChildNodes)
                {
                    mXmlNode = i;
                    __t t_ = Activator.CreateInstance<__t>();
                    t_._serialize(this);
                    sbyte key_ = t_._keyI8();
                    nValue[key_] = t_;
                }
            }
            mXmlNode = mXmlNodes.Pop();
        }

        public void _serialize(ref List<sbyte> nValue, string nName)
        {
            if (null == nValue)
            {
                nValue = new List<sbyte>();
            }
            XmlNode xmlNode_ = mXmlNode.SelectSingleNode(nName);
            if (null == xmlNode_)
            {
                return;
            }
            foreach (XmlNode i in xmlNode_.ChildNodes)
            {
                string text_ = i.InnerText;
                sbyte value_ = Convert.ToSByte(text_);
                nValue.Add(value_);
            }
        }

        public void _serialize(ref byte nValue, string nName, byte nOptimal = default(byte))
        {
            nValue = nOptimal;
            XmlAttribute xmlAttribute_ = mXmlNode.Attributes[nName];
            if (null != xmlAttribute_)
            {
                string text_ = xmlAttribute_.InnerText;
                nValue = Convert.ToByte(text_);
            }
        }

        public void _serialize<__t>(ref Dictionary<byte, __t> nValue, string nName) where __t : IKeyU8
        {
            if (null == nValue)
            {
                nValue = new Dictionary<byte, __t>();
            }
            mXmlNodes.Push(mXmlNode);
            XmlNode xmlNode_ = mXmlNode.SelectSingleNode(nName);
            if (null != xmlNode_)
            {
                foreach (XmlNode i in xmlNode_.ChildNodes)
                {
                    mXmlNode = i;
                    __t t_ = Activator.CreateInstance<__t>();
                    t_._serialize(this);
                    byte key_ = t_._keyU8();
                    nValue[key_] = t_;
                }
            }
            mXmlNode = mXmlNodes.Pop();
        }

        public void _serialize(ref List<byte> nValue, string nName)
        {
            if (null == nValue)
            {
                nValue = new List<byte>();
            }
            XmlNode xmlNode_ = mXmlNode.SelectSingleNode(nName);
            if (null == xmlNode_)
            {
                return;
            }
            foreach (XmlNode i in xmlNode_.ChildNodes)
            {
                string text_ = i.InnerText;
                byte value_ = Convert.ToByte(text_);
                nValue.Add(value_);
            }
        }

        public void _serialize(ref short nValue, string nName, short nOptimal = default(short))
        {
            nValue = nOptimal;
            XmlAttribute xmlAttribute_ = mXmlNode.Attributes[nName];
            if (null != xmlAttribute_)
            {
                string text_ = xmlAttribute_.InnerText;
                nValue = Convert.ToInt16(text_);
            }
        }

        public void _serialize<__t>(ref Dictionary<short, __t> nValue, string nName) where __t : IKeyI16
        {
            if (null == nValue)
            {
                nValue = new Dictionary<short, __t>();
            }
            mXmlNodes.Push(mXmlNode);
            XmlNode xmlNode_ = mXmlNode.SelectSingleNode(nName);
            if (null != xmlNode_)
            {
                foreach (XmlNode i in xmlNode_.ChildNodes)
                {
                    mXmlNode = i;
                    __t t_ = Activator.CreateInstance<__t>();
                    t_._serialize(this);
                    short key_ = t_._keyI16();
                    nValue[key_] = t_;
                }
            }
            mXmlNode = mXmlNodes.Pop();
        }

        public void _serialize(ref List<short> nValue, string nName)
        {
            if (null == nValue)
            {
                nValue = new List<short>();
            }
            XmlNode xmlNode_ = mXmlNode.SelectSingleNode(nName);
            if (null == xmlNode_)
            {
                return;
            }
            foreach (XmlNode i in xmlNode_.ChildNodes)
            {
                string text_ = i.InnerText;
                short value_ = Convert.ToInt16(text_);
                nValue.Add(value_);
            }
        }

        public void _serialize(ref ushort nValue, string nName, ushort nOptimal = default(ushort))
        {
            nValue = nOptimal;
            XmlAttribute xmlAttribute_ = mXmlNode.Attributes[nName];
            if (null != xmlAttribute_)
            {
                string text_ = xmlAttribute_.InnerText;
                nValue = Convert.ToUInt16(text_);
            }
        }

        public void _serialize<__t>(ref Dictionary<ushort, __t> nValue, string nName) where __t : IKeyU16
        {
            if (null == nValue)
            {
                nValue = new Dictionary<ushort, __t>();
            }
            mXmlNodes.Push(mXmlNode);
            XmlNode xmlNode_ = mXmlNode.SelectSingleNode(nName);
            if (null != xmlNode_)
            {
                foreach (XmlNode i in xmlNode_.ChildNodes)
                {
                    mXmlNode = i;
                    __t t_ = Activator.CreateInstance<__t>();
                    t_._serialize(this);
                    ushort key_ = t_._keyU16();
                    nValue[key_] = t_;
                }
            }
            mXmlNode = mXmlNodes.Pop();
        }

        public void _serialize(ref List<ushort> nValue, string nName)
        {
            if (null == nValue)
            {
                nValue = new List<ushort>();
            }
            XmlNode xmlNode_ = mXmlNode.SelectSingleNode(nName);
            if (null == xmlNode_)
            {
                return;
            }
            foreach (XmlNode i in xmlNode_.ChildNodes)
            {
                string text_ = i.InnerText;
                ushort value_ = Convert.ToUInt16(text_);
                nValue.Add(value_);
            }
        }

        public void _serialize(ref int nValue, string nName, int nOptimal = default(int))
        {
            nValue = nOptimal;
            XmlAttribute xmlAttribute_ = mXmlNode.Attributes[nName];
            if (null != xmlAttribute_)
            {
                string text_ = xmlAttribute_.InnerText;
                nValue = Convert.ToInt32(text_);
            }
        }

        public void _serialize<__t>(ref Dictionary<int, __t> nValue, string nName) where __t : IKeyI32
        {
            if (null == nValue)
            {
                nValue = new Dictionary<int, __t>();
            }
            mXmlNodes.Push(mXmlNode);
            XmlNode xmlNode_ = mXmlNode.SelectSingleNode(nName);
            if (null != xmlNode_)
            {
                foreach (XmlNode i in xmlNode_.ChildNodes)
                {
                    mXmlNode = i;
                    __t t_ = Activator.CreateInstance<__t>();
                    t_._serialize(this);
                    int key_ = t_._keyI32();
                    nValue[key_] = t_;
                }
            }
            mXmlNode = mXmlNodes.Pop();
        }

        public void _serialize(ref List<int> nValue, string nName)
        {
            if (null == nValue)
            {
                nValue = new List<int>();
            }
            XmlNode xmlNode_ = mXmlNode.SelectSingleNode(nName);
            if (null == xmlNode_)
            {
                return;
            }
            foreach (XmlNode i in xmlNode_.ChildNodes)
            {
                string text_ = i.InnerText;
                int value_ = Convert.ToInt32(text_);
                nValue.Add(value_);
            }
        }

        public void _serialize(ref uint nValue, string nName, uint nOptimal = default(uint))
        {
            nValue = nOptimal;
            XmlAttribute xmlAttribute_ = mXmlNode.Attributes[nName];
            if (null != xmlAttribute_)
            {
                string text_ = xmlAttribute_.InnerText;
                nValue = Convert.ToUInt32(text_);
            }
        }

        public void _serialize<__t>(ref Dictionary<uint, __t> nValue, string nName) where __t : IKeyU32
        {
            if (null == nValue)
            {
                nValue = new Dictionary<uint, __t>();
            }
            mXmlNodes.Push(mXmlNode);
            XmlNode xmlNode_ = mXmlNode.SelectSingleNode(nName);
            if (null != xmlNode_)
            {
                foreach (XmlNode i in xmlNode_.ChildNodes)
                {
                    mXmlNode = i;
                    __t t_ = Activator.CreateInstance<__t>();
                    t_._serialize(this);
                    uint key_ = t_._keyU32();
                    nValue[key_] = t_;
                }
            }
            mXmlNode = mXmlNodes.Pop();
        }

        public void _serialize(ref List<uint> nValue, string nName)
        {
            if (null == nValue)
            {
                nValue = new List<uint>();
            }
            XmlNode xmlNode_ = mXmlNode.SelectSingleNode(nName);
            if (null == xmlNode_)
            {
                return;
            }
            foreach (XmlNode i in xmlNode_.ChildNodes)
            {
                string text_ = i.InnerText;
                uint value_ = Convert.ToUInt32(text_);
                nValue.Add(value_);
            }
        }

        public void _serialize(ref long nValue, string nName, long nOptimal = default(long))
        {
            nValue = nOptimal;
            XmlAttribute xmlAttribute_ = mXmlNode.Attributes[nName];
            if (null != xmlAttribute_)
            {
                string text_ = xmlAttribute_.InnerText;
                nValue = Convert.ToInt64(text_);
            }
        }

        public void _serialize<__t>(ref Dictionary<long, __t> nValue, string nName) where __t : IKeyI64
        {
            if (null == nValue)
            {
                nValue = new Dictionary<long, __t>();
            }
            mXmlNodes.Push(mXmlNode);
            XmlNode xmlNode_ = mXmlNode.SelectSingleNode(nName);
            if (null != xmlNode_)
            {
                foreach (XmlNode i in xmlNode_.ChildNodes)
                {
                    mXmlNode = i;
                    __t t_ = Activator.CreateInstance<__t>();
                    t_._serialize(this);
                    long key_ = t_._keyI64();
                    nValue[key_] = t_;
                }
            }
            mXmlNode = mXmlNodes.Pop();
        }

        public void _serialize(ref List<long> nValue, string nName)
        {
            if (null == nValue)
            {
                nValue = new List<long>();
            }
            XmlNode xmlNode_ = mXmlNode.SelectSingleNode(nName);
            if (null == xmlNode_)
            {
                return;
            }
            foreach (XmlNode i in xmlNode_.ChildNodes)
            {
                string text_ = i.InnerText;
                long value_ = Convert.ToInt64(text_);
                nValue.Add(value_);
            }
        }

        public void _serialize(ref ulong nValue, string nName, ulong nOptimal = default(ulong))
        {
            nValue = nOptimal;
            XmlAttribute xmlAttribute_ = mXmlNode.Attributes[nName];
            if (null != xmlAttribute_)
            {
                string text_ = xmlAttribute_.InnerText;
                nValue = Convert.ToUInt64(text_);
            }
        }

        public void _serialize<__t>(ref Dictionary<ulong, __t> nValue, string nName) where __t : IKeyU64
        {
            if (null == nValue)
            {
                nValue = new Dictionary<ulong, __t>();
            }
            mXmlNodes.Push(mXmlNode);
            XmlNode xmlNode_ = mXmlNode.SelectSingleNode(nName);
            if (null != xmlNode_)
            {
                foreach (XmlNode i in xmlNode_.ChildNodes)
                {
                    mXmlNode = i;
                    __t t_ = Activator.CreateInstance<__t>();
                    t_._serialize(this);
                    ulong key_ = t_._keyU64();
                    nValue[key_] = t_;
                }
            }
            mXmlNode = mXmlNodes.Pop();
        }

        public void _serialize(ref List<ulong> nValue, string nName)
        {
            if (null == nValue)
            {
                nValue = new List<ulong>();
            }
            XmlNode xmlNode_ = mXmlNode.SelectSingleNode(nName);
            if (null == xmlNode_)
            {
                return;
            }
            foreach (XmlNode i in xmlNode_.ChildNodes)
            {
                string text_ = i.InnerText;
                ulong value_ = Convert.ToUInt64(text_);
                nValue.Add(value_);
            }
        }

        public void _serialize(ref string nValue, string nName, string nOptimal = default(string))
        {
            nValue = nOptimal;
            XmlAttribute xmlAttribute_ = mXmlNode.Attributes[nName];
            if (null != xmlAttribute_)
            {
                nValue = xmlAttribute_.InnerText;
            }
        }

        public void _serialize<__t>(ref Dictionary<string, __t> nValue, string nName) where __t : IKeyStr
        {
            if (null == nValue)
            {
                nValue = new Dictionary<string, __t>();
            }
            mXmlNodes.Push(mXmlNode);
            XmlNode xmlNode_ = mXmlNode.SelectSingleNode(nName);
            if (null != xmlNode_)
            {
                foreach (XmlNode i in xmlNode_.ChildNodes)
                {
                    mXmlNode = i;
                    __t t_ = Activator.CreateInstance<__t>();
                    t_._serialize(this);
                    string key_ = t_._keyStr();
                    nValue[key_] = t_;
                }
            }
            mXmlNode = mXmlNodes.Pop();
        }

        public void _serialize(ref List<string> nValue, string nName)
        {
            if (null == nValue)
            {
                nValue = new List<string>();
            }
            XmlNode xmlNode_ = mXmlNode.SelectSingleNode(nName);
            if (null == xmlNode_)
            {
                return;
            }
            foreach (XmlNode i in xmlNode_.ChildNodes)
            {
                string text_ = i.InnerText;
                nValue.Add(text_);
            }
        }

        public void _serialize(ref float nValue, string nName, float nOptimal = default(float))
        {
            nValue = nOptimal;
            XmlAttribute xmlAttribute_ = mXmlNode.Attributes[nName];
            if (null != xmlAttribute_)
            {
                string text_ = xmlAttribute_.InnerText;
                nValue = Convert.ToSingle(text_);
            }
        }

        public void _serialize<__t>(ref Dictionary<float, __t> nValue, string nName) where __t : IKeyFloat
        {
            if (null == nValue)
            {
                nValue = new Dictionary<float, __t>();
            }
            mXmlNodes.Push(mXmlNode);
            XmlNode xmlNode_ = mXmlNode.SelectSingleNode(nName);
            if (null != xmlNode_)
            {
                foreach (XmlNode i in xmlNode_.ChildNodes)
                {
                    mXmlNode = i;
                    __t t_ = Activator.CreateInstance<__t>();
                    t_._serialize(this);
                    float key_ = t_._keyFloat();
                    nValue[key_] = t_;
                }
            }
            mXmlNode = mXmlNodes.Pop();
        }

        public void _serialize(ref List<float> nValue, string nName)
        {
            if (null == nValue)
            {
                nValue = new List<float>();
            }
            XmlNode xmlNode_ = mXmlNode.SelectSingleNode(nName);
            if (null == xmlNode_)
            {
                return;
            }
            foreach (XmlNode i in xmlNode_.ChildNodes)
            {
                string text_ = i.InnerText;
                float value_ = Convert.ToSingle(text_);
                nValue.Add(value_);
            }
        }

        public void _serialize(ref double nValue, string nName, double nOptimal = default(double))
        {
            nValue = nOptimal;
            XmlAttribute xmlAttribute_ = mXmlNode.Attributes[nName];
            if (null != xmlAttribute_)
            {
                string text_ = xmlAttribute_.InnerText;
                nValue = Convert.ToDouble(text_);
            }
        }

        public void _serialize<__t>(ref Dictionary<double, __t> nValue, string nName) where __t : IKeyDouble
        {
            if (null == nValue)
            {
                nValue = new Dictionary<double, __t>();
            }
            mXmlNodes.Push(mXmlNode);
            XmlNode xmlNode_ = mXmlNode.SelectSingleNode(nName);
            if (null != xmlNode_)
            {
                foreach (XmlNode i in xmlNode_.ChildNodes)
                {
                    mXmlNode = i;
                    __t t_ = Activator.CreateInstance<__t>();
                    t_._serialize(this);
                    double key_ = t_._keyDouble();
                    nValue[key_] = t_;
                }
            }
            mXmlNode = mXmlNodes.Pop();
        }

        public void _serialize(ref List<double> nValue, string nName)
        {
            if (null == nValue)
            {
                nValue = new List<double>();
            }
            XmlNode xmlNode_ = mXmlNode.SelectSingleNode(nName);
            if (null == xmlNode_)
            {
                return;
            }
            foreach (XmlNode i in xmlNode_.ChildNodes)
            {
                string text_ = i.InnerText;
                double value_ = Convert.ToDouble(text_);
                nValue.Add(value_);
            }
        }

        public void _serialize<__t>(ref __t nValue, string nName, __t nOptimal = default(__t)) where __t : IStream
        {
            mXmlNodes.Push(mXmlNode);
            mXmlNode = mXmlNode.SelectSingleNode(nName);
            if (null == mXmlNode)
            {
                nValue = nOptimal;
            }
            else
            {
                if (object.Equals(nValue, default(__t)))
                {
                    nValue = Activator.CreateInstance<__t>();
                }
                nValue._serialize(this);
            }
            mXmlNode = mXmlNodes.Pop();
        }

        public void _serialize<__t>(ref List<__t> nValue, string nName) where __t : IStream
        {
            if (null == nValue)
            {
                nValue = new List<__t>();
            }
            mXmlNodes.Push(mXmlNode);
            XmlNode xmlNode_ = mXmlNode.SelectSingleNode(nName);
            if (null != xmlNode_)
            {
                foreach (XmlNode i in xmlNode_.ChildNodes)
                {
                    mXmlNode = i;
                    __t t_ = Activator.CreateInstance<__t>();
                    t_._serialize(this);
                    nValue.Add(t_);
                }
            }
            mXmlNode = mXmlNodes.Pop();
        }

        public void _openUrl(string nUrl)
        {
            UrlParser urlParser_ = new UrlParser(nUrl);
            string path_ = urlParser_._returnResult();
            mXmlDocument.Load(path_);
        }

        public void _selectStream(string nStreamName)
        {
            mXmlNode = mXmlDocument.SelectSingleNode(nStreamName);
        }

        public SerializeIO_ _serializeIO()
        {
            return SerializeIO_.mInput_;
        }

        public void _runClose()
        {
            mStreamCreator = null;
            mXmlDocument = null;
            mXmlNodes.Clear();
            mXmlNodes = null;
            mXmlNode = null;
        }

        public XmlISerialize()
        {
            mXmlDocument = new XmlDocument();
            mXmlNodes = new Stack<XmlNode>();
            mStreamCreator = null;
            mXmlNode = null;
        }

        IStreamCreator mStreamCreator;
        XmlDocument mXmlDocument;
        Stack<XmlNode> mXmlNodes;
        XmlNode mXmlNode;
    }
}
