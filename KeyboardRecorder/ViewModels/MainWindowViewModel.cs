using AutoMapper;
using Caliburn.Micro;
using KeyboardRecorder.RecorderStateMachine;
using ViewModels.States;
using Recorder = KeyboardRecorder.RecorderStateMachine.Recorder;

namespace ViewModels
{
    public class MainWindowViewModel : PropertyChangedBase
    {
        public MainWindowViewModel()
        {
            

            var r = Mapper.Map<RecorderViewModel>(new Recorder());
        }
    }
}