using System.Runtime.InteropServices;

// ReSharper disable InconsistentNaming

namespace KeyboardAPI.Interops.Structs
{
    [StructLayout(LayoutKind.Explicit)]
    internal struct INPUT_UNION
    {
        [FieldOffset(0)] public MOUSEINPUT mi;
        [FieldOffset(0)] public KEYBDINPUT ki;
        [FieldOffset(0)] public HARDWAREINPUT hi;
    }
}