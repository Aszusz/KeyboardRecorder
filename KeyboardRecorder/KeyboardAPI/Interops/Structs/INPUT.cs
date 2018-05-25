using System.Runtime.InteropServices;
using KeyboardAPI.Interops.Enums;

// ReSharper disable InconsistentNaming

namespace KeyboardAPI.Interops.Structs
{
    [StructLayout(LayoutKind.Sequential)]
    internal struct INPUT
    {
        public INPUT_TYPE type;
        public INPUT_UNION U;

        public static int Size => Marshal.SizeOf(typeof(INPUT));
    }
}