using System;
using System.Runtime.InteropServices;
using KeyboardAPI.Interops.Enums;

// ReSharper disable InconsistentNaming

namespace KeyboardAPI.Interops.Structs
{
    [StructLayout(LayoutKind.Sequential)]
    internal struct KEYBDINPUT
    {
        public VIRTUAL_KEY_CODE wVk;
        public SCAN_CODE wScan;
        public KEYEVENTF dwFlags;
        public int time;
        public UIntPtr dwExtraInfo;
    }
}