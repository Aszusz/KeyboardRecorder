using System;

namespace KeyboardRecorder
{
    [Flags]
    public enum KeyModifier
    {
        None = 0,
        LShift = 1,
        RShift = 2,
        LCtrl = 4,
        RCtrl = 8,
        LAtl = 16,
        RAlt = 32,
        LWin = 64,
        RWin = 128
    }
}