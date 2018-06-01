using System;
using System.Windows.Input;
using KeyboardToolkit.Common;
using KeyboardToolkit.Receiver;
using KeyboardToolkit.StateMonitor;

namespace KeyboardRecorder
{
    public class KeyCombinationReceiver : IKeyCombinationReceiver
    {
        private readonly IKeyStateMonitor _monitor;
        private readonly IKeyReceiver _receiver;

        public KeyCombinationReceiver(IKeyReceiver receiver, IKeyStateMonitor monitor)
        {
            _receiver = receiver;
            _monitor = monitor;
        }

        public event Action<KeyCombination> KeyCombinationReceived;

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public void Install()
        {
            _receiver.KeyReceived += ReceiverOnKeyReceived;
            _receiver.Install();
        }

        public void Uninstall()
        {
            _receiver.Uninstall();
            _receiver.KeyReceived -= ReceiverOnKeyReceived;
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                Uninstall();
            }
        }

        protected virtual void RaiseKeyCombinationReceived(KeyCombination obj)
        {
            KeyCombinationReceived?.Invoke(obj);
        }

        private void ReceiverOnKeyReceived(object sender, KeyEventArgs keyEventArgs)
        {
            if (keyEventArgs.KeyState == KeyState.KeyDown) return;
            if (RegisteredKeys.IsModalKey(keyEventArgs.Key)) return;

            var modifiers = KeyModifier.None;
            if (_monitor.GetKeyState(Key.LeftCtrl) == KeyState.KeyDown) modifiers |= KeyModifier.LCtrl;
            if (_monitor.GetKeyState(Key.RightCtrl) == KeyState.KeyDown) modifiers |= KeyModifier.RCtrl;
            if (_monitor.GetKeyState(Key.LeftShift) == KeyState.KeyDown) modifiers |= KeyModifier.LShift;
            if (_monitor.GetKeyState(Key.RightShift) == KeyState.KeyDown) modifiers |= KeyModifier.RShift;
            if (_monitor.GetKeyState(Key.LeftAlt) == KeyState.KeyDown) modifiers |= KeyModifier.LAtl;
            if (_monitor.GetKeyState(Key.RightAlt) == KeyState.KeyDown) modifiers |= KeyModifier.RAlt;
            if (_monitor.GetKeyState(Key.LWin) == KeyState.KeyDown) modifiers |= KeyModifier.LWin;
            if (_monitor.GetKeyState(Key.RWin) == KeyState.KeyDown) modifiers |= KeyModifier.RWin;

            RaiseKeyCombinationReceived(new KeyCombination(keyEventArgs.Key, modifiers));
        }
    }
}