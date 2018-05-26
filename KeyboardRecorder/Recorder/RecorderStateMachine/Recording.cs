namespace KeyboardRecorder.RecorderStateMachine
{
    public class Recording : IRecorderState
    {
        private readonly KeyCombinationListener _listener;
        private readonly Script _script;

        public Recording(KeyCombinationListener listener, Script script)
        {
            _listener = listener;
            _script = script;
        }

        public void Start()
        {
            _listener.KeyCombinationReceived += ListenerOnKeyCombinationReceived;
            _listener.Start();
        }

        public void Stop()
        {
            _listener.Stop();
            _listener.KeyCombinationReceived -= ListenerOnKeyCombinationReceived;
        }

        private void ListenerOnKeyCombinationReceived(KeyCombination keyCombination)
        {
            _script.Add(keyCombination);
        }
    }
}