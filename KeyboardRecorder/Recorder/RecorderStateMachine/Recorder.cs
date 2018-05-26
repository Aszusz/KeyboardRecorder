using Stateless;

namespace Recorder.RecorderStateMachine
{
    public class Recorder : IRecorder
    {
        private static readonly IRecorderState Stopped = new Stopped();
        private static readonly IRecorderState Playing = new Playing();
        private static readonly IRecorderState Recording = new Recording();
        private readonly StateMachine<IRecorderState, Trigger> _stateMachine;

        public Recorder()
        {
            State = Stopped;

            _stateMachine = new StateMachine<IRecorderState, Trigger>(
                () => State,
                state => { State = state; });

            _stateMachine
                .Configure(Stopped)
                .Permit(Trigger.Play, Playing)
                .Permit(Trigger.Record, Recording);

            _stateMachine
                .Configure(Recording)
                .Permit(Trigger.Stop, Stopped);

            _stateMachine
                .Configure(Playing)
                .Permit(Trigger.Stop, Stopped);
        }

        public IRecorderState State { get; private set; }

        public void Record()
        {
            _stateMachine.Fire(Trigger.Record);
        }

        public void Play()
        {
            _stateMachine.Fire(Trigger.Play);
        }

        public void Stop()
        {
            _stateMachine.Fire(Trigger.Stop);
        }
    }
}