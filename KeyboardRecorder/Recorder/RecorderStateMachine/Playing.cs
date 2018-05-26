namespace KeyboardRecorder.RecorderStateMachine
{
    public class Playing : IRecorderState
    {
        private Script _script;

        public Playing(Script script)
        {
            _script = script;
        }
    }
}