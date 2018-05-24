using Caliburn.Micro;

namespace MyApp
{
    public class MainWindowViewModel : PropertyChangedBase
    {
        private string _title;

        public MainWindowViewModel()
        {
            Title = "My App";
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