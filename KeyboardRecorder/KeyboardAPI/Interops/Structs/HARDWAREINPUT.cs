using System.Runtime.InteropServices;

// ReSharper disable InconsistentNaming

namespace KeyboardAPI.Interops.Structs
{
    [StructLayout(LayoutKind.Sequential)]
    internal struct HARDWAREINPUT
    {
        public int uMsg;
        public short wParamL;
        public short wParamH;
    }
}