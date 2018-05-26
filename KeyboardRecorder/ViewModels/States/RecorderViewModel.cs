using Caliburn.Micro;
using KeyboardRecorder.RecorderStateMachine;

namespace ViewModels.States
{
    public class RecorderViewModel : PropertyChangedBase, IRecorder
    {
        private readonly Recorder _recorder;

        public RecorderViewModel(Recorder recorder)
        {
            _recorder = recorder;
        }

        public IRecorderState State { get; }

        public bool CanPlay => _recorder.CanPlay;
        public bool CanRecord => _recorder.CanRecord;
        public bool CanStop => _recorder.CanStop;

        public void Record()
        {
            _recorder.Record();
        }

        public void Play()
        {
            _recorder.Play();
        }

        public void Stop()
        {
            _recorder.Stop();
        }
    }
}