using System;

namespace KeyboardRecorder
{
    public interface IKeyCombinationReceiver : IDisposable
    {
        event Action<KeyCombination> KeyCombinationReceived;
        void Install();
        void Uninstall();
    }
}