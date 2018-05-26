using System;
using System.Collections.Generic;
using KeyboardAPI.APIs;

namespace KeyboardRecorder
{
    public class KeyCombinationListener : IDisposable
    {
        private readonly IKeyboard _keyboard;
        private bool _isLeftAltDown;
        private bool _isLeftControlDown;
        private bool _isLeftShiftDown;
        private bool _isRightAltDown;
        private bool _isRightControlDown;
        private bool _isRightShiftDown;

        public KeyCombinationListener(IKeyboard keyboard)
        {
            _keyboard = keyboard;
            _keyboard.Received += KeyboardOnReceived;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public event Action<KeyCombination> KeyCombinationReceived;

        public void Start()
        {
            _keyboard.Install();
        }

        public void Stop()
        {
            _keyboard.Uninstall();
        }

        private void KeyboardOnReceived(object sender, KeyEventArgs keyEventArgs)
        {
            var key = keyEventArgs.Key;
            var action = keyEventArgs.Action;

            switch (key)
            {
                case Key.LeftShift:
                    _isLeftShiftDown = action == KeyAction.KeyDown;
                    return;
                case Key.RightShift:
                    _isRightShiftDown = action == KeyAction.KeyDown;
                    return;
                case Key.LeftControl:
                    _isLeftControlDown = action == KeyAction.KeyDown;
                    return;
                case Key.RightControl:
                    _isRightControlDown = action == KeyAction.KeyDown;
                    return;
                case Key.LeftAlt:
                    _isLeftAltDown = action == KeyAction.KeyDown;
                    return;
                case Key.RightAlt:
                    _isRightAltDown = action == KeyAction.KeyDown;
                    return;
            }

            if (action == KeyAction.KeyUp && RegisteredKeys.IsRegisteredKey(key))
            {
                var mod = _isLeftShiftDown || _isRightShiftDown ? KeyMod.Shift : 0;
                mod |= _isLeftControlDown || _isRightControlDown ? KeyMod.Control : 0;
                mod |= _isLeftAltDown ? KeyMod.LeftAlt : 0;
                mod |= _isRightAltDown ? KeyMod.RightAlt : 0;

                var combination = new KeyCombination(key, mod);
                RaiseKeyCombinationReceived(combination);
            }
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                _keyboard.Received -= KeyboardOnReceived;
            }
        }

        protected virtual void RaiseKeyCombinationReceived(KeyCombination obj)
        {
            KeyCombinationReceived?.Invoke(obj);
        }

        public void Send(KeyCombination combination)
        {
            var shift = combination.KeyMod.HasFlag(KeyMod.Shift);
            var control = combination.KeyMod.HasFlag(KeyMod.Control);
            var leftAlt = combination.KeyMod.HasFlag(KeyMod.LeftAlt);
            var rightAlt = combination.KeyMod.HasFlag(KeyMod.RightAlt);

            var sequence = new List<KeyEventArgs>();

            if (shift) sequence.Add(new KeyEventArgs(Key.Shift, KeyAction.KeyDown));
            if (control) sequence.Add(new KeyEventArgs(Key.Control, KeyAction.KeyDown));
            if (leftAlt) sequence.Add(new KeyEventArgs(Key.LeftAlt, KeyAction.KeyDown));
            if (rightAlt) sequence.Add(new KeyEventArgs(Key.RightAlt, KeyAction.KeyDown));
            sequence.Add(new KeyEventArgs(combination.Key, KeyAction.KeyDown));
            sequence.Add(new KeyEventArgs(combination.Key, KeyAction.KeyUp));
            if (rightAlt) sequence.Add(new KeyEventArgs(Key.RightAlt, KeyAction.KeyUp));
            if (leftAlt) sequence.Add(new KeyEventArgs(Key.LeftAlt, KeyAction.KeyUp));
            if (control) sequence.Add(new KeyEventArgs(Key.Control, KeyAction.KeyUp));
            if (shift) sequence.Add(new KeyEventArgs(Key.Shift, KeyAction.KeyUp));

            _keyboard.Send(sequence);
        }
    }
}