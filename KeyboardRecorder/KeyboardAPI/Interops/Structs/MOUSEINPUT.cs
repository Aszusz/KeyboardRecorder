using System;
using System.Runtime.InteropServices;
using KeyboardAPI.Interops.Enums;

// ReSharper disable InconsistentNaming

namespace KeyboardAPI.Interops.Structs
{
    [StructLayout(LayoutKind.Sequential)]
    internal struct MOUSEINPUT
    {
        public int dx;
        public int dy;
        public int mouseData;
        public MOUSEEVENTF dwFlags;
        public uint time;
        public UIntPtr dwExtraInfo;
    }
}