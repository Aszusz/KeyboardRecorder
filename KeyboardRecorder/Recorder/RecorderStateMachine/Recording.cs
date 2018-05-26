namespace KeyboardRecorder.RecorderStateMachine
{
    public class Recording : IRecorderState
    {
        private readonly KeyCombinationListener _listener;

        public Recording(KeyCombinationListener listener)
        {
            _listener = listener;
        }

        public void Start()
        {
            _listener.Start();
        }

        public void Stop()
        {
            _listener.Stop();
        }
    }
}