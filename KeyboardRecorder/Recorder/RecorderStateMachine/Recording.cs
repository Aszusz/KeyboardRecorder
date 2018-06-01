namespace KeyboardRecorder.RecorderStateMachine
{
    public class Recording : IRecorderState
    {
        private readonly Script _script;

        public Recording(Script script)
        {
            _script = script;
        }

        public void Start()
        {
        }

        public void Stop()
        {
        }

        private void ListenerOnKeyCombinationReceived(KeyCombination keyCombination)
        {
            _script.Add(keyCombination);
        }
    }
}