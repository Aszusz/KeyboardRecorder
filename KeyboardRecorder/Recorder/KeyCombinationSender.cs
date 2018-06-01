using System.Collections.Generic;
using System.Windows.Input;
using KeyboardToolkit.Common;
using KeyboardToolkit.Sender;

namespace KeyboardRecorder
{
    public class KeyCombinationSender
    {
        private readonly IKeySender _sender;

        public KeyCombinationSender(IKeySender sender)
        {
            _sender = sender;
        }

        public void Send(KeyCombination combination)
        {
            var keys = new List<KeyEventArgs>();

            if (combination.KeyModifier.HasFlag(KeyModifier.LCtrl))
                keys.Add(new KeyEventArgs(Key.LeftCtrl, KeyState.KeyDown));
            if (combination.KeyModifier.HasFlag(KeyModifier.RCtrl))
                keys.Add(new KeyEventArgs(Key.RightCtrl, KeyState.KeyDown));
            if (combination.KeyModifier.HasFlag(KeyModifier.LShift))
                keys.Add(new KeyEventArgs(Key.LeftShift, KeyState.KeyDown));
            if (combination.KeyModifier.HasFlag(KeyModifier.RShift))
                keys.Add(new KeyEventArgs(Key.RightShift, KeyState.KeyDown));
            if (combination.KeyModifier.HasFlag(KeyModifier.LAtl))
                keys.Add(new KeyEventArgs(Key.LeftAlt, KeyState.KeyDown));
            if (combination.KeyModifier.HasFlag(KeyModifier.RAlt))
                keys.Add(new KeyEventArgs(Key.RightAlt, KeyState.KeyDown));
            if (combination.KeyModifier.HasFlag(KeyModifier.LWin))
                keys.Add(new KeyEventArgs(Key.LWin, KeyState.KeyDown));
            if (combination.KeyModifier.HasFlag(KeyModifier.RWin))
                keys.Add(new KeyEventArgs(Key.RWin, KeyState.KeyDown));

            keys.Add(new KeyEventArgs(combination.Key, KeyState.KeyDown));
            keys.Add(new KeyEventArgs(combination.Key, KeyState.KeyUp));

            if (combination.KeyModifier.HasFlag(KeyModifier.RWin))
                keys.Add(new KeyEventArgs(Key.RWin, KeyState.KeyUp));
            if (combination.KeyModifier.HasFlag(KeyModifier.LWin))
                keys.Add(new KeyEventArgs(Key.LWin, KeyState.KeyUp));
            if (combination.KeyModifier.HasFlag(KeyModifier.RAlt))
                keys.Add(new KeyEventArgs(Key.RightAlt, KeyState.KeyUp));
            if (combination.KeyModifier.HasFlag(KeyModifier.LAtl))
                keys.Add(new KeyEventArgs(Key.LeftAlt, KeyState.KeyUp));
            if (combination.KeyModifier.HasFlag(KeyModifier.RShift))
                keys.Add(new KeyEventArgs(Key.RightShift, KeyState.KeyUp));
            if (combination.KeyModifier.HasFlag(KeyModifier.LShift))
                keys.Add(new KeyEventArgs(Key.LeftShift, KeyState.KeyUp));
            if (combination.KeyModifier.HasFlag(KeyModifier.RCtrl))
                keys.Add(new KeyEventArgs(Key.RightCtrl, KeyState.KeyUp));
            if (combination.KeyModifier.HasFlag(KeyModifier.LCtrl))
                keys.Add(new KeyEventArgs(Key.LeftCtrl, KeyState.KeyUp));

            _sender.Send(keys);
        }
    }
}