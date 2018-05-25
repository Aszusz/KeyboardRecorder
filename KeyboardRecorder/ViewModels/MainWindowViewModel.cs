using System;
using Caliburn.Micro;
using Recorder;

namespace ViewModels
{
    public class MainWindowViewModel : PropertyChangedBase
    {
        private readonly KeyCombinationListener _keyCombinationListener;
        private string _title;

        public MainWindowViewModel(string title, KeyCombinationListener keyCombinationListener)
        {
            Title = title;
            _keyCombinationListener = keyCombinationListener;
            _keyCombinationListener.KeyCombinationReceived += KeyCombinationListenerOnKeyCombinationReceived;
            _keyCombinationListener.Start();
        }

        private void KeyCombinationListenerOnKeyCombinationReceived(KeyCombination keyCombination)
        {
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