namespace Recorder.RecorderStateMachine
{
    public interface IRecorder
    {
        IRecorderState State { get; }

        void Record();
        void Play();
        void Stop();
    }
}