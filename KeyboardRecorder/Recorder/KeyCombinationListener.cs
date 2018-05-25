using System;
using KeyboardAPI.APIs;

namespace Recorder
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
            }
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                _keyboard.Received -= KeyboardOnReceived;
            }
        }
    }
}