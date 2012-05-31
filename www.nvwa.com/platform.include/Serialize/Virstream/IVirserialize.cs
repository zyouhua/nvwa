using System.Collections.Generic;

namespace platform.include
{
    public interface IVirserialize : ISerialize
    {
        //__i8
        void _virserialize<__t>(ref Dictionary<sbyte, __t> nValue, string nName) where __t : IVirI8;
        //__u8
        void _virserialize<__t>(ref Dictionary<byte, __t> nValue, string nName) where __t : IVirU8;
        //__i16
        void _virserialize<__t>(ref Dictionary<short, __t> nValue, string nName) where __t : IVirI16;
        //__u16
        void _virserialize<__t>(ref Dictionary<ushort, __t> nValue, string nName) where __t : IVirU16;
        //__i32
        void _virserialize<__t>(ref Dictionary<int, __t> nValue, string nName) where __t : IVirI32;
        //__u32
        void _virserialize<__t>(ref Dictionary<uint, __t> nValue, string nName) where __t : IVirU32;
        //__i64
        void _virserialize<__t>(ref Dictionary<long, __t> nValue, string nName) where __t : IVirI64;
        //__u64
        void _virserialize<__t>(ref Dictionary<ulong, __t> nValue, string nName) where __t : IVirU64;
        //__str
        void _virserialize<__t>(ref Dictionary<string, __t> nValue, string nName) where __t : IVirStr;
        //__float
        void _virserialize<__t>(ref Dictionary<float, __t> nValue, string nName) where __t : IVirFloat;
        //__double
        void _virserialize<__t>(ref Dictionary<double, __t> nValue, string nName) where __t : IVirDouble;
        //__t
        void _virserialize<__t>(ref List<__t> nValue, string nName) where __t : IVirstream;
        void _virserialize<__t>(ref __t nValue, string nName) where __t : IVirstream;
        //creator
        void _setCreator(IStreamCreator nStreamCreator);
        void _clearCreator();
    }
}
