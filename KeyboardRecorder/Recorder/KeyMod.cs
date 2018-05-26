using System;

namespace Recorder
{
    [Flags]
    public enum KeyMod
    {
        Shift = 1,
        Control = 2,
        LeftAlt = 4,
        RightAlt = 8
    }
}