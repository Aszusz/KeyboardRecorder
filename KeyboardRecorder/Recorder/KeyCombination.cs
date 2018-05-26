using System;
using KeyboardAPI.APIs;

namespace KeyboardRecorder
{
    public class KeyCombination : IEquatable<KeyCombination>
    {
        public KeyCombination(Key key, KeyMod mod = 0)
        {
            KeyMod = mod;
            Key = key;
        }

        public Key Key { get; }

        public KeyMod KeyMod { get; }

        public bool Equals(KeyCombination other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return Key == other.Key;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != GetType()) return false;
            return Equals((KeyCombination) obj);
        }

        public override int GetHashCode()
        {
            return (int) Key;
        }

        public static bool operator ==(KeyCombination left, KeyCombination right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(KeyCombination left, KeyCombination right)
        {
            return !Equals(left, right);
        }
    }
}