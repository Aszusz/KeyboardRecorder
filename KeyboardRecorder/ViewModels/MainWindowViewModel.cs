using System.Collections.Generic;
using Caliburn.Micro;
using KeyboardAPI.APIs;

namespace ViewModels
{
    public class MainWindowViewModel : PropertyChangedBase
    {
        private readonly IKeyboard _keyboard;
        private string _title;

        public MainWindowViewModel(string title, IKeyboard keyboard)
        {
            Title = title;

            _keyboard = keyboard;
            _keyboard.Install();
            _keyboard.Received += (sender, args) =>
            {
                var a = args.Key;
            };

            var expected = new List<KeyEventArgs>()
            {
                new KeyEventArgs(Key.KeyP, KeyAction.KeyDown),
                new KeyEventArgs(Key.KeyP, KeyAction.KeyUp)
            };


            _keyboard.Send(expected);
        }

        public string Title
        {
            get { return _title; }
            set
            {
                if (value == _title) return;
                _title = value;
                NotifyOfPropertyChange(() => Title);
            }
        }
    }
}