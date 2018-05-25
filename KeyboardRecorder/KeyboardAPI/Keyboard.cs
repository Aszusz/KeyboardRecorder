using System;
using System.Collections.Generic;

namespace KeyboardAPI
{
    public class Keyboard : IKeyboard
    {
        public event EventHandler<KeyEventArgs> Received;

        public void Send(IEnumerable<KeyEventArgs> sequence)
        {
        }

        public void Install()
        {
            throw new NotImplementedException();
        }

        public void Uninstall()
        {
            throw new NotImplementedException();
        }

        protected virtual void RaiseKeyEvent(KeyEventArgs args)
        {
            Received?.Invoke(this, args);
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}