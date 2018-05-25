using KeyboardAPI.APIs;

namespace Recorder
{
    public class KeyCombination
    {
        public KeyCombination(bool shift, bool control, bool leftAlt, bool rightAlt, Key key)
        {
            Shift = shift;
            Control = control;
            LeftAlt = leftAlt;
            RightAlt = rightAlt;
            Key = key;
        }

        public bool Shift { get; }

        public bool Control { get; }

        public bool LeftAlt { get; }

        public bool RightAlt { get; }

        public Key Key { get; }
    }
}