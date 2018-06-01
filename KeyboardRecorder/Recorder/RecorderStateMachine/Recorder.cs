using Stateless;

namespace KeyboardRecorder.RecorderStateMachine
{
    public class Recorder : IRecorder
    {
        private readonly StateMachine<IRecorderState, Trigger> _stateMachine;

        public Recorder()
        {
            var script = new Script();
            var recording = new Recording(script);
            var playing = new Playing(script);
            var stopped = new Stopped();

            State = stopped;

            _stateMachine = new StateMachine<IRecorderState, Trigger>(
                () => State,
                state => { State = state; });

            _stateMachine
                .Configure(stopped)
                .Permit(Trigger.Play, playing)
                .Permit(Trigger.Record, recording);

            _stateMachine
                .Configure(recording)
                .OnEntry(() => recording.Start())
                .OnExit(() => recording.Stop())
                .Permit(Trigger.Stop, stopped);

            _stateMachine
                .Configure(playing)
                .Permit(Trigger.Stop, stopped);
        }

        public bool CanPlay => _stateMachine.CanFire(Trigger.Play);
        public bool CanRecord => _stateMachine.CanFire(Trigger.Record);
        public bool CanStop => _stateMachine.CanFire(Trigger.Stop);

        public IRecorderState State { get; private set; }

        public void Play()
        {
            _stateMachine.Fire(Trigger.Play);
        }

        public void Record()
        {
            _stateMachine.Fire(Trigger.Record);
        }

        public void Stop()
        {
            _stateMachine.Fire(Trigger.Stop);
        }
    }
}