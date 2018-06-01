using System.Collections.Generic;
using System.Linq;
using System.Windows.Input;

namespace KeyboardRecorder
{
    public class RegisteredKeys
    {
        private static readonly IEnumerable<Key> Letters = new HashSet<Key>
        {
            Key.A,
            Key.B,
            Key.C,
            Key.D,
            Key.E,
            Key.F,
            Key.G,
            Key.H,
            Key.I,
            Key.J,
            Key.K,
            Key.L,
            Key.M,
            Key.N,
            Key.O,
            Key.P,
            Key.Q,
            Key.R,
            Key.S,
            Key.T,
            Key.U,
            Key.V,
            Key.W,
            Key.X,
            Key.Y,
            Key.Z
        };

        private static readonly IEnumerable<Key> Numbers = new HashSet<Key>
        {
            Key.D0,
            Key.D1,
            Key.D2,
            Key.D3,
            Key.D4,
            Key.D5,
            Key.D6,
            Key.D7,
            Key.D8,
            Key.D9,
            Key.NumPad0,
            Key.NumPad1,
            Key.NumPad2,
            Key.NumPad3,
            Key.NumPad4,
            Key.NumPad5,
            Key.NumPad6,
            Key.NumPad7,
            Key.NumPad8,
            Key.NumPad9,
        };

        private static readonly IEnumerable<Key> ModalKeys = new List<Key>()
        {
            Key.LeftCtrl,
            Key.RightCtrl,
            Key.LeftShift,
            Key.RightShift,
            Key.LeftAlt,
            Key.RightAlt,
            Key.LWin,
            Key.RWin
        };

        public static bool IsModalKey(Key key)
        {
            return ModalKeys.Contains(key);
        }

        public static bool IsRegisteredKey(Key key)
        {
            return Letters.Contains(key) || Numbers.Contains(key);
        }
    }
}