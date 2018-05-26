using System.Collections.Generic;
using System.Linq;
using KeyboardAPI.APIs;

namespace KeyboardRecorder
{
    public class RegisteredKeys
    {
        private static readonly IEnumerable<Key> Letters = new HashSet<Key>
        {
            Key.KeyA,
            Key.KeyB,
            Key.KeyC,
            Key.KeyD,
            Key.KeyE,
            Key.KeyF,
            Key.KeyG,
            Key.KeyH,
            Key.KeyI,
            Key.KeyJ,
            Key.KeyK,
            Key.KeyL,
            Key.KeyM,
            Key.KeyN,
            Key.KeyO,
            Key.KeyP,
            Key.KeyQ,
            Key.KeyR,
            Key.KeyS,
            Key.KeyT,
            Key.KeyU,
            Key.KeyV,
            Key.KeyW,
            Key.KeyX,
            Key.KeyY,
            Key.KeyZ
        };

        private static readonly IEnumerable<Key> Numbers = new HashSet<Key>
        {
            Key.Key0,
            Key.Key1,
            Key.Key2,
            Key.Key3,
            Key.Key4,
            Key.Key5,
            Key.Key6,
            Key.Key7,
            Key.Key8,
            Key.Key9,
            Key.Numpad0,
            Key.Numpad1,
            Key.Numpad2,
            Key.Numpad3,
            Key.Numpad4,
            Key.Numpad5,
            Key.Numpad6,
            Key.Numpad7,
            Key.Numpad8,
            Key.Numpad9,
        };

        public static bool IsRegisteredKey(Key key)
        {
            return Letters.Contains(key) || Numbers.Contains(key);
        }
    }
}