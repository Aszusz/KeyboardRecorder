using System;

namespace KeyboardAPI.APIs
{
    public class KeyEventArgs : IEquatable<KeyEventArgs>
    {
        public KeyEventArgs(Key key, KeyAction action)
        {
            Key = key;
            Action = action;
        }

        public Key Key { get; }

        public KeyAction Action { get; }

        public bool Equals(KeyEventArgs other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return Key == other.Key && Action == other.Action;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            return obj.GetType() == GetType()
                   && Equals((KeyEventArgs) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return ((int) Key*397) ^ (int) Action;
            }
        }

        public static bool operator ==(KeyEventArgs left, KeyEventArgs right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(KeyEventArgs left, KeyEventArgs right)
        {
            return !Equals(left, right);
        }
    }
}