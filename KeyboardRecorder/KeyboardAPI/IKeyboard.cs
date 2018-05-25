using System;
using System.Collections.Generic;

namespace KeyboardAPI
{
    public interface IKeyboard : IDisposable
    {
        event EventHandler<KeyEventArgs> Received;
        void Send(IEnumerable<KeyEventArgs> sequence);
        void Install();
        void Uninstall();
    }
}