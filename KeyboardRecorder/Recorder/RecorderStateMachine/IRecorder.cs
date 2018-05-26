namespace KeyboardRecorder.RecorderStateMachine
{
    public interface IRecorder
    {
        IRecorderState State { get; }
        bool CanPlay { get; }
        bool CanRecord { get; }
        bool CanStop { get; }

        void Record();
        void Play();
        void Stop();
    }
}