using Caliburn.Micro;

namespace ViewModels
{
    public class MainWindowViewModel : PropertyChangedBase
    {
        private string _title;

        public MainWindowViewModel(string title)
        {
            Title = title;
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