namespace KeyboardAPI
{
    public class KeyEventArgs
    {
        public KeyEventArgs(Key key, KeyAction action)
        {
            Key = key;
            Action = action;
        }

        public Key Key { get; }

        public KeyAction Action { get; }
    }
}