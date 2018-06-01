using System;
using System.Windows.Input;

namespace KeyboardRecorder
{
    public class KeyCombination : IEquatable<KeyCombination>
    {
        public KeyCombination(Key key, KeyModifier modifier = KeyModifier.None)
        {
            KeyModifier = modifier;
            Key = key;
        }

        public Key Key { get; }

        public KeyModifier KeyModifier { get; }

        public static bool operator ==(KeyCombination left, KeyCombination right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(KeyCombination left, KeyCombination right)
        {
            return !Equals(left, right);
        }

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
            return obj.GetType() == GetType()
                   && Equals((KeyCombination) obj);
        }

        public override int GetHashCode()
        {
            return (int) Key;
        }

        public override string ToString()
        {
            var s = "";
            if (KeyModifier.HasFlag(KeyModifier.LCtrl))
            {
                s += KeyModifier.LCtrl + " + ";
            }
            if (KeyModifier.HasFlag(KeyModifier.RCtrl))
            {
                s += KeyModifier.RCtrl + " + ";
            }
            if (KeyModifier.HasFlag(KeyModifier.LShift))
            {
                s += KeyModifier.LShift + " + ";
            }
            if (KeyModifier.HasFlag(KeyModifier.RShift))
            {
                s += KeyModifier.RShift + " + ";
            }
            if (KeyModifier.HasFlag(KeyModifier.LAtl))
            {
                s += KeyModifier.LAtl + " + ";
            }
            if (KeyModifier.HasFlag(KeyModifier.RAlt))
            {
                s += KeyModifier.RAlt + " + ";
            }
            if (KeyModifier.HasFlag(KeyModifier.LWin))
            {
                s += KeyModifier.LWin + " + ";
            }
            if (KeyModifier.HasFlag(KeyModifier.RWin))
            {
                s += KeyModifier.RWin + " + ";
            }
            s += Key.ToString();
            return s;
        }
    }
}